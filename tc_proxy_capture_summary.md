# Teamcenter Proxy Capture — Call Inventory Report

> **Source file:** `C:\PYTHON\VPM-TC\1\tc_proxy_capture.jsonl`
> **Captured by:** `tc_http_capture_proxy.py` running on `http://127.0.0.1:8899/tc`
> **Generated from:** One full CHECKSHEET.exe session (81 item lookups)

---

## 1. Overall Statistics

| Metric | Value |
|---|---|
| Total records captured | **502** |
| HTTP methods seen | `POST` only |
| HTTP status codes seen | `200 OK` only |
| Unique endpoints hit | **8** |
| Records with partial errors in body | **81** (all from `expandGRMRelationsForPrimary`) |
| Records containing credential fields | **2** (login call only) |
| Records with `logCorrelationID` | **500** |

---

## 2. Endpoint Inventory

All calls go to `/tc/RestServices/…`

| # | Endpoint | Call Count | Purpose |
|---|---|---|---|
| 1 | `Core-2008-06-Session/login` | **1** | Authenticate — sends username + password, receives session cookies + User UID |
| 2 | `Core-2007-01-Session/getTCSessionInfo` | **1** | Retrieve server version, transient volume path, session flags |
| 3 | `Core-2011-06-Session/getTypeDescriptions` | **14** | Fetch type metadata (property descriptors, LOVs, class hierarchy) for ~14 TC types |
| 4 | `Core-2008-06-Session/setObjectPropertyPolicy` | **162** | Set which properties the server should return for each subsequent call (called once per item lookup, twice: before find + before GRM expand) |
| 5 | `Query-2010-04-SavedQuery/findSavedQueries` | **81** | Look up saved query UIDs by name (`Item Revision…` / `Item…`) |
| 6 | `Query-2008-06-SavedQuery/executeSavedQueries` | **81** | Run the saved query with search criteria; returns matching Item/ItemRevision UIDs |
| 7 | `Core-2007-09-DataManagement/loadObjects` | **81** | Load full object data for UIDs returned by the query |
| 8 | `Core-2007-09-DataManagement/expandGRMRelationsForPrimary` | **81** | Expand `H4_mty_plant_rel` GRM relation on each revision — retrieves plant/MTY associations |

**Total: 502 calls / 8 unique endpoints**

---

## 3. Data Captured Per Record

Each JSONL record is a JSON object with the following top-level keys:

```
{
  "timestamp":   ISO-8601 string,
  "method":      "POST",
  "path":        "/tc/RestServices/<service>/<operation>",
  "request": {
    "headers":   { "<HeaderName>": "<value>", … },
    "body":      "<XML wrapped in RequestEnvelope bodystring CDATA>"
  },
  "response": {
    "status":    200,
    "headers":   { … },
    "body":      "<raw XML response>"
  }
}
```

### 3a. Request Body Format

All requests use the TC XML REST envelope:

```xml
<RequestEnvelope>
  <state>…session/policy token…</state>
  <bodystring><![CDATA[
    <?xml version="1.0" encoding="utf-8"?>
    <OperationInput xmlns="…">
      …operation-specific XML payload…
    </OperationInput>
  ]]></bodystring>
</RequestEnvelope>
```

### 3b. Per-Endpoint Data Shape

#### `login`
- **Request:** `username`, `password` (plaintext), `locale`, `group`, `role`, `sessionDiscriminator`
- **Response:** `User` UID, `GroupMember` UID, session discriminator, partial errors block

#### `getTCSessionInfo`
- **Request:** Empty input element
- **Response:** `serverVersion` (e.g. `23120.0004.0000.2024050800`), `transientVolRootDir`, `isInV7Mode`, `moduleNumber`, `bypass`, `jounaling` flags

#### `getTypeDescriptions` (14 calls)
- **Request:** List of type names (e.g. `User`, `Group`, `Role`, `H4_Hussmann_Item`, `H4_Hussmann_ItemRevision`, `H4_ECN_NPDRevision`, `ReleaseStatus`, `ImanQuery`, `Form`, `UnitOfMeasure`, …)
- **Response:** Full type schemas including:
  - Property descriptors (name, type, display name, cardinality)
  - LOV (List of Values) references
  - Class hierarchy (`parentTypeName`)
  - `typeUid`, `uid`, `className`

#### `setObjectPropertyPolicy` (162 calls)
- **Request:** List of TC type names + property names to include in subsequent responses (controls what fields `loadObjects` and `expandGRM…` return)
- **Response:** Policy token string (e.g. `Dynamic:69231-1`) used for session state

#### `findSavedQueries` (81 calls)
- **Request:** Query name string — either `Item Revision...` or `Item...`
- **Response:** UID of the matching `ImanQuery` object

#### `executeSavedQueries` (81 calls)
- **Request:** Query UID + search criteria entries (key/value pairs, e.g. `item_id = <value>`)
- **Response:** Array of matching `objectUIDS` (Item Revision UIDs)

#### `loadObjects` (81 calls)
- **Request:** One or more TC UIDs
- **Response:** Full object graphs for the requested UIDs, including all properties set by the current policy. Properties observed in responses:

| Property | Description |
|---|---|
| `item_id` | Part number / ECN number |
| `item_revision_id` | Revision identifier (e.g. A, B, 00) |
| `object_name` | Display name |
| `object_desc` | Description text |
| `object_type` | TC type name |
| `h4_Nomenclature` | Case nomenclature code (e.g. RLN4MA) |
| `h4_PLM_Revision` | Internal PLM revision |
| `h4_Hussmann_Item_Type` | Custom Hussmann classification |
| `h4_Plant` | Plant code(s) |
| `h4_ECN_Number` | ECN reference number |
| `h4_Product_Line` | Product line identifier |
| `h4_Product_Family` | Product family |
| `h4_Model_Group` | Model group |
| `h4_High_Level_Category` | Category classification |
| `h4_Sub_Category` | Sub-category |
| `h4_Finish_Code` | Finish code |
| `h4_Finish_Color` | Finish color |
| `h4_BOM_Option_Code` | BOM option code |
| `h4_EAU` | Estimated annual usage |
| `h4_Risk_Level` | Risk level flag |
| `h4_Cross_Ref_Part_No` | Cross-reference part number |
| `h4_MAPICS_Item_Type` | MAPICS item type |
| `h4_Template_Name` | Template name |
| `h4_Plant_Coded` | Coded plant identifier |
| `h4_BBK_Source` / `h4_BGN_Source` / `h4_CNO_Source` / `h4_HAB_Source` / `h4_MTY_Source` / `h4_SWN_Source` | Source identifiers per plant type |
| `process_stage` | Process/lifecycle stage |
| `release_status_list` | List of release statuses attached |
| `items_tag` | UID of the parent `Item` |
| `uom_tag` | Unit of measure UID |
| `owning_user` | Owner user ID |
| `effectivity_text` | Effectivity expression |

**TC object types seen in `loadObjects` responses:**

| Type | Count |
|---|---|
| `H4_Hussmann_ItemRevision` | 321 |
| `ReleaseStatus` | 296 |
| `ImanQuery` | 163 |
| `Form` | 163 |
| `H4_Hussmann_Item` | 161 |
| `User` | 87 |
| `UnitOfMeasure` | 81 |
| `ListOfValuesString` | 10 |
| `Fnd0ListOfValuesDynamic` | 8 |
| `Folder` | 7 |
| `H4_ECN_NPDRevision` | 4 |
| `Group`, `Role`, `Person`, `GroupMember`, `ImanVolume`, … | < 10 each |

#### `expandGRMRelationsForPrimary` (81 calls)
- **Request:** Primary object UIDs, relation type filter (`H4_mty_plant_rel`), `otherSideObjectTypes`
- **Response:** For each input UID — related objects on the `H4_mty_plant_rel` relation (plant-MTY associations). Response includes `inputObject`, `relationshipData`, and related `otherSideObject` entries.
- **Note:** 81 responses contain `partialErrors` (non-fatal; returned alongside valid data)

**Relations expanded:**

| Relation Name | Count |
|---|---|
| `H4_mty_plant_rel` | 80 |
| `CMHasSolutionItem` | 1 |

---

## 4. Data Quality Findings

| Finding | Detail |
|---|---|
| All HTTP methods | `POST` — no `GET`, `PUT`, or `DELETE` calls |
| All HTTP statuses | `200 OK` — no 4xx or 5xx at transport level |
| Partial errors in body | 81 records have `<ns0:errorValues>` inside a `200` response (TC's way of returning non-fatal errors alongside results) |
| Response XML format | All responses are raw XML (no `ResponseEnvelope` wrapper) |
| Request XML format | All requests use `RequestEnvelope`/`bodystring`/`CDATA` wrapping |
| Session cookie scope | `Cookie` header present on 7 distinct endpoint paths (session maintained throughout) |

---

## 5. BOM Endpoint Status — CRITICAL GAP

| BOM Endpoint | Present in Capture? |
|---|---|
| `Cad-2007-01-StructureManagement/createBOMWindows` | **NOT CAPTURED** |
| `Cad-2007-01-StructureManagement/expandPSOneLevel` | **NOT CAPTURED** |
| `Cad-2007-01-StructureManagement/closeWindow` | **NOT CAPTURED** |

### What this means

CHECKSHEET.exe does **not** use `createBOMWindows` / `expandPSOneLevel` to build its BOM display. Instead it uses the **GRM expansion path**:

1. `findSavedQueries` → finds `Item Revision…` query
2. `executeSavedQueries` → searches by `item_id` → gets revision UIDs
3. `loadObjects` → loads full object properties for those revisions
4. `expandGRMRelationsForPrimary` with `H4_mty_plant_rel` → gets plant/MTY relationships

This means the Check Sheet application is **not traversing a structural BOM tree at all**. It is querying Item Revisions by search criteria and expanding a custom GRM relation (`H4_mty_plant_rel`) to obtain plant-level data — not part-level BOM children.

---

## 6. Security / Sensitivity Notes

> **Do not share this capture file externally without redacting the following.**

| Sensitive Field | Records | Risk |
|---|---|---|
| `password` | 2 | Plaintext TC password in login request body — **HIGH** |
| `username` | 2 | Plaintext TC username in login request body — **HIGH** |
| `sessionDiscriminator` | 1 | Session token — **MEDIUM** |
| `logCorrelationID` | 500 | Internal correlation IDs — LOW |
| Session cookies | Throughout | `Cookie` headers carry the active TC session — **MEDIUM** |
| TC UIDs | Throughout | Internal TC object UIDs are present in requests and responses |

---

## 7. Implications for BOM Retrieval in tc_connector.py

Given the findings above, the correct strategy to retrieve a full structural BOM is:

1. Use the **`Cad-*` or `StructureManagement` SOA services** (`createBOMWindows`, `expandPSOneLevel`) — these are **not** what CHECKSHEET.exe uses, but they are the standard TC BOM traversal path.
2. Alternatively, use `expandGRMRelationsForPrimary` with `IMAN_master_form` / `IMAN_specification` / `IMAN_structure` relation types to walk the structure if BOM Window services continue to fail.
3. The `H4_mty_plant_rel` relation gives **plant-to-revision mapping**, not BOM children. This is the data CHECKSHEET.exe is actually collecting (plant associations per item revision).

---

*Report generated: 2026-03-21*
*Capture file: `tc_proxy_capture.jsonl` — 502 records*
