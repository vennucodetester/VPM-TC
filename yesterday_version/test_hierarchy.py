"""
Quick standalone test: walk from 0200501 up through TC where-used to find root assembly.
Expected path from BOM Explorer screenshot:
  RL5WE → ... → 3190768 → 3190773 → 0200501

Usage:
    python test_hierarchy.py                   # prompts for password
    python test_hierarchy.py --password SECRET # or pass inline (not recommended)
    python test_hierarchy.py --probe           # probe WhereUsed JSON body variants (raw HTTP)
    python test_hierarchy.py --timeout 180     # HTTP timeout for all TC posts (where_used uses 180s internally)
"""

import sys
import getpass
import json
import logging
import argparse

# Show live progress on stdout
logging.basicConfig(
    stream=sys.stdout,
    level=logging.INFO,
    format="%(asctime)s  %(message)s",
    datefmt="%H:%M:%S",
)
log = logging.getLogger("test_hierarchy")

_TC_NULL = "AAAAAAAAAAAAAA"


def _probe_variants(item_rev_uid):
    """Bodies for JsonRestServices/Core-2012-02-DataManagement/WhereUsed (plan V1–V6)."""
    empty_maps_list = {
        "stringMap": [], "doubleMap": [], "intMap": [],
        "boolMap": [], "dateMap": [], "tagMap": [], "floatMap": [],
    }
    empty_maps_obj = {
        "stringMap": {}, "doubleMap": {}, "intMap": {},
        "boolMap": {}, "dateMap": {}, "tagMap": {}, "floatMap": {},
    }
    return [
        ("V1_baseline_array_maps", {
            "input": [{
                "inputObject": {"uid": item_rev_uid},
                "useLocalParams": False,
                "inputParams": dict(empty_maps_list),
                "clientId": "",
            }],
            "configParams": dict(empty_maps_list),
        }),
        ("V2_maps_as_empty_objects", {
            "input": [{
                "inputObject": {"uid": item_rev_uid},
                "useLocalParams": False,
                "inputParams": dict(empty_maps_obj),
                "clientId": "",
            }],
            "configParams": dict(empty_maps_obj),
        }),
        ("V3_omit_inputParams", {
            "input": [{
                "inputObject": {"uid": item_rev_uid},
                "useLocalParams": False,
                "clientId": "",
            }],
            "configParams": dict(empty_maps_obj),
        }),
        ("V4_configParams_empty_only", {
            "input": [{
                "inputObject": {"uid": item_rev_uid},
                "useLocalParams": False,
                "clientId": "",
            }],
            "configParams": {},
        }),
        ("V5_PascalCase_fields", {
            "Input": [{
                "InputObject": {"uid": item_rev_uid},
                "UseLocalParams": False,
                "ClientId": "",
            }],
            "ConfigParams": {},
        }),
        ("V6_minimal_input_only", {
            "input": [{"inputObject": {"uid": item_rev_uid}}],
        }),
    ]


def run_probe(client, item_rev_uid, http_timeout=60):
    """POST each body variant; print full raw HTTP status + body (no exception handling)."""
    base = client.base_url.rstrip("/")
    state = client._state
    # Lowercase whereUsed matches JsonRestServices binding on TC 14 (capital WhereUsed → 214086).
    url_2012 = f"{base}/JsonRestServices/Core-2012-02-DataManagement/whereUsed"
    url_2007 = f"{base}/JsonRestServices/Core-2007-01-DataManagement/whereUsed"

    log.info("=== PROBE: Core-2012-02-DataManagement/whereUsed (session envelope) ===\n")

    for label, body in _probe_variants(item_rev_uid):
        payload = {"header": {"state": state, "policy": {}}, "body": body}
        try:
            r = client.session.post(url_2012, json=payload, timeout=http_timeout)
        except Exception as e:
            log.info(f"\n--- {label} ---\nREQUEST FAILED: {e}\n")
            continue
        text = r.text if r.text else ""
        log.info(f"\n--- {label} ---\nHTTP {r.status_code}\n{text[:12000]}\n")

    # V7: 2007-01 lowercase operation (per plan)
    body_2007 = {
        "objects": [{"uid": item_rev_uid}],
        "numLevels": 1,
        "whereUsedPrecise": False,
        "rule": {"uid": _TC_NULL},
    }
    payload7 = {"header": {"state": state, "policy": {}}, "body": body_2007}
    log.info("=== PROBE V7: Core-2007-01-DataManagement/whereUsed ===\n")
    try:
        r7 = client.session.post(url_2007, json=payload7, timeout=http_timeout)
        log.info(f"\n--- V7_2007_whereUsed_lowercase ---\nHTTP {r7.status_code}\n{r7.text[:12000]}\n")
    except Exception as e:
        log.info(f"V7 REQUEST FAILED: {e}")


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--url",      default="http://STLV-HSMWEBTCP1:8080/tc")
    parser.add_argument("--username", default="ccbefb")
    parser.add_argument("--item",     default="0200501", help="Bare item ID to test")
    parser.add_argument("--revision", default=None,     help="Specific revision, e.g. A")
    parser.add_argument("--password", default=None,     help="TC password (prompted if omitted)")
    parser.add_argument("--max-levels", type=int, default=20)
    parser.add_argument("--debug",    action="store_true",
                        help="Print raw where_used output for each level")
    parser.add_argument("--probe",    action="store_true",
                        help="Probe WhereUsed JSON body variants; print raw HTTP responses")
    parser.add_argument(
        "--timeout",
        type=int,
        default=120,
        metavar="SEC",
        help="Default HTTP read timeout (seconds) for TC posts in this script; login uses max(120, this). Default 120",
    )
    args = parser.parse_args()

    password = args.password or getpass.getpass(f"TC password for {args.username}@{args.url}: ")

    try:
        from tc_connector import TcSoaClient, TcSoaError, TcAuthError
    except ImportError as e:
        log.error(f"Cannot import tc_connector: {e}")
        sys.exit(1)

    log.info(f"Connecting to {args.url} as {args.username} (post_timeout={args.timeout}s) …")
    client = TcSoaClient(args.url, post_timeout=args.timeout)
    try:
        client.login(args.username, password)
    except TcAuthError as e:
        log.error(f"Login failed: {e}")
        sys.exit(1)
    except TcSoaError as e:
        log.error(
            "Login failed (TC service error): %s\n"
            "If this mentions Web Tier / Server Manager / assign a server, that is a Teamcenter "
            "infrastructure issue on the server side — retry later or contact your TC admin.",
            e,
        )
        sys.exit(1)
    log.info("Login OK.\n")

    item_id = args.item
    revision_id = args.revision

    log.info(f"=== Step 1: resolve_item_to_revision_uid('{item_id}', revision='{revision_id}') ===")
    uid = client.resolve_item_to_revision_uid(item_id, revision_id)
    if not uid:
        log.error(
            f"Could not resolve {item_id} to any TC UID.  "
            "Check that the item exists and the saved query 'Item Revision...' works."
        )
        sys.exit(1)
    log.info(f"  Resolved → UID: {uid}\n")

    if args.probe:
        run_probe(client, uid, http_timeout=args.timeout)
        try:
            client.logout()
        except Exception:
            pass
        return

    # -------------------------------------------------------- where-used loop
    log.info("=== Step 2: climbing where-used hierarchy ===")
    chain_ids = [item_id]
    visited = {uid}
    current_uid = uid

    for level in range(1, args.max_levels + 1):
        log.info(f"  Level {level}: calling where_used({current_uid})")
        raw_parents = client.where_used(current_uid)

        if args.debug:
            log.info(f"    RAW parents returned: {json.dumps(raw_parents, indent=2, default=str)}")

        if not raw_parents:
            log.info(f"  → No parents found at level {level}.  This IS the root.")
            break

        parent_uid = raw_parents[0]
        log.info(f"  → First parent UID: {parent_uid}")

        if parent_uid in visited:
            log.warning(f"  Cycle detected at level {level}, stopping.")
            break
        visited.add(parent_uid)

        try:
            props = client.get_properties([parent_uid], ["item_id", "item_revision_id", "object_name"])
            p = props.get(parent_uid, {})
            p_item = p.get("item_id", "?")
            p_rev = p.get("item_revision_id", "?")
            p_name = p.get("object_name", "")
            log.info(f"  → Parent props: item_id={p_item}  rev={p_rev}  name={p_name}")
        except Exception as e:
            p_item = "?"
            log.warning(f"  Could not get parent properties: {e}")

        chain_ids.append(p_item)
        current_uid = parent_uid

    log.info("\n=== RESULT ===")
    log.info(f"Chain (bottom → top):  {' → '.join(chain_ids)}")
    root = chain_ids[-1]
    log.info(f"Root (highest-level assembly): {root}")

    if root.upper().startswith("RL5WE"):
        log.info("✓ SUCCESS — root matches expected RL5WE")
    else:
        log.info(
            f"⚠ Root is '{root}' — may be correct if RL5WE was not in the loaded BOM set, "
            "or may indicate where-used still needs debugging.  Check chain above."
        )

    try:
        client.logout()
    except Exception:
        pass


if __name__ == "__main__":
    main()
