---
status: active
last_updated: 2026-04-06
related: [vpm_whereUsed.md, vpm_tc_soa_protocol.md]
---

# vpm_error_214086 — "invalid syntax"

## Summary
TC SOA error 214086 returned by `/tc/JsonRestServices/...` when the JSON
request body doesn't match what the binding expects. Root cause: VPM is
hand-crafting the JSON envelope and getting either the namespace, the op
version, or the parameter shape wrong.

## Details
- Seen on `whereUsed` calls (both 2007-01 and 2012-02 namespaces tried).
- The JsonRest binding is stricter than RestServices about envelope shape.
- The official Siemens client never hits this because it builds the
  envelope from the strongly-typed proxy classes in `TcSoaCoreStrong.dll`.

## Fix path
Stop hand-crafting JSON. Use the Siemens DLL bridge
(`entities/vpm_siemens_bridge.md`) so the official client builds the request.

## Sources
- `WHEREUSED_AND_TC_CONNECTIVITY_TRIALS.md`
- `tc_connector.py` (where the hand-crafted JSON lives)
