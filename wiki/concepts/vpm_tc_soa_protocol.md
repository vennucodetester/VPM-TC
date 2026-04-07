---
status: active
last_updated: 2026-04-06
related: [vpm_whereUsed.md, vpm_error_214086.md, vpm_siemens_bridge.md]
---

# vpm_tc_soa_protocol — Teamcenter SOA over HTTP

## Summary
Teamcenter exposes its services via two HTTP bindings, multiple op
versions, and a session-cookie auth model. Getting any of these wrong
gives cryptic errors (214086, 1003, etc).

## Bindings
- **REST** — `/tc/RestServices/<Module>-<Year-Month>-<Service>` —
  used by the official Siemens client. Strict, stable.
- **JsonRest** — `/tc/JsonRestServices/...` — used by VPM hand-crafted
  code. Same paths, slightly different envelope expectations. Stricter
  about parameter shape; mismatches give error 214086.

## Op versioning
Each service has multiple dated versions, e.g.:
- `Core-2008-06-Session.Login`
- `Cad-2007-01-DataManagement.WhereUsed`
- `Cad-2012-02-DataManagement.WhereUsed`

The newer version is not always a superset; parameter shapes can differ.

## Session model
1. POST to `Core-2008-06-Session.Login` with credentials.
2. Server returns a session cookie (`JSESSIONID` etc).
3. Subsequent calls must carry the cookie.
4. POST to `Core-2006-03-Session.Logout` at end.

The official client handles all of this in `Connection`. Hand-crafted code
must manage cookies manually.

## What VPM gets wrong
- Picks JsonRest binding but uses REST-style envelopes.
- Mixes op versions (2007-01 params with 2012-02 path or vice versa).
- Sometimes loses the session cookie between calls.

## Cure
Use the Siemens DLL bridge (`entities/vpm_siemens_bridge.md`) — it builds
correct envelopes from strongly-typed classes.

## Sources
- `TEAMCENTER_DECOMPILATION_FINDINGS_CLEAR.md`
- `decompiled_checksheet/TcSoaCoreStrong/...`
- `tc_proxy_capture_summary.md`
