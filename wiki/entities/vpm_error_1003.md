---
status: active
last_updated: 2026-04-06
related: [vpm_tc_server.md, vpm_siemens_bridge.md]
---

# vpm_error_1003 — "Failed to assign a server"

## Summary
TC SOA error code **1003**, message "Failed to assign a server". Thrown by
the TC web tier when it cannot allocate a backend TC server process to
service the session. Surfaced as
`Teamcenter.Schemas.Soa._2006_03.Exceptions.InternalServerException`.

## Details
- Affects **all** clients equally — VPM code, the official Siemens
  checksheet `.exe`, and the Siemens DLL bridge POC.
- The HTTP transport is fine: `/tc/RestServices/Core-2008-06-Session`
  responds with HTTP 400 (server alive, just rejecting the empty request).
- 1003 is raised on the **Login** call, not on the ping.
- Out of our control — needs the TC admins to restart the web tier or
  free up backend slots.

## How to recognize it
- Login attempt hangs ~30-60s then errors.
- Error message contains "Failed to assign a server" or code "1003".
- Checksheet app shows the same error in parallel → confirms infra issue.

## Mitigation
- None on our side. Wait for TC to recover, then retry.
- VPN reachable + ping returns HTTP 400 ≠ TC actually usable. Login is the
  real liveness test.

## Sources
- This session (2026-04-06) — both VPM v3.2.5 and bridge POC hit 1003.
- `test_siemens_bridge.py` log output.
