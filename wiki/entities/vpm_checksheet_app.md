---
status: active
last_updated: 2026-04-06
related: [vpm_siemens_bridge.md, vpm_tc_soa_protocol.md]
---

# vpm_checksheet_app — Decompiled reference VB.NET app

## Summary
"Check Sheet 1.0.3.5" is an existing in-house VB.NET tool that talks to the
same TC server VPM uses, and does it reliably. Decompiled and used as a
**ground-truth reference** for how SOA calls *should* be made.

## What it proves
- The official Siemens TC client libraries work against this TC instance.
- Login uses `Connection` constructed with `SoaConstants.REST` +
  `SoaConstants.HTTP` (NOT JsonRest).
- All TC SOA DLLs are AnyCPU and load in 64-bit processes.
- The exact endpoint base is `http://STLV-HSMWEBTCP1:8080/tc`.
- TC username/password lives in `CHECKSHEET.exe.config` under
  `userSettings → Rapid_Check.My.MySettings`.

## Key files
- `Check Sheet 1.0.3.5/CHECKSHEET.exe` — runnable original
- `Check Sheet 1.0.3.5/CHECKSHEET.exe.config` — config (URL, settings)
- `Check Sheet 1.0.3.5/TcSoa*.dll` — the TC client DLLs we re-use in the bridge
- `decompiled_checksheet/CHECKSHEET/Rapid_Check/TCFunctions.cs` — login pattern
- `decompiled_checksheet/TcSoaCoreStrong/.../DataManagementService.cs` —
  the strongly-typed proxy for whereUsed

## Use as oracle
When unsure how to call a SOA op, check how the checksheet app calls it
in the decompiled source first.

## Sources
- `CHECKSHEET_DECOMPILATION_FINDINGS.md`
- `CHECKSHEET_EXE_COMPLETE_REFERENCE.md`
