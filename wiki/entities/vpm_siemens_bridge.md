---
status: blocked
last_updated: 2026-04-06
related: [vpm_whereUsed.md, vpm_checksheet_app.md, vpm_pythonnet_quirks.md, vpm_error_1003.md]
---

# vpm_siemens_bridge — pythonnet + Siemens TC DLL bridge

## Summary
Instead of hand-crafting SOA JSON, load the official Siemens TC client
DLLs into Python via `pythonnet` and call the same strongly-typed services
the checksheet app uses (`SessionService.Login`,
`DataManagementService.WhereUsed`, etc).

## Status
- Mechanically **proven**: pythonnet 3.0.5 loads all 9 TC SOA assemblies.
- Server reachable from .NET HTTP inside Python (`--diag` mode succeeded).
- **Blocked** end-to-end: cannot complete login while TC web tier returns
  error 1003. Same blocker affects the official checksheet app, so this
  is not a bridge bug.

## Architecture
```
Python  ──pythonnet──▶  Teamcenter.Soa.Client.Connection
                       │
                       ├─ SessionService.Login(...)
                       ├─ DataManagementService.WhereUsed(...)
                       └─ StructureManagementService.* (top-down BOM)
```

- **Helper DLL:** `TcPythonHelper.dll` (compiled from `TcPythonHelper.cs`)
  - `SimpleCredentialManager : CredentialManager`
  - `SimpleExceptionHandler : ExceptionHandler`
  - Needed because pythonnet 3.x can't subclass .NET interfaces from Python.
- **DLLs loaded** (all AnyCPU, work in 64-bit Python):
  TcSoaClient, TcSoaCommon, TcSoaCoreStrong, TcSoaCoreTypes,
  TcSoaStrongModel, TcSoaQueryStrong, TcSoaQueryTypes, TcSoaCadStrong,
  TcSoaCadTypes, TcPythonHelper.
- **DLL location:** copied from `Check Sheet 1.0.3.5/` to
  `%TEMP%\tc_soa_dlls` at runtime to dodge OneDrive CAS issues.

## How to run
```
python test_siemens_bridge.py --user USER --password PASS --item 0200501
python test_siemens_bridge.py --diag        # raw .NET HTTP test
python test_siemens_bridge.py --ping        # plain reachability
```

## Known gotchas
- Must auto-write `python.exe.config` with
  `<loadFromRemoteSources enabled="true"/>` (handled in script).
- Login uses 60s threaded timeout to avoid indefinite hangs.
- See `concepts/vpm_pythonnet_quirks.md` for more.

## Next step (when TC up)
Run the script and confirm `WhereUsed()` returns parent UIDs for a known
test item. If yes → integrate `SiemensBridge` into `tc_connector.py`.

## Sources
- `test_siemens_bridge.py`
- `TcPythonHelper.cs`
- `Check Sheet 1.0.3.5/TcSoa*.dll`
- `decompiled_checksheet/CHECKSHEET/Rapid_Check/TCFunctions.cs`
