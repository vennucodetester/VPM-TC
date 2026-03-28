# Teamcenter WhereUsed & connectivity — what we tried

This note summarizes attempts to get **bottom-up “where used”** (part → parent assemblies) working over **JsonRestServices**, plus login/connectivity issues observed on site. It is for future debugging, not end-user documentation.

---

## Goal

Resolve random **item / assembly IDs** from daily PR files to **top-level assemblies** without relying only on cached BOM files. **Top-down BOM** already worked; **where-used climb** required a working `where_used` SOA call.

---

## What did **not** work (and why)

### 1. `JsonRestServices/.../WhereUsed` (capital **W**)

- **Symptom:** HTTP 500, **214086** — *“The service request has invalid syntax.”*
- **Interpretation:** The **session envelope** was accepted; TC rejected the **operation body** binding for this operation name/shape on JsonRestServices.
- **Tried:** Many JSON body variants (see below); all still **214086** on capital-W for this server.

### 2. Body shape experiments (all with capital `WhereUsed` on JsonRestServices)

| Variant | Result |
|--------|--------|
| `inputParams` / `configParams` maps as **empty arrays** `[]` | 214086 |
| Maps as **empty objects** `{}` | 214086 |
| **Omit** `inputParams` | 214086 |
| **Minimal** `input` only (`inputObject` + `uid`) | 214086 |
| **PascalCase** (`Input`, `ConfigParams`, …) | 214086 |
| **`use_session_envelope=False`** (raw body) | **214020 / 214022** — envelope parse failure (JsonRestServices expects the envelope for these calls) |

So the failure was **not** resolved by map-as-object vs array alone; capital-W on JsonRestServices stayed invalid for this binding.

### 3. `JsonRestServices/.../whereUsed` (lowercase **w**)

- **Symptom:** **No 214086** — request appeared **accepted**, but responses sometimes **timed out** at 60s when run **after** several failed capital-W attempts (session/server looked overloaded; later attempts including **logout** also timed out).
- **Interpretation:** Lowercase operation name matches what the server actually executes for JSON in many TC 14 setups; long runtimes or cascading timeouts are environmental/session related, not proof that the body was wrong.

### 4. `RestServices` and `Core-2007-01` WhereUsed / whereUsed

- **Mixed:** Legacy **2007-01** body (`objects`, `numLevels`, `rule` with null UID) is the right *shape* for that API; success depends on deployment and routing.
- **Timeouts:** When the tier was already stressed, **RestServices** and **2007-01** calls also hit **read timeouts** in sequence.

### 5. Login / Web Tier — **error 1003**

- **Symptom:** HTTP 500, *“Failed to assign a server… Web Tier and/or Server Manager.”*
- **Cause:** **Teamcenter infrastructure** (no SOA server assigned, pool/routing issue) — **not** an incorrect login JSON for the usual `Core-2008-06-Session/login` envelope.
- **Client mitigations added:** Retries on transient web-tier text, **`TcAuthError` not retried**, optional **`RestServices`** login fallback after JsonRest failures, longer **login read** timeout than generic posts.

### 6. Earlier hypothesis: maps must be `{}` not `[]`

- **Decompiled .NET client** serializes `WhereUsedConfigParameters` maps as **ArrayLists** of key/value wire objects → empty maps are **`[]`** in JSON.
- **Empirical:** Both `[]` and `{}` still produced **214086** on **capital-W** JsonRestServices; the decisive fix for naming was **lowercase `whereUsed`**, not map encoding alone.

---

## What **does** work in code (current direction)

1. **Primary `where_used` path:** `JsonRestServices/Core-2012-02-DataManagement/**whereUsed**` (lowercase) with **empty-array** typed maps, session envelope, **longer read timeout** than normal posts.
2. **Fallbacks:** Same body on **2007-01** `whereUsed`, **RestServices**, then capital-W with **short** timeout (fast fail on 214086).
3. **`_post(timeout=...)`** supports scalar or `(connect, read)` tuple; **login** uses **`max(120, post_timeout)`** read and retries / RestServices fallback for pool errors.
4. **`test_hierarchy.py`:** `--probe` for raw responses, **`--timeout`** for default post timeout; probe URL aligned to lowercase `whereUsed` where applicable.
5. **`_extract_where_used_parent_uids`:** Handles **`parentObject`** (2012-02) and legacy **`parentItemRev`** / **`parentItemRevision`**.

---

## Operational notes

- **214086** on capital-W: treat as **wrong JsonRest operation name or binding**, not “TC is down.”
- **1003 / assign a server:** **Ops / TC admin** (Web Tier, Server Manager, SOA pool).
- After many failed/hung calls, **retry in a fresh session** or wait before concluding the lowercase API is wrong.

---

## Files touched in this effort (reference)

- `tc_connector.py` — `where_used`, `_post` timeouts, `login` retries / RestServices fallback, `_is_transient_tc_web_tier_error`
- `test_hierarchy.py` — `--probe`, `--timeout`, probe URLs
- This file — `WHEREUSED_AND_TC_CONNECTIVITY_TRIALS.md`
