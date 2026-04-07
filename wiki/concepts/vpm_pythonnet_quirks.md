---
status: active
last_updated: 2026-04-06
related: [vpm_siemens_bridge.md]
---

# vpm_pythonnet_quirks — Gotchas hit while wiring Python ↔ .NET

## Summary
pythonnet 3.x can load most .NET DLLs into Python, but corporate .NET
security and pythonnet's interface limitations cause specific failures
that are easy to misdiagnose.

## Quirk 1 — CAS policy blocks "remote" assemblies
`HRESULT 0x80131515` when calling `clr.AddReference()` on DLLs in
OneDrive **or even local %TEMP%** on corporate machines.
**Fix:** auto-write `python.exe.config` next to the Python executable:
```xml
<configuration>
  <runtime>
    <loadFromRemoteSources enabled="true"/>
  </runtime>
</configuration>
```
Plus a coreclr fallback path. Both implemented in `test_siemens_bridge.py`.

## Quirk 2 — Cannot subclass .NET interfaces from Python
pythonnet 3.x raises `TypeError: interface takes exactly one argument`
when trying to implement an interface like `CredentialManager` directly
in Python.
**Fix:** write a small C# helper DLL with concrete classes that
implement the interface, then import the helper from Python.
See `TcPythonHelper.cs`.

Compile:
```
csc /target:library /out:TcPythonHelper.dll \
    /reference:TcSoaClient.dll /reference:TcSoaCommon.dll \
    TcPythonHelper.cs
```

## Quirk 3 — AnyCPU vs x86
All Siemens TcSoa DLLs are AnyCPU (PE flags: `IL_ONLY=True`,
`32BIT_REQ=False`), so they load fine in 64-bit Python. Verify with
`dumpbin /headers` or `corflags` if a new DLL fails to load.

## Quirk 4 — Login can hang forever
Without a timeout, `SessionService.Login()` will wait indefinitely if
the server is in 1003 state. **Fix:** wrap in a thread with a 60s join.

## Quirk 5 — Path with spaces
DLLs in `Check Sheet 1.0.3.5/` (note the spaces) can confuse some
loaders. The script copies them to `%TEMP%\tc_soa_dlls` to sidestep this
and the OneDrive CAS issue at the same time.

## Sources
- `test_siemens_bridge.py`
- `TcPythonHelper.cs`
- This session's debugging history (`vpm_log.md`)
