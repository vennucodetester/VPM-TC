# CHECKSHEET Decompilation Findings

## What Was Decompiled

- `Check Sheet 1.0.3.5/CHECKSHEET.exe`
- Output project: `decompiled_checksheet/CHECKSHEET`
- Main Teamcenter code:
  - `decompiled_checksheet/CHECKSHEET/Rapid_Check/TCFunctions.cs`
  - `decompiled_checksheet/CHECKSHEET/Rapid_Check/Tc_CredentialManager.cs`
  - `decompiled_checksheet/CHECKSHEET/Rapid_Check/Tc_ExceptionHandler.cs`
  - `decompiled_checksheet/CHECKSHEET/Rapid_Check/CheckSheetFunctios.cs`
  - `decompiled_checksheet/CHECKSHEET/Rapid_Check/Declarations.cs`

## Proven Working Flow

1. The EXE uses the official Teamcenter .NET client libraries, not handcrafted HTTP.
2. It creates a `Teamcenter.Soa.Client.Connection` with:
   - `SoaConstants.REST`
   - `SoaConstants.HTTP`
   - `CookieCollection`
   - custom `Tc_CredentialManager`
3. It logs in through `SessionService.Login(user, password, group, role, "", discriminator)`.
4. It sets property policy through `SessionService.SetObjectPropertyPolicy(...)`.
5. It finds a saved query with `SavedQueryService.FindSavedQueries(...)`.
6. It executes the query with `SavedQueryService.ExecuteSavedQueries(...)`.
7. It loads returned UIDs with `DataManagementService.LoadObjects(...)`.

## Credential Details

- `Tc_CredentialManager` returns:
  - username
  - password
  - group = `""`
  - role = `""`
  - discriminator = `"SoaAppX"`
- The app code does not call `LoginSSO`.
- `Teamcenter_SSO64.dll` exists in the deployment, but no explicit SSO branch was found in the decompiled app code.

## Exact Query Behavior

- ECN lookup uses saved query name `Item Revision...`
- ECN lookup entry list is only `["Item ID"]`
- Item lookup uses saved query name `Item...`
- Item lookup entry list is `["Type", "Item ID"]`
- Saved query discovery is not broad or heuristic; it asks for the exact query name with `FindSavedQueries`

## Exact Relation And Policy Behavior

- ECN relation used: `CMHasSolutionItem`
- Secondary object type filter used: `H4_Hussmann_ItemRevision`
- Plant form relations used:
  - `H4_bgn_plant_rel`
  - `H4_mty_plant_rel`
  - `H4_cno_plant_rel`
  - `H4_swn_plant_rel`
  - `H4_bbk_plant_rel`
  - `H4_hab_plant_rel`
- Property policies are smaller and more targeted than the current Python version

## Most Important Mismatches Vs Python

1. Python is handcrafting raw REST payloads, but the working EXE uses Siemens' official SOA client stack.
2. Python sends property policy to `Core-2007-09-DataManagement/setObjectPropertyPolicy`; the working EXE uses `SessionService.SetObjectPropertyPolicy(...)`.
3. Python tries many login body formats; the working EXE uses one login path through the client library with `user/password/group/role/locale/discriminator`.
4. Python tries multiple saved-query discovery methods and loose query-name heuristics; the working EXE uses exact `FindSavedQueries` calls for `Item...` and `Item Revision...`.
5. Python uses one generic query-name list for ECN, PR, and item searches; the working EXE uses distinct exact queries for item vs item revision.
6. Python does not apply the same secondary object type filter for `CMHasSolutionItem`.

## Best Technical Conclusion

The safest path is to stop reverse-engineering Teamcenter JSON by hand and instead build a thin bridge around the official Teamcenter .NET assemblies used by `CHECKSHEET.exe`.

This can be done by either:

- calling the .NET DLLs directly from Python with `pythonnet`, or
- building a small x86 .NET helper that exposes the exact working operations to Python

The .NET helper approach is likely the lowest-risk option because:

- `CHECKSHEET.exe` is x86
- the official client libraries are already proven in this environment
- the current Python raw REST path is diverging from the real service usage
