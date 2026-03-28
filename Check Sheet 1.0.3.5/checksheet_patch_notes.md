# CHECKSHEET URL Unlock Patch Notes

## Target
- Original executable: `CHECKSHEET.exe`
- Backup copy: `CHECKSHEET.original.exe`
- Patched copy: `CHECKSHEET.patched.exe`

## Runtime Identification
- Binary contains CLR header (`COM descriptor` present), indicating managed .NET assembly.
- Main form type: `Rapid_Check.frmMain`
- Method containing URL textbox initialization: `InitializeComponent` (`MethodDef #152`, RVA `0x5A50`)

## Patch Applied
- Goal: ungrey/unlock TC URL textbox by forcing `Enabled = True`.
- In `frmMain.InitializeComponent`, the URL textbox disable instruction sequence was:
  - `get_txtTC_Url`
  - `ldc.i4.0`
  - `callvirt token(0x0A000109)` (`set_Enabled`)
- Patched one IL byte:
  - File offset: `0x4C5A`
  - Before: `16 6F 09 01 00 0A` (`ldc.i4.0`)
  - After:  `17 6F 09 01 00 0A` (`ldc.i4.1`)

## Validation
- Static verification confirms byte change in patched file only.
- Smoke test launch:
  - `CHECKSHEET.patched.exe` starts successfully and stays alive for 3 seconds.
  - Process terminates cleanly after test.

## SHA256
- `CHECKSHEET.original.exe`  
  `1c0d281bd8db55a4e6331fc99630c7c0283656f849b27e458b04eff4cf23edf6`
- `CHECKSHEET.patched.exe`  
  `21bff6fb61b3220b9f838ab87d163417e5bc67605b1dfcfd8b377a2826726a9f`
- `CHECKSHEET.exe` (unchanged)  
  `1c0d281bd8db55a4e6331fc99630c7c0283656f849b27e458b04eff4cf23edf6`

## Rollback
- To undo patch usage, run the original executable (`CHECKSHEET.exe` or `CHECKSHEET.original.exe`).
- To replace a patched active binary with original:
  1. Close the app completely.
  2. Copy `CHECKSHEET.original.exe` over the active executable.
  3. Relaunch app.
