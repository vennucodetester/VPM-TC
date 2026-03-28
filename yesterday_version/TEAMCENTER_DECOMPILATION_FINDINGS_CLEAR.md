# Teamcenter Decompilation Findings

## Purpose

This document summarizes what was proven by decompiling the working `CHECKSHEET.exe` and the main Teamcenter .NET assemblies that ship with it.

The goal is to answer one question clearly:

**Why does the working EXE connect successfully while the Python Teamcenter client struggles?**

## What Was Decompiled

### Main EXE

- `C:\Users\silam\OneDrive\Documents\VPM-WORKING\Check Sheet 1.0.3.5\CHECKSHEET.exe`

### Decompiled output

- `C:\Users\silam\OneDrive\Documents\VPM-WORKING\decompiled_checksheet\CHECKSHEET`
- `C:\Users\silam\OneDrive\Documents\VPM-WORKING\decompiled_checksheet\TcSoaClient`
- `C:\Users\silam\OneDrive\Documents\VPM-WORKING\decompiled_checksheet\TcSoaCoreStrong`
- `C:\Users\silam\OneDrive\Documents\VPM-WORKING\decompiled_checksheet\TcSoaQueryStrong`
- `C:\Users\silam\OneDrive\Documents\VPM-WORKING\decompiled_checksheet\TcSoaCadStrong`
- `C:\Users\silam\OneDrive\Documents\VPM-WORKING\decompiled_checksheet\TcSoaCommon`
- `C:\Users\silam\OneDrive\Documents\VPM-WORKING\decompiled_checksheet\TcSoaStrongModel`

### Key files inspected

- `decompiled_checksheet/CHECKSHEET/Rapid_Check/TCFunctions.cs`
- `decompiled_checksheet/CHECKSHEET/Rapid_Check/Tc_CredentialManager.cs`
- `decompiled_checksheet/CHECKSHEET/Rapid_Check/Tc_ExceptionHandler.cs`
- `decompiled_checksheet/CHECKSHEET/Rapid_Check/CheckSheetFunctios.cs`
- `decompiled_checksheet/CHECKSHEET/Rapid_Check/Declarations.cs`
- `decompiled_checksheet/TcSoaClient/Teamcenter/Soa/Client/Connection.cs`
- `decompiled_checksheet/TcSoaCoreStrong/Teamcenter/Services/Strong/Core/SessionRestBindingStub.cs`
- `decompiled_checksheet/TcSoaQueryStrong/Teamcenter/Services/Strong/Query/SavedQueryRestBindingStub.cs`
- `decompiled_checksheet/TcSoaCadStrong/Teamcenter/Services/Strong/Cad/StructureManagementRestBindingStub.cs`

## High Confidence Findings

### 1. The working EXE does not use a hand-written HTTP client

It uses Siemens' official Teamcenter .NET SOA client libraries:

- `TcSoaClient.dll`
- `TcSoaCoreStrong.dll`
- `TcSoaQueryStrong.dll`
- `TcSoaCadStrong.dll`
- `TcSoaStrongModel.dll`

This is the single most important finding.

The current Python implementation is trying to manually reproduce behavior that the EXE gets from Siemens' client stack.

### 2. The EXE uses REST + HTTP through the official client connection object

The decompiled login code shows:

- `Teamcenter.Soa.Client.Connection(...)`
- `SoaConstants.REST`
- `SoaConstants.HTTP`
- `CookieCollection`
- custom credential manager

That means the EXE is not using a random private transport. It is using Teamcenter REST binding, but through the official client layer.

### 3. Login is performed through `SessionService.Login(...)`

The working EXE calls:

- `SessionService.getService(connection)`
- `service.Login(user, password, group, role, "", discriminator)`

The credential manager returns:

- username
- password
- group = `""`
- role = `""`
- discriminator = `"SoaAppX"`

### 4. The EXE code does not explicitly call `LoginSSO`

Important nuance:

- `Teamcenter_SSO64.dll` exists in the deployment
- the Teamcenter client libraries support `LoginSSO`
- but the app code we decompiled calls normal `Login(...)`, not `LoginSSO(...)`

So from the application layer, the working client appears to be using standard credentials, not an explicit SSO login path.

### 5. Property policy is set through `SessionService`, not DataManagement

The working EXE calls:

- `SessionService.SetObjectPropertyPolicy(...)`

This is a major mismatch with the Python version, which currently posts to:

- `Core-2007-09-DataManagement/setObjectPropertyPolicy`

This is one of the strongest concrete reasons the Python code is not matching the working implementation.

### 6. Saved query discovery is exact, not heuristic

The EXE does not try many possible query names.

It does this:

1. `FindSavedQueries(...)`
2. pass the exact query name
3. if found, use that query object
4. call `ExecuteSavedQueries(...)`
5. call `DataManagementService.LoadObjects(...)` on returned UIDs

That means the working client is not:

- pulling every saved query first
- heuristically picking one
- trying broad wildcard behavior first

### 7. Exact query names used by the working EXE

The decompiled code proves:

- ECN revision lookup uses `Item Revision...`
- item lookup uses `Item...`

It does **not** prove that your Python fallback query list is the best strategy.

In fact, the EXE suggests the opposite:

- use exact query names
- use the exact entry fields that the working app already uses

### 8. Exact query entry fields used by the EXE

For item revision lookup:

- entries = `["Item ID"]`

For item lookup:

- entries = `["Type", "Item ID"]`

That means the Python version is currently too generic in its query handling.

### 9. Exact ECN relation flow used by the EXE

The working EXE does this:

1. find ECN revision
2. expand relation `CMHasSolutionItem`
3. filter secondary object type to `H4_Hussmann_ItemRevision`
4. read properties from those returned solution items

The current Python version uses the same relation name, but does not mirror the full behavior closely enough.

### 10. Exact plant form relation flow used by the EXE

The EXE also follows plant-specific form relations:

- `H4_bgn_plant_rel`
- `H4_mty_plant_rel`
- `H4_cno_plant_rel`
- `H4_swn_plant_rel`
- `H4_bbk_plant_rel`
- `H4_hab_plant_rel`

This confirms that the working app uses a specific Hussmann object model, not just generic Teamcenter objects.

### 11. BOM behavior is also implemented through official Teamcenter CAD services

The decompiled code proves the working stack supports:

- `GetRevisionRules()`
- `CreateBOMWindows(...)`
- `ExpandPSOneLevel(...)`

So login, query, and BOM are all inside the official Teamcenter service layer.

## What This Means For The Current Python Code

## Main conclusion

The Python connector is not failing because of one typo.

It is failing because it is trying to manually reproduce an official Teamcenter client workflow while diverging in several critical places.

## Concrete mismatches

### 1. Login path mismatch

Python:

- tries multiple hand-built JSON login bodies
- guesses service shapes
- interprets raw responses manually

Working EXE:

- creates official Teamcenter connection object
- calls `SessionService.Login(...)`

### 2. Property policy mismatch

Python:

- sends policy through DataManagement REST

Working EXE:

- sends policy through `SessionService.SetObjectPropertyPolicy(...)`

### 3. Query discovery mismatch

Python:

- tries multiple discovery methods
- uses wildcard/fallback behavior
- uses heuristic matching across several query names

Working EXE:

- uses exact `FindSavedQueries(...)`
- passes exact query names

### 4. Query usage mismatch

Python:

- reuses a broad query-name list for ECN, PR, and item searches

Working EXE:

- uses a specific item revision query for ECN-related work
- uses a specific item query for item lookup

### 5. Relation/filter mismatch

Python:

- expands relation but does not fully mirror the exact object-type filtering logic

Working EXE:

- uses exact `CMHasSolutionItem`
- filters to `H4_Hussmann_ItemRevision`

## What We Can Say About SSO

## What is proven

- `Teamcenter_SSO64.dll` exists
- Teamcenter client assemblies support `LoginSSO`

## What is not proven

- the app code itself using `LoginSSO`

## Current best reading

The working EXE appears to use standard Teamcenter credential login from the application layer.

That said, the Siemens client stack may still be handling lower-level details that our Python raw HTTP client does not reproduce.

## Can The Entire EXE Be Rebuilt In Python?

## Technically possible in theory

Yes, much of the business logic is now readable.

## Low-risk? No

Not as a pure raw-REST rewrite.

That path is exactly what has already been consuming time.

## What is realistic

If the goal is to reproduce the Teamcenter behavior reliably, the lowest-risk path is:

1. use the official Teamcenter .NET assemblies directly
2. expose only the needed operations to Python

## Best implementation choices

### Best option

Build a small .NET helper or bridge that wraps the proven Teamcenter calls:

- connect/login
- find ECN
- find item revision
- get solution items
- get plant forms
- create BOM window
- expand BOM one level

Then call that helper from Python.

### Possible option

Use `pythonnet` to call the Teamcenter .NET assemblies directly from Python.

### Highest-risk option

Keep handcrafting raw Teamcenter REST payloads until they happen to match the Siemens client behavior.

This is not the recommended route.

## Final Recommendation

If the target is:

- reliable Teamcenter login
- reliable ECN search
- reliable BOM expansion

then we should stop treating `tc_connector.py` as a raw-REST reverse-engineering project.

We now have enough decompiled evidence to justify a new direction:

**Use the official Teamcenter .NET client path as the implementation backbone.**

That is the clearest finding from the decompilation work.
