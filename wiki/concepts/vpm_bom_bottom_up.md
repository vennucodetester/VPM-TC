---
status: blocked
last_updated: 2026-04-06
related: [vpm_whereUsed.md, vpm_bom_top_down.md, vpm_siemens_bridge.md]
---

# vpm_bom_bottom_up — Bottom-up BOM (broken)

## Summary
Given a child item, find its parent assemblies (and their parents, up to
the top). This is the **central unsolved problem** in VPM.

## Why it's hard
- The natural API is `DataManagementService.WhereUsed`, which has been
  unreliable from VPM's hand-crafted JsonRest calls (error 214086).
- No top-down traversal can substitute without already knowing every
  possible top-level assembly.

## Alternatives considered
1. **Hand-crafted whereUsed JSON** — tried, gives 214086. *Rejected.*
2. **Reverse lookup table** (build an index by walking every BOM
   top-down once, persist to disk) — *Rejected by user* (see
   `decisions/vpm_ADR-001-no-reverse-lookup.md`).
3. **Siemens DLL bridge** (call `WhereUsed` via official client through
   pythonnet) — *Current approach*, blocked on TC web tier (1003).
   See `decisions/vpm_ADR-002-siemens-dll-bridge.md`.

## Open questions
- Does TC have a SQL or RAC-only API that does whereUsed reliably?
- Could we capture the official client's exact wire traffic (mitmproxy)
  and replay it from Python without pythonnet?

## Sources
- `entities/vpm_whereUsed.md`
- `WHEREUSED_AND_TC_CONNECTIVITY_TRIALS.md`
