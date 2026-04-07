# vpm_log — Append-only log of attempts

Newest entries at the top. Never delete; supersede with new entries.

---

## 2026-04-06 — LLM wiki created
**Tried:** Set up `wiki/` per Karpathy's LLM Wiki gist with `vpm_` prefix on
all files for cross-project searchability.
**Outcome:** Initial scaffold + seeded pages from existing decompilation /
trials docs. See `vpm_WIKI_SCHEMA.md`.
**Links:** `decisions/vpm_ADR-003-llm-wiki.md`

## 2026-04-06 — Siemens DLL bridge POC end-to-end test
**Tried:** `test_siemens_bridge.py` with `TcPythonHelper.dll`. Loads 9/9 TC
SOA assemblies. Pings server (HTTP 400 = alive). Attempts login.
**Outcome:** Login hangs / eventually returns error 1003 from TC web tier.
The official checksheet app shows the same 1003 in parallel. Not a code bug.
**Links:** `entities/vpm_siemens_bridge.md`, `entities/vpm_error_1003.md`,
`test_siemens_bridge.py`

## 2026-04-06 — pythonnet interface subclassing limitation
**Tried:** Subclass `CredentialManager` directly in Python.
**Outcome:** `TypeError: interface takes exactly one argument`. pythonnet 3.x
cannot implement .NET interfaces from Python. Fixed by writing
`TcPythonHelper.cs` (`SimpleCredentialManager`, `SimpleExceptionHandler`),
compiled to `TcPythonHelper.dll` with `csc.exe /target:library`.
**Links:** `concepts/vpm_pythonnet_quirks.md`, `TcPythonHelper.cs`

## 2026-04-06 — .NET CAS policy blocked OneDrive DLL load
**Tried:** Load TC DLLs from OneDrive path via `clr.AddReference()`.
**Outcome:** HRESULT `0x80131515` — corporate .NET treats OneDrive (and even
local %TEMP%) as untrusted. Fixed by auto-writing
`python.exe.config` with `<loadFromRemoteSources enabled="true"/>` and adding
a coreclr fallback path. Also copy DLLs to `%TEMP%\tc_soa_dlls`.
**Links:** `concepts/vpm_pythonnet_quirks.md`

## 2026-04-06 — Yesterday's version (v3.2.5) saved for side-by-side testing
**Tried:** Snapshot commit `1d8379e` into `yesterday_version/`.
**Outcome:** Confirmed v3.2.5 also hits error 1003 right now → confirms
infra issue, not regression.
**Links:** `vpm_state.md`

## (older) — Hand-crafted JsonRest whereUsed attempts
**Tried:** Multiple binding/namespace combos for `whereUsed` against
`/tc/JsonRestServices/...` (2007-01 and 2012-02).
**Outcome:** Errors 214086 (invalid syntax) and timeouts. Bottom-up has
never worked reliably from VPM.
**Links:** `entities/vpm_whereUsed.md`, `entities/vpm_error_214086.md`,
`WHEREUSED_AND_TC_CONNECTIVITY_TRIALS.md`
