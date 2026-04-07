---
status: active
last_updated: 2026-04-06
---

# vpm_state — Current state of the VPM project

## TC server
- **URL:** `http://STLV-HSMWEBTCP1:8080/tc`
- **Reachability:** server responds (HTTP 400 on `/RestServices/Core-2008-06-Session` = alive)
- **Login status:** **BLOCKED** — web tier returns error **1003 "Failed to assign a server"**
  for both our code AND the official Siemens checksheet app. Not a code bug.
- **VPN:** required from outside the corporate network.

## Last known-good VPM version
- **Tag/commit:** `v3.2.5` / `1d8379e`
- **Saved at:** `yesterday_version/` (full snapshot for side-by-side testing)
- **Caveats:** that version connected to TC fine when TC was healthy, but
  whereUsed (bottom-up BOM) was already broken there too.

## Active blockers
1. TC web tier returning 1003 — out of our control, infra issue.
2. Bottom-up `whereUsed` has never worked reliably from VPM (see `entities/vpm_whereUsed.md`).
3. Siemens DLL bridge POC loads all DLLs and reaches the server, but cannot
   complete the login round-trip while TC is in 1003 state.

## What works
- Top-down BOM via `createBOMWindows` + `expandPSOneLevel` (when TC is up).
- pythonnet loads all 9 TC SOA DLLs successfully (after CAS policy fix + helper DLL).
- `--diag` mode in `test_siemens_bridge.py` confirms .NET HTTP from Python can
  reach the TC server.

## Next steps when TC is back up
1. Re-run `test_siemens_bridge.py --user X --password Y --item 0200501`
2. If login succeeds, call `DataManagementService.WhereUsed()` via the bridge.
3. If that returns parents, integrate `SiemensBridge` into `tc_connector.py`
   as the primary path for `where_used()` / `find_top_level_assembly()`.
