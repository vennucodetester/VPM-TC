"""
Proof-of-concept: Use official Siemens Teamcenter .NET DLLs from Python via pythonnet
to call WhereUsed and find parent assemblies.

Usage:
    python test_siemens_bridge.py --user USERNAME --password PASSWORD --item 0200501
    python test_siemens_bridge.py --user USERNAME --password PASSWORD --item 0200501 --climb
    python test_siemens_bridge.py --user USERNAME --password PASSWORD --list-queries

Requirements:
    pip install pythonnet
"""

import argparse
import os
import sys
import traceback

# ---------------------------------------------------------------------------
# 1. Load Siemens TC .NET assemblies via pythonnet
# ---------------------------------------------------------------------------

DLL_DIR = os.path.join(os.path.dirname(os.path.abspath(__file__)), "Check Sheet 1.0.3.5")

def load_tc_assemblies():
    """Load all required Teamcenter SOA .NET DLLs."""
    import clr
    sys.path.insert(0, DLL_DIR)

    required = [
        "TcSoaClient",
        "TcSoaCommon",
        "TcSoaCoreStrong",
        "TcSoaCoreTypes",
        "TcSoaStrongModel",
        "TcSoaQueryStrong",
        "TcSoaQueryTypes",
        "TcSoaCadStrong",
        "TcSoaCadTypes",
    ]
    for dll in required:
        path = os.path.join(DLL_DIR, dll)
        try:
            clr.AddReference(path)
        except Exception as e:
            print(f"  WARNING: Could not load {dll}: {e}")

    print(f"Loaded {len(required)} TC assemblies from {DLL_DIR}")


# ---------------------------------------------------------------------------
# 2. Implement CredentialManager interface (same as checksheet app)
# ---------------------------------------------------------------------------

def create_credential_manager(username, password):
    """Create a .NET CredentialManager implementation matching the checksheet pattern."""
    from Teamcenter.Soa.Client import CredentialManager

    class PyCredentialManager(CredentialManager):
        def __init__(self, user, pwd):
            self._user = user
            self._pwd = pwd
            self._group = ""
            self._role = ""
            self._discriminator = "SoaAppX"

        @property
        def CredentialType(self):
            return 0

        def GetCredentials(self, exception):
            # Return empty array on re-auth (same as checksheet)
            from System import Array, String
            return Array.CreateInstance(String, 0)

        def SetGroupRole(self, group, role):
            pass

        def SetUserPassword(self, user, password, discriminator):
            pass

        def get_login_args(self):
            return (self._user, self._pwd, self._group, self._role, "", self._discriminator)

    return PyCredentialManager(username, password)


def create_exception_handler():
    """Create a .NET ExceptionHandler (no-op, same as checksheet)."""
    from Teamcenter.Soa.Client import ExceptionHandler

    class PyExceptionHandler(ExceptionHandler):
        def HandleException(self, exception):
            print(f"  TC Exception: {exception}")

    return PyExceptionHandler()


# ---------------------------------------------------------------------------
# 3. Connect and login
# ---------------------------------------------------------------------------

def tc_connect(url, username, password):
    """Create Connection and login, mirroring TCFunctions.TC_login exactly."""
    from System.Net import CookieCollection
    from Teamcenter.Soa import SoaConstants
    from Teamcenter.Soa.Client import Connection
    from Teamcenter.Services.Strong.Core import SessionService

    cred_mgr = create_credential_manager(username, password)

    print(f"Connecting to {url} ...")
    print(f"  Protocol: {SoaConstants.REST} / {SoaConstants.HTTP}")

    conn = Connection(url, CookieCollection(), cred_mgr, SoaConstants.REST, SoaConstants.HTTP, False)
    conn.ExceptionHandler = create_exception_handler()

    session_svc = SessionService.getService(conn)
    args = cred_mgr.get_login_args()
    print(f"  Logging in as {args[0]} ...")
    response = session_svc.Login(args[0], args[1], args[2], args[3], args[4], args[5])

    print(f"  Login OK")
    return conn


def tc_logout(conn):
    """Logout and cleanup."""
    from Teamcenter.Services.Strong.Core import SessionService
    try:
        session_svc = SessionService.getService(conn)
        session_svc.Logout()
        print("Logged out.")
    except Exception as e:
        print(f"  Logout error: {e}")


# ---------------------------------------------------------------------------
# 4. Set property policy (so returned objects have useful properties)
# ---------------------------------------------------------------------------

def set_item_policy(conn):
    """Set object property policy for ItemRevision properties."""
    from Teamcenter.Services.Strong.Core import SessionService
    from Teamcenter.Soa.Common import ObjectPropertyPolicy

    session_svc = SessionService.getService(conn)
    policy = ObjectPropertyPolicy()

    from System import Array, String
    props = Array[String](["item_id", "item_revision_id", "object_name", "object_type",
                           "items_tag", "bom_view_tags"])
    policy.AddType("ItemRevision", props)

    h4_props = Array[String](["item_id", "item_revision_id", "object_name", "object_type",
                              "items_tag", "bom_view_tags"])
    policy.AddType("H4_Hussmann_ItemRevision", h4_props)

    item_props = Array[String](["item_id", "object_name", "object_type"])
    policy.AddType("Item", item_props)
    policy.AddType("H4_Hussmann_Item", item_props)

    session_svc.SetObjectPropertyPolicy(policy)
    print("  Property policy set.")


# ---------------------------------------------------------------------------
# 5. Resolve item ID to ItemRevision ModelObject via saved query
# ---------------------------------------------------------------------------

def resolve_item(conn, item_id):
    """Find an ItemRevision by item_id using the 'Item Revision...' saved query."""
    from Teamcenter.Services.Strong.Query import SavedQueryService
    from Teamcenter.Services.Strong.Core import DataManagementService
    from System import Array, String

    query_svc = SavedQueryService.getService(conn)
    dm_svc = DataManagementService.getService(conn)

    # Find the saved query named "Item Revision..."
    query_names = Array[String](["Item Revision..."])
    find_resp = query_svc.FindSavedQueries(query_names)

    if find_resp.SavedQueries is None or len(find_resp.SavedQueries) == 0:
        print(f"  ERROR: 'Item Revision...' saved query not found!")
        return None

    saved_query = find_resp.SavedQueries[0]
    print(f"  Found saved query: uid={saved_query.Uid}")

    # Execute the query with Item ID filter
    from Teamcenter.Services.Strong.Query._2008_06.SavedQuery import SavedQueryInput
    query_input = SavedQueryInput()
    query_input.Query = saved_query
    query_input.MaxNumToReturn = 10
    query_input.LimitList = Array.CreateInstance(type(saved_query), 0)
    query_input.Entries = Array[String](["Item ID"])
    query_input.Values = Array[String]([item_id])

    inputs = Array[SavedQueryInput]([query_input])
    exec_resp = query_svc.ExecuteSavedQueries(inputs)

    if exec_resp.ArrayOfResults is None or len(exec_resp.ArrayOfResults) == 0:
        print(f"  No results for item_id={item_id}")
        return None

    objects = exec_resp.ArrayOfResults[0].Objects
    if objects is None or len(objects) == 0:
        print(f"  No ItemRevision found for {item_id}")
        return None

    # Get properties to show what we found
    props_to_get = Array[String](["item_id", "item_revision_id", "object_name"])
    dm_svc.GetProperties(Array.CreateInstance(type(objects[0]), [o for o in objects]), props_to_get)

    print(f"  Found {len(objects)} revision(s) for {item_id}:")
    for obj in objects:
        try:
            rev_id = obj.GetPropertyObject("item_revision_id").StringValue if obj else "?"
            name = obj.GetPropertyObject("object_name").StringValue if obj else "?"
            print(f"    uid={obj.Uid}  rev={rev_id}  name={name}  type={obj.TypeObject.Name}")
        except Exception:
            print(f"    uid={obj.Uid}  type={obj.TypeObject.Name}")

    return objects[0]  # Return first (latest) revision


# ---------------------------------------------------------------------------
# 6. Call WhereUsed (the main event!)
# ---------------------------------------------------------------------------

def where_used_2012(conn, item_rev_obj):
    """Call DataManagementService.WhereUsed (2012-02 API) via official Siemens client."""
    from Teamcenter.Services.Strong.Core import DataManagementService
    from Teamcenter.Services.Strong.Core._2012_02.DataManagement import (
        WhereUsedInputData, WhereUsedConfigParameters
    )
    from System import Array
    from System.Collections import Hashtable

    dm_svc = DataManagementService.getService(conn)

    # Build input (same structure the checksheet would use)
    input_data = WhereUsedInputData()
    input_data.InputObject = item_rev_obj
    input_data.UseLocalParams = False
    input_data.ClientId = ""

    # Config params with empty maps
    config = WhereUsedConfigParameters()
    config.StringMap = Hashtable()
    config.DoubleMap = Hashtable()
    config.IntMap = Hashtable()
    config.BoolMap = Hashtable()
    config.DateMap = Hashtable()
    config.TagMap = Hashtable()
    config.FloatMap = Hashtable()

    input_data.InputParams = config

    inputs = Array[WhereUsedInputData]([input_data])

    # Empty config params for the call itself
    call_config = WhereUsedConfigParameters()
    call_config.StringMap = Hashtable()
    call_config.DoubleMap = Hashtable()
    call_config.IntMap = Hashtable()
    call_config.BoolMap = Hashtable()
    call_config.DateMap = Hashtable()
    call_config.TagMap = Hashtable()
    call_config.FloatMap = Hashtable()

    print(f"\n  Calling WhereUsed (2012-02) for uid={item_rev_obj.Uid} ...")
    response = dm_svc.WhereUsed(inputs, call_config)

    # Parse response
    parents = []
    if response.Output is not None:
        for output_entry in response.Output:
            if output_entry.Info is not None:
                for info in output_entry.Info:
                    parent = info.ParentObject
                    if parent is not None and parent.Uid != "AAAAAAAAAAAAAA":
                        parents.append(parent)
                        try:
                            pid = parent.GetPropertyObject("item_id").StringValue
                            prev = parent.GetPropertyObject("item_revision_id").StringValue
                            pname = parent.GetPropertyObject("object_name").StringValue
                            print(f"    PARENT: {pid}/{prev} ({pname})  uid={parent.Uid}  level={info.Level}")
                        except Exception:
                            print(f"    PARENT: uid={parent.Uid}  type={parent.TypeObject.Name}  level={info.Level}")

    # Also check ServiceData for partial errors
    svc_data = response.ServiceData
    if svc_data is not None:
        n_err = svc_data.SizeOfPartialErrors
        if n_err > 0:
            print(f"\n  Partial errors ({n_err}):")
            for i in range(n_err):
                err = svc_data.GetPartialError(i)
                for msg in err.Messages:
                    print(f"    [{err.Uid}] {msg}")

    if not parents:
        print("  No parents found (item may be a top-level assembly or not in any BOM)")

    return parents


def where_used_2007(conn, item_rev_obj):
    """Fallback: Call WhereUsed (2007-01 API) via official Siemens client."""
    from Teamcenter.Services.Strong.Core import DataManagementService
    from Teamcenter.Soa.Client.Model import ModelObject
    from System import Array

    dm_svc = DataManagementService.getService(conn)

    objects = Array[ModelObject]([item_rev_obj])

    # Create a null ModelObject for the rule parameter
    # NullModelObject has uid AAAAAAAAAAAAAA
    from Teamcenter.Soa.Client.Model import NullModelObject
    null_obj = NullModelObject.INSTANCE

    print(f"\n  Calling WhereUsed (2007-01) for uid={item_rev_obj.Uid} ...")
    response = dm_svc.WhereUsed(objects, 1, False, null_obj)

    parents = []
    if response.Output is not None:
        for output_entry in response.Output:
            if output_entry.Info is not None:
                for info in output_entry.Info:
                    parent = info.ParentItemRev
                    if parent is not None and parent.Uid != "AAAAAAAAAAAAAA":
                        parents.append(parent)
                        try:
                            pid = parent.GetPropertyObject("item_id").StringValue
                            prev = parent.GetPropertyObject("item_revision_id").StringValue
                            pname = parent.GetPropertyObject("object_name").StringValue
                            print(f"    PARENT: {pid}/{prev} ({pname})  uid={parent.Uid}  level={info.Level}")
                        except Exception:
                            print(f"    PARENT: uid={parent.Uid}  type={parent.TypeObject.Name}  level={info.Level}")

    if not parents:
        print("  No parents found via 2007-01 API")

    return parents


# ---------------------------------------------------------------------------
# 7. Climb hierarchy (optional --climb flag)
# ---------------------------------------------------------------------------

def climb_hierarchy(conn, item_id, max_levels=20):
    """Recursively climb where-used to find top-level assembly."""
    print(f"\n{'='*60}")
    print(f"CLIMBING HIERARCHY for {item_id}")
    print(f"{'='*60}")

    set_item_policy(conn)
    item_rev = resolve_item(conn, item_id)
    if item_rev is None:
        print("FAILED: Could not resolve item")
        return

    chain = [item_id]
    current = item_rev
    visited = set()

    for level in range(max_levels):
        uid = current.Uid
        if uid in visited:
            print(f"\n  CYCLE detected at uid={uid}, stopping")
            break
        visited.add(uid)

        # Try 2012-02 first, fall back to 2007-01
        parents = where_used_2012(conn, current)
        if not parents:
            parents = where_used_2007(conn, current)

        if not parents:
            print(f"\n  REACHED TOP: No more parents at level {level}")
            break

        # Follow first parent
        current = parents[0]
        try:
            pid = current.GetPropertyObject("item_id").StringValue
            chain.append(pid)
        except Exception:
            chain.append(f"uid:{current.Uid}")

    print(f"\n{'='*60}")
    print(f"HIERARCHY CHAIN: {' -> '.join(chain)}")
    print(f"TOP-LEVEL: {chain[-1]}")
    print(f"{'='*60}")


# ---------------------------------------------------------------------------
# 8. List available saved queries (diagnostic)
# ---------------------------------------------------------------------------

def list_queries(conn):
    """List all available saved queries on the server."""
    from Teamcenter.Services.Strong.Query import SavedQueryService

    query_svc = SavedQueryService.getService(conn)
    resp = query_svc.GetSavedQueries()

    if resp.Queries is not None:
        print(f"\nAvailable saved queries ({len(resp.Queries)}):")
        for i, q in enumerate(resp.Queries):
            desc = resp.Descriptions[i] if resp.Descriptions and i < len(resp.Descriptions) else ""
            print(f"  {q.Uid}  {q.GetPropertyObject('query_name').StringValue if q else '?'}  -- {desc}")
    else:
        print("No saved queries returned")


# ---------------------------------------------------------------------------
# Main
# ---------------------------------------------------------------------------

def main():
    parser = argparse.ArgumentParser(description="Siemens TC .NET Bridge POC")
    parser.add_argument("--url", default="http://STLV-HSMWEBTCP1:8080/tc",
                        help="Teamcenter base URL")
    parser.add_argument("--user", required=True, help="TC username")
    parser.add_argument("--password", required=True, help="TC password")
    parser.add_argument("--item", help="Item ID to look up (e.g., 0200501)")
    parser.add_argument("--climb", action="store_true",
                        help="Climb full hierarchy to top-level assembly")
    parser.add_argument("--list-queries", action="store_true",
                        help="List all available saved queries")
    args = parser.parse_args()

    # Load assemblies
    load_tc_assemblies()

    conn = None
    try:
        conn = tc_connect(args.url, args.user, args.password)

        if args.list_queries:
            list_queries(conn)

        if args.item:
            if args.climb:
                climb_hierarchy(conn, args.item)
            else:
                set_item_policy(conn)
                item_rev = resolve_item(conn, args.item)
                if item_rev:
                    print("\n--- Trying 2012-02 WhereUsed ---")
                    parents_2012 = where_used_2012(conn, item_rev)
                    print("\n--- Trying 2007-01 WhereUsed ---")
                    parents_2007 = where_used_2007(conn, item_rev)

        if not args.item and not args.list_queries:
            print("\nNo action specified. Use --item or --list-queries.")

    except Exception as e:
        print(f"\nERROR: {e}")
        traceback.print_exc()
        sys.exit(1)
    finally:
        if conn:
            tc_logout(conn)


if __name__ == "__main__":
    main()
