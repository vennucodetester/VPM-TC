---
status: active
last_updated: 2026-04-06
related: [vpm_error_1003.md, vpm_tc_soa_protocol.md]
---

# vpm_tc_server — Teamcenter server STLV-HSMWEBTCP1

## Summary
The Teamcenter SOA web tier VPM and the checksheet app both connect to.

## Connection details
- **Base URL:** `http://STLV-HSMWEBTCP1:8080/tc`
- **Binding paths:**
  - REST (used by official client): `/tc/RestServices/...`
  - JsonRest (used by VPM hand-crafted code): `/tc/JsonRestServices/...`
- **Liveness ping:** `GET /tc/RestServices/Core-2008-06-Session` →
  HTTP 400 means alive (server rejects empty body).
- **Auth:** TC username + password (set in `CHECKSHEET.exe.config` for
  the reference app; passed via CLI for the bridge POC).
- **VPN:** required from outside the corporate network. Same VPN as
  always; no proxy quirks.

## Operational notes
- Currently in error 1003 state (see `vpm_error_1003.md`).
- HTTP-200 ping ≠ usable — login is the real liveness test.
- No load balancer quirks observed; single endpoint.

## Sources
- `TC_CONNECTION_RUNDOWN.md`
- `tc_proxy_capture_summary.md`
- `CHECKSHEET.exe.config`
