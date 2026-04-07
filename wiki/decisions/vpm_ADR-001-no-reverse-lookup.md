---
status: accepted
last_updated: 2026-04-06
related: [vpm_bom_bottom_up.md, vpm_whereUsed.md]
---

# ADR-001 — Do not build a reverse-lookup table for whereUsed

## Context
Bottom-up `whereUsed` is broken via hand-crafted JsonRest. One natural
workaround: walk every top-level assembly top-down once, persist a
`{child_uid → [parent_uids]}` index, and serve whereUsed from that index.

## Decision
**Rejected.** Per user direction: "reverse lookup is not an option."

## Rationale (inferred)
- Index would go stale immediately as engineers edit BOMs in TC.
- "Every top-level assembly" is not a small or fixed set.
- Adds a stateful sync problem on top of a connectivity problem.
- User wants a *live* answer from TC, not a cached one.

## Consequences
- Must solve whereUsed at the source (TC SOA), not work around it.
- Drives the pivot to the Siemens DLL bridge (ADR-002).

## Sources
- User direct quote (this session): "reverse lookup is not an option."
