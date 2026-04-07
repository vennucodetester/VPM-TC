---
status: blocked
last_updated: 2026-04-06
related: [vpm_error_214086.md, vpm_error_1003.md, vpm_siemens_bridge.md, vpm_bom_bottom_up.md]
---

# vpm_whereUsed — Bottom-up BOM lookup in Teamcenter

## Summary
The Teamcenter SOA `whereUsed` operation is supposed to return parent
assemblies for a given item. In VPM it has **never worked reliably** via
hand-crafted HTTP/JSON. This is the central pain point of the project.

## Details
- Two known op versions:
  - `Cad-2007-01-DataManagement.WhereUsed` (older)
  - `Cad-2012-02-DataManagement.WhereUsed` (newer)
- Two binding flavors:
  - `/tc/RestServices/...` — used by official Siemens client
  - `/tc/JsonRestServices/...` — what VPM hand-crafts
- Hand-crafted attempts return error 214086 ("invalid syntax") or hang.
- The official checksheet app uses the strongly-typed
  `DataManagementService` from `TcSoaCoreStrong.dll`, which serializes the
  request correctly internally.

## Current approach
Pivot to the **Siemens DLL bridge** (`entities/vpm_siemens_bridge.md`) and
call `DataManagementService.WhereUsed()` through pythonnet instead of
hand-crafting JSON. POC built; blocked on TC web tier (error 1003).

## Open questions
- Does the 2012-02 version actually accept the same input shape as 2007-01?
- Does whereUsed only return *latest revision* parents or all revisions?
- Are there permission requirements that silently return empty arrays?

## Sources
- `WHEREUSED_AND_TC_CONNECTIVITY_TRIALS.md`
- `tc_connector.py` (current hand-crafted impl)
- `decompiled_checksheet/TcSoaCoreStrong/Teamcenter/Services/Strong/Core/DataManagementService.cs`
