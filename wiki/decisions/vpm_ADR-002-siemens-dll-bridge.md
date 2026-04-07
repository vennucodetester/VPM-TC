---
status: accepted
last_updated: 2026-04-06
related: [vpm_siemens_bridge.md, vpm_whereUsed.md, vpm_checksheet_app.md]
---

# ADR-002 — Use the Siemens TC client DLLs from Python via pythonnet

## Context
- Hand-crafted JsonRest `whereUsed` calls have been unreliable for months
  (errors 214086, timeouts).
- The official VB.NET checksheet app uses the strongly-typed Siemens
  client DLLs and works reliably.
- Reverse-lookup table is rejected (ADR-001).

## Decision
Bridge into the official Siemens TC client DLLs from Python using
`pythonnet`. Call `SessionService.Login()` and
`DataManagementService.WhereUsed()` directly through those DLLs.

## Rationale
- Eliminates the entire class of envelope-shape bugs (the DLLs build
  the request from typed objects).
- Re-uses Siemens-tested code instead of reverse-engineering wire format.
- All TcSoa DLLs are AnyCPU and load in 64-bit Python (verified).
- Same DLLs the checksheet app ships, so we know they work against this
  TC instance.

## Consequences
- New runtime dependency: `pythonnet` (`pip install pythonnet`).
- Need a tiny C# helper DLL (`TcPythonHelper.dll`) because pythonnet
  can't subclass .NET interfaces from Python.
- Must handle .NET CAS policy on corporate machines.
- Windows-only (acceptable; VPM is already Windows-only).
- Once integrated, `tc_connector.py` will have a `SiemensBridge` primary
  path with the existing HTTP code as fallback.

## Status
POC built and proven mechanically. End-to-end blocked on TC web tier
(error 1003) — not a bridge issue.

## Sources
- `entities/vpm_siemens_bridge.md`
- `test_siemens_bridge.py`
- `TcPythonHelper.cs`
