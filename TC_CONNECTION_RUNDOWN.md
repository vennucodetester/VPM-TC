# Teamcenter SOA Connection - Full Rundown

## Overview

VPM needs to connect directly to Teamcenter (TC) to pull ECN + BOM data instead of relying on manual Excel exports. A working .NET app (Check Sheet 1.0.3.5) was used as a reference to understand how TC SOA works.

---

## TC Server Details

| Setting | Value |
|---------|-------|
| **TC Base URL** | `http://STLV-HSMWEBTCP1:8080/tc` |
| **SSO Server** | `http://STLV-HSMWEBTCP1.internal.hussmann.com:8086/tcssols` |
| **SSO App ID** | `Teamcenter` |
| **API Binding** | `JsonRestServices` (HTTP POST, JSON body) |
| **Endpoint Pattern** | `POST {baseUrl}/JsonRestServices/{namespace}/{operation}` |

---

## How TC SOA Works

Teamcenter exposes its API via **Service Oriented Architecture (SOA)**. Every call is an HTTP POST with a JSON body structured as:

```json
{
    "header": {
        "state": {
            "clientVersion": "14000.1.0",
            "clientId": "VPM-Python",
            "logCorrelationId": "",
            "stateless": false
        },
        "policy": {}
    },
    "body": { ...operation-specific data... }
}
```

The response is always JSON. Session state is maintained via **JSESSIONID cookie** (managed automatically by `requests.Session()` in Python).

---

## Bug Timeline - Login Issue

### Bug 1: Silent Login Failure (field name)

**Original code:**
```json
{
    "credentials": {
        "user": "ccbefb",
        "password": "...",
        "group": "",
        "role": "",
        "locale": "",
        "discriminator": "VPM"
    }
}
```

**TC Response (HTTP 200):**
```json
{
    ".QName": "...InvalidCredentialsException",
    "ssoServerURL": "http://STLV-HSMWEBTCP1.internal.hussmann.com:8086/tcssols",
    "ssoAppID": "Teamcenter",
    "code": 1007,
    "message": "No User Id Specified."
}
```

**Problem:** TC returned HTTP 200 with an error JSON body. Our code only checked HTTP status codes, not the `.QName` field. It set `is_connected = True` and moved on. Every subsequent API call then failed with `"User does not have a valid session."` because the login never actually succeeded.

**Root cause theory at this point:** We assumed the field name `"user"` was wrong and should be `"userid"`. Changed it. Still failed with the same error.

### Bug 2: The `descrimator` typo crash

After adding multiple login format attempts, Format #1 included a `"descrimator"` field (typo found in .NET DLLs). This caused TC's JSON parser to crash:

**TC Response (HTTP 500):**
```json
{
    ".QName": "...InternalServerException",
    "messages": [
        {"code": 214022, "message": "An error has occurred during the JSON parsing."},
        {"code": 214004, "message": "Please see the log file 'tcserver.exe8164554d.syslog'..."}
    ]
}
```

**Problem:** Our error detection only checked for `InvalidCredentials` and `InvalidUser` in `.QName`. It didn't check for `InternalServerException`, so HTTP 500 with a JSON body was treated as success. The remaining formats (which were correct) were never tried.

### The Actual Fix (Current State)

1. **Error detection now catches ANY `.QName` containing "Exception"** - not just specific exception types
2. **Removed the `descrimator` field** that crashed TC's JSON parser
3. **The field name `"user"` was correct all along** - the real problem was that the login was never properly attempted due to error handling bugs
4. **Three formats are tried in order:**

**Format 1 (Standard 2008-06):**
```json
{
    "credentials": {
        "user": "username",
        "password": "password",
        "group": "",
        "role": "",
        "locale": "",
        "discriminator": "SoaAppX"
    }
}
```

**Format 2 (Flat 2006-03):**
```json
{
    "user": "username",
    "password": "password",
    "group": "",
    "role": "",
    "locale": "",
    "discriminator": "SoaAppX"
}
```

**Format 3 (sessionDiscriminator at top level):**
```json
{
    "credentials": {
        "user": "username",
        "password": "password",
        "group": "",
        "role": "",
        "locale": ""
    },
    "sessionDiscriminator": "SoaAppX"
}
```

---

## Saved Query Issue

After login, VPM needs to search TC for items (ECNs, PRs, parts). TC uses **Saved Queries** - named query templates stored in TC. You find a query by name, get its UID, then execute it with parameters.

### What We Tried

Three methods to discover saved queries:
1. `Query-2007-09-SavedQuery/getSavedQueries` - returns all queries (failed with HTTP 500 when login wasn't working)
2. `Query-2010-04-SavedQuery/describeSavedQueries` - another discovery method (same failure)
3. `Query-2010-04-SavedQuery/findSavedQueries` - search by name

Query names tried: `__Item`, `Item...`, `__WEB_find_Items`, `Item Revision...`, `__Item_Revision`, `__WEB_find_item_revision`

### Why They All Failed

**Every query call returned empty results because the session was never authenticated.** The login bug meant there was no valid session, so TC returned empty `modelObjects: {}` for every query search. The saved query names may or may not be correct - we can't know until login actually works.

---

## What the Check Sheet .NET App Taught Us

### From CHECKSHEET.exe.config
- TC URL: `http://STLV-HSMWEBTCP1:8080/tc`
- App discriminator: `SoaAppX`

### From .NET DLLs (TcSoaClient.dll, TcSoaCommon.dll, TcSoaCoreStrong.dll)
- Login namespace: `Core-2008-06-Session`
- Login method: `login`
- Logout method: `Logout` (capital L in .NET, lowercase in JSON REST)
- Credential fields: `User`, `Password`, `Group`, `Role`, `Locale`, `Descrimator` (typo in .NET)
- Session discriminator: `SoaAppX` (used to distinguish multiple client sessions)
- Credential type: `CLIENT_CREDENTIAL_TYPE_STD` (standard, not SSO)
- The .NET DLLs handle SSO negotiation automatically, but the app uses standard credentials

### Key TC SOA Services Used by Check Sheet
| Service | Purpose |
|---------|---------|
| `Core-2008-06-Session/login` | Authenticate |
| `Core-2006-03-Session/logout` | End session |
| `Query-2007-09-SavedQuery/getSavedQueries` | List all saved queries |
| `Query-2010-04-SavedQuery/findSavedQueries` | Find query by name |
| `Query-2008-06-SavedQuery/executeSavedQueries` | Run a query |
| `Core-2007-09-DataManagement/getProperties` | Get object properties |
| `Core-2007-09-DataManagement/expandGRMRelationsForPrimary` | Follow relationships (e.g., ECN -> solution items) |
| `Cad-2007-01-StructureManagement/createBOMWindows` | Open BOM structure |
| `Cad-2007-01-StructureManagement/expandPSOneLevel` | Expand one level of BOM |

### ECN Relationship Chain
```
ECN (H4_ECN_CAPRevision, H4_ECN_CODRevision, etc.)
  |-- CMHasSolutionItem --> Item Revisions (parts being changed)
      |-- BOM children (via BOM window expansion)
      |-- Plant forms (H4_bbk_plant_rel, H4_bgn_plant_rel, etc.)
```

### ECN Types in This TC Environment
- `H4_ECN_CAPRevision`
- `H4_ECN_CODRevision`
- `H4_ECN_NPDRevision`
- `H4_ECN_VAVERevision`

### Custom Hussmann Properties (h4_*)
40+ custom properties on items/revisions:
`h4_BOM_Option_Code`, `h4_Hussmann_Item_Type`, `h4_High_Level_Category`, `h4_Sub_Category`, `h4_Product_Family`, `h4_Product_Line`, `h4_Model_Group`, `h4_Nomenclature`, `h4_Finish_Code`, `h4_Finish_Color`, `h4_EAU`, `h4_PLM_Revision`, `h4_Risk_Level`, `h4_ECN_Number`, `h4_Cross_Ref_Part_No`, `h4_MAPICS_Item_Type`, `h4_US_Baan_Item_Type`, `h4_Plant`, `h4_Plant_Coded`, `h4_Plant_Template`, `h4_Template_Name`, `h4_Master_Template`

---

## Debug Logging

A debug log file is created at:
```
C:\Users\silam\OneDrive\Documents\VPM-WORKING\tc_debug.log
```

This file is overwritten each time the app starts. It logs:
- Every HTTP POST request (URL + body)
- Every HTTP response (status code + first 3000 chars of body)
- Response JSON keys
- Login attempt results
- Saved query discovery steps
- All errors with full details

---

## What's Still Unknown (Pending Login Success)

1. **Which login format actually works** - need a successful login to determine
2. **What saved query names exist** in this TC environment
3. **What entry field names** the saved queries expect (e.g., `"Item ID"` vs `"item_id"` vs `"ItemID"`)
4. **Workflow task names** - TC EPMTask names that map to VPM workflow columns (e.g., "Review", "Approve", etc.)
5. **Whether SSO is required** - the TC server returns SSO URLs in every response, which may mean direct login is blocked and SSO token-based auth is needed instead

---

## Files Modified

| File | Changes |
|------|---------|
| `tc_connector.py` | TC SOA client, login dialog, search dialog, data fetcher (~750 lines) |
| `main.py` | ECN Data dropdown menu (Excel + TC options), `connect_to_teamcenter()` method |
| `advanced_excel_importer.py` | `load_from_tc_data()` method on `EcnDashboardEngine` |

---

## Known Remaining Bug

**QMenu UnboundLocalError in main.py:** A `from PyQt6.QtWidgets import QMenu` local import was added inside `create_toolbar()` for the ECN dropdown menu. This causes Python to treat `QMenu` as a local variable throughout the entire function, breaking the earlier usage of `QMenu` at line ~4608 for the Import menu. Fix: remove the local import (QMenu should already be imported at module level, or add it there).
