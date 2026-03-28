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
import time
import traceback
import urllib.request
import urllib.error

# ---------------------------------------------------------------------------
# 0. Fix .NET CAS policy BEFORE importing pythonnet
# ---------------------------------------------------------------------------

def _ensure_loadfromremotesources():
    """
    .NET Framework blocks Assembly.LoadFrom() on 'untrusted' paths unless
    loadFromRemoteSources is enabled. Create a python.exe.config next to
    the running Python interpreter to allow it.
    """
    python_exe = sys.executable
    config_path = python_exe + ".config"
    config_xml = """\
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5"/>
  </startup>
  <runtime>
    <loadFromRemoteSources enabled="true"/>
  </runtime>
  <system.net>
    <defaultProxy useDefaultCredentials="true">
      <proxy usesystemdefault="true"/>
    </defaultProxy>
    <connectionManagement>
      <add address="*" maxconnection="10"/>
    </connectionManagement>
  </system.net>
</configuration>
"""
    needs_write = False
    if not os.path.exists(config_path):
        needs_write = True
    else:
        with open(config_path, "r") as f:
            if "loadFromRemoteSources" not in f.read():
                needs_write = True

    if needs_write:
        try:
            with open(config_path, "w") as f:
                f.write(config_xml)
            print(f"  Created {config_path} (loadFromRemoteSources=true)")
            print(f"  NOTE: You may need to re-run the script for this to take effect.")
        except PermissionError:
            print(f"  WARNING: Cannot write {config_path} (no permission).")
            print(f"  Try running as Administrator once, or manually create this file.")

# Run before anything else
_ensure_loadfromremotesources()

# ---------------------------------------------------------------------------
# 1. Load Siemens TC .NET assemblies via pythonnet
# ---------------------------------------------------------------------------

DLL_SOURCE_DIR = os.path.join(os.path.dirname(os.path.abspath(__file__)), "Check Sheet 1.0.3.5")

# .NET blocks loading DLLs from OneDrive/network paths (CAS policy).
# Copy them to a local temp folder so they load cleanly.
LOCAL_DLL_DIR = os.path.join(os.environ.get("TEMP", r"C:\Temp"), "tc_soa_dlls")

REQUIRED_DLLS = [
    "TcSoaClient",
    "TcSoaCommon",
    "TcSoaCoreStrong",
    "TcSoaCoreTypes",
    "TcSoaStrongModel",
    "TcSoaQueryStrong",
    "TcSoaQueryTypes",
    "TcSoaCadStrong",
    "TcSoaCadTypes",
    "TcPythonHelper",
]


def _ensure_local_dlls():
    """Copy DLLs from OneDrive/network source to local temp if needed."""
    import shutil
    os.makedirs(LOCAL_DLL_DIR, exist_ok=True)
    for dll_name in REQUIRED_DLLS:
        src = os.path.join(DLL_SOURCE_DIR, f"{dll_name}.dll")
        dst = os.path.join(LOCAL_DLL_DIR, f"{dll_name}.dll")
        if not os.path.exists(dst) or os.path.getmtime(src) > os.path.getmtime(dst):
            shutil.copy2(src, dst)
    # Also copy any other DLLs the TC libs depend on (log4net, binding interfaces, etc.)
    for f in os.listdir(DLL_SOURCE_DIR):
        if f.lower().endswith(".dll"):
            src = os.path.join(DLL_SOURCE_DIR, f)
            dst = os.path.join(LOCAL_DLL_DIR, f)
            if not os.path.exists(dst) or os.path.getmtime(src) > os.path.getmtime(dst):
                shutil.copy2(src, dst)
    print(f"  DLLs staged to local path: {LOCAL_DLL_DIR}")


def _try_set_coreclr_runtime():
    """
    If .NET Framework CAS blocks loading, try switching pythonnet to .NET Core
    which has no CAS restrictions. Must be called BEFORE 'import clr'.
    """
    try:
        from clr_loader import get_coreclr
        runtime = get_coreclr()
        # Set the runtime for pythonnet
        import pythonnet
        pythonnet.set_runtime(runtime)
        print("  Using .NET Core (coreclr) runtime — no CAS restrictions")
        return True
    except Exception as e:
        print(f"  coreclr not available ({e}), using .NET Framework")
        return False


def load_tc_assemblies(use_coreclr=False):
    """Load all required Teamcenter SOA .NET DLLs from a local (non-network) path."""
    if use_coreclr:
        _try_set_coreclr_runtime()

    import clr

    _ensure_local_dlls()
    sys.path.insert(0, LOCAL_DLL_DIR)

    loaded = 0
    for dll in REQUIRED_DLLS:
        path = os.path.join(LOCAL_DLL_DIR, dll)
        try:
            clr.AddReference(path)
            loaded += 1
        except Exception as e:
            print(f"  WARNING: Could not load {dll}: {e}")

    if loaded == 0 and not use_coreclr:
        print("\n  All DLLs failed with .NET Framework. Retrying with .NET Core...")
        return load_tc_assemblies(use_coreclr=True)

    print(f"Loaded {loaded}/{len(REQUIRED_DLLS)} TC assemblies from {LOCAL_DLL_DIR}")


# ---------------------------------------------------------------------------
# 2. Use precompiled C# helper DLL for .NET interface implementations
#    (pythonnet can't subclass .NET interfaces directly)
# ---------------------------------------------------------------------------

def create_credential_manager(username, password):
    """Create a CredentialManager using the precompiled TcPythonHelper.dll."""
    from TcPythonHelper import SimpleCredentialManager
    mgr = SimpleCredentialManager()
    mgr.SetCredentials(username, password)
    return mgr


def create_exception_handler():
    """Create an ExceptionHandler using the precompiled TcPythonHelper.dll."""
    from TcPythonHelper import SimpleExceptionHandler
    return SimpleExceptionHandler()


# ---------------------------------------------------------------------------
# 3. Connectivity pre-check and login
# ---------------------------------------------------------------------------

def ping_tc_url(url, timeout=15):
    """Quick HTTP check to see if the TC SOA web tier is reachable at all."""
    # Try both RestServices and JsonRestServices endpoints
    test_urls = [
        f"{url.rstrip('/')}/RestServices/Core-2008-06-Session",
        f"{url.rstrip('/')}/JsonRestServices/Core-2008-06-Session",
        url.rstrip('/'),
    ]
    for test_url in test_urls:
        try:
            req = urllib.request.Request(test_url, method="GET")
            resp = urllib.request.urlopen(req, timeout=timeout)
            print(f"  REACHABLE: {test_url} -> HTTP {resp.status}")
            return True
        except urllib.error.HTTPError as e:
            # HTTP error but server responded — that's fine, SOA tier is alive
            print(f"  REACHABLE: {test_url} -> HTTP {e.code} (server responded)")
            return True
        except urllib.error.URLError as e:
            print(f"  UNREACHABLE: {test_url} -> {e.reason}")
        except Exception as e:
            print(f"  UNREACHABLE: {test_url} -> {e}")
    return False


def tc_connect(url, username, password, retries=3, retry_delay=8):
    """Create Connection and login with retry logic for flaky SOA web tier."""
    from System.Net import CookieCollection
    from Teamcenter.Soa import SoaConstants
    from Teamcenter.Soa.Client import Connection
    from Teamcenter.Services.Strong.Core import SessionService

    # Pre-check: is the SOA tier even reachable?
    print(f"\nPre-check: pinging {url} ...")
    if not ping_tc_url(url):
        print("\n  WARNING: SOA web tier appears unreachable.")
        print("  Active Workspace uses a different path/port than SOA RestServices.")
        print("  The SOA pool on :8080 may be down. Ask IT to check the web tier.")
        print("  Will still attempt login in case ping was a false negative...\n")

    # Configure .NET networking to match checksheet behavior
    try:
        import System
        from System.Net import ServicePointManager, SecurityProtocolType, WebRequest, CredentialCache
        ServicePointManager.DefaultConnectionLimit = 10
        ServicePointManager.Expect100Continue = False
        ServicePointManager.UseNagleAlgorithm = False
        # Allow all TLS versions
        ServicePointManager.SecurityProtocol = (
            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12
        )
        # Use system default proxy (same as browser/checksheet)
        WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy()
        WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultCredentials
        print("  .NET ServicePointManager configured")
    except Exception as e:
        print(f"  WARNING: Could not configure ServicePointManager: {e}")

    cred_mgr = create_credential_manager(username, password)

    # Enable .NET network tracing to see what the DLL is doing
    try:
        import System.Diagnostics
        ts = System.Diagnostics.TraceSource("System.Net", System.Diagnostics.SourceLevels.All)
        log_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), "dotnet_trace.log")
        listener = System.Diagnostics.TextWriterTraceListener(log_path)
        ts.Listeners.Add(listener)
        System.Diagnostics.Trace.AutoFlush = True
        print(f"  .NET trace logging to: {log_path}")
    except Exception as e:
        print(f"  Could not enable .NET tracing: {e}")

    for attempt in range(1, retries + 1):
        try:
            # Ensure URL has trailing slash (some TC SOA clients require it)
            if not url.endswith("/"):
                url = url + "/"
            print(f"Login attempt {attempt}/{retries} to {url} ...")
            print(f"  Protocol: {SoaConstants.REST} / {SoaConstants.HTTP}")

            conn = Connection(url, CookieCollection(), cred_mgr,
                              SoaConstants.REST, SoaConstants.HTTP, False)
            conn.ExceptionHandler = create_exception_handler()

            session_svc = SessionService.getService(conn)
            args = cred_mgr.GetLoginArgs()
            print(f"  Logging in as {args[0]} ...")
            print(f"  (If this hangs, check dotnet_trace.log and kill with Ctrl+C)")
            # Run login in a thread with timeout so we don't hang forever
            import threading
            login_result = [None]
            login_error = [None]

            def _do_login():
                try:
                    login_result[0] = session_svc.Login(
                        args[0], args[1], args[2], args[3], args[4], args[5]
                    )
                except Exception as e:
                    login_error[0] = e

            t = threading.Thread(target=_do_login, daemon=True)
            t.start()
            t.join(timeout=60)  # 60 second timeout

            if t.is_alive():
                print(f"\n  LOGIN TIMED OUT after 60s!")
                print(f"  Check dotnet_trace.log for what happened.")
                print(f"  The Siemens DLL's internal HTTP call is hanging.")
                raise TimeoutError("Login hung for 60s")

            if login_error[0]:
                raise login_error[0]

            print(f"  Login OK!")
            return conn

        except Exception as e:
            err_str = str(e).lower()
            is_transient = any(kw in err_str for kw in [
                "timeout", "timed out", "assign a server", "web tier",
                "server manager", "1003", "connection", "socket",
            ])

            if is_transient and attempt < retries:
                print(f"  Transient error: {e}")
                print(f"  Retrying in {retry_delay}s ...")
                time.sleep(retry_delay)
            else:
                raise


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
    parser.add_argument("--user", default="(user)", help="TC username")
    parser.add_argument("--password", default="(password)", help="TC password")
    parser.add_argument("--item", default="0200501", help="Item ID to look up (e.g., 0200501)")
    parser.add_argument("--climb", action="store_true",
                        help="Climb full hierarchy to top-level assembly")
    parser.add_argument("--list-queries", action="store_true",
                        help="List all available saved queries")
    parser.add_argument("--ping", action="store_true",
                        help="Just check if TC SOA web tier is reachable (no login)")
    parser.add_argument("--diag", action="store_true",
                        help="Run .NET HTTP diagnostic (tests if .NET can reach TC)")
    parser.add_argument("--retries", type=int, default=3,
                        help="Login retry attempts (default: 3)")
    args = parser.parse_args()

    # Ping-only mode (no DLLs needed)
    if args.ping:
        print(f"Pinging TC SOA web tier at {args.url} ...")
        ok = ping_tc_url(args.url)
        sys.exit(0 if ok else 1)

    # .NET HTTP diagnostic mode
    if args.diag:
        print(f"Running .NET HTTP diagnostic to {args.url} ...")
        load_tc_assemblies()
        try:
            import System
            from System.Net import HttpWebRequest, ServicePointManager, SecurityProtocolType
            from System import Uri
            ServicePointManager.SecurityProtocol = (
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12
            )
            ServicePointManager.Expect100Continue = False
            ServicePointManager.DefaultConnectionLimit = 10

            test_url = f"{args.url.rstrip('/')}/RestServices/Core-2008-06-Session/login"
            print(f"  Testing .NET HttpWebRequest to: {test_url}")
            req = HttpWebRequest.Create(Uri(test_url))
            req.Method = "POST"
            req.ContentType = "application/json"
            req.Timeout = 30000  # 30 seconds
            req.Proxy = System.Net.WebRequest.GetSystemWebProxy()

            # Write a minimal JSON body
            body = b'{"header":{},"body":{}}'
            stream = req.GetRequestStream()
            stream.Write(body, 0, len(body))
            stream.Close()

            print("  Waiting for response (30s timeout)...")
            resp = req.GetResponse()
            print(f"  .NET HTTP OK: {resp.StatusCode}")
            resp.Close()
        except System.Net.WebException as e:
            if e.Response:
                print(f"  .NET HTTP error response: {e.Response.StatusCode} (server responded!)")
            else:
                print(f"  .NET HTTP failed: {e.Message}")
                print(f"  This means .NET's HTTP stack can't reach TC — likely proxy issue")
        except Exception as e:
            print(f"  .NET HTTP error: {e}")
        sys.exit(0)

    # Require credentials for non-ping operations
    if args.user == "(user)" or args.password == "(password)":
        parser.error("Replace (user) and (password) with your actual TC credentials in the script, or pass --user X --password Y")

    # Load assemblies
    load_tc_assemblies()

    conn = None
    try:
        conn = tc_connect(args.url, args.user, args.password, retries=args.retries)

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
