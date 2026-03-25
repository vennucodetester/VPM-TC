"""
Teamcenter BOM Diagnostic Script
=================================
Tests which API approaches can retrieve BOM (Bill of Materials) child data
from the Teamcenter server. Run this before implementing the full BOM
traversal to determine which path actually works.

Usage:
    python tc_bom_diagnostic.py

You will be prompted for TC server URL, username, and password.
Results are printed to console and saved to tc_bom_diagnostic_results.txt.
"""

import sys
import os
import json
import getpass
import datetime

# Reuse the proven TcSoaClient from tc_connector
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
from tc_connector import TcSoaClient, TcSoaError, TcAuthError, TcConnectionError

# ---------------------------------------------------------------------------
# Configuration
# ---------------------------------------------------------------------------

# Known item to test against — user confirmed RLN4MA has a full BOM tree in TC
TEST_NOMENCLATURE = "RLN4MA"

# Relations to probe for BOM-like structure
GRM_RELATIONS_TO_TEST = [
    "IMAN_specification",
    "IMAN_master_form",
    "IMAN_reference",
    "TC_Is_Represented_By",
    "structure_revisions",
    "PSConnectionRevision",
    "Fnd0BOSRelation",
]

# Properties that might expose BOM children
BOM_PROPERTIES_TO_TEST = [
    "ps_children",
    "ps_parents",
    "structure_revisions",
    "bom_view_tags",
    "items_tag",
    "IMAN_master_form_rev",
]

# ---------------------------------------------------------------------------
# Output helpers
# ---------------------------------------------------------------------------

_output_lines = []

def out(msg=""):
    """Print and buffer for file output."""
    print(msg)
    _output_lines.append(msg)

def save_results(filepath):
    with open(filepath, "w", encoding="utf-8") as f:
        f.write("\n".join(_output_lines))
    print(f"\nResults saved to: {filepath}")

def fmt_uids(uids, max_show=10):
    if not uids:
        return "(none)"
    shown = uids[:max_show]
    extra = f" ... and {len(uids) - max_show} more" if len(uids) > max_show else ""
    return ", ".join(shown) + extra

# ---------------------------------------------------------------------------
# Diagnostic Tests
# ---------------------------------------------------------------------------

def test_find_item(client, nomenclature):
    """Find the item revision UID for the test nomenclature."""
    out(f"=== SETUP: Finding item revision for '{nomenclature}' ===")

    # Set a broad property policy so loadObjects returns useful data
    try:
        client.set_property_policy({
            "H4_Hussmann_ItemRevision": [
                "item_id", "item_revision_id", "object_name",
                "object_type", "h4_Nomenclature", "items_tag",
            ],
            "H4_Hussmann_Item": [
                "item_id", "bom_view_tags",
            ],
        })
    except TcSoaError as e:
        out(f"  WARNING: set_property_policy failed: {e}")
        out(f"  Continuing without explicit policy...")

    uids = client.execute_saved_query(
        "Item Revision...", ["Item ID"], [nomenclature]
    )
    out(f"  Query 'Item Revision...' with Item ID='{nomenclature}': {len(uids)} UIDs")

    if not uids:
        out("  WARNING: No item revision found. Cannot continue tests.")
        return None, None

    # Pick the first UID
    test_uid = uids[0]
    out(f"  Using UID: {test_uid}")

    # Get basic properties
    props = client.get_properties([test_uid], [
        "item_id", "item_revision_id", "object_name", "object_type", "items_tag"
    ])
    p = props.get(test_uid, {})
    out(f"  item_id:          {p.get('item_id', '?')}")
    out(f"  item_revision_id: {p.get('item_revision_id', '?')}")
    out(f"  object_name:      {p.get('object_name', '?')}")
    out(f"  object_type:      {p.get('object_type', '?')}")
    out(f"  items_tag:        {p.get('items_tag', '?')}")

    item_uid = p.get("items_tag", "")
    out()
    return test_uid, item_uid


def get_raw_property(client, uid, prop_name):
    """
    Get both dbValues and uiValues for a property, bypassing get_properties'
    value selection logic. This is critical for UID-array properties like
    ps_children where dbValues contain UIDs and uiValues contain display text.
    """
    body = {
        "objects": [{"uid": uid}],
        "attributes": [prop_name]
    }
    result = client._post("Core-2006-03-DataManagement", "getProperties", body)
    service_data = client._get_service_data(result)
    model_objects = service_data.get("modelObjects", {})

    # Check all model objects for the property (TC may return it on a different UID)
    for obj_uid, obj_data in model_objects.items():
        obj_props = obj_data.get("props", {})
        if prop_name in obj_props:
            prop_data = obj_props[prop_name]
            db_values = prop_data.get("dbValues", [])
            ui_values = prop_data.get("uiValues", [])
            return db_values, ui_values

    # Also check the requested UID specifically
    obj_data = model_objects.get(uid, {})
    obj_props = obj_data.get("props", {})
    prop_data = obj_props.get(prop_name, {})
    return prop_data.get("dbValues", []), prop_data.get("uiValues", [])


def test_ps_children(client, item_rev_uid):
    """Test 1: Can we get BOM children via ps_children property?"""
    out("=== TEST 1: ps_children property ===")
    out(f"  Calling getProperties([{item_rev_uid}], ['ps_children'])")

    try:
        # Use raw extraction to get both dbValues and uiValues
        db_values, ui_values = get_raw_property(client, item_rev_uid, "ps_children")
        out(f"  dbValues ({len(db_values)}): {json.dumps(db_values, default=str)[:500]}")
        out(f"  uiValues ({len(ui_values)}): {json.dumps(ui_values, default=str)[:500]}")

        # UIDs are in dbValues
        raw_value = db_values if db_values else ui_values

        out(f"  Raw value type: {type(raw_value).__name__}")
        out(f"  Raw value: {json.dumps(raw_value, default=str)[:500]}")

        # Normalize to list
        if isinstance(raw_value, list):
            child_uids = [u for u in raw_value if u]
        elif isinstance(raw_value, str) and raw_value:
            child_uids = [raw_value]
        else:
            child_uids = []

        out(f"  Child UIDs found: {len(child_uids)}")
        out(f"  UIDs: {fmt_uids(child_uids)}")

        if child_uids:
            # Check what TYPE these children are
            out(f"  Checking object types of first {min(5, len(child_uids))} children...")
            check_uids = child_uids[:5]
            try:
                child_props = client.get_properties(
                    check_uids, ["object_type", "item_id", "item_revision_id", "object_name"]
                )
                for uid in check_uids:
                    cp = child_props.get(uid, {})
                    out(f"    {uid}: type={cp.get('object_type', '?')}, "
                        f"item_id={cp.get('item_id', '?')}, "
                        f"rev={cp.get('item_revision_id', '?')}, "
                        f"name={cp.get('object_name', '?')}")
            except TcSoaError as e:
                out(f"    ERROR getting child properties: {e}")

            out(f"  RESULT: ps_children WORKS — returned {len(child_uids)} children")
            return True, child_uids
        else:
            out(f"  RESULT: ps_children returned EMPTY")
            return False, []

    except TcSoaError as e:
        out(f"  ERROR: {e}")
        out(f"  RESULT: ps_children FAILED")
        return False, []


def test_structure_revisions(client, item_rev_uid):
    """Test 2: Can we get BOM via structure_revisions → bvr_occurrences chain?"""
    out("=== TEST 2: structure_revisions property ===")
    out(f"  Calling getProperties([{item_rev_uid}], ['structure_revisions'])")

    try:
        # Use raw extraction to get both dbValues and uiValues
        db_values, ui_values = get_raw_property(client, item_rev_uid, "structure_revisions")
        out(f"  dbValues ({len(db_values)}): {json.dumps(db_values, default=str)[:500]}")
        out(f"  uiValues ({len(ui_values)}): {json.dumps(ui_values, default=str)[:500]}")

        raw_value = db_values if db_values else ui_values

        # Normalize to list
        if isinstance(raw_value, list):
            bvr_uids = [u for u in raw_value if u]
        elif isinstance(raw_value, str) and raw_value:
            bvr_uids = [raw_value]
        else:
            bvr_uids = []

        out(f"  PSBOMViewRevision UIDs found: {len(bvr_uids)}")
        out(f"  UIDs: {fmt_uids(bvr_uids)}")

        if bvr_uids:
            # Check what type they are and get their bvr_occurrences
            out(f"  Checking types and bvr_occurrences for first {min(3, len(bvr_uids))} BVRs...")
            check_uids = bvr_uids[:3]
            try:
                # Get object_type and object_name via normal get_properties
                bvr_props = client.get_properties(
                    check_uids, ["object_type", "object_name"]
                )
                total_occurrences = 0
                for uid in check_uids:
                    bp = bvr_props.get(uid, {})
                    # Use raw extraction for bvr_occurrences (UID array)
                    occ_db, occ_ui = get_raw_property(client, uid, "bvr_occurrences")
                    out(f"    {uid} bvr_occurrences dbValues: {len(occ_db)}, uiValues: {len(occ_ui)}")
                    occ_uids = [u for u in (occ_db if occ_db else occ_ui) if u]
                    total_occurrences += len(occ_uids)

                    out(f"    {uid}: type={bp.get('object_type', '?')}, "
                        f"name={bp.get('object_name', '?')}, "
                        f"bvr_occurrences={len(occ_uids)}")
                    if occ_uids:
                        out(f"      occurrence UIDs: {fmt_uids(occ_uids, 5)}")

                        # Check what type the occurrences are
                        occ_check = occ_uids[:3]
                        try:
                            occ_props = client.get_properties(
                                occ_check,
                                ["object_type", "child_item", "item_id",
                                 "object_name", "ps_children"]
                            )
                            for ouid in occ_check:
                                op = occ_props.get(ouid, {})
                                out(f"        {ouid}: type={op.get('object_type', '?')}, "
                                    f"child_item={op.get('child_item', '?')}, "
                                    f"item_id={op.get('item_id', '?')}")
                        except TcSoaError as e:
                            out(f"        ERROR getting occurrence props: {e}")

                if total_occurrences > 0:
                    out(f"  RESULT: structure_revisions WORKS — {total_occurrences} total occurrences")
                    return True, bvr_uids
                else:
                    out(f"  RESULT: structure_revisions found BVRs but bvr_occurrences is EMPTY")
                    return False, bvr_uids

            except TcSoaError as e:
                out(f"    ERROR getting BVR properties: {e}")
                out(f"  RESULT: structure_revisions found BVRs but could not read them")
                return False, bvr_uids
        else:
            out(f"  RESULT: structure_revisions returned EMPTY")
            return False, []

    except TcSoaError as e:
        out(f"  ERROR: {e}")
        out(f"  RESULT: structure_revisions FAILED")
        return False, []


def test_bom_view_tags(client, item_uid):
    """Test 3: Check BOM views on the parent Item."""
    out("=== TEST 3: bom_view_tags on Item ===")
    if not item_uid:
        out("  SKIPPED: no Item UID available")
        return False, []

    out(f"  Calling getProperties([{item_uid}], ['bom_view_tags'])")

    try:
        props = client.get_properties([item_uid], ["bom_view_tags"])
        p = props.get(item_uid, {})
        raw_value = p.get("bom_view_tags", "")

        out(f"  Raw value type: {type(raw_value).__name__}")
        out(f"  Raw value: {json.dumps(raw_value, default=str)[:500]}")

        if isinstance(raw_value, list):
            view_uids = [u for u in raw_value if u]
        elif isinstance(raw_value, str) and raw_value:
            view_uids = [raw_value]
        else:
            view_uids = []

        out(f"  BOM View UIDs found: {len(view_uids)}")

        if view_uids:
            # Check view types
            try:
                view_props = client.get_properties(
                    view_uids, ["object_type", "view_type", "object_name"]
                )
                for uid in view_uids:
                    vp = view_props.get(uid, {})
                    out(f"    {uid}: type={vp.get('object_type', '?')}, "
                        f"view_type={vp.get('view_type', '?')}, "
                        f"name={vp.get('object_name', '?')}")
            except TcSoaError as e:
                out(f"    ERROR getting view properties: {e}")

            out(f"  RESULT: bom_view_tags found {len(view_uids)} views")
            return True, view_uids
        else:
            out(f"  RESULT: bom_view_tags returned EMPTY — Item has no BOM views")
            return False, []

    except TcSoaError as e:
        out(f"  ERROR: {e}")
        return False, []


def test_grm_relations(client, item_rev_uid):
    """Test 4: Probe GRM relations for BOM-like structure."""
    out("=== TEST 4: GRM relation exploration ===")
    out(f"  Testing {len(GRM_RELATIONS_TO_TEST)} relations on UID {item_rev_uid}")

    working_relations = {}
    for rel_name in GRM_RELATIONS_TO_TEST:
        out(f"\n  Trying relation: '{rel_name}'")
        try:
            result = client.expand_grm_relations([item_rev_uid], rel_name)
            related = result.get(item_rev_uid, [])
            out(f"    Related objects: {len(related)}")
            if related:
                out(f"    UIDs: {fmt_uids(related, 5)}")
                # Check types of first few
                check = related[:3]
                try:
                    rp = client.get_properties(check, ["object_type", "object_name", "item_id"])
                    for uid in check:
                        p = rp.get(uid, {})
                        out(f"      {uid}: type={p.get('object_type', '?')}, "
                            f"name={p.get('object_name', '?')}, "
                            f"item_id={p.get('item_id', '?')}")
                except TcSoaError:
                    pass
                working_relations[rel_name] = len(related)
        except (TcSoaError, Exception) as e:
            error_str = str(e)
            # Truncate long errors
            if len(error_str) > 200:
                error_str = error_str[:200] + "..."
            out(f"    ERROR: {error_str}")

    out(f"\n  SUMMARY: {len(working_relations)} relations returned data:")
    for name, count in working_relations.items():
        out(f"    {name}: {count} related objects")
    if not working_relations:
        out(f"    (none)")

    return working_relations


def test_wildcard_query(client, nomenclature):
    """Test 5: Wildcard nomenclature search."""
    out(f"=== TEST 5: Wildcard nomenclature query ===")

    patterns = [
        f"{nomenclature}*",
        f"*{nomenclature}*",
    ]

    for pattern in patterns:
        out(f"\n  Query 'Item Revision...' with Item ID='{pattern}'")
        try:
            uids = client.execute_saved_query(
                "Item Revision...", ["Item ID"], [pattern]
            )
            out(f"    Results: {len(uids)} UIDs")
            if uids:
                # Get item_ids to see what we found
                check = uids[:10]
                try:
                    props = client.get_properties(
                        check, ["item_id", "item_revision_id", "object_name", "h4_Nomenclature"]
                    )
                    for uid in check:
                        p = props.get(uid, {})
                        out(f"      {p.get('item_id', '?')}/{p.get('item_revision_id', '?')} "
                            f"— {p.get('object_name', '?')} "
                            f"[nom={p.get('h4_Nomenclature', '?')}]")
                    if len(uids) > 10:
                        out(f"      ... and {len(uids) - 10} more")
                except TcSoaError:
                    out(f"    UIDs: {fmt_uids(uids)}")
        except TcSoaError as e:
            out(f"    ERROR: {e}")

    out()


def test_all_properties_raw(client, item_rev_uid):
    """Test 6: Dump all BOM-related properties to see what has data."""
    out("=== TEST 6: Raw BOM property dump ===")
    out(f"  Fetching {len(BOM_PROPERTIES_TO_TEST)} properties from {item_rev_uid}")

    try:
        for prop_name in BOM_PROPERTIES_TO_TEST:
            try:
                db_vals, ui_vals = get_raw_property(client, item_rev_uid, prop_name)
                has_data = "HAS DATA" if (db_vals or ui_vals) else "empty"
                db_str = json.dumps(db_vals, default=str)[:150] if db_vals else "(empty)"
                ui_str = json.dumps(ui_vals, default=str)[:150] if ui_vals else "(empty)"
                out(f"  {prop_name}: [{has_data}]")
                out(f"    dbValues: {db_str}")
                out(f"    uiValues: {ui_str}")
            except TcSoaError as e:
                out(f"  {prop_name}: [ERROR] {str(e)[:100]}")

    except TcSoaError as e:
        out(f"  ERROR: {e}")

    out()


# ---------------------------------------------------------------------------
# Main
# ---------------------------------------------------------------------------

def main():
    out("=" * 70)
    out("Teamcenter BOM Diagnostic")
    out(f"Run at: {datetime.datetime.now().isoformat()}")
    out("=" * 70)
    out()

    # Get credentials
    default_url = "http://STLV-HSMWEBTCP1:8080/tc"
    url = input(f"TC Server URL [{default_url}]: ").strip() or default_url
    username = input("Username: ").strip()
    password = getpass.getpass("Password: ")

    if not username or not password:
        out("ERROR: Username and password required.")
        return

    out(f"Server: {url}")
    out(f"User:   {username}")
    out()

    # Connect
    client = TcSoaClient(url)

    out("--- Connecting ---")
    try:
        reachable, msg = client.test_connection()
        if not reachable:
            out(f"ERROR: Server not reachable: {msg}")
            return
        out(f"  Server reachable: {msg}")

        client.login(username, password)
        out(f"  Login successful")
    except (TcAuthError, TcConnectionError, TcSoaError) as e:
        out(f"ERROR: {e}")
        return
    out()

    try:
        # SETUP: Find the test item
        item_rev_uid, item_uid = test_find_item(client, TEST_NOMENCLATURE)
        if not item_rev_uid:
            out("\nCannot proceed without an item revision UID.")
            return

        # TEST 1: ps_children
        ps_works, ps_children = test_ps_children(client, item_rev_uid)
        out()

        # TEST 2: structure_revisions
        sr_works, sr_uids = test_structure_revisions(client, item_rev_uid)
        out()

        # TEST 3: bom_view_tags
        bv_works, bv_uids = test_bom_view_tags(client, item_uid)
        out()

        # TEST 4: GRM relations
        grm_results = test_grm_relations(client, item_rev_uid)
        out()

        # TEST 5: Wildcard query
        test_wildcard_query(client, TEST_NOMENCLATURE)

        # TEST 6: Raw property dump
        test_all_properties_raw(client, item_rev_uid)

        # SUMMARY
        out("=" * 70)
        out("DIAGNOSTIC SUMMARY")
        out("=" * 70)
        out()
        out(f"  Test item: {TEST_NOMENCLATURE} (UID: {item_rev_uid})")
        out()
        out(f"  TEST 1 — ps_children:          {'WORKS (' + str(len(ps_children)) + ' children)' if ps_works else 'EMPTY/FAILED'}")
        out(f"  TEST 2 — structure_revisions:   {'WORKS' if sr_works else 'EMPTY/FAILED'}")
        out(f"  TEST 3 — bom_view_tags:         {'WORKS (' + str(len(bv_uids)) + ' views)' if bv_works else 'EMPTY/FAILED'}")
        out(f"  TEST 4 — GRM relations:         {len(grm_results)} relations returned data")
        for name, count in grm_results.items():
            out(f"             {name}: {count}")
        out()

        if ps_works:
            out("  RECOMMENDATION: Use ps_children via getProperties for BOM traversal.")
            out("                  This is the simplest, most direct path.")
        elif sr_works:
            out("  RECOMMENDATION: Use structure_revisions → bvr_occurrences chain.")
            out("                  More complex but uses proven getProperties endpoint.")
        elif bv_works:
            out("  RECOMMENDATION: BOM views exist. May need XML REST binding for")
            out("                  createBOMWindows — consider building XML request body.")
        else:
            out("  RECOMMENDATION: No property-based BOM path found.")
            out("                  Options: XML REST binding, or wildcard query only.")

        out()

    finally:
        try:
            client.logout()
            out("--- Logged out ---")
        except Exception:
            pass

    # Save results
    results_path = os.path.join(
        os.path.dirname(os.path.abspath(__file__)),
        "tc_bom_diagnostic_results.txt"
    )
    save_results(results_path)


if __name__ == "__main__":
    main()
