# CHECKSHEET.exe - Complete Technical Reference

This document contains EVERYTHING extracted from the decompiled CHECKSHEET.exe.
Every URL, every parameter, every constant, every property name, every flow - verified from source code.

---

## 1. APPLICATION IDENTITY

- **Tool Name**: `CHECKSHEET-TC10`
- **Framework**: .NET Framework 4.5, VB.NET compiled (WinForms)
- **Architecture**: x86
- **Entry point**: `Declarations.main()` -> `Application.Run(new frmMain())`

---

## 2. TEAMCENTER CONNECTION - EXACT DETAILS

### 2.1 Server URL (from config)
```
http://STLV-HSMWEBTCP1:8080/tc
```
- User types this into the `txtTC_Url` textbox
- The Connection class appends `/` if missing

### 2.2 Connection Constructor Call
```csharp
objCon = new Connection(Url, new CookieCollection(), tc_CredentialManager, SoaConstants.REST, SoaConstants.HTTP, useCompression: false);
```

Parameters:
| Parameter | Value | Notes |
|-----------|-------|-------|
| hostPath | User-entered URL (e.g. `http://STLV-HSMWEBTCP1:8080/tc`) | Trailing `/` added if missing |
| cookieCollection | `new CookieCollection()` | Empty, fresh cookies |
| credentialManager | `Tc_CredentialManager` instance | Custom class, see below |
| binding | `"REST"` | `SoaConstants.REST` |
| protocol | `"HTTP"` | `SoaConstants.HTTP` |
| useCompression | `false` | Explicitly disabled |

### 2.3 What the Connection constructor does internally
1. Appends `/` to hostPath if needed -> `http://STLV-HSMWEBTCP1:8080/tc/`
2. Creates `HttpTransport(this)` (because protocol = "HTTP")
3. Creates `XmlRestSender(this, sessionManager, transport, notifier)` as the Sender
4. Creates `SessionManager(credentialManager, this)`
5. Creates `ModelManagerImpl(this, null)`

### 2.4 ExceptionHandler
```csharp
objCon.ExceptionHandler = new Tc_ExceptionHandler();
```
- The exception handler does nothing (all methods are empty stubs)

---

## 3. URL PATTERN FOR ALL REST CALLS

### 3.1 URL Construction (from HttpTransport.ExecuteRequest)
```
{hostPath}{servletURI}/{service}/{operation}
```

Where:
- `hostPath` = `http://STLV-HSMWEBTCP1:8080/tc/`
- `servletURI` = `"RestServices"` (from `SoaConstants.REST_SERVICES`)
- `service` = port name like `"Core-2008-06-Session"`
- `operation` = method name with first char lowercased like `"login"`

### 3.2 Operation name transformation (from XmlRestSender.Invoke)
```csharp
// First character is lowercased
string operation2 = new string(operation[0], 1).ToLower() + operation.Substring(1);
```
So `"Login"` becomes `"login"`, `"SetObjectPropertyPolicy"` becomes `"setObjectPropertyPolicy"`, etc.

### 3.3 HTTP Method
Always `POST` (from `httpClient.MakeWebRequest(uRL, HttpMethods.POST, requestBytes)`)

### 3.4 Request Body Format
XML serialized using `XmlBindingUtils.Serialize()`, wrapped in a session envelope by `sessionManager.ConstructRequestEnvelope()`

---

## 4. CREDENTIAL MANAGER - EXACT VALUES

```csharp
public class Tc_CredentialManager : CredentialManager
{
    public int CredentialType => 0;  // NOT SSO (SSO would be different)

    // Returns: [username, password, "", "", "SoaAppX"]
    public string[] PromptForCredentials(string name, string password)
    {
        return new string[5] { name, password, group, role, discriminator };
    }
}
```

| Field | Value |
|-------|-------|
| group | `""` (empty string) |
| role | `""` (empty string) |
| discriminator | `"SoaAppX"` |
| CredentialType | `0` (standard credentials, NOT SSO) |

---

## 5. LOGIN - EXACT REST CALL

### 5.1 Service port name
```
Core-2008-06-Session
```

### 5.2 Operation
```
login
```

### 5.3 Full URL
```
http://STLV-HSMWEBTCP1:8080/tc/RestServices/Core-2008-06-Session/login
```

### 5.4 Login Input Fields (XML body)
```xml
<LoginInput>
    <Username>{user}</Username>
    <Password>{password}</Password>
    <Group></Group>
    <Role></Role>
    <Locale></Locale>
    <SessionDiscriminator>SoaAppX</SessionDiscriminator>
</LoginInput>
```

### 5.5 Login Response Contains
- `ServiceData`
- `User` (ModelObject)
- `GroupMember` (ModelObject)

---

## 6. LOGOUT - EXACT REST CALL

### Full URL
```
http://STLV-HSMWEBTCP1:8080/tc/RestServices/Core-2006-03-Session/logout
```

---

## 7. PROPERTY POLICIES - ALL 6 DISTINCT POLICIES

The EXE sets property policy through `SessionService.SetObjectPropertyPolicy()`, which calls:
```
POST http://.../tc/RestServices/Core-2008-06-Session/setObjectPropertyPolicy
```

### 7.1 ECN Policy
- Type: dynamically determined (see ECN type mapping below)
- Properties (9):
```
["item_id", "object_name", "object_desc", "item_revision_id", "items_tag", "analyst_user_id", "owning_user", "owning_group", "project_ids"]
```

### 7.2 Item Policy
- Type: `"H4_Hussmann_Item"`
- Properties (8):
```
["item_id", "h4_Product_Family", "h4_Model_Group", "h4_Product_Line", "analyst_user_id", "owning_user", "uom_tag", "h4_Hussmann_Item_Type"]
```

### 7.3 Item Revision Policy
- Type: `"H4_Hussmann_ItemRevision"`
- Properties (7):
```
["item_id", "object_name", "object_desc", "item_revision_id", "items_tag", "owning_group", "h4_Hussmann_Item_Type"]
```

### 7.4 CheckSheet Policy
- Type: `"H4_Hussmann_ItemRevision"`
- Properties (36):
```
["item_id", "object_name", "item_revision_id", "items_tag", "object_desc", "h4_Nomenclature", "h4_BGN_Source", "h4_BBK_Source", "h4_CNO_Source", "h4_HAB_Source", "h4_MTY_Source", "h4_SWN_Source", "h4_BOM_Option_Code", "h4_ECN_Number", "h4_Finish_Code", "h4_Finish_Color", "h4_Risk_Level", "h4_High_Level_Category", "h4_Sub_Category", "h4_Hussmann_Item_Type", "h4_Template_Name", "h4_Plant", "object_type", "release_status_list", "effectivity_text", "h4_PLM_Revision", "process_stage", "", "h4_Plant_Template", "h4_Template_Name", "h4_Plant", "h4_Plant_Coded", "h4_Product_Family", "h4_Model_Group", "h4_Product_Line", "h4_EAU"]
```
Note: index 27 is empty string `""`, and some properties repeat (h4_Template_Name, h4_Plant appear twice)

### 7.5 BOM Policy
- Types: `"BOMLine"` + `"RevisionRule"`
- BOMLine properties (2): `["bl_item_item_id", "bl_rev_item_revision_id"]`
- RevisionRule properties (1): `["object_name"]`

### 7.6 Form Policy
- Type: dynamically set to the plant form type (e.g. `"H4_BGN_View_Form"`)
- Properties (7):
```
["h4_Plant_Template", "h4_Template_Name", "h4_Plant", "h4_Plant_Coded", "h4_MAPICS_Item_Type", "h4_US_Baan_Item_Type", "h4_Cross_Ref_Part_No"]
```

---

## 8. SAVED QUERIES - EXACT NAMES AND PARAMETERS

### 8.1 FindSavedQueries REST call
```
POST http://.../tc/RestServices/Query-2010-04-SavedQuery/findSavedQueries
```

Input:
```
FindSavedQueriesCriteriaInput:
    QueryNames = ["{exact query name}"]
    QueryType = 0
```

### 8.2 ExecuteSavedQueries REST call
```
POST http://.../tc/RestServices/Query-2008-06-SavedQuery/executeSavedQueries
```

### 8.3 Item Revision Query (used for ECN lookup)
- Query name: `"Item Revision..."`
- Entries: `["Item ID"]`
- Values: `["{ECN number}"]`
- MaxNumToReturn: `0` (unlimited)

### 8.4 Item Query (used for item lookup)
- Query name: `"Item..."`
- Entries: `["Type", "Item ID"]`
- Values: `["{item type}", "{item ID}"]`
- The item type passed is `"H4_Hussmann_Item"`

### 8.5 After query: LoadObjects
```
POST http://.../tc/RestServices/Core-2007-09-DataManagement/loadObjects
```
- Called with the `ObjectUIDS` from query results

---

## 9. ECN TYPE MAPPING - EXACT LOGIC

The ECN type is determined from the input ECN ID string:

```
If input contains "CAP"  -> "H4_ECN_CAPRevision"
If input contains "COD"  -> "H4_ECN_CODRevision"
If input contains "NPD"  -> "H4_ECN_NPDRevision"
If input contains "VAVE" -> "H4_ECN_VAVERevision"
Otherwise                -> "ChangeNoticeRevision"
```

Case-insensitive (uses `.ToUpper().Contains()`).

---

## 10. RELATION EXPANSION - EXACT CALLS

### 10.1 ExpandGRMRelationsForPrimary
```
POST http://.../tc/RestServices/Core-2007-06-DataManagement/expandGRMRelationsForPrimary
```

### 10.2 ECN Solution Items
- Relation: `"CMHasSolutionItem"`
- Secondary object type filter: `"H4_Hussmann_ItemRevision"`
- ExpItemRev: `false`
- ReturnRelations: `false`

### 10.3 Plant Form Relations
Each plant maps to a specific relation and form type:

| Plant | Relation Name | Form Type |
|-------|--------------|-----------|
| BRIDGETON | `H4_bgn_plant_rel` | `H4_BGN_View_Form` |
| MONTERREY | `H4_mty_plant_rel` | `H4_MTY_View_Form` |
| CHINO | `H4_cno_plant_rel` | `H4_CNO_View_Form` |
| SUWANEE | `H4_swn_plant_rel` | `H4_SWN_View_Form` |
| BOLINGBROOK | `H4_bbk_plant_rel` | `H4_BBK_View_Form` |
| AFTERMARKET | `H4_hab_plant_rel` | `H4_HAB_View_Form` |

---

## 11. PLANT SOURCE ATTRIBUTE MAPPING

| Plant | Source Attribute |
|-------|----------------|
| BRIDGETON | `h4_BGN_Source` |
| MONTERREY | `h4_MTY_Source` |
| CHINO | `h4_CNO_Source` |
| SUWANEE | `h4_SWN_Source` |
| BOLINGBROOK | `h4_BBK_Source` |
| AFTERMARKET | `h4_HAB_Source` |

---

## 12. PLANT FORM PROPERTY EXTRACTION

### BRIDGETON
- `h4_Plant_Template` -> column 28
- `h4_Template_Name` -> column 29
- `h4_Plant` -> column 30
- `h4_Plant_Coded` -> column 31

### MONTERREY
- `h4_MAPICS_Item_Type` -> column 28
- `h4_Plant` -> column 29
- `h4_Plant_Coded` -> column 30

### CHINO
- `h4_US_Baan_Item_Type` -> column 28

### SUWANEE
- `h4_US_Baan_Item_Type` -> column 28
- `h4_Cross_Ref_Part_No` -> column 29
- `h4_Plant_Coded` -> column 30

### BOLINGBROOK / AFTERMARKET
- No additional form properties extracted

---

## 13. BOM EXPANSION - EXACT FLOW

### 13.1 Revision Rule Name
```
"HSM_WIP_Latest_Production_Released"
```

### 13.2 BOM View Filter
Looks for `bom_view_tags` where `view_type` = `"PLM View"`

### 13.3 Exact sequence
1. Set BOM policy (BOMLine + RevisionRule)
2. Get StructureManagementService
3. Get `items_tag` from item revision -> get the Item object
4. Get `bom_view_tags` from Item -> find one with view_type = "PLM View"
5. Get revision rule by name `"HSM_WIP_Latest_Production_Released"`
6. `CreateBOMWindows` with Item, ItemRev, BomView, RevRule
7. `ExpandPSOneLevel` on the top BomLine, ExcludeFilter = "None", ExpItemRev = false
8. For each child: read `bl_rev_item_revision_id` and `bl_item_item_id`
9. Concatenate child item IDs with `"| "` separator

### 13.4 REST URLs
```
POST http://.../tc/RestServices/Cad-2007-01-StructureManagement/getRevisionRules
POST http://.../tc/RestServices/Cad-2007-01-StructureManagement/createBOMWindows
POST http://.../tc/RestServices/Cad-2007-01-StructureManagement/expandPSOneLevel
POST http://.../tc/RestServices/Core-2007-09-DataManagement/getProperties
```

---

## 14. CHECKSHEET GENERATION FLOW (Generate_CheckSheet)

Complete step-by-step:

1. **Set ECN policy** -> `setObjectPolicy_ECN(conn, ecnType)`
2. **Find ECN revision** -> `GetLatestItemRevision(conn, ecnType, ecnNumber)` using `"Item Revision..."` query with `["Item ID"]`
3. **Set CheckSheet policy** -> `setObjectPolicy_CheckSheet(conn)`
4. **Get solution items** -> `GetSecondaryObjects(conn, ecnRevision, "CMHasSolutionItem", "H4_Hussmann_ItemRevision")`
5. **For each solution item**:
   a. Read 20+ properties from the item revision
   b. Look up the parent Item via `GetLatestItem(conn, "H4_Hussmann_Item", itemId)` using `"Item..."` query with `["Type", "Item ID"]`
   c. Read properties from the Item (UOM, Product Family, Product Line, Model Group, Analyst, Owner)
   d. Get plant form properties via `UpdateFormProperty()` using plant-specific relation
   e. Validate all properties against rules from `DataBase-Report.XML`
   f. Color-code cells (Green=4=pass, Red=3=fail, Yellow=6=warning, White=0=neutral)

---

## 15. NETWORK FILE PATHS (from frmMain.Loc_Update)

| Site | Default ECN Folder Path |
|------|------------------------|
| Aftermarket | `\\internal.hussmann.com\sites\Apps\CAX\CaxData\projects\se\misc_ecos\_TC_ECNs` |
| Bolingbrook | `\\Mryv-engfs02\Caxdata\projects\se\misc_ecos\_TC_ECNs` |
| Bridgeton | `\\STLV-ENGFS01\Caxdata\projects\se\misc_ecos\_TC_ECNs` |
| Monterrey | `\\Mryv-engfs02\Caxdata\projects\se\misc_ecos\_TC_ECNs` |
| Chino | `\\internal.hussmann.com\sites\Apps\CAX\CaxData\projects\se\misc_ecos\_TC_ECNs` |
| Suwanee | `\\SWNV-ENGFS01\Caxdata\projects\se\misc_ecos\_TC_ECNs` |

Alternative path (CheckBox2): `\\internal.hussmann.com\Sites\Apps\CaxPublic\1_ECNs`

---

## 16. DATA VALIDATION RULES

The EXE loads `DataBase-Report.XML` from its startup directory to validate properties.
It maps Hussmann Item Types to validation categories:

| Hussmann Item Type | Category Key |
|-------------------|-------------|
| Case | Case |
| S-Kit | S-Kit |
| Material Bill - Case | MBC |
| Material Bill - ADD | MBA |
| Material Bill - ADD & Delete | MBAD |
| Material Bill - Retrofit | MBR |
| Module (or Assembly + not Welded subcategory) | Module |
| Assembly + Welded subcategory | Assembly-Make |
| Assembly + Buy source | Assembly-Buy |
| M-Kit | M-Kit |
| O-Kit or S3C O-Kit | O-Kit |
| Retrofit-Kit | Retrofit-Kit |
| Option-Class | Opt-Class |
| Part + Assemblies high-level cat | Part-Weld |
| Part/Assembly + Finished Tubes (or Part + Fabricated Parts + Copper Tubing) | Part-TUBE |
| Part + Buy source (not F&H, not Formed Metal Outsourced, not Aluminum) | Part-Buy |
| Part + Buy + Formed Metal Outsourced (or Aluminum) | Part-MBuy |
| Part/Assembly + COP source | Part-COP |
| Part/Assembly + Technical Publications | Part-COP |
| Part/Assembly + Reference MOA & Diagram | Part-MOA |
| Part/Assembly + Compressors | Part-Compr |
| Part/Assembly + Indirect Material | Part-IndMtl |
| Part/Assembly + Copper | Part-Cu |
| Generic BOM + Paint | PA-Paint |
| Part/Assembly + Fasteners & Hardware + Buy | Part-FH |
| Part/Assembly + Fabricated Parts (not CC DISCRETE template) | Part-GMP |
| Part/Assembly + Fabricated Parts + CC DISCRETE template | Part-SMT |
| Part/Assembly + Lightings subcategory | Part-Lightings |
| Generic BOM + nomenclature ends in "M" | M-Kit |
| Generic BOM + nomenclature ends in "O" | O-Kit |

For each category, the XML contains expected values for:
- High_Level_Category
- Subcategory
- Unit_of_Measure
- Product_Family
- Model_Group
- Product_Line
- Finish_Code
- Finish_Color
- Master_Template
- BOM_Option_Code
- Plant_Template
- Template_Name
- Source
- Nomenclature (for Module/Assembly/Part/Option-Class types)

---

## 17. EXCEL OUTPUT FORMAT

- File saved as: `CS_{ECN_ID}.xlsx`
- Saved to: `{FldrPath}\{ECN_ID}\CS_{ECN_ID}.xlsx` (creates subfolder if needed)
- Sheet name: `"Report"`
- Freeze panes at row 2
- AutoFilter on column B
- Color coding: 0=White, 3=Red, 4=Green, 6=Yellow

---

## 18. SOLIDEDGE INTEGRATION

The EXE also compares Teamcenter data with SolidEdge file properties:
- Uses `SolidEdgeFileProperties.dll` (COM interop)
- Uses `RevisionManager.dll` (COM interop)
- File types checked: `.DFT`, `.ASM`, `.PAR`, `.PSM`, `.CFG`, `.DWG`
- SE properties read: Document Number, Title, Revision, TCMIG-OSM, TCMIG-OSD, TCMIG-DVI, IR LOGO

---

## 19. ALL DLLs SHIPPED WITH THE EXE

| DLL | Purpose |
|-----|---------|
| TcSoaClient.dll (295K) | Core SOA client - Connection, Transport, Sender |
| TcSoaCommon.dll (220K) | Common types - SoaConstants, ObjectPropertyPolicy |
| TcSoaCoreStrong.dll (480K) | Session, DataManagement services |
| TcSoaCoreTypes.dll (541K) | Core schema types |
| TcSoaQueryStrong.dll (48K) | SavedQuery service |
| TcSoaQueryTypes.dll (65K) | Query schema types |
| TcSoaCadStrong.dll (220K) | StructureManagement service |
| TcSoaCadTypes.dll (303K) | CAD schema types |
| TcSoaStrongModel.dll (1.3M) | 2195 strongly-typed model classes |
| TcMemNetBindingInterface.dll (7K) | Memory binding |
| TcServerNetBindingInterface.dll (16K) | Server binding |
| Teamcenter_SSO64.dll (108K) | SSO support (present but not used by app code) |
| Interop.RevisionManager.dll (44K) | SolidEdge Revision Manager COM interop |
| Interop.SolidEdgeFileProperties.dll (9K) | SolidEdge file properties COM interop |
| log4net.dll (264K) | Logging framework |

---

## 20. CONFIG FILE SETTINGS

```xml
<userSettings>
    <setting name="InputFileType">.txt;.csv</setting>
    <setting name="TC_Url">http://STLV-HSMWEBTCP1:8080/tc</setting>
    <setting name="TC_UserName">UserName</setting>
    <setting name="TC_Password">Password</setting>
    <setting name="Illegal_Character">#:\?*<>%/|"~!</setting>
</userSettings>
<startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5"/>
</startup>
```

---

## 21. COMPLETE REST API CALL SEQUENCE (for CheckSheet generation)

```
1. POST .../tc/RestServices/Core-2008-06-Session/login
2. POST .../tc/RestServices/Core-2008-06-Session/setObjectPropertyPolicy  (ECN policy)
3. POST .../tc/RestServices/Query-2010-04-SavedQuery/findSavedQueries  ("Item Revision...")
4. POST .../tc/RestServices/Query-2008-06-SavedQuery/executeSavedQueries
5. POST .../tc/RestServices/Core-2007-09-DataManagement/loadObjects
6. POST .../tc/RestServices/Core-2008-06-Session/setObjectPropertyPolicy  (CheckSheet policy)
7. POST .../tc/RestServices/Core-2007-06-DataManagement/expandGRMRelationsForPrimary  (CMHasSolutionItem)
   --- For each solution item: ---
8. POST .../tc/RestServices/Query-2010-04-SavedQuery/findSavedQueries  ("Item...")
9. POST .../tc/RestServices/Query-2008-06-SavedQuery/executeSavedQueries
10. POST .../tc/RestServices/Core-2007-09-DataManagement/loadObjects
11. POST .../tc/RestServices/Core-2008-06-Session/setObjectPropertyPolicy  (Form policy)
12. POST .../tc/RestServices/Core-2007-06-DataManagement/expandGRMRelationsForPrimary  (plant rel)
    --- End per-item ---
13. POST .../tc/RestServices/Core-2006-03-Session/logout
```

For BOM expansion (GetChildNames), additional calls:
```
A. POST .../tc/RestServices/Core-2008-06-Session/setObjectPropertyPolicy  (BOM policy)
B. POST .../tc/RestServices/Core-2007-09-DataManagement/getProperties  (bom_view_tags)
C. POST .../tc/RestServices/Core-2007-09-DataManagement/getProperties  (view_type)
D. POST .../tc/RestServices/Cad-2007-01-StructureManagement/getRevisionRules
E. POST .../tc/RestServices/Cad-2007-01-StructureManagement/createBOMWindows
F. POST .../tc/RestServices/Cad-2007-01-StructureManagement/expandPSOneLevel
```

---

## 22. KEY HUSSMANN CUSTOM TYPES AND ATTRIBUTES

### Object Types
- `H4_Hussmann_Item` - Custom item type
- `H4_Hussmann_ItemRevision` - Custom item revision type
- `H4_ECN_CAPRevision` - CAP ECN revision
- `H4_ECN_CODRevision` - COD ECN revision
- `H4_ECN_NPDRevision` - NPD ECN revision
- `H4_ECN_VAVERevision` - VAVE ECN revision
- `ChangeNoticeRevision` - OOTB change notice revision (default)
- `H4_BGN_View_Form`, `H4_MTY_View_Form`, `H4_CNO_View_Form`, `H4_SWN_View_Form`, `H4_HAB_View_Form`, `H4_BBK_View_Form` - Plant form types

### Custom Attributes
- `h4_Nomenclature`, `h4_BGN_Source`, `h4_BBK_Source`, `h4_CNO_Source`, `h4_HAB_Source`, `h4_MTY_Source`, `h4_SWN_Source`
- `h4_BOM_Option_Code`, `h4_ECN_Number`, `h4_Finish_Code`, `h4_Finish_Color`
- `h4_Risk_Level`, `h4_High_Level_Category`, `h4_Sub_Category`, `h4_Hussmann_Item_Type`
- `h4_Template_Name`, `h4_Plant`, `h4_Plant_Template`, `h4_Plant_Coded`
- `h4_PLM_Revision`, `h4_Product_Family`, `h4_Model_Group`, `h4_Product_Line`, `h4_EAU`
- `h4_MAPICS_Item_Type`, `h4_US_Baan_Item_Type`, `h4_Cross_Ref_Part_No`

### OOTB Attributes Used
- `item_id`, `object_name`, `object_desc`, `item_revision_id`, `items_tag`
- `analyst_user_id`, `owning_user`, `owning_group`, `project_ids`, `uom_tag`
- `object_type`, `release_status_list`, `effectivity_text`, `process_stage`
- `bom_view_tags`, `view_type`, `bl_item_item_id`, `bl_rev_item_revision_id`

---

## 23. XML DATA FILES

The EXE ships with validation rule files:
- `DataBase-Report.xml` (79K) - Current validation rules
- `DataBase-Report-old.xml` (81K) - Previous version
- `MTY-DataBase.xml` (85K) - Monterrey-specific rules
- `MTY-DataBase(Old).xml` (42K) - Previous Monterrey version
- `NounList.xml` (34K) - Nomenclature validation
- `office.xml` (379K) - Office integration settings

---

## 24. INPUT MODES

The EXE supports multiple input types:
1. `ECN` - Single ECN number
2. `ItemID` - Single item ID
3. `MultipleItemID` - File containing multiple item IDs (reads .txt/.csv)
4. `ECN_CheckSheet` - ECN for CheckSheet generation (the main mode)
5. `MultipleItemIDFolder` - Folder-based multi-item
6. `Unknown` - Default

The CheckSheet mode (`rbChkSheet.Checked`) is the primary workflow we care about.
