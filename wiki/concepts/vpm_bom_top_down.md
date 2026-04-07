---
status: active
last_updated: 2026-04-06
related: [vpm_bom_bottom_up.md, vpm_tc_soa_protocol.md]
---

# vpm_bom_top_down — Top-down BOM expansion (works)

## Summary
Given a top-level assembly, expand its children one level at a time using
`createBOMWindows` + `expandPSOneLevel`. This path **works** in VPM when
TC is healthy.

## Pattern
1. `StructureManagementService.CreateBOMWindows(item)` → returns a
   `BOMWindow` handle and a top `BOMLine`.
2. `StructureManagementService.ExpandPSOneLevel(bomLines)` → returns
   children of those lines.
3. Recurse depth-first or breadth-first as needed.
4. `StructureManagementService.CloseBOMWindows(bomWindows)` to clean up.

## Why it works
The strongly-typed call shapes match what the server expects, and the
session is held by the official `Connection` object.

## Caveats
- Requires knowing the **top-level assembly UID** to start.
- Doesn't help when you have a child item and need to find its parents
  (that's `whereUsed`, see `vpm_bom_bottom_up.md`).

## Code refs
- `tc_connector.py` — see existing top-down expansion functions
- `decompiled_checksheet/.../StructureManagementService.cs`
