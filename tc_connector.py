"""
Teamcenter SOA Connector for VPM
================================
Pure Python TC SOA client using the JsonRestServices HTTP/JSON binding.
All service endpoints, body formats, query names, and property policies
are matched exactly to the proven working CHECKSHEET.exe (.NET app).

See CHECKSHEET_EXE_COMPLETE_REFERENCE.md for the decompilation evidence.
"""

import requests
import json
import csv
import datetime
import logging
import os
import re
import time
from PyQt6.QtWidgets import (
    QDialog, QVBoxLayout, QHBoxLayout, QLabel, QLineEdit, QPushButton,
    QCheckBox, QRadioButton, QButtonGroup, QProgressBar, QMessageBox,
    QGroupBox, QFormLayout, QTextEdit, QWidget
)
from PyQt6.QtCore import Qt, QTimer
from PyQt6.QtGui import QFont

# Set up file logging for TC debugging
_log_dir = os.path.dirname(os.path.abspath(__file__))
_log_file = os.path.join(_log_dir, "tc_debug.log")
_tc_logger = logging.getLogger("tc_connector")
_tc_logger.setLevel(logging.DEBUG)
# Append so each run adds lines; git can show real diffs. Delete tc_debug.log manually to reset.
_file_handler = logging.FileHandler(_log_file, mode='a', encoding='utf-8')
_file_handler.setFormatter(logging.Formatter('%(asctime)s [%(levelname)s] %(message)s'))
_tc_logger.addHandler(_file_handler)
_tc_logger.info("TC Connector module loaded")


# ============================================================================
# EXCEPTIONS
# ============================================================================

class TcSoaError(Exception):
    """Raised when TC SOA returns an error in serviceData."""
    pass


class TcAuthError(TcSoaError):
    """Raised on authentication failure or session timeout."""
    pass


class TcConnectionError(TcSoaError):
    """Raised on network connectivity issues."""
    pass


def _is_transient_tc_web_tier_error(exc):
    """HTTP 500 from TC when Web Tier / pool is overloaded (often transient; retry)."""
    text = str(exc).lower()
    return (
        "assign a server" in text
        or "server manager" in text
        or "web tier" in text
        or "unexpected error on the web tier" in text
        or ("1003" in text and "assign" in text)
        or "tcserver is busy" in text
        or "server is busy" in text
        or "cannot authenticate the user" in text
    )


# ============================================================================
# CONSTANTS — Exact values from decompiled CHECKSHEET.exe
# ============================================================================

# ECN property policy (9 properties) — from Declarations.HSM_ECN_POLICY_PROPETIES
ECN_POLICY_PROPS = [
    "item_id", "object_name", "object_desc", "item_revision_id",
    "items_tag", "analyst_user_id", "owning_user", "owning_group", "project_ids"
]

# Item policy (8 properties) — from Declarations.HSM_ITEM_POLICY_PROPETIES
ITEM_POLICY_PROPS = [
    "item_id", "h4_Product_Family", "h4_Model_Group", "h4_Product_Line",
    "analyst_user_id", "owning_user", "uom_tag", "h4_Hussmann_Item_Type"
]

# Item revision policy (7 properties) — from Declarations.HSM_ITEM_REV_POLICY_PROPETIES
ITEM_REV_POLICY_PROPS = [
    "item_id", "object_name", "object_desc", "item_revision_id",
    "items_tag", "owning_group", "h4_Hussmann_Item_Type"
]

# CheckSheet policy (36 properties) — from Declarations.HSM_Check_Sheet_POLICY_PROPETIES
CHECKSHEET_POLICY_PROPS = [
    "item_id", "object_name", "item_revision_id", "items_tag", "object_desc",
    "h4_Nomenclature", "h4_BGN_Source", "h4_BBK_Source", "h4_CNO_Source",
    "h4_HAB_Source", "h4_MTY_Source", "h4_SWN_Source", "h4_BOM_Option_Code",
    "h4_ECN_Number", "h4_Finish_Code", "h4_Finish_Color", "h4_Risk_Level",
    "h4_High_Level_Category", "h4_Sub_Category", "h4_Hussmann_Item_Type",
    "h4_Template_Name", "h4_Plant", "object_type", "release_status_list",
    "effectivity_text", "h4_PLM_Revision", "process_stage",
    "h4_Plant_Template", "h4_Plant_Coded",
    "h4_Product_Family", "h4_Model_Group", "h4_Product_Line", "h4_EAU"
]

# Form policy (7 properties) — from Declarations.HSM_Check_Sheet_Form_PROPETIES
FORM_POLICY_PROPS = [
    "h4_Plant_Template", "h4_Template_Name", "h4_Plant", "h4_Plant_Coded",
    "h4_MAPICS_Item_Type", "h4_US_Baan_Item_Type", "h4_Cross_Ref_Part_No"
]

# BOM line policy (2 properties) — from Declarations.BOM_LINE_POLICY_PROPETIES
BOM_LINE_POLICY_PROPS = ["bl_item_item_id", "bl_rev_item_revision_id", "bl_quantity"]

# Revision rule policy (1 property) — from Declarations.REV_RULE_POLICY_PROPETIES
REV_RULE_POLICY_PROPS = ["object_name"]

# Revision rule name — from Declarations.HSM_DEFAULT_REV_RULE
HSM_REVISION_RULE = "HSM_WIP_Latest_Production_Released"
HSM_REVISION_RULE_FALLBACKS = [HSM_REVISION_RULE, "HSM_Production_DesignReleased_WIP", "Latest Working"]

# BOM view type — from Declarations.HSM_DEFAULT_VIEW_NAME
HSM_BOM_VIEW_TYPE = "MTY View"


# Unified property policy: union of every type/property combo VPM uses during a run.
# Set ONCE at login so subsequent calls (where_used, lookup_*, etc.) don't re-send
# setObjectPropertyPolicy on every item. See plan: vpm_speed plan, fix #1.
UNIFIED_POLICY = {
    "H4_Hussmann_ItemRevision": list(CHECKSHEET_POLICY_PROPS),
    "ItemRevision": [
        "item_id", "item_revision_id", "object_name", "object_desc",
        "release_status_list", "process_stage",
    ],
}


def get_ecn_type(ecn_id):
    """
    Determine ECN type from the ECN ID string.
    Exact logic from decompiled InputInfo.ECNType property.
    """
    upper = ecn_id.upper()
    if "CAP" in upper:
        return "H4_ECN_CAPRevision"
    if "COD" in upper:
        return "H4_ECN_CODRevision"
    if "NPD" in upper:
        return "H4_ECN_NPDRevision"
    if "VAVE" in upper:
        return "H4_ECN_VAVERevision"
    return "ChangeNoticeRevision"


# ============================================================================
# TC SOA CLIENT — Low-level JSON REST client
# ============================================================================

class TcSoaClient:
    """
    Low-level Teamcenter SOA client using the JsonRestServices HTTP/JSON binding.
    All endpoints and body formats match the decompiled CHECKSHEET.exe exactly.
    """

    def __init__(self, base_url, post_timeout=60):
        self.base_url = base_url.rstrip('/')
        self.post_timeout = post_timeout
        self.session = requests.Session()
        self.session.headers.update({
            'Content-Type': 'application/json',
            'Accept': 'application/json',
        })
        self.is_connected = False
        self.username = None
        self._state = {
            "clientVersion": "14000.1.0",
            "clientId": "VPM-Python",
            "logCorrelationId": "",
            "stateless": False
        }
        self._saved_query_uid_cache = {}
        self._revision_rules_cache = None
        self._last_policy_signature = None
        self._bom_create_mode_cache = None
        self._bom_expand_mode_cache = None
        # Performance caches (cleared on logout). See speedup plan.
        self._where_used_cache = {}      # uid -> list[parent_uids]
        self._top_level_cache = {}       # (base_id, rev) -> result dict
        self._item_props_cache = {}      # uid -> dict of fetched props
        self._nomenclature_cache = {}    # nom -> list[result dicts]
        self._where_used_strategy = None  # tuple of attempt that succeeded last
        self._unified_policy_set = False  # True after one-shot policy set at login

    @staticmethod
    def _get_service_data(result):
        """Teamcenter may return either serviceData or ServiceData."""
        service_data = result.get("serviceData")
        if isinstance(service_data, dict):
            return service_data
        service_data = result.get("ServiceData")
        if isinstance(service_data, dict):
            return service_data
        # Some endpoints (e.g., Base.ServiceData responses) place serviceData
        # fields at the top level instead of nesting under serviceData/ServiceData.
        if isinstance(result, dict) and any(k in result for k in ("modelObjects", "plain", "created", "updated", "deleted")):
            return result
        return {}

    @staticmethod
    def _sanitize_for_log(value):
        """Redact sensitive values before writing to debug logs."""
        if isinstance(value, dict):
            out = {}
            for key, val in value.items():
                if str(key).lower() in {"password", "passwd", "pwd"}:
                    out[key] = "***REDACTED***"
                else:
                    out[key] = TcSoaClient._sanitize_for_log(val)
            return out
        if isinstance(value, list):
            return [TcSoaClient._sanitize_for_log(v) for v in value]
        return value

    @staticmethod
    def _is_dom_parse_error(exc):
        """Identify TC DOM parsing failures used for fallback retry logic."""
        text = str(exc).lower()
        return "dom parsing" in text or "internalserverexception" in text

    @classmethod
    def _extract_error_messages(cls, result):
        """Collect readable error text from common TC exception shapes."""
        messages = []

        top_level_message = result.get("message")
        if top_level_message:
            messages.append(str(top_level_message))

        for entry in result.get("messages", []):
            if isinstance(entry, dict):
                msg = entry.get("message")
                if msg:
                    messages.append(str(msg))
            elif entry:
                messages.append(str(entry))

        service_data = cls._get_service_data(result)
        for partial_error in service_data.get("partialErrors", []):
            for error_value in partial_error.get("errorValues", []):
                msg = error_value.get("message")
                if msg:
                    messages.append(str(msg))

        unique_messages = []
        for message in messages:
            if message not in unique_messages:
                unique_messages.append(message)
        return unique_messages

    def _post(
        self,
        namespace,
        operation,
        body,
        endpoint_family="JsonRestServices",
        use_session_envelope=True,
        timeout=None,
    ):
        """
        Core HTTP POST to TC SOA endpoint.
        URL pattern: {base_url}/{endpoint_family}/{namespace}/{operation}
        timeout: seconds for this request (defaults to self.post_timeout).
        """
        if timeout is None:
            timeout = self.post_timeout
        url = f"{self.base_url}/{endpoint_family}/{namespace}/{operation}"

        if use_session_envelope:
            payload = {
                "header": {
                    "state": self._state,
                    "policy": {}
                },
                "body": body
            }
            payload_mode = "session-envelope"
        else:
            payload = body
            payload_mode = "raw-body"

        _tc_logger.debug(f"POST {url}")
        _tc_logger.debug(
            f"  Request mode: endpoint_family={endpoint_family}, payload_mode={payload_mode}"
        )
        _tc_logger.debug(
            f"  Body: {json.dumps(self._sanitize_for_log(body), default=str)[:2000]}"
        )
        _tc_logger.debug(
            f"  Payload: {json.dumps(self._sanitize_for_log(payload), default=str)[:3000]}"
        )

        try:
            # Scalar timeout = same limit for connect+read. Callers may pass (connect_sec, read_sec).
            resp = self.session.post(url, json=payload, timeout=timeout)
        except requests.exceptions.ConnectionError as e:
            _tc_logger.error(f"  ConnectionError: {e}")
            raise TcConnectionError(
                f"Cannot connect to TC server at {self.base_url}. "
                f"Check the server URL and network connection.\n\nDetails: {e}"
            )
        except requests.exceptions.Timeout:
            _tc_logger.error(f"  Timeout")
            raise TcConnectionError(
                f"Connection to TC server timed out. The server may be down or overloaded."
            )

        _tc_logger.debug(f"  Response HTTP {resp.status_code}")
        _tc_logger.debug(f"  Response body (first 3000 chars): {resp.text[:3000]}")

        if resp.status_code == 401:
            raise TcAuthError("Authentication failed. Check username and password.")

        try:
            result = resp.json()
        except (json.JSONDecodeError, ValueError):
            _tc_logger.error(f"  Failed to parse JSON: {resp.text[:1000]}")
            if resp.status_code != 200:
                raise TcSoaError(
                    f"TC server returned HTTP {resp.status_code}: {resp.text[:500]}"
                )
            raise TcSoaError(
                f"TC server returned non-JSON response: {resp.text[:500]}"
            )

        _tc_logger.debug(f"  Response keys: {list(result.keys())}")

        qname = str(result.get('.QName', ''))
        if 'Exception' in qname:
            error_messages = self._extract_error_messages(result)
            combined = '; '.join(error_messages) if error_messages else qname
            _tc_logger.warning(f"  TC exception response: {qname} | {combined}")
            if 'credential' in combined.lower() or 'session' in combined.lower() or 'login' in combined.lower():
                raise TcAuthError(combined)
            raise TcSoaError(f"{qname}: {combined}")

        service_data = self._get_service_data(result)
        partial_errors = service_data.get('partialErrors', [])
        if partial_errors:
            _tc_logger.warning(f"  Partial errors: {json.dumps(partial_errors, default=str)[:2000]}")
            error_msgs = self._extract_error_messages(result)
            if error_msgs:
                combined = ' '.join(error_msgs)
                if 'session' in combined.lower() or 'login' in combined.lower():
                    raise TcAuthError(f"Session error: {'; '.join(error_msgs)}")
                raise TcSoaError(f"TC SOA error: {'; '.join(error_msgs)}")

        if resp.status_code != 200:
            raise TcSoaError(
                f"TC server returned HTTP {resp.status_code}: {resp.text[:500]}"
            )

        return result

    # ------------------------------------------------------------------
    # SESSION OPERATIONS
    # ------------------------------------------------------------------

    def login(self, username, password):
        """
        Login to Teamcenter.
        Uses Core-2008-06-Session/login with exact parameters from CHECKSHEET.exe.
        Read timeout is at least 180s (SSO / JsonRest on Web Tier; Rich Client uses a different path).
        Retries up to 3 times on transient Web Tier / “assign a server” errors (code 1003 class).
        If JsonRestServices still fails, tries RestServices once (alternate routing on some sites).
        """
        # Single correct format — matches the EXE's SessionService.Login() call
        body = {
            "username": username,
            "password": password,
            "group": "",
            "role": "",
            "locale": "",
            "sessionDiscriminator": "SoaAppX"
        }

        _tc_logger.info(f"Login attempt: Core-2008-06-Session/login, user={username}")
        # Floor 180s: SSO / JsonRest login often exceeds 120s on loaded sites; Rich Client uses a different path.
        login_read = max(180, int(self.post_timeout))
        login_timeout = (15, login_read)
        max_attempts = 3
        retry_delay_s = 8

        result = None
        last_err = None
        for attempt in range(1, max_attempts + 1):
            try:
                result = self._post(
                    "Core-2008-06-Session",
                    "login",
                    body,
                    timeout=login_timeout,
                    endpoint_family="JsonRestServices",
                )
                last_err = None
                break
            except TcAuthError:
                raise
            except TcSoaError as e:
                last_err = e
                if _is_transient_tc_web_tier_error(e) and attempt < max_attempts:
                    _tc_logger.warning(
                        "  Login attempt %s/%s: transient Web Tier / pool error — retrying in %ss: %s",
                        attempt,
                        max_attempts,
                        retry_delay_s,
                        e,
                    )
                    time.sleep(retry_delay_s)
                    continue
                if not _is_transient_tc_web_tier_error(e):
                    raise
                break

        if result is None and last_err is not None:
            _tc_logger.warning(
                "  JsonRestServices login failed with Web Tier / pool error; trying RestServices once"
            )
            try:
                result = self._post(
                    "Core-2008-06-Session",
                    "login",
                    body,
                    timeout=login_timeout,
                    endpoint_family="RestServices",
                )
            except TcSoaError as e2:
                _tc_logger.warning("  RestServices login failed: %s", e2)
                raise TcSoaError(
                    f"{last_err} (RestServices fallback also failed: {e2})"
                ) from e2

        if result is None:
            raise last_err if last_err else TcSoaError("Login failed with no response")

        _tc_logger.info(f"Login SUCCESS")
        _tc_logger.info(f"  Response keys: {list(result.keys())}")
        self.is_connected = True
        self.username = username

        # Set the unified property policy ONCE per session so subsequent calls
        # don't re-send setObjectPropertyPolicy on every item lookup.
        try:
            self.set_property_policy(UNIFIED_POLICY)
            self._unified_policy_set = True
            _tc_logger.info("  Unified property policy set (one-shot)")
        except Exception as policy_err:
            _tc_logger.warning(f"  Unified policy set failed (non-fatal): {policy_err}")

        return True

    def logout(self):
        """Logout from Teamcenter. Safe to call even if not connected."""
        if not self.is_connected:
            return
        try:
            self._post("Core-2006-03-Session", "logout", {}, timeout=(10, 60))
        except Exception:
            pass
        finally:
            self.is_connected = False
            self.username = None
            # Clear performance caches so a fresh login starts clean.
            self._where_used_cache.clear()
            self._top_level_cache.clear()
            self._item_props_cache.clear()
            self._nomenclature_cache.clear()
            self._where_used_strategy = None
            self._unified_policy_set = False
            self._last_policy_signature = None

    def test_connection(self):
        """Test if the server URL is reachable."""
        try:
            resp = self.session.get(self.base_url, timeout=30)
            return True, "TC server is reachable"
        except requests.exceptions.ConnectionError as e:
            return False, f"Cannot connect: {e}"
        except requests.exceptions.Timeout:
            return False, "Connection timed out"

    # ------------------------------------------------------------------
    # PROPERTY POLICY — Core-2008-06-Session (NOT DataManagement)
    # ------------------------------------------------------------------

    def set_property_policy(self, types_with_props):
        """
        Set object property policy via Core-2008-06-Session/setObjectPropertyPolicy.
        This matches the EXE's SessionService.SetObjectPropertyPolicy() call.

        Args:
            types_with_props: dict mapping type names to lists of property names.
        """
        policy_types = []
        for type_name, props in types_with_props.items():
            # Filter out empty strings (the EXE has one at index 27)
            filtered_props = [p for p in props if p]
            policy_types.append({
                "name": type_name,
                "properties": [{"name": p} for p in filtered_props]
            })

        policy_signature = json.dumps(policy_types, sort_keys=True)
        if self._last_policy_signature == policy_signature:
            return

        # Teamcenter schema uses SetObjectPropertyPolicyInput.ObjectPropertyPolicy
        # (capitalized), while many examples online use lowercase. We try the
        # schema-accurate form first and include lowercase fallback if needed.
        body = {
            "ObjectPropertyPolicy": {
                "useRefCount": False,
                "types": policy_types
            }
        }

        try:
            self._post("Core-2008-06-Session", "setObjectPropertyPolicy", body)
            self._last_policy_signature = policy_signature
            return
        except TcSoaError as first_error:
            if not self._is_dom_parse_error(first_error):
                raise

            _tc_logger.warning(
                "setObjectPropertyPolicy failed with DOM parsing error; trying compatibility fallbacks."
            )
            lowercase_body = {
                "objectPropertyPolicy": body["ObjectPropertyPolicy"]
            }
            fallback_attempts = [
                ("JsonRestServices", False, body),
                ("JsonRestServices", True, lowercase_body),
                ("JsonRestServices", False, lowercase_body),
                ("RestServices", False, body),
                ("RestServices", True, body),
            ]
            last_error = first_error
            for endpoint_family, use_session_envelope, retry_body in fallback_attempts:
                try:
                    _tc_logger.warning(
                        "Retry setObjectPropertyPolicy with "
                        f"endpoint_family={endpoint_family}, "
                        f"use_session_envelope={use_session_envelope}, "
                        f"keys={list(retry_body.keys())}"
                    )
                    self._post(
                        "Core-2008-06-Session",
                        "setObjectPropertyPolicy",
                        retry_body,
                        endpoint_family=endpoint_family,
                        use_session_envelope=use_session_envelope,
                    )
                    self._last_policy_signature = policy_signature
                    _tc_logger.info(
                        "setObjectPropertyPolicy compatibility retry succeeded."
                    )
                    return
                except TcSoaError as retry_error:
                    last_error = retry_error
                    _tc_logger.warning(
                        f"setObjectPropertyPolicy fallback failed: {retry_error}"
                    )

            raise TcSoaError(
                "setObjectPropertyPolicy failed after compatibility retries. "
                f"Initial error: {first_error}. Last error: {last_error}"
            ) from first_error

    # ------------------------------------------------------------------
    # SAVED QUERIES — Exact findSavedQueries, no heuristics
    # ------------------------------------------------------------------

    def find_saved_query(self, query_name):
        """
        Find a saved query by exact name using Query-2010-04-SavedQuery/findSavedQueries.
        Matches the EXE's SavedQueryService.FindSavedQueries() call.

        Args:
            query_name: Exact query name, e.g. "Item Revision..." or "Item..."

        Returns:
            Query UID string

        Raises:
            TcSoaError if query not found
        """
        cached_uid = self._saved_query_uid_cache.get(query_name)
        if cached_uid:
            return cached_uid

        _tc_logger.info(f"findSavedQueries: looking for '{query_name}'")

        body = {
            "savedQueryCriteriaInputs": [{
                "queryNames": [query_name],
                "queryType": 0
            }]
        }

        result = self._post("Query-2010-04-SavedQuery", "findSavedQueries", body)

        # Extract query UID from response
        saved_queries = result.get('savedQueries', [])
        _tc_logger.info(f"  savedQueries response: {json.dumps(saved_queries, default=str)[:1000]}")

        if saved_queries:
            for q in saved_queries:
                if q:
                    uid = q.get('uid', q) if isinstance(q, dict) else q
                    if uid:
                        _tc_logger.info(f"  Found query UID: {uid}")
                        self._saved_query_uid_cache[query_name] = uid
                        return uid

        # Some TC environments return empty savedQueries for FindSavedQueries
        # even when the query exists. Fallback to Query-2006-03 catalog lookup.
        _tc_logger.warning(
            f"  findSavedQueries returned empty for '{query_name}', "
            "falling back to getSavedQueries catalog lookup."
        )
        catalog = self._post("Query-2006-03-SavedQuery", "getSavedQueries", {})
        queries = catalog.get("queries", [])
        _tc_logger.info(f"  getSavedQueries returned {len(queries)} queries")

        def _norm(text):
            return "".join(ch for ch in str(text).lower() if ch.isalnum())

        wanted_norm = _norm(query_name)
        exact_uid = None
        fuzzy_uid = None
        fuzzy_name = None

        for q in queries:
            if not isinstance(q, dict):
                continue
            name = q.get("name", "")
            query_obj = q.get("query", {})
            uid = query_obj.get("uid") if isinstance(query_obj, dict) else None
            if not uid:
                continue

            if name == query_name:
                exact_uid = uid
                break

            if _norm(name) == wanted_norm and not fuzzy_uid:
                fuzzy_uid = uid
                fuzzy_name = name

        if exact_uid:
            _tc_logger.info(f"  Catalog exact match UID: {exact_uid}")
            self._saved_query_uid_cache[query_name] = exact_uid
            return exact_uid

        if fuzzy_uid:
            _tc_logger.warning(
                f"  Catalog normalized match '{fuzzy_name}' for requested "
                f"'{query_name}', UID: {fuzzy_uid}"
            )
            self._saved_query_uid_cache[query_name] = fuzzy_uid
            return fuzzy_uid

        raise TcSoaError(
            f"Saved query '{query_name}' not found in Teamcenter "
            "(findSavedQueries and getSavedQueries both returned no match)"
        )

    def execute_saved_query(self, query_name, entries, values, max_results=0):
        """
        Find and execute a saved query.
        Matches the EXE's FindSavedQueries + ExecuteSavedQueries + LoadObjects flow.

        Args:
            query_name: Exact query name (e.g. "Item Revision...")
            entries: Entry field names (e.g. ["Item ID"])
            values: Entry values (e.g. ["ECN-CAP-12345"])
            max_results: 0 = unlimited (matches EXE's MaxNumToReturn=0)

        Returns:
            List of UIDs found
        """
        query_uid = self.find_saved_query(query_name)

        # Execute the query — matches EXE's QueryInput structure
        exec_body = {
            # Tc 2008-06 schema field is "input" (not "inputData")
            "input": [{
                "query": {"uid": query_uid},
                "entries": entries,
                "values": values,
                "maxNumToReturn": max_results,
                "limitList": [],
                "resultsType": 0,
                "requestId": "",
                "clientId": "",
            }]
        }

        exec_result = self._post(
            "Query-2008-06-SavedQuery", "executeSavedQueries", exec_body
        )

        # Extract UIDs from results
        found_uids = []
        if 'arrayOfResults' in exec_result:
            for result_set in exec_result['arrayOfResults']:
                # The EXE uses queryResults.ObjectUIDS then calls LoadObjects
                object_uids = (
                    result_set.get('objectUIDS')
                    or result_set.get('objectUIDs')
                    or result_set.get('objectUids')
                    or result_set.get('objects', [])
                )
                for obj in object_uids:
                    if isinstance(obj, str):
                        found_uids.append(obj)
                    elif isinstance(obj, dict) and 'uid' in obj:
                        found_uids.append(obj['uid'])

        _tc_logger.info(f"  Query returned {len(found_uids)} UIDs")

        # LoadObjects — matches EXE's DataManagementService.LoadObjects(objectUIDS)
        if found_uids:
            load_body = {
                "uids": found_uids
            }
            try:
                self._post("Core-2007-09-DataManagement", "loadObjects", load_body)
            except TcSoaError:
                pass  # loadObjects may fail for some object types, UIDs are still valid

        return found_uids

    def get_saved_queries_catalog(self):
        """
        Return full saved query catalog via Query-2006-03-SavedQuery/getSavedQueries.
        """
        result = self._post("Query-2006-03-SavedQuery", "getSavedQueries", {})
        queries = result.get("queries", [])
        return queries if isinstance(queries, list) else []

    def describe_saved_query_fields(self, query_uid):
        """
        Return entry field definitions for one saved query UID.
        """
        body = {
            "queries": [{"uid": query_uid}]
        }
        result = self._post("Query-2006-03-SavedQuery", "describeSavedQueries", body)
        field_lists = result.get("fieldLists", [])
        if not field_lists or not isinstance(field_lists, list):
            return []
        fields = field_lists[0].get("fields", [])
        return fields if isinstance(fields, list) else []

    def execute_saved_query_by_uid(self, query_uid, entries, values, max_results=0):
        """
        Execute Query-2008-06-SavedQuery by direct query UID.
        """
        exec_body = {
            "input": [{
                "query": {"uid": query_uid},
                "entries": entries,
                "values": values,
                "maxNumToReturn": max_results,
                "limitList": [],
                "resultsType": 0,
                "requestId": "",
                "clientId": "",
            }]
        }

        exec_result = self._post(
            "Query-2008-06-SavedQuery", "executeSavedQueries", exec_body
        )

        found_uids = []
        if 'arrayOfResults' in exec_result:
            for result_set in exec_result['arrayOfResults']:
                object_uids = (
                    result_set.get('objectUIDS')
                    or result_set.get('objectUIDs')
                    or result_set.get('objectUids')
                    or result_set.get('objects', [])
                )
                for obj in object_uids:
                    if isinstance(obj, str):
                        found_uids.append(obj)
                    elif isinstance(obj, dict) and 'uid' in obj:
                        found_uids.append(obj['uid'])

        if found_uids:
            load_body = {"uids": found_uids}
            try:
                self._post("Core-2007-09-DataManagement", "loadObjects", load_body)
            except TcSoaError:
                pass

        return found_uids

    # ------------------------------------------------------------------
    # PROPERTY OPERATIONS
    # ------------------------------------------------------------------

    def get_properties(self, uids, properties):
        """
        Get properties of TC objects via Core-2007-09-DataManagement/getProperties.

        Args:
            uids: List of object UIDs
            properties: List of property names to fetch

        Returns:
            Dict mapping UID to dict of property values: {uid: {prop_name: value}}
        """
        if not uids:
            return {}

        objects = [{"uid": uid} for uid in uids]
        body = {
            "objects": objects,
            "attributes": properties
        }

        # Tc SOA binding uses Core-2006-03 DataManagement for GetProperties.
        result = self._post("Core-2006-03-DataManagement", "getProperties", body)

        props_map = {}
        service_data = self._get_service_data(result)
        model_objects = service_data.get('modelObjects', {})

        # UID/tag properties must use dbValues (uiValues can be display text).
        def _prefer_db_value(prop_name):
            pname = str(prop_name or "").lower()
            if pname.endswith("_tag") or pname.endswith("_tags"):
                return True
            return pname in {
                "items_tag",
                "bom_view_tags",
                "fnd0groupmember",
                "uom_tag",
                "structure_revisions",
                "bvr_occurrences",
                "ps_children",
                "child_item",
            }

        for uid in uids:
            obj_data = model_objects.get(uid, {})
            obj_props = obj_data.get('props', {})
            props_map[uid] = {}
            for prop_name in properties:
                prop_data = obj_props.get(prop_name, {})
                ui_values = prop_data.get('uiValues', [])
                db_values = prop_data.get('dbValues', [])
                if _prefer_db_value(prop_name):
                    if db_values:
                        props_map[uid][prop_name] = db_values[0] if len(db_values) == 1 else db_values
                    elif ui_values:
                        props_map[uid][prop_name] = ui_values[0] if len(ui_values) == 1 else ui_values
                    else:
                        props_map[uid][prop_name] = ""
                else:
                    if ui_values:
                        props_map[uid][prop_name] = ui_values[0] if len(ui_values) == 1 else ui_values
                    elif db_values:
                        props_map[uid][prop_name] = db_values[0] if len(db_values) == 1 else db_values
                    else:
                        props_map[uid][prop_name] = ""

        return props_map

    # ------------------------------------------------------------------
    # GRM RELATION OPERATIONS — Core-2007-09-DataManagement
    # ------------------------------------------------------------------

    def expand_grm_relations(self, uids, relation_name, secondary_object_types=None):
        """
        Expand GRM relations via Core-2007-09-DataManagement/expandGRMRelationsForPrimary.
        Matches the EXE's DataManagementService.ExpandGRMRelationsForPrimary() call.

        Args:
            uids: List of primary object UIDs
            relation_name: Relation type name, e.g. "CMHasSolutionItem"
            secondary_object_types: List of type names to filter, e.g. ["H4_Hussmann_ItemRevision"]

        Returns:
            Dict mapping primary UID to list of related UIDs
        """
        if not uids:
            return {}

        primary_objects = [{"uid": uid} for uid in uids]

        # Matches EXE's ExpandGRMRelationsPref2 structure
        body = {
            "primaryObjects": primary_objects,
            "pref": {
                "expItemRev": False,
                "returnRelations": False,
                "info": [{
                    "relationTypeName": relation_name,
                    "otherSideObjectTypes": secondary_object_types or []
                }]
            }
        }

        result = self._post(
            "Core-2007-09-DataManagement", "expandGRMRelationsForPrimary", body
        )

        relations_map = {}
        output = result.get('output', [])
        for entry in output:
            primary_uid = entry.get('inputObject', {}).get('uid', '')
            related_uids = []
            relation_data = entry.get('relationshipData', [])
            for rel in relation_data:
                related_objects = rel.get('relationshipObjects', [])
                for ro in related_objects:
                    other_obj = ro.get('otherSideObject', {})
                    if isinstance(other_obj, dict) and 'uid' in other_obj:
                        related_uids.append(other_obj['uid'])
                    elif isinstance(other_obj, str):
                        related_uids.append(other_obj)
            relations_map[primary_uid] = related_uids

        return relations_map

    # ------------------------------------------------------------------
    # WHERE-USED — Climb BOM hierarchy to find top-level assembly
    # ------------------------------------------------------------------

    @staticmethod
    def split_item_id_and_revision(item_id_str):
        """
        Saved queries and Item ID fields use the bare id; revision is separate.
        Accepts '3233143', '3233143/C', 'AFE96/A' → (base_id, rev_or_None).
        """
        s = str(item_id_str or "").strip()
        if not s:
            return "", None
        if "/" in s:
            left, right = s.split("/", 1)
            rev = right.strip() or None
            return left.strip(), rev
        return s, None

    def _extract_where_used_parent_uids(self, entry):
        """Pull parent ItemRevision UIDs from one whereUsed output element (2012-02: info[].parentObject.uid, etc.)."""
        uids = []

        def _uid_from_obj(o):
            if isinstance(o, str) and o:
                return o
            if isinstance(o, dict):
                u = o.get("uid")
                if u:
                    return u
            return None

        if not isinstance(entry, dict):
            return uids

        for key in ("parentItemRev", "parentItemRevision", "parentObject", "component"):
            u = _uid_from_obj(entry.get(key))
            if u:
                uids.append(u)

        infos = entry.get("info") or entry.get("Info") or []
        for info in infos:
            if not isinstance(info, dict):
                continue
            for key in ("parentItemRev", "parentItemRevision", "parentObject"):
                u = _uid_from_obj(info.get(key))
                if u:
                    uids.append(u)

        return uids

    # NULL UID constant from decompiled NullModelObject.NULL_ID
    _TC_NULL_UID = "AAAAAAAAAAAAAA"

    # Read timeout for WhereUsed HTTP layer (connect is short; read holds the BOM work).
    # Keep moderate to avoid piling sequential multi-minute waits when an endpoint misbehaves.
    _WHERE_USED_TIMEOUT_S = 120
    _WHERE_USED_FALLBACK_TIMEOUT_S = 25

    def where_used(self, item_revision_uid):
        """
        Find parent assemblies that contain this item revision as a BOM child.

        Primary path uses **lowercase** operation name ``whereUsed`` on Core-2012-02 (JsonRestServices
        rejects capital ``WhereUsed`` with 214086). Maps use empty arrays per SOA wire format.
        Falls back to Core-2007-01 ``whereUsed``, RestServices, then capital-W as last resort.
        Uses an extended HTTP timeout for where-used calls.

        Returns list of parent ItemRevision UIDs (strings).
        """
        if not item_revision_uid:
            return []

        # Memoization: parents for a given uid don't change during a run.
        cached = self._where_used_cache.get(item_revision_uid)
        if cached is not None:
            _tc_logger.info(f"where_used: uid={item_revision_uid} (cache hit, {len(cached)} parents)")
            return list(cached)

        _tc_logger.info(f"where_used: uid={item_revision_uid}")

        # Property policy is set ONCE at login (UNIFIED_POLICY); no per-call resend.
        if not self._unified_policy_set:
            self.set_property_policy(UNIFIED_POLICY)
            self._unified_policy_set = True

        # SOA typed maps serialize as arrays of {key,value} entries; empty maps are [].
        _empty_maps_list = {
            "stringMap": [], "doubleMap": [], "intMap": [],
            "boolMap": [], "dateMap": [], "tagMap": [], "floatMap": [],
        }

        body_2012 = {
            "input": [{
                "inputObject": {"uid": item_revision_uid},
                "useLocalParams": False,
                "inputParams": dict(_empty_maps_list),
                "clientId": "",
            }],
            "configParams": dict(_empty_maps_list),
        }

        body_2012_no_input_params = {
            "input": [{
                "inputObject": {"uid": item_revision_uid},
                "useLocalParams": False,
                "clientId": "",
            }],
            "configParams": dict(_empty_maps_list),
        }

        body_2007 = {
            "objects": [{"uid": item_revision_uid}],
            "numLevels": 1,
            "whereUsedPrecise": False,
            "rule": {"uid": self._TC_NULL_UID},
        }

        # (endpoint_family, service, operation, body, envelope, read_timeout_seconds)
        # JsonRest lowercase first. RestServices last — often slower / duplicate; short fallbacks for capital-W.
        attempts = [
            ("JsonRestServices", "Core-2012-02-DataManagement", "whereUsed", body_2012, True, self._WHERE_USED_TIMEOUT_S),
            ("JsonRestServices", "Core-2012-02-DataManagement", "whereUsed", body_2012_no_input_params, True, self._WHERE_USED_TIMEOUT_S),
            ("JsonRestServices", "Core-2007-01-DataManagement", "whereUsed", body_2007, True, self._WHERE_USED_TIMEOUT_S),
            ("RestServices", "Core-2012-02-DataManagement", "whereUsed", body_2012, True, self._WHERE_USED_TIMEOUT_S),
            # Last resort: capital-W (214086 on JsonRest is instant; RestServices may differ)
            ("JsonRestServices", "Core-2012-02-DataManagement", "WhereUsed", body_2012, True, self._WHERE_USED_FALLBACK_TIMEOUT_S),
            ("RestServices", "Core-2012-02-DataManagement", "WhereUsed", body_2012, True, self._WHERE_USED_FALLBACK_TIMEOUT_S),
            ("JsonRestServices", "Core-2007-01-DataManagement", "WhereUsed", body_2007, True, self._WHERE_USED_FALLBACK_TIMEOUT_S),
        ]

        # Sticky strategy: once an attempt succeeds for this run, try it FIRST on
        # subsequent calls. Avoids the 7-fallback storm on every where_used.
        # Key = (endpoint_family, service, operation) only — body is rebuilt each call
        # so id(body) always differs, which was breaking the match.
        if self._where_used_strategy is not None:
            stick_key = self._where_used_strategy
            reordered = []
            for a in attempts:
                key = (a[0], a[1], a[2])
                if key == stick_key:
                    reordered.insert(0, a)
                else:
                    reordered.append(a)
            attempts = reordered

        result = None
        successful_attempt = None
        for endpoint_family, service, operation, body, envelope, read_sec in attempts:
            # (connect, read) avoids blaming TC for slow reads when the socket was stuck connecting.
            http_timeout = (15, int(read_sec))
            label = (
                f"{endpoint_family}/{service}/{operation} "
                f"envelope={envelope} read_timeout={read_sec}s"
            )
            try:
                result = self._post(
                    service,
                    operation,
                    body,
                    endpoint_family=endpoint_family,
                    use_session_envelope=envelope,
                    timeout=http_timeout,
                )
                _tc_logger.info(f"  where_used: {label} succeeded")
                successful_attempt = (endpoint_family, service, operation)
                break
            except TcSoaError as e:
                _tc_logger.warning(f"  where_used: {label} failed: {e}")

        if result is None:
            _tc_logger.warning("  where_used: all endpoints failed, returning empty")
            return []

        parents = []

        # Parse output[].info[].parentItemRev / parentObject
        output = result.get("output", [])
        for entry in output:
            if not isinstance(entry, dict):
                continue
            for uid in self._extract_where_used_parent_uids(entry):
                if uid and uid != item_revision_uid and uid != self._TC_NULL_UID:
                    parents.append(uid)

        # Fallback: ItemRevision objects in ServiceData.modelObjects
        svc_data = result.get("ServiceData") or result.get("serviceData") or {}
        if isinstance(svc_data, dict):
            for uid_key, obj in svc_data.get("modelObjects", {}).items():
                if isinstance(obj, dict) and "Revision" in obj.get("type", ""):
                    if uid_key != item_revision_uid and uid_key != self._TC_NULL_UID:
                        parents.append(uid_key)

        seen = set()
        unique_parents = []
        for uid in parents:
            if uid not in seen:
                seen.add(uid)
                unique_parents.append(uid)

        _tc_logger.info(f"  where_used found {len(unique_parents)} parents")
        # Cache result and remember the winning strategy for this run.
        self._where_used_cache[item_revision_uid] = list(unique_parents)
        if successful_attempt is not None and self._where_used_strategy is None:
            self._where_used_strategy = successful_attempt
            _tc_logger.info(f"  where_used: sticky strategy locked to {successful_attempt[:3]}")
        return unique_parents

    def resolve_item_to_revision_uid(self, item_id, revision_id=None):
        """
        Resolve an item_id (e.g. '3233143') to its ItemRevision UID.
        Optionally filter by revision_id (e.g. 'C').
        Reuses the 'Item Revision...' saved query.
        """
        if not item_id:
            return None

        base_id, rev_from_id = self.split_item_id_and_revision(item_id)
        if not base_id:
            return None
        if revision_id is None and rev_from_id:
            revision_id = rev_from_id

        _tc_logger.info(f"resolve_item_to_revision_uid: {base_id}/{revision_id or '*'}")

        try:
            uids = self.execute_saved_query(
                "Item Revision...", ["Item ID"], [str(base_id)]
            )
        except TcSoaError as e:
            _tc_logger.warning(f"  Saved query failed for {item_id}: {e}")
            return None

        if not uids:
            _tc_logger.info(f"  No UIDs found for {base_id}")
            return None

        if not revision_id or len(uids) == 1:
            _tc_logger.info(f"  Resolved {base_id} → {uids[0]}")
            return uids[0]

        # Multiple revisions — fetch properties to match revision_id
        try:
            props = self.get_properties(uids, ["item_revision_id"])
            for uid in uids:
                rev = props.get(uid, {}).get("item_revision_id", "")
                if rev.upper() == revision_id.upper():
                    _tc_logger.info(f"  Resolved {base_id}/{revision_id} → {uid}")
                    return uid
        except TcSoaError:
            pass

        # Fallback: return first
        _tc_logger.info(f"  Could not match revision {revision_id}, returning first UID")
        return uids[0]

    def find_top_level_assembly(self, item_id, revision_id=None, max_levels=20):
        """
        Climb where-used chain from item_id to find the highest-level assembly.

        Returns dict:
            {
                "root_item_id": "RLN4MA",
                "root_revision_id": "D",
                "root_uid": "BoHAknFJoeVOgD",
                "chain": ["3233143", "3232926", "RLN4MA"],
                "found": True
            }
        Or {"found": False, "chain": [item_id], "error": "..."} on failure.
        """
        base_id, rev_from_id = self.split_item_id_and_revision(item_id)
        if not base_id:
            return {"found": False, "chain": [item_id], "error": "Empty item id"}

        if revision_id is None and rev_from_id:
            revision_id = rev_from_id

        # Memoize: same item asked twice in a run -> instant.
        cache_key = (base_id, (revision_id or "").upper())
        cached_top = self._top_level_cache.get(cache_key)
        if cached_top is not None:
            _tc_logger.info(
                f"find_top_level_assembly: {base_id}/{revision_id or '*'} (cache hit)"
            )
            return dict(cached_top)

        _tc_logger.info(f"find_top_level_assembly: {base_id}/{revision_id or '*'}")

        # Step 1: Resolve item_id to UID (saved query uses bare Item ID only)
        current_uid = self.resolve_item_to_revision_uid(base_id, revision_id)
        if not current_uid:
            return {"found": False, "chain": [base_id], "error": "Could not resolve item to UID"}

        chain = [base_id]
        visited = {current_uid}

        for level in range(max_levels):
            parents = self.where_used(current_uid)
            if not parents:
                # No more parents — current is the root
                break

            # Pick first parent (primary assembly path)
            parent_uid = parents[0]
            if parent_uid in visited:
                _tc_logger.warning(f"  Cycle detected at level {level}")
                break
            visited.add(parent_uid)

            # Get parent's item_id (use cache to skip already-known uids).
            cached_props = self._item_props_cache.get(parent_uid)
            if cached_props is not None:
                parent_item_id = cached_props.get("item_id", "")
                parent_rev_id = cached_props.get("item_revision_id", "")
            else:
                try:
                    props = self.get_properties(
                        [parent_uid],
                        ["item_id", "item_revision_id", "object_name"],
                    )
                    parent_props = props.get(parent_uid, {})
                    parent_item_id = parent_props.get("item_id", "")
                    parent_rev_id = parent_props.get("item_revision_id", "")
                    if parent_props:
                        self._item_props_cache[parent_uid] = dict(parent_props)
                except TcSoaError:
                    parent_item_id = ""
                    parent_rev_id = ""

            if parent_item_id:
                chain.append(parent_item_id)
            current_uid = parent_uid

        # Current_uid is now the root
        # Get final properties (cache hit avoids round trip)
        root_item_id = chain[-1] if chain else base_id
        root_rev_id = ""
        cached_root = self._item_props_cache.get(current_uid)
        if cached_root is not None:
            root_item_id = cached_root.get("item_id", root_item_id)
            root_rev_id = cached_root.get("item_revision_id", "")
        else:
            try:
                props = self.get_properties([current_uid], ["item_id", "item_revision_id", "object_name"])
                root_props = props.get(current_uid, {})
                root_item_id = root_props.get("item_id", root_item_id)
                root_rev_id = root_props.get("item_revision_id", "")
                if root_props:
                    self._item_props_cache[current_uid] = dict(root_props)
            except TcSoaError:
                pass

        _tc_logger.info(f"  Top-level: {root_item_id}/{root_rev_id} (chain: {' → '.join(chain)})")
        result_dict = {
            "root_item_id": root_item_id,
            "root_revision_id": root_rev_id,
            "root_uid": current_uid,
            "chain": chain,
            "found": True,
        }
        # Cache for the rest of the run.
        self._top_level_cache[cache_key] = dict(result_dict)
        return result_dict

    # ------------------------------------------------------------------
    # BOM / STRUCTURE OPERATIONS — Exact EXE flow
    # ------------------------------------------------------------------

    def get_revision_rules(self):
        """
        Get all revision rules via Cad-2007-01-StructureManagement/getRevisionRules.
        Returns dict of {rule_name: rule_uid}.
        """
        if isinstance(self._revision_rules_cache, dict) and self._revision_rules_cache:
            return dict(self._revision_rules_cache)

        result = self._post(
            "Cad-2007-01-StructureManagement", "getRevisionRules", {}
        )

        rules = {}
        output = result.get('output', [])
        for entry in output:
            rev_rule = entry.get('revRule', {})
            rule_uid = rev_rule.get('uid', '') if isinstance(rev_rule, dict) else rev_rule
            if rule_uid:
                # Get the name from the revRule object properties
                rule_name = ""
                props = rev_rule.get('props', {}) if isinstance(rev_rule, dict) else {}
                name_prop = props.get('object_name', {})
                if name_prop:
                    ui_vals = name_prop.get('uiValues', [])
                    db_vals = name_prop.get('dbValues', [])
                    rule_name = (ui_vals[0] if ui_vals else db_vals[0] if db_vals else "")
                if rule_name:
                    rules[rule_name] = rule_uid

        # If names weren't embedded, fetch them via getProperties
        if not rules:
            rule_uids = []
            for entry in output:
                rev_rule = entry.get('revRule', {})
                uid = rev_rule.get('uid', '') if isinstance(rev_rule, dict) else rev_rule
                if uid:
                    rule_uids.append(uid)
            if rule_uids:
                props = self.get_properties(rule_uids, ["object_name"])
                for uid, prop_dict in props.items():
                    name = prop_dict.get("object_name", "")
                    if name:
                        rules[name] = uid

        _tc_logger.info(f"  Found {len(rules)} revision rules")
        self._revision_rules_cache = dict(rules)
        return rules

    def get_bom_for_item_revision(self, item_rev_uid):
        """
        Get BOM children for an item revision, following the EXACT EXE flow:
        1. Set BOM policy
        2. Get items_tag from item revision -> Item UID
        3. Get bom_view_tags from Item -> find PLM View
        4. Get revision rules -> find HSM_WIP_Latest_Production_Released
        5. CreateBOMWindows with all pieces
        6. ExpandPSOneLevel
        7. Read child properties

        Args:
            item_rev_uid: UID of the item revision

        Returns:
            List of child dicts: [{"uid": ..., "item_id": ..., "rev_id": ...}]
        """
        started_at = time.perf_counter()
        _tc_logger.info(f"get_bom_for_item_revision: {item_rev_uid}")

        # Step 1: Set BOM policy — matches EXE's setObjectPolicy_BOM
        self.set_property_policy({
            "BOMLine": BOM_LINE_POLICY_PROPS,
            "RevisionRule": REV_RULE_POLICY_PROPS
        })

        # Step 2: Get items_tag from item revision to get the parent Item
        _tc_logger.info("  Step 2: Getting items_tag from item revision")
        rev_props = self.get_properties([item_rev_uid], ["items_tag"])
        items_tag = rev_props.get(item_rev_uid, {}).get("items_tag", "")

        # items_tag may be a UID string or need extraction from modelObjects
        item_uid = items_tag
        if not item_uid:
            # Try to extract from serviceData modelObjects
            _tc_logger.warning("  items_tag not found directly, trying alternate extraction")
            raise TcSoaError(f"Could not get parent Item from item revision {item_rev_uid}")

        _tc_logger.info(f"  Parent Item UID: {item_uid}")

        # Step 3: Get bom_view_tags from Item, find one with view_type = "PLM View"
        _tc_logger.info("  Step 3: Getting bom_view_tags from Item")
        item_props = self.get_properties([item_uid], ["bom_view_tags"])
        bom_view_tags = item_props.get(item_uid, {}).get("bom_view_tags", "")

        # bom_view_tags may be a single UID or list
        bom_view_uids = []
        if isinstance(bom_view_tags, list):
            bom_view_uids = bom_view_tags
        elif bom_view_tags:
            bom_view_uids = [bom_view_tags]

        bom_view_uid = None
        if bom_view_uids:
            # Check view_type for each to find "PLM View"
            view_props = self.get_properties(bom_view_uids, ["view_type"])
            for vid in bom_view_uids:
                vtype = view_props.get(vid, {}).get("view_type", "")
                _tc_logger.info(f"    BOM view {vid}: view_type='{vtype}'")
                if vtype == HSM_BOM_VIEW_TYPE:
                    bom_view_uid = vid
                    break
            # If no PLM View found, use the first one
            if not bom_view_uid and bom_view_uids:
                bom_view_uid = bom_view_uids[0]
                _tc_logger.warning(f"  No '{HSM_BOM_VIEW_TYPE}' view found, using first: {bom_view_uid}")

        _tc_logger.info(f"  BOM View UID: {bom_view_uid}")

        # Step 4: Get revision rules, find the right one
        _tc_logger.info("  Step 4: Getting revision rules")
        rev_rule_started_at = time.perf_counter()
        rev_rules = self.get_revision_rules()
        rev_rule_elapsed_ms = (time.perf_counter() - rev_rule_started_at) * 1000.0
        if rev_rule_elapsed_ms > 500:
            _tc_logger.info(f"  Revision rule lookup took {rev_rule_elapsed_ms:.1f} ms")
        rev_rule_uid = ""
        selected_rule_name = ""
        for rule_name in HSM_REVISION_RULE_FALLBACKS:
            candidate_uid = rev_rules.get(rule_name, "")
            if candidate_uid:
                rev_rule_uid = candidate_uid
                selected_rule_name = rule_name
                break
        if not rev_rule_uid:
            _tc_logger.warning(
                "  No configured revision rule found. Tried "
                f"{HSM_REVISION_RULE_FALLBACKS}. "
                f"Available: {list(rev_rules.keys())[:10]}"
            )
            # Continue without revision rule
        else:
            _tc_logger.info(
                f"  Using revision rule '{selected_rule_name}' UID: {rev_rule_uid}"
            )

        # Step 5: CreateBOMWindows — matches EXE's CreateBOMWindowsInfo
        _tc_logger.info("  Step 5: CreateBOMWindows")
        def _build_create_info(use_uid_dicts, include_bom_view):
            if use_uid_dicts:
                info = {
                    "item": {"uid": item_uid},
                    "itemRev": {"uid": item_rev_uid},
                }
                if include_bom_view and bom_view_uid:
                    info["bomView"] = {"uid": bom_view_uid}
                if rev_rule_uid:
                    info["revRuleConfigInfo"] = {"revRule": {"uid": rev_rule_uid}}
                return info

            info = {
                "item": item_uid,
                "itemRev": item_rev_uid,
            }
            if include_bom_view and bom_view_uid:
                info["bomView"] = bom_view_uid
            if rev_rule_uid:
                info["revRuleConfigInfo"] = {"revRule": rev_rule_uid}
            return info

        create_attempts = []
        include_view_opts = [True, False] if bom_view_uid else [False]
        for include_view in include_view_opts:
            for use_uid_dicts in (True, False):
                info_payload = _build_create_info(use_uid_dicts, include_view)
                create_attempts.append({
                    "payload_key": "info",
                    "include_view": include_view,
                    "use_uid_dicts": use_uid_dicts,
                    "body": {"info": [info_payload]},
                })
                create_attempts.append({
                    "payload_key": "input",
                    "include_view": include_view,
                    "use_uid_dicts": use_uid_dicts,
                    "body": {"input": [info_payload]},
                })

        create_cache = self._bom_create_mode_cache
        if create_cache:
            def _create_match(a):
                return (
                    a.get("payload_key") == create_cache.get("payload_key")
                    and a.get("include_view") == create_cache.get("include_view")
                    and a.get("use_uid_dicts") == create_cache.get("use_uid_dicts")
                )
            create_attempts = sorted(create_attempts, key=lambda a: 0 if _create_match(a) else 1)

        # Transport/payload fallbacks for TC sites that only accept specific bindings.
        create_modes = [
            ("JsonRestServices", True),
            ("JsonRestServices", False),
            ("RestServices", True),
            ("RestServices", False),
        ]
        if create_cache:
            preferred_mode = (
                create_cache.get("endpoint_family"),
                bool(create_cache.get("use_session_envelope")),
            )
            if preferred_mode in create_modes:
                create_modes = [preferred_mode] + [m for m in create_modes if m != preferred_mode]

        result = None
        top_line_uid = ""
        create_last_error = None
        for attempt in create_attempts:
            attempt_label = (
                "create("
                f"{attempt.get('payload_key')}:{'with' if attempt.get('include_view') else 'without'} bomView, "
                f"{'uid-dicts' if attempt.get('use_uid_dicts') else 'uid-strings'})"
            )
            attempt_body = attempt.get("body", {})
            for endpoint_family, use_session_envelope in create_modes:
                try:
                    _tc_logger.info(
                        "  Trying createBOMWindows "
                        f"{attempt_label}, endpoint_family={endpoint_family}, "
                        f"use_session_envelope={use_session_envelope}"
                    )
                    create_result = self._post(
                        "Cad-2007-01-StructureManagement",
                        "createBOMWindows",
                        attempt_body,
                        endpoint_family=endpoint_family,
                        use_session_envelope=use_session_envelope,
                    )

                    create_output = create_result.get("output", [])
                    if not create_output:
                        _tc_logger.warning(
                            "  createBOMWindows returned empty output; "
                            "trying next compatibility mode: "
                            f"{attempt_label}, endpoint_family={endpoint_family}, "
                            f"use_session_envelope={use_session_envelope}"
                        )
                        continue

                    first_entry = create_output[0] if isinstance(create_output[0], dict) else {}
                    top_line = first_entry.get("bomLine", {}) if isinstance(first_entry, dict) else {}
                    candidate_top_uid = top_line.get("uid", "") if isinstance(top_line, dict) else str(top_line or "")
                    if not candidate_top_uid:
                        _tc_logger.warning(
                            "  createBOMWindows returned no top bomLine UID; "
                            "trying next compatibility mode: "
                            f"{attempt_label}, endpoint_family={endpoint_family}, "
                            f"use_session_envelope={use_session_envelope}"
                        )
                        continue

                    result = create_result
                    top_line_uid = candidate_top_uid
                    self._bom_create_mode_cache = {
                        "payload_key": attempt.get("payload_key"),
                        "include_view": attempt.get("include_view"),
                        "use_uid_dicts": attempt.get("use_uid_dicts"),
                        "endpoint_family": endpoint_family,
                        "use_session_envelope": bool(use_session_envelope),
                    }
                    _tc_logger.info(
                        "  createBOMWindows mode selected: "
                        f"{attempt_label}, endpoint_family={endpoint_family}, "
                        f"use_session_envelope={use_session_envelope}"
                    )
                    create_last_error = None
                    break
                except TcSoaError as exc:
                    create_last_error = exc
                    if self._is_dom_parse_error(exc):
                        _tc_logger.warning(
                            "  createBOMWindows parse failure, retrying with compatibility mode: "
                            f"{attempt_label}, endpoint_family={endpoint_family}, "
                            f"use_session_envelope={use_session_envelope}"
                        )
                        continue
                    raise
            if result is not None:
                break

        if result is None:
            raise create_last_error or TcSoaError(
                "Failed to create BOM window — no compatible response with output and top BOM line"
            )
        _tc_logger.info(f"  Top BOM line UID: {top_line_uid}")

        # Step 6: ExpandPSOneLevel — matches EXE's ExpandPSOneLevelInfo
        _tc_logger.info("  Step 6: ExpandPSOneLevel")
        expand_body = {
            "input": {
                "parentBomLines": [{"uid": top_line_uid}],
                "excludeFilter": "None"
            },
            "pref": {
                "expItemRev": False
            }
        }
        expand_modes = [
            ("JsonRestServices", True),
            ("JsonRestServices", False),
            ("RestServices", True),
            ("RestServices", False),
        ]
        expand_cache = self._bom_expand_mode_cache
        if expand_cache:
            preferred_expand_mode = (
                expand_cache.get("endpoint_family"),
                bool(expand_cache.get("use_session_envelope")),
            )
            if preferred_expand_mode in expand_modes:
                expand_modes = [preferred_expand_mode] + [m for m in expand_modes if m != preferred_expand_mode]
        expand_result = None
        expand_last_error = None
        for endpoint_family, use_session_envelope in expand_modes:
            try:
                _tc_logger.info(
                    "  Trying expandPSOneLevel "
                    f"endpoint_family={endpoint_family}, "
                    f"use_session_envelope={use_session_envelope}"
                )
                expand_result = self._post(
                    "Cad-2007-01-StructureManagement",
                    "expandPSOneLevel",
                    expand_body,
                    endpoint_family=endpoint_family,
                    use_session_envelope=use_session_envelope,
                )
                self._bom_expand_mode_cache = {
                    "endpoint_family": endpoint_family,
                    "use_session_envelope": bool(use_session_envelope),
                }
                expand_last_error = None
                break
            except TcSoaError as exc:
                expand_last_error = exc
                if self._is_dom_parse_error(exc):
                    _tc_logger.warning(
                        "  expandPSOneLevel parse failure, retrying with compatibility mode: "
                        f"endpoint_family={endpoint_family}, "
                        f"use_session_envelope={use_session_envelope}"
                    )
                    continue
                raise
        if expand_result is None:
            raise expand_last_error or TcSoaError("expandPSOneLevel failed")

        # Step 7: Extract child BOM lines and read their properties
        children = []
        expand_output = expand_result.get('output', [])
        for entry in expand_output:
            child_data = entry.get('children', [])
            for child in child_data:
                child_bomline = child.get('bomLine', child)
                if isinstance(child_bomline, dict):
                    uid = child_bomline.get('uid', '')
                    if uid:
                        children.append({"uid": uid})
                elif isinstance(child_bomline, str) and child_bomline:
                    children.append({"uid": child_bomline})

        _tc_logger.info(f"  Found {len(children)} child BOM lines")

        # Get properties for child BOM lines
        if children:
            child_uids = [c['uid'] for c in children if c['uid']]
            if child_uids:
                props = self.get_properties(child_uids, BOM_LINE_POLICY_PROPS)
                for child in children:
                    uid = child['uid']
                    if uid in props:
                        child['item_id'] = props[uid].get('bl_item_item_id', '')
                        child['rev_id'] = props[uid].get('bl_rev_item_revision_id', '')
                        child['quantity'] = props[uid].get('bl_quantity', '')

        # Filter to only children that have a revision ID (matches EXE behavior)
        children = [c for c in children if c.get('rev_id')]

        elapsed_ms = (time.perf_counter() - started_at) * 1000.0
        _tc_logger.info(
            f"  Returning {len(children)} children with revision IDs "
            f"(elapsed {elapsed_ms:.1f} ms)"
        )
        return children


# ============================================================================
# TC LOGIN DIALOG — PyQt6
# ============================================================================

class TcLoginDialog(QDialog):
    """Login dialog for Teamcenter connection."""

    def __init__(self, tc_config=None, parent=None):
        super().__init__(parent)
        self.setWindowTitle("Connect to Teamcenter")
        self.setFixedSize(420, 280)
        self._client = None
        self._config = tc_config or {}

        layout = QVBoxLayout(self)
        layout.setSpacing(12)

        title = QLabel("Teamcenter Connection")
        title.setFont(QFont("Calibri", 14, QFont.Weight.Bold))
        title.setStyleSheet("color: #7719AA;")
        layout.addWidget(title)

        form = QFormLayout()
        form.setSpacing(8)

        self.url_edit = QLineEdit()
        self.url_edit.setPlaceholderText("http://server:8080/tc")
        self.url_edit.setText(self._config.get("server_url", ""))
        form.addRow("Server URL:", self.url_edit)

        self.user_edit = QLineEdit()
        self.user_edit.setPlaceholderText("TC username")
        self.user_edit.setText(self._config.get("username", ""))
        form.addRow("Username:", self.user_edit)

        self.pass_edit = QLineEdit()
        self.pass_edit.setEchoMode(QLineEdit.EchoMode.Password)
        self.pass_edit.setPlaceholderText("TC password")
        form.addRow("Password:", self.pass_edit)

        layout.addLayout(form)

        remember_layout = QHBoxLayout()
        self.remember_url = QCheckBox("Remember URL")
        self.remember_url.setChecked(self._config.get("remember_url", True))
        remember_layout.addWidget(self.remember_url)
        self.remember_user = QCheckBox("Remember Username")
        self.remember_user.setChecked(self._config.get("remember_username", True))
        remember_layout.addWidget(self.remember_user)
        layout.addLayout(remember_layout)

        self.status_label = QLabel("")
        self.status_label.setStyleSheet("color: #666; font-size: 11px;")
        self.status_label.setWordWrap(True)
        layout.addWidget(self.status_label)

        btn_layout = QHBoxLayout()
        btn_layout.addStretch()

        self.connect_btn = QPushButton("Connect")
        self.connect_btn.setStyleSheet("""
            QPushButton {
                background-color: #7719AA; color: white; border: none;
                padding: 8px 24px; border-radius: 4px; font-weight: bold;
            }
            QPushButton:hover { background-color: #9B59B6; }
            QPushButton:disabled { background-color: #C0C0C0; }
        """)
        self.connect_btn.clicked.connect(self._on_connect)
        btn_layout.addWidget(self.connect_btn)

        cancel_btn = QPushButton("Cancel")
        cancel_btn.setStyleSheet("padding: 8px 16px;")
        cancel_btn.clicked.connect(self.reject)
        btn_layout.addWidget(cancel_btn)

        layout.addLayout(btn_layout)

        if not self.url_edit.text():
            self.url_edit.setFocus()
        elif not self.user_edit.text():
            self.user_edit.setFocus()
        else:
            self.pass_edit.setFocus()

    def _on_connect(self):
        """Handle connect button click."""
        url = self.url_edit.text().strip()
        username = self.user_edit.text().strip()
        password = self.pass_edit.text()

        if not url:
            self.status_label.setText("Please enter the TC server URL.")
            self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
            return
        if not username or not password:
            self.status_label.setText("Please enter username and password.")
            self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
            return

        self.connect_btn.setEnabled(False)
        self.status_label.setText("Connecting to TC server...")
        self.status_label.setStyleSheet("color: #666; font-size: 11px;")

        from PyQt6.QtWidgets import QApplication
        QApplication.processEvents()

        try:
            # Longer than default 60s: GUI login hits JsonRestServices; Rich Client/AW use other routes and can work when HTTP is slow.
            client = TcSoaClient(url, post_timeout=180)

            reachable, msg = client.test_connection()
            if not reachable:
                self.status_label.setText(f"Server not reachable: {msg}")
                self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
                self.connect_btn.setEnabled(True)
                return

            self.status_label.setText("Authenticating...")
            QApplication.processEvents()

            client.login(username, password)

            self._client = client
            self.status_label.setText("Connected successfully!")
            self.status_label.setStyleSheet("color: #28a745; font-size: 11px;")

            QTimer.singleShot(500, self.accept)

        except TcAuthError as e:
            self.status_label.setText(f"Authentication failed: {e}")
            self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
            self.connect_btn.setEnabled(True)
        except TcConnectionError as e:
            self.status_label.setText(
                f"{e}\n\n"
                "Tip: Thick Client / Active Workspace can work while this dialog fails — they do not use "
                "the same HTTP SOA path as port 8080 JsonRestServices. Retry, or ask IT to check the Web Tier."
            )
            self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
            self.connect_btn.setEnabled(True)
        except Exception as e:
            self.status_label.setText(f"Unexpected error: {e}")
            self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
            self.connect_btn.setEnabled(True)

    def get_client(self):
        """Return the connected TcSoaClient instance."""
        return self._client

    def get_config(self):
        """Return config dict to save (URL, username, preferences)."""
        config = {
            "remember_url": self.remember_url.isChecked(),
            "remember_username": self.remember_user.isChecked(),
        }
        if self.remember_url.isChecked():
            config["server_url"] = self.url_edit.text().strip()
        else:
            config["server_url"] = ""
        if self.remember_user.isChecked():
            config["username"] = self.user_edit.text().strip()
        else:
            config["username"] = ""
        return config


# ============================================================================
# TC SEARCH DIALOG — PyQt6
# ============================================================================

class TcSearchDialog(QDialog):
    """Search dialog for specifying which ECN data to fetch from TC."""

    def __init__(self, client, parent=None):
        super().__init__(parent)
        self.setWindowTitle("Fetch ECN Data from Teamcenter")
        self.setFixedSize(480, 340)
        self._client = client
        self._results = []

        layout = QVBoxLayout(self)
        layout.setSpacing(12)

        title = QLabel("Search Teamcenter")
        title.setFont(QFont("Calibri", 14, QFont.Weight.Bold))
        title.setStyleSheet("color: #7719AA;")
        layout.addWidget(title)

        mode_group = QGroupBox("Search by")
        mode_layout = QHBoxLayout(mode_group)
        self.mode_btn_group = QButtonGroup(self)

        self.rb_ecn = QRadioButton("ECN Number")
        self.rb_ecn.setChecked(True)
        self.mode_btn_group.addButton(self.rb_ecn, 0)
        mode_layout.addWidget(self.rb_ecn)

        self.rb_pr = QRadioButton("PR Number")
        self.mode_btn_group.addButton(self.rb_pr, 1)
        mode_layout.addWidget(self.rb_pr)

        self.rb_item = QRadioButton("Item ID")
        self.mode_btn_group.addButton(self.rb_item, 2)
        mode_layout.addWidget(self.rb_item)

        self.rb_case = QRadioButton("Case Nomenclature")
        self.mode_btn_group.addButton(self.rb_case, 3)
        mode_layout.addWidget(self.rb_case)

        layout.addWidget(mode_group)

        input_layout = QFormLayout()
        self.search_edit = QLineEdit()
        self.search_edit.setPlaceholderText("Enter ID(s), comma-separated for multiple")
        input_layout.addRow("Search:", self.search_edit)
        layout.addLayout(input_layout)

        self.progress = QProgressBar()
        self.progress.setVisible(False)
        layout.addWidget(self.progress)

        self.status_label = QLabel("")
        self.status_label.setStyleSheet("color: #666; font-size: 11px;")
        self.status_label.setWordWrap(True)
        layout.addWidget(self.status_label)

        self.log_text = QTextEdit()
        self.log_text.setReadOnly(True)
        self.log_text.setMaximumHeight(150)
        self.log_text.setStyleSheet("font-size: 10px; font-family: 'Consolas'; background: #F9F7FB;")
        self.log_text.setVisible(False)
        layout.addWidget(self.log_text)

        btn_layout = QHBoxLayout()
        btn_layout.addStretch()

        self.fetch_btn = QPushButton("Fetch Data")
        self.fetch_btn.setStyleSheet("""
            QPushButton {
                background-color: #7719AA; color: white; border: none;
                padding: 8px 24px; border-radius: 4px; font-weight: bold;
            }
            QPushButton:hover { background-color: #9B59B6; }
            QPushButton:disabled { background-color: #C0C0C0; }
        """)
        self.fetch_btn.clicked.connect(self._on_fetch)
        btn_layout.addWidget(self.fetch_btn)

        cancel_btn = QPushButton("Cancel")
        cancel_btn.setStyleSheet("padding: 8px 16px;")
        cancel_btn.clicked.connect(self.reject)
        btn_layout.addWidget(cancel_btn)

        layout.addLayout(btn_layout)

        self.search_edit.setFocus()

    def _log(self, msg):
        """Append a message to the log area."""
        self.log_text.setVisible(True)
        self.log_text.append(msg)
        from PyQt6.QtWidgets import QApplication
        QApplication.processEvents()

    @staticmethod
    def _sanitize_filename_token(text):
        token = str(text or "").strip().lower()
        token = re.sub(r"[^a-z0-9]+", "_", token)
        token = token.strip("_")
        return token or "nomenclature"

    @staticmethod
    def _csv_safe(value):
        if isinstance(value, (list, dict)):
            return json.dumps(value, ensure_ascii=True)
        if value is None:
            return ""
        return value

    def _write_csv_file(self, file_path, rows, fieldnames):
        with open(file_path, "w", newline="", encoding="utf-8-sig") as f:
            writer = csv.DictWriter(f, fieldnames=fieldnames, extrasaction="ignore")
            writer.writeheader()
            for row in rows:
                if not isinstance(row, dict):
                    continue
                writer.writerow({k: self._csv_safe(row.get(k, "")) for k in fieldnames})

    def _write_csv_with_fallback(self, file_path, rows, fieldnames):
        try:
            self._write_csv_file(file_path, rows, fieldnames)
            return file_path, ""
        except PermissionError:
            base, ext = os.path.splitext(file_path)
            stamp = datetime.datetime.now().strftime("%Y%m%d_%H%M%S")
            fallback_path = f"{base}_{stamp}{ext}"
            suffix = 1
            while os.path.exists(fallback_path):
                fallback_path = f"{base}_{stamp}_{suffix}{ext}"
                suffix += 1
            self._write_csv_file(fallback_path, rows, fieldnames)
            warning = (
                f"Original file locked: {file_path}. "
                f"Wrote fallback file: {fallback_path}"
            )
            return fallback_path, warning

    def _export_case_bom_csv(self, nomenclature, bom_result, flat_rows):
        token = self._sanitize_filename_token(nomenclature)
        export_dir = _log_dir
        bom = bom_result.get("bom", {}) or {}
        nodes = bom.get("nodes", []) or []
        bom_path = os.path.join(export_dir, f"{token}_bom.csv")

        node_fields = [
            "depth", "item_id", "item_revision_id", "object_name",
            "h4_Nomenclature", "release_status_list", "process_stage",
        ]
        written_bom_path, warn_bom = self._write_csv_with_fallback(bom_path, nodes, node_fields)
        warnings = [w for w in [warn_bom] if w]

        return {
            "bom": written_bom_path,
            "warnings": warnings,
        }

    def _on_fetch(self):
        """Handle fetch button click."""
        search_text = self.search_edit.text().strip()
        if not search_text:
            self.status_label.setText("Please enter search criteria.")
            self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
            return

        search_ids = [s.strip() for s in search_text.split(',') if s.strip()]
        mode = self.mode_btn_group.checkedId()

        self.fetch_btn.setEnabled(False)
        self.progress.setVisible(True)
        self.progress.setRange(0, len(search_ids) * 3)
        self.progress.setValue(0)
        self.status_label.setText("Fetching data...")
        self.status_label.setStyleSheet("color: #666; font-size: 11px;")

        from PyQt6.QtWidgets import QApplication

        try:
            fetcher = TcEcnDataFetcher(self._client)
            all_rows = []

            for i, search_id in enumerate(search_ids):
                self._log(f"Searching for: {search_id}")
                self.progress.setValue(i * 3)
                QApplication.processEvents()

                if mode == 0:  # ECN Number
                    rows = fetcher.fetch_ecn_data(search_id)
                elif mode == 1:  # PR Number
                    rows = fetcher.fetch_pr_data(search_id)
                elif mode == 2:  # Item ID
                    rows = fetcher.fetch_item_data(search_id)
                else:  # Case Nomenclature
                    def _bom_progress(processed, queued, depth, stage="Expanding level"):
                        self.status_label.setText(
                            f"Searching for: {search_id} BOM... {stage}. "
                            f"{processed} nodes processed (depth {depth}, queue {queued})"
                        )
                        QApplication.processEvents()

                    bom_result = fetcher.fetch_bom_by_nomenclature(
                        search_id,
                        recursive=True,
                        progress_callback=_bom_progress,
                        max_nodes=1200,
                        max_seconds=900,
                    )
                    self.status_label.setText(f"Searching for: {search_id} BOM... Writing CSV")
                    QApplication.processEvents()
                    rows = fetcher.flatten_bom_result_to_rows(bom_result)
                    export_paths = self._export_case_bom_csv(search_id, bom_result, rows)
                    bom_data = bom_result.get('bom', {})
                    node_count = bom_data.get('visited_count', 0)
                    bom_nodes = bom_data.get('nodes', [])
                    max_depth = max((n.get('depth', 0) for n in bom_nodes), default=0) if bom_nodes else 0
                    truncated = bool(bom_data.get("truncated"))
                    self._log(
                        f"  BOM: {node_count} parts found, {max_depth} levels deep"
                    )
                    if truncated:
                        self._log(
                            f"  BOM traversal capped: {bom_data.get('truncate_reason', 'unknown')}. "
                            f"Queue remaining: {bom_data.get('queue_remaining', 0)}"
                        )
                    # Save hierarchical tree files
                    try:
                        tree_paths = fetcher.save_bom_tree_files(bom_result)
                        self._log(f"  Tree JSON: {tree_paths['json']}")
                        self._log(f"  Tree TXT:  {tree_paths['txt']}")
                    except Exception as tree_err:
                        self._log(f"  Warning: Could not save tree files: {tree_err}")
                        _tc_logger.warning(f"save_bom_tree_files failed: {tree_err}")
                    for warn in export_paths.get("warnings", []):
                        self._log(f"  Warning: {warn}")
                    self._log(f"  CSV BOM:  {export_paths['bom']}")

                self._log(f"  Found {len(rows)} items")
                self.progress.setValue(i * 3 + 3)
                QApplication.processEvents()
                all_rows.extend(rows)

            self._results = all_rows
            self.progress.setValue(self.progress.maximum())
            self.status_label.setText(f"Fetched {len(all_rows)} items from {len(search_ids)} search(es).")
            self.status_label.setStyleSheet("color: #28a745; font-size: 11px;")
            self._log(f"Total: {len(all_rows)} items fetched")

            if all_rows:
                QTimer.singleShot(800, self.accept)
            else:
                self.status_label.setText("No items found. Try a different search.")
                self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
                self.fetch_btn.setEnabled(True)

        except TcAuthError as e:
            self.status_label.setText(f"Session expired: {e}")
            self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
            self._log(f"AUTH ERROR: {e}")
            self.fetch_btn.setEnabled(True)
        except TcSoaError as e:
            self.status_label.setText(f"TC error: {e}")
            self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
            self._log(f"TC ERROR: {e}")
            self._log(f"Debug log saved to: {_log_file}")
            self.fetch_btn.setEnabled(True)
        except Exception as e:
            import traceback
            self.status_label.setText(f"Error: {e}")
            self.status_label.setStyleSheet("color: #dc3545; font-size: 11px;")
            self._log(f"ERROR: {type(e).__name__}: {e}")
            self._log(f"Debug log saved to: {_log_file}")
            _tc_logger.error(f"Unexpected error: {traceback.format_exc()}")
            self.fetch_btn.setEnabled(True)

    def get_results(self):
        """Return list of row dicts fetched from TC."""
        return self._results


# ============================================================================
# TC ECN DATA FETCHER — Business Logic (matches CHECKSHEET.exe flow)
# ============================================================================

class TcEcnDataFetcher:
    """
    Fetches ECN workflow data from TC following the exact sequence
    proven by the decompiled CHECKSHEET.exe.
    """

    def __init__(self, client):
        self.client = client

    def fetch_ecn_data(self, ecn_number):
        """
        Fetch all data for an ECN following the EXE's Generate_CheckSheet flow:
        1. Detect ECN type from ID
        2. Set ECN property policy
        3. Find ECN via "Item Revision..." query
        4. Set CheckSheet property policy
        5. Expand CMHasSolutionItem filtered to H4_Hussmann_ItemRevision
        6. For each solution item, get parent Item properties

        Returns:
            List of row dicts, one per solution item
        """
        _tc_logger.info(f"fetch_ecn_data: {ecn_number}")

        # Step 1: Detect ECN type
        ecn_type = get_ecn_type(ecn_number)
        _tc_logger.info(f"  ECN type: {ecn_type}")

        # Step 2: Set ECN property policy
        self.client.set_property_policy({
            ecn_type: ECN_POLICY_PROPS
        })

        # Step 3: Find ECN via "Item Revision..." with ["Item ID"]
        ecn_uids = self.client.execute_saved_query(
            "Item Revision...", ["Item ID"], [ecn_number]
        )
        if not ecn_uids:
            _tc_logger.warning(f"  ECN '{ecn_number}' not found")
            return []

        _tc_logger.info(f"  Found {len(ecn_uids)} ECN UIDs")

        # Get ECN properties
        ecn_props = self.client.get_properties(ecn_uids, ECN_POLICY_PROPS)

        # Step 4: Set CheckSheet property policy
        self.client.set_property_policy({
            "H4_Hussmann_ItemRevision": CHECKSHEET_POLICY_PROPS
        })

        # Step 5: Expand CMHasSolutionItem filtered to H4_Hussmann_ItemRevision
        solution_map = self.client.expand_grm_relations(
            ecn_uids, "CMHasSolutionItem", ["H4_Hussmann_ItemRevision"]
        )

        all_solution_uids = []
        for uids in solution_map.values():
            all_solution_uids.extend(uids)

        if not all_solution_uids:
            _tc_logger.warning(f"  No solution items found for ECN {ecn_number}")
            return []

        _tc_logger.info(f"  Found {len(all_solution_uids)} solution items")

        # Get solution item properties
        solution_props = self.client.get_properties(all_solution_uids, CHECKSHEET_POLICY_PROPS)

        # Step 6: For each solution item, get parent Item for additional properties
        # Set Item policy
        self.client.set_property_policy({
            "H4_Hussmann_Item": ITEM_POLICY_PROPS
        })

        # Build rows
        rows = []
        for ecn_uid in ecn_uids:
            ecn_data = ecn_props.get(ecn_uid, {})
            ecn_id = ecn_data.get("item_id", ecn_number)
            ecn_name = ecn_data.get("object_name", "")
            ecn_desc = ecn_data.get("object_desc", "")

            solution_uids = solution_map.get(ecn_uid, [])
            for sol_uid in solution_uids:
                sol_data = solution_props.get(sol_uid, {})
                item_id = sol_data.get("item_id", "")

                # Get parent Item for additional properties (UOM, Product Family, etc.)
                item_extra = {}
                if item_id:
                    try:
                        item_uids = self.client.execute_saved_query(
                            "Item...", ["Type", "Item ID"], ["H4_Hussmann_Item", item_id]
                        )
                        if item_uids:
                            item_props = self.client.get_properties(item_uids, ITEM_POLICY_PROPS)
                            item_extra = item_props.get(item_uids[0], {})
                    except TcSoaError as e:
                        _tc_logger.warning(f"  Failed to get Item for {item_id}: {e}")

                row = self._build_row_dict(ecn_id, ecn_name, ecn_desc, sol_data, item_extra)
                rows.append(row)

        _tc_logger.info(f"  Built {len(rows)} rows for ECN {ecn_number}")
        return rows

    def fetch_pr_data(self, pr_number):
        """Fetch data for a PR number. Finds related ECNs and fetches their data."""
        # Find the PR item revision
        pr_uids = self.client.execute_saved_query(
            "Item Revision...", ["Item ID"], [pr_number]
        )
        if not pr_uids:
            return []

        # Find ECNs related to this PR
        ecn_map = self.client.expand_grm_relations(pr_uids, "CMHasSolutionItem")

        all_rows = []
        ecn_uids = []
        for uids in ecn_map.values():
            ecn_uids.extend(uids)

        if ecn_uids:
            ecn_props = self.client.get_properties(ecn_uids, ["item_id"])
            for uid, props in ecn_props.items():
                ecn_id = props.get("item_id", "")
                if ecn_id:
                    rows = self.fetch_ecn_data(ecn_id)
                    for row in rows:
                        row["PR ID"] = pr_number
                    all_rows.extend(rows)

        return all_rows

    def fetch_item_data(self, item_id):
        """Fetch data for a specific item ID."""
        # Set policy
        self.client.set_property_policy({
            "H4_Hussmann_ItemRevision": CHECKSHEET_POLICY_PROPS
        })

        # Use "Item Revision..." query.
        # Support both raw item IDs ("3242449") and item/revision inputs
        # ("3242449/A") seen in user workflows.
        item_uids = []
        if "/" in item_id:
            base_id, rev_id = item_id.split("/", 1)
            base_id = base_id.strip()
            rev_id = rev_id.strip()
            if base_id and rev_id:
                item_uids = self.client.execute_saved_query(
                    "Item Revision...", ["Item ID", "Revision"], [base_id, rev_id]
                )
            if not item_uids and base_id:
                item_uids = self.client.execute_saved_query(
                    "Item Revision...", ["Item ID"], [base_id]
                )
        else:
            item_uids = self.client.execute_saved_query(
                "Item Revision...", ["Item ID"], [item_id]
            )
        if not item_uids:
            return []

        item_props = self.client.get_properties(item_uids, CHECKSHEET_POLICY_PROPS)

        rows = []
        for uid in item_uids:
            item_data = item_props.get(uid, {})
            ecn_number = item_data.get("h4_ECN_Number", "")
            row = self._build_row_dict(ecn_number, "", "", item_data, {})
            rows.append(row)

        return rows

    def get_bom_children_via_structure_revisions(self, item_rev_uid, view_type=None):
        """
        Get BOM children using the proven chain:
        ItemRevision → structure_revisions → bvr_occurrences → child_item

        This approach works via getProperties only (no createBOMWindows needed).

        Args:
            item_rev_uid: UID of the item revision
            view_type: BOM view type to use (default: HSM_BOM_VIEW_TYPE)

        Returns:
            List of child dicts: [{"item_id": ..., "name": ..., "occurrence_uid": ...}]
        """
        if view_type is None:
            view_type = HSM_BOM_VIEW_TYPE

        _tc_logger.info(f"get_bom_children_via_structure_revisions: {item_rev_uid}, view={view_type}")

        # Step 1: Get structure_revisions (PSBOMViewRevision UIDs)
        sr_props = self.client.get_properties([item_rev_uid], ["structure_revisions"])
        sr_value = sr_props.get(item_rev_uid, {}).get("structure_revisions", "")
        if isinstance(sr_value, str):
            bvr_uids = [sr_value] if sr_value else []
        elif isinstance(sr_value, list):
            bvr_uids = [u for u in sr_value if u]
        else:
            bvr_uids = []

        if not bvr_uids:
            _tc_logger.info(f"  No structure_revisions found for {item_rev_uid}")
            return []

        _tc_logger.info(f"  Found {len(bvr_uids)} BOMView Revisions")

        # Step 2: Get BVR properties — filter to desired view type
        bvr_props = self.client.get_properties(
            bvr_uids, ["object_name", "bvr_occurrences"]
        )

        target_bvr_uid = None
        for uid in bvr_uids:
            bp = bvr_props.get(uid, {})
            name = str(bp.get("object_name", ""))
            _tc_logger.info(f"  BVR {uid}: name={name}")
            if view_type.lower() in name.lower():
                target_bvr_uid = uid
                break

        # Fallback: if desired view not found, use the first BVR
        if not target_bvr_uid:
            _tc_logger.info(f"  View '{view_type}' not found, using first BVR")
            target_bvr_uid = bvr_uids[0]

        # Step 3: Get bvr_occurrences from the target BVR
        occ_value = bvr_props.get(target_bvr_uid, {}).get("bvr_occurrences", "")
        if isinstance(occ_value, str):
            occ_uids = [occ_value] if occ_value else []
        elif isinstance(occ_value, list):
            occ_uids = [u for u in occ_value if u]
        else:
            occ_uids = []

        if not occ_uids:
            _tc_logger.info(f"  No bvr_occurrences for BVR {target_bvr_uid}")
            return []

        _tc_logger.info(f"  Found {len(occ_uids)} occurrences")

        # Step 4: Get child_item and object_name from each occurrence
        occ_props = self.client.get_properties(
            occ_uids, ["child_item", "object_name"]
        )

        children = []
        for occ_uid in occ_uids:
            op = occ_props.get(occ_uid, {})
            child_item_value = op.get("child_item", "")
            if isinstance(child_item_value, list):
                child_item_uid = next((str(v).strip() for v in child_item_value if str(v).strip()), "")
            else:
                child_item_uid = str(child_item_value).strip()
            occ_name = str(op.get("object_name", ""))

            if not child_item_uid:
                continue

            # child_item is typically a child ItemRevision UID (dbValue).
            # Use it directly for traversal; item_id is loaded later via get_properties.
            children.append({
                "child_rev_uid": child_item_uid,
                "item_id": "",
                "name": occ_name,
                "occurrence_uid": occ_uid,
                "child_item_raw": child_item_uid,
            })

        _tc_logger.info(
            f"  Returning {len(children)} children by UID: "
            f"{[c.get('child_rev_uid', '') for c in children]}"
        )
        return children

    def fetch_bom_children(self, item_revision_uid):
        """
        Fetch BOM children for an item revision.
        Prefer BOM-window expansion (closest to TC UI). Fall back to
        structure_revisions → bvr_occurrences when BOM-window calls fail.

        Args:
            item_revision_uid: UID of the item revision

        Returns:
            List of child dicts.
        """
        try:
            children = self.client.get_bom_for_item_revision(item_revision_uid)
            if children:
                return children
            _tc_logger.info(
                "BOM window expansion returned no children; "
                "falling back to structure_revisions chain"
            )
            return self.get_bom_children_via_structure_revisions(item_revision_uid)
        except TcSoaError as e:
            _tc_logger.warning(f"BOM window expansion failed: {e}")
            try:
                return self.get_bom_children_via_structure_revisions(item_revision_uid)
            except TcSoaError as fallback_error:
                _tc_logger.warning(f"BOM via structure_revisions failed: {fallback_error}")
                return []
        except Exception as e:
            _tc_logger.warning(f"BOM expansion unexpected error: {e}")
            return []

    @staticmethod
    def _rev_sort_key(rev_id):
        """Best-effort revision sort key for mixed alpha/num revisions."""
        text = str(rev_id or "").strip().upper()
        if not text:
            return ("", 0, "")
        alpha = "".join(ch for ch in text if ch.isalpha())
        digits = "".join(ch for ch in text if ch.isdigit())
        num = int(digits) if digits.isdigit() else -1
        return (alpha, num, text)

    @staticmethod
    def _to_status_text(value):
        if isinstance(value, list):
            return " ".join(str(v) for v in value if v is not None).upper()
        return str(value or "").upper()

    def lookup_item_revisions_by_nomenclature(self, nomenclature):
        """
        Resolve a case nomenclature (e.g. RLN5MA) to matching item revision UIDs.
        Uses saved query catalog + field introspection to find queries that expose
        nomenclature-like entry names.
        """
        nom = str(nomenclature or "").strip()
        if not nom:
            return []

        # Memoize: same nomenclature looked up twice in a run -> instant.
        cached = getattr(self.client, "_nomenclature_cache", {}).get(nom)
        if cached is not None:
            _tc_logger.info(
                f"lookup_item_revisions_by_nomenclature: '{nom}' (cache hit, {len(cached)} revs)"
            )
            return [dict(r) for r in cached]

        _tc_logger.info(f"lookup_item_revisions_by_nomenclature: '{nom}'")
        # Property policy is set ONCE at login (UNIFIED_POLICY); no per-call resend.
        if not getattr(self.client, "_unified_policy_set", False):
            self.client.set_property_policy(UNIFIED_POLICY)
            self.client._unified_policy_set = True

        matched_uids = []

        # Fast path: try direct "Item Revision..." query with Item ID
        try:
            fast_uids = self.client.execute_saved_query(
                "Item Revision...", ["Item ID"], [nom]
            )
            if fast_uids:
                _tc_logger.info(f"  Fast path: found {len(fast_uids)} UIDs for '{nom}'")
                matched_uids.extend(fast_uids)
        except TcSoaError:
            pass

        # Slow path is opt-in only — the saved-query catalog scan + describe +
        # 3-wildcard cross product was producing 30-100+ HTTP round trips per
        # nomenclature miss. Fast path covers the normal case.
        if not matched_uids and getattr(self, "_enable_slow_nomenclature_scan", False):
            queries = self.client.get_saved_queries_catalog()
            _tc_logger.info(f"  Saved query catalog size: {len(queries)}")

            candidate_queries = []
            for q in queries:
                if not isinstance(q, dict):
                    continue
                qname = str(q.get("name", ""))
                qdesc = str(q.get("description", ""))
                qobj = q.get("query", {})
                quid = qobj.get("uid", "") if isinstance(qobj, dict) else ""
                if not quid:
                    continue
                text = f"{qname} {qdesc}".upper()
                if "ITEM" in text and "REV" in text:
                    candidate_queries.append((quid, qname))
                elif "HUSSMANN ITEM REVISION SEARCH" in text:
                    candidate_queries.append((quid, qname))

            _tc_logger.info(f"  Candidate queries for nomenclature lookup: {len(candidate_queries)}")

            tried = 0
            for query_uid, query_name in candidate_queries:
                try:
                    fields = self.client.describe_saved_query_fields(query_uid)
                except TcSoaError as e:
                    _tc_logger.warning(f"  describeSavedQueries failed for {query_name}: {e}")
                    continue

                entry_names = []
                for f in fields:
                    if isinstance(f, dict):
                        ename = str(f.get("entryName", "")).strip()
                        if ename:
                            entry_names.append(ename)

                target_entries = []
                for f in fields:
                    if not isinstance(f, dict):
                        continue
                    ename = str(f.get("entryName", "")).strip()
                    aname = str(f.get("attributeName", "")).strip()
                    token = f"{ename} {aname}".upper()
                    if any(k in token for k in ["NOMENCLATURE", "H4_NOMENCLATURE", "MODEL", "CASE"]):
                        if ename:
                            target_entries.append(ename)
                target_entries = list(dict.fromkeys(target_entries))
                if not target_entries:
                    continue

                for entry in target_entries:
                    for candidate_value in [nom, f"{nom}*", f"*{nom}*"]:
                        tried += 1
                        try:
                            uids = self.client.execute_saved_query_by_uid(
                                query_uid, [entry], [candidate_value], max_results=0
                            )
                            if uids:
                                _tc_logger.info(
                                    f"  Query '{query_name}' entry '{entry}' value "
                                    f"'{candidate_value}' returned {len(uids)} UIDs"
                                )
                                matched_uids.extend(uids)
                                break
                        except TcSoaError as e:
                            _tc_logger.warning(
                                f"  Query '{query_name}' entry '{entry}' value "
                                f"'{candidate_value}' failed: {e}"
                            )

            _tc_logger.info(f"  Nomenclature lookup attempts: {tried}")
        matched_uids = sorted(set(u for u in matched_uids if u))
        if not matched_uids:
            _tc_logger.warning(f"  No item revisions found for nomenclature '{nom}'")
            try:
                self.client._nomenclature_cache[nom] = []
            except Exception:
                pass
            return []

        props = self.client.get_properties(
            matched_uids,
            ["item_id", "item_revision_id", "object_name", "object_desc",
             "h4_Nomenclature", "release_status_list", "process_stage"]
        )

        results = []
        for uid in matched_uids:
            p = props.get(uid, {})
            results.append({
                "uid": uid,
                "item_id": p.get("item_id", ""),
                "item_revision_id": p.get("item_revision_id", ""),
                "object_name": p.get("object_name", ""),
                "object_desc": p.get("object_desc", ""),
                "h4_Nomenclature": p.get("h4_Nomenclature", ""),
                "release_status_list": p.get("release_status_list", ""),
                "process_stage": p.get("process_stage", ""),
            })

        _tc_logger.info(f"  Nomenclature lookup resolved {len(results)} revisions")
        # Cache for the rest of the run.
        try:
            self.client._nomenclature_cache[nom] = [dict(r) for r in results]
        except Exception:
            pass
        return results

    def select_revisions_for_bom(self, revision_candidates):
        """
        Select revisions per item_id:
        - latest released
        - latest workflow/in-review
        - latest design/in-work
        """
        grouped = {}
        for c in revision_candidates:
            iid = str(c.get("item_id", "")).strip()
            if not iid:
                continue
            grouped.setdefault(iid, []).append(c)

        selected = []
        for item_id, candidates in grouped.items():
            sorted_candidates = sorted(
                candidates, key=lambda c: self._rev_sort_key(c.get("item_revision_id", ""))
            )

            released = []
            workflow = []
            design = []
            for c in sorted_candidates:
                release_text = self._to_status_text(c.get("release_status_list", ""))
                stage_text = self._to_status_text(c.get("process_stage", ""))
                is_released = "RELEASE" in release_text
                is_design = any(k in stage_text for k in ["DESIGN", "WIP", "INWORK"])
                is_workflow = any(k in stage_text for k in ["WORKFLOW", "REVIEW", "APPROVAL", "CFT", "MCN", "ECN"])

                if is_released:
                    released.append(c)
                elif is_design:
                    design.append(c)
                elif is_workflow:
                    workflow.append(c)

            picked = []
            if released:
                picked.append(released[-1])
            if workflow:
                picked.append(workflow[-1])
            if design:
                picked.append(design[-1])
            if not picked and sorted_candidates:
                picked.append(sorted_candidates[-1])

            seen = set()
            for c in picked:
                uid = c.get("uid", "")
                if uid and uid not in seen:
                    seen.add(uid)
                    selected.append(c)

        _tc_logger.info(
            f"select_revisions_for_bom: selected {len(selected)} from {len(revision_candidates)} candidates"
        )
        return selected

    def _resolve_item_revision_uid(self, item_id, rev_id="", cache=None):
        """Resolve item_id/rev_id to item revision UID.

        When rev_id is provided, picks the exact matching revision.
        When rev_id is empty (BOM child resolution), applies HSM revision rule:
          1. Latest revision with PRODUCTION RELEASED status
          2. Fallback: latest revision with any RELEASED status
          3. Fallback: latest revision overall (highest alpha/numeric)
        """
        key = (str(item_id or "").strip(), str(rev_id or "").strip())
        if cache is not None and key in cache:
            return cache[key]

        uid = ""
        candidate_uids = []
        if key[0] and key[1]:
            candidate_uids = self.client.execute_saved_query(
                "Item Revision...", ["Item ID", "Revision"], [key[0], key[1]]
            )
        if not candidate_uids and key[0]:
            candidate_uids = self.client.execute_saved_query("Item Revision...", ["Item ID"], [key[0]])

        if candidate_uids:
            try:
                props = self.client.get_properties(
                    candidate_uids,
                    ["item_id", "item_revision_id", "object_type", "release_status_list"]
                )
                desired_rev = key[1].upper()

                if desired_rev:
                    # Exact rev_id specified — keep existing exact-match behavior
                    exact_rev_match = ""
                    any_revision = ""
                    for candidate_uid in candidate_uids:
                        p = props.get(candidate_uid, {})
                        cand_rev = str(p.get("item_revision_id", "")).strip()
                        if not cand_rev:
                            continue
                        if cand_rev.upper() == desired_rev and not exact_rev_match:
                            exact_rev_match = candidate_uid
                        if not any_revision:
                            any_revision = candidate_uid
                    uid = exact_rev_match or any_revision or candidate_uids[0]
                else:
                    # No rev_id — apply HSM revision rule:
                    # Prefer latest PRODUCTION RELEASED, then any RELEASED, then latest overall
                    scored = []
                    for candidate_uid in candidate_uids:
                        p = props.get(candidate_uid, {})
                        cand_rev = str(p.get("item_revision_id", "")).strip()
                        if not cand_rev:
                            continue
                        sort_key = self._rev_sort_key(cand_rev)
                        release_text = self._to_status_text(p.get("release_status_list", ""))
                        is_prod_released = "PRODUCTION RELEASED" in release_text
                        is_any_released = "RELEASE" in release_text
                        scored.append((sort_key, is_prod_released, is_any_released, candidate_uid, cand_rev))

                    if scored:
                        # Sort ascending by rev sort key; last = highest/latest
                        scored.sort(key=lambda x: x[0])
                        # Tier 1: latest PRODUCTION RELEASED
                        prod_released = [s for s in scored if s[1]]
                        # Tier 2: latest with any RELEASED status
                        any_released = [s for s in scored if s[2]]
                        if prod_released:
                            uid = prod_released[-1][3]
                            picked_rev = prod_released[-1][4]
                        elif any_released:
                            uid = any_released[-1][3]
                            picked_rev = any_released[-1][4]
                        else:
                            uid = scored[-1][3]
                            picked_rev = scored[-1][4]
                        _tc_logger.info(
                            f"  _resolve_item_revision_uid({key[0]}): "
                            f"picked rev {picked_rev} from {len(scored)} candidates "
                            f"[revs: {[s[4] for s in scored]}]"
                        )
                    else:
                        uid = candidate_uids[0]
            except Exception:
                uid = candidate_uids[0]

        if cache is not None:
            cache[key] = uid
        return uid

    def fetch_recursive_bom(
        self,
        root_revisions,
        max_depth=20,
        progress_callback=None,
        max_nodes=1200,
        max_seconds=900,
    ):
        """
        Expand BOM recursively from root item revision records.
        Uses structure_revisions → bvr_occurrences chain for each level.
        """
        uid_cache = {}
        queue = []
        visited_uids = set()
        nodes = []
        edges = []
        uid_normalization_cache = {}
        child_uid_props_cache = {}
        started_at = time.perf_counter()
        t_get_node_props = 0.0
        t_fetch_children = 0.0
        t_child_uid_props = 0.0
        t_resolve_uid = 0.0
        normalize_failures = 0
        truncated = False
        truncate_reason = ""

        node_props = [
            "item_id", "item_revision_id", "object_name",
            "h4_Nomenclature", "release_status_list", "process_stage",
            "h4_ECN_Number",
        ]

        for root in root_revisions:
            uid = root.get("uid", "")
            if uid:
                queue.append((uid, 0, None))

        def _emit_progress(stage, depth):
            if callable(progress_callback):
                processed = len(visited_uids)
                queued = len(queue)
                try:
                    progress_callback(processed, queued, depth, stage)
                except TypeError:
                    progress_callback(processed, queued, depth)

        while queue:
            if max_nodes and len(visited_uids) >= int(max_nodes):
                truncated = True
                truncate_reason = f"max_nodes_reached:{int(max_nodes)}"
                break
            if max_seconds and (time.perf_counter() - started_at) >= float(max_seconds):
                truncated = True
                truncate_reason = f"max_seconds_reached:{int(float(max_seconds))}"
                break

            current_uid, depth, parent_uid = queue.pop(0)
            if current_uid in visited_uids:
                if parent_uid:
                    edges.append({"parent_uid": parent_uid, "child_uid": current_uid, "depth": depth})
                continue

            visited_uids.add(current_uid)
            t0 = time.perf_counter()
            props = self.client.get_properties([current_uid], node_props)
            t_get_node_props += (time.perf_counter() - t0)
            p = props.get(current_uid, {})
            current_item_id = p.get("item_id", "")

            nodes.append({
                "uid": current_uid,
                "depth": depth,
                "item_id": current_item_id,
                "item_revision_id": p.get("item_revision_id", ""),
                "object_name": p.get("object_name", ""),
                "h4_Nomenclature": p.get("h4_Nomenclature", ""),
                "release_status_list": p.get("release_status_list", ""),
                "process_stage": p.get("process_stage", ""),
                "h4_ECN_Number": p.get("h4_ECN_Number", ""),
            })
            if parent_uid:
                edges.append({"parent_uid": parent_uid, "child_uid": current_uid, "depth": depth})

            if depth >= max_depth:
                if callable(progress_callback) and (len(visited_uids) == 1 or len(visited_uids) % 25 == 0):
                    _emit_progress("Expanding level", depth)
                continue

            _tc_logger.info(f"  BOM expand depth={depth} item={current_item_id} uid={current_uid}")
            _emit_progress("Opening BOM window", depth)
            t0 = time.perf_counter()
            children = self.fetch_bom_children(current_uid)
            t_fetch_children += (time.perf_counter() - t0)
            child_uids = [
                str(c.get("child_rev_uid", "")).strip()
                for c in children
                if isinstance(c, dict) and str(c.get("child_rev_uid", "")).strip()
            ]
            if child_uids:
                t1 = time.perf_counter()
                missing_child_uids = [u for u in child_uids if u not in child_uid_props_cache]
                if missing_child_uids:
                    fetched_props = self.client.get_properties(
                        missing_child_uids, ["item_id", "item_revision_id"]
                    )
                    for u in missing_child_uids:
                        child_uid_props_cache[u] = fetched_props.get(u, {})
                child_uid_props = {
                    u: child_uid_props_cache.get(u, {})
                    for u in child_uids
                }
                t_child_uid_props += (time.perf_counter() - t1)
            else:
                child_uid_props = {}

            _emit_progress("Resolving child revisions", depth)
            for child in children:
                child_uid = str(child.get("child_rev_uid", "")).strip()
                if child_uid:
                    cached_norm_uid = uid_normalization_cache.get(child_uid)
                    if cached_norm_uid is not None:
                        if cached_norm_uid:
                            queue.append((cached_norm_uid, depth + 1, current_uid))
                        continue

                    cp = child_uid_props.get(child_uid, {})
                    cp_rev = str(cp.get("item_revision_id", "")).strip()
                    if cp_rev:
                        uid_normalization_cache[child_uid] = child_uid
                        queue.append((child_uid, depth + 1, current_uid))
                        continue

                    resolve_item_id = str(child.get("item_id", "")).strip() or str(cp.get("item_id", "")).strip()
                    resolve_rev_id = str(child.get("rev_id", "")).strip() or cp_rev
                    if resolve_item_id:
                        t_resolve_start = time.perf_counter()
                        resolved_uid = self._resolve_item_revision_uid(
                            resolve_item_id, resolve_rev_id, cache=uid_cache
                        )
                        t_resolve_uid += (time.perf_counter() - t_resolve_start)
                        if resolved_uid:
                            uid_normalization_cache[child_uid] = resolved_uid
                            queue.append((resolved_uid, depth + 1, current_uid))
                            continue
                        else:
                            uid_normalization_cache[child_uid] = ""
                            normalize_failures += 1
                            _tc_logger.info(
                                f"    Could not normalize child UID '{child_uid}' to ItemRevision UID"
                            )
                    else:
                        uid_normalization_cache[child_uid] = ""
                    continue

                child_item_id = child.get("item_id", "")
                if not child_item_id:
                    continue

                # Resolve child item_id to an ItemRevision UID
                t_resolve_start = time.perf_counter()
                child_uid = self._resolve_item_revision_uid(
                    child_item_id, child.get("rev_id", ""), cache=uid_cache
                )
                t_resolve_uid += (time.perf_counter() - t_resolve_start)
                if not child_uid:
                    _tc_logger.info(f"    Could not resolve item_id '{child_item_id}' to UID")
                    # Still record it as a leaf node with what we know
                    leaf_uid = f"unresolved:{child_item_id}"
                    if leaf_uid not in visited_uids:
                        visited_uids.add(leaf_uid)
                        nodes.append({
                            "uid": leaf_uid,
                            "depth": depth + 1,
                            "item_id": child_item_id,
                            "item_revision_id": "",
                            "object_name": child.get("name", ""),
                            "h4_Nomenclature": "",
                            "release_status_list": "",
                            "process_stage": "",
                        })
                        edges.append({"parent_uid": current_uid, "child_uid": leaf_uid, "depth": depth + 1})
                    continue

                queue.append((child_uid, depth + 1, current_uid))

            if callable(progress_callback) and (len(visited_uids) == 1 or len(visited_uids) % 25 == 0):
                _emit_progress("Expanding level", depth)

            if len(visited_uids) == 1 or len(visited_uids) % 50 == 0:
                elapsed_s = time.perf_counter() - started_at
                _tc_logger.info(
                    "  BOM progress: "
                    f"visited={len(visited_uids)}, queue={len(queue)}, depth={depth}, "
                    f"elapsed={elapsed_s:.1f}s, "
                    f"timing_ms(node_props={t_get_node_props*1000:.1f}, "
                    f"fetch_children={t_fetch_children*1000:.1f}, "
                    f"child_uid_props={t_child_uid_props*1000:.1f}, "
                    f"resolve_uid={t_resolve_uid*1000:.1f}), "
                    f"normalize_failures={normalize_failures}"
                )

        _tc_logger.info(
            f"fetch_recursive_bom complete: {len(nodes)} nodes, {len(edges)} edges, "
            f"max_depth_reached={max(n['depth'] for n in nodes) if nodes else 0}"
        )
        return {
            "nodes": nodes,
            "edges": edges,
            "visited_count": len(visited_uids),
            "truncated": truncated,
            "truncate_reason": truncate_reason,
            "queue_remaining": len(queue),
            "elapsed_seconds": round(time.perf_counter() - started_at, 3),
        }

    def fetch_bom_by_nomenclature(
        self,
        nomenclature,
        recursive=True,
        max_depth=100,
        progress_callback=None,
        max_nodes=1200,
        max_seconds=900,
    ):
        """
        Entry point: resolve nomenclature -> select revisions -> expand BOM.
        """
        candidates = self.lookup_item_revisions_by_nomenclature(nomenclature)
        selected = self.select_revisions_for_bom(candidates)
        if not selected:
            return {
                "nomenclature": nomenclature,
                "candidates": candidates,
                "selected_revisions": [],
                "bom": {
                    "nodes": [],
                    "edges": [],
                    "visited_count": 0,
                    "truncated": False,
                    "truncate_reason": "",
                    "queue_remaining": 0,
                    "elapsed_seconds": 0.0,
                },
            }

        if recursive:
            bom = self.fetch_recursive_bom(
                selected,
                max_depth=max_depth,
                progress_callback=progress_callback,
                max_nodes=max_nodes,
                max_seconds=max_seconds,
            )
        else:
            # Single-level fallback
            nodes = []
            edges = []
            for s in selected:
                parent_uid = s.get("uid", "")
                if not parent_uid:
                    continue
                nodes.append({"uid": parent_uid, "depth": 0, "item_id": s.get("item_id", ""), "item_revision_id": s.get("item_revision_id", "")})
                children = self.fetch_bom_children(parent_uid)
                for c in children:
                    child_uid = self._resolve_item_revision_uid(c.get("item_id", ""), c.get("rev_id", ""))
                    if child_uid:
                        edges.append({"parent_uid": parent_uid, "child_uid": child_uid, "depth": 1})
            bom = {
                "nodes": nodes,
                "edges": edges,
                "visited_count": len({n['uid'] for n in nodes}),
                "truncated": False,
                "truncate_reason": "",
                "queue_remaining": 0,
                "elapsed_seconds": 0.0,
            }

        _tc_logger.info(
            f"fetch_bom_by_nomenclature '{nomenclature}': "
            f"{len(candidates)} candidates, {len(selected)} selected, "
            f"{bom.get('visited_count', 0)} visited nodes"
        )
        return {
            "nomenclature": nomenclature,
            "candidates": candidates,
            "selected_revisions": selected,
            "bom": bom,
        }

    def flatten_bom_result_to_rows(self, bom_result):
        """
        Convert fetch_bom_by_nomenclature() payload to row dicts that can be
        consumed by advanced_excel_importer.load_from_tc_data().
        """
        nomenclature = str(bom_result.get("nomenclature", "")).strip()
        bom = bom_result.get("bom", {}) or {}
        nodes = bom.get("nodes", []) or []
        edges = bom.get("edges", []) or []

        if not nodes:
            return []

        node_by_uid = {
            n.get("uid"): n for n in nodes
            if isinstance(n, dict) and n.get("uid")
        }
        parent_of = {}
        for e in edges:
            if not isinstance(e, dict):
                continue
            p = e.get("parent_uid")
            c = e.get("child_uid")
            if p and c:
                # Keep first parent for stable grouping.
                parent_of.setdefault(c, p)

        def root_uid(uid):
            seen = set()
            cur = uid
            while cur in parent_of and cur not in seen:
                seen.add(cur)
                cur = parent_of[cur]
            return cur

        rows = []
        for uid, node in node_by_uid.items():
            item_id = str(node.get("item_id", "")).strip() or uid
            rev_id = str(node.get("item_revision_id", "")).strip()
            rid = root_uid(uid)
            root = node_by_uid.get(rid, {})
            root_item = str(root.get("item_id", "")).strip() or rid
            root_rev = str(root.get("item_revision_id", "")).strip()
            ecn_key = f"BOM:{root_item}/{root_rev}" if root_rev else f"BOM:{root_item}"

            row = {
                "PR ID": f"NOM:{nomenclature}" if nomenclature else "NOM:UNKNOWN",
                "ECN ID": ecn_key,
                "ECN Description": f"Case BOM {nomenclature}" if nomenclature else "Case BOM",
                "ECN Detail": str(root.get("object_name", "")).strip(),
                "ECN Number": ecn_key,
                "Item ID": item_id,
                "Item ID/Rev": f"{item_id}/{rev_id}" if rev_id else item_id,
                "Item Revision": rev_id,
                "Item Name": str(node.get("object_name", "")).strip(),
                "Nomenclature": str(node.get("h4_Nomenclature", "")).strip() or nomenclature,
                "Process Stage": node.get("process_stage", ""),
                "Item Release Status": node.get("release_status_list", ""),
                "_source": "teamcenter_bom_nomenclature",
                "_item_uid": uid,
                "_bom_depth": node.get("depth", 0),
                "_bom_parent_uid": parent_of.get(uid, ""),
                "_bom_root_uid": rid,
            }
            rows.append(row)

        _tc_logger.info(
            f"flatten_bom_result_to_rows: generated {len(rows)} rows for "
            f"nomenclature '{nomenclature}'"
        )
        return rows

    def save_bom_tree_files(self, bom_result, output_dir=None):
        """
        Save BOM data as hierarchical JSON and human-readable tree text.

        Args:
            bom_result: Output from fetch_bom_by_nomenclature()
            output_dir: Directory to save files (default: tc_bom_output/ in working dir)

        Returns:
            Dict with file paths: {"json": path, "txt": path}
        """
        nomenclature = str(bom_result.get("nomenclature", "")).strip() or "unknown"
        bom = bom_result.get("bom", {}) or {}
        nodes = bom.get("nodes", []) or []
        edges = bom.get("edges", []) or []

        if output_dir is None:
            output_dir = os.path.join(_log_dir, "tc_bom_output")
        os.makedirs(output_dir, exist_ok=True)

        # Build lookup structures
        node_by_uid = {}
        for n in nodes:
            if isinstance(n, dict) and n.get("uid"):
                node_by_uid[n["uid"]] = n

        children_of = {}  # parent_uid -> [child_uid, ...]
        for e in edges:
            if not isinstance(e, dict):
                continue
            p = e.get("parent_uid", "")
            c = e.get("child_uid", "")
            if p and c:
                children_of.setdefault(p, []).append(c)

        # Find root nodes (nodes with no parent in edges)
        child_set = set()
        for e in edges:
            if isinstance(e, dict):
                child_set.add(e.get("child_uid", ""))
        root_uids = [n["uid"] for n in nodes if n.get("uid") and n["uid"] not in child_set]

        def _build_tree_node(uid):
            """Recursively build a tree dict from a node UID."""
            node = node_by_uid.get(uid, {})
            tree = {
                "item_id": node.get("item_id", ""),
                "revision": node.get("item_revision_id", ""),
                "name": node.get("object_name", ""),
                "nomenclature": node.get("h4_Nomenclature", ""),
                "release_status": node.get("release_status_list", ""),
                "process_stage": node.get("process_stage", ""),
                "ecn": node.get("h4_ECN_Number", ""),
                "uid": uid,
                "depth": node.get("depth", 0),
                "children": [],
            }
            for child_uid in children_of.get(uid, []):
                tree["children"].append(_build_tree_node(child_uid))
            return tree

        # Build hierarchical JSON
        tree_roots = [_build_tree_node(uid) for uid in root_uids]

        json_data = {
            "nomenclature": nomenclature,
            "fetched_at": datetime.datetime.now().isoformat(),
            "view_type": HSM_BOM_VIEW_TYPE,
            "total_parts": len(nodes),
            "max_depth": max((n.get("depth", 0) for n in nodes), default=0),
            "roots": tree_roots if len(tree_roots) != 1 else None,
            "root": tree_roots[0] if len(tree_roots) == 1 else None,
        }
        # Use "root" for single root, "roots" for multiple
        if len(tree_roots) == 1:
            del json_data["roots"]
        else:
            del json_data["root"]

        token = re.sub(r"[^a-zA-Z0-9]+", "_", nomenclature).strip("_") or "bom"
        json_path = os.path.join(output_dir, f"{token}_bom_tree.json")
        txt_path = os.path.join(output_dir, f"{token}_bom_tree.txt")

        # Write JSON
        with open(json_path, "w", encoding="utf-8") as f:
            json.dump(json_data, f, indent=2, ensure_ascii=False)

        # Write human-readable tree text
        lines = [
            f"BOM Tree: {nomenclature}",
            f"Fetched: {json_data['fetched_at']}",
            f"View: {HSM_BOM_VIEW_TYPE}",
            f"Total parts: {len(nodes)}",
            f"Max depth: {json_data['max_depth']}",
            "",
        ]

        def _tree_text(node, prefix="", is_last=True):
            item_id = node.get("item_id", "?")
            rev = node.get("revision", "")
            name = node.get("name", "")
            release = str(node.get("release_status", "") or "").upper()
            process = str(node.get("process_stage", "") or "")
            # Status markers
            if "PRODUCTION RELEASED" in release:
                marker = "✓"
            elif "on-hold" in process.lower() or "onhold" in process.lower():
                marker = "⏸"
            else:
                marker = "✗"
            label = f"{marker} {item_id}/{rev}" if rev else f"{marker} {item_id}"
            if name:
                label += f" — {name}"
            connector = "└── " if is_last else "├── "
            if prefix == "" and node.get("depth", 0) == 0:
                # Root node — no connector
                lines.append(label)
            else:
                lines.append(f"{prefix}{connector}{label}")

            children = node.get("children", [])
            for i, child in enumerate(children):
                child_is_last = (i == len(children) - 1)
                if prefix == "" and node.get("depth", 0) == 0:
                    child_prefix = ""
                else:
                    child_prefix = prefix + ("    " if is_last else "│   ")
                _tree_text(child, child_prefix, child_is_last)

        for root in tree_roots:
            _tree_text(root)
            lines.append("")

        with open(txt_path, "w", encoding="utf-8") as f:
            f.write("\n".join(lines))

        # Generate dependency report
        report_path = os.path.join(output_dir, f"{token}_dependency_report.txt")
        report_lines = [
            f"Dependency Report: {nomenclature}",
            f"Generated: {json_data['fetched_at']}",
            f"Total parts: {len(nodes)}",
            "",
        ]

        # Analyze: find unreleased and blocked parts
        unreleased = []
        blocked = []
        released_count = 0
        for n in nodes:
            if not isinstance(n, dict):
                continue
            iid = n.get("item_id", "")
            rev = n.get("item_revision_id", "")
            nm = n.get("object_name", "")
            rel = str(n.get("release_status_list", "") or "").upper()
            ps = str(n.get("process_stage", "") or "")
            ecn_num = n.get("h4_ECN_Number", "")
            is_prod_rel = "PRODUCTION RELEASED" in rel
            is_on_hold = "on-hold" in ps.lower() or "onhold" in ps.lower()

            if is_prod_rel:
                released_count += 1
            else:
                unreleased.append({
                    "item_id": iid, "rev": rev, "name": nm,
                    "release": rel or "(none)", "ecn": ecn_num,
                    "workflow": ps.split("/")[0].strip() if "/" in ps else ps,
                })
            if is_on_hold:
                blocked.append({
                    "item_id": iid, "rev": rev, "name": nm,
                    "workflow": ps.split("/")[0].strip() if "/" in ps else ps,
                    "ecn": ecn_num,
                })

        pct = (released_count / len(nodes) * 100) if nodes else 0
        report_lines.append(f"SUMMARY")
        report_lines.append(f"  Released (PRODUCTION RELEASED): {released_count} of {len(nodes)} ({pct:.1f}%)")
        report_lines.append(f"  Unreleased: {len(unreleased)}")
        report_lines.append(f"  Blocked (On-Hold): {len(blocked)}")
        report_lines.append("")

        if blocked:
            report_lines.append("BLOCKED PARTS (On-Hold Auto Complete)")
            report_lines.append("-" * 60)
            for b in blocked:
                lbl = f"{b['item_id']}/{b['rev']}" if b['rev'] else b['item_id']
                report_lines.append(f"  ⏸ {lbl} — {b['name']}")
                if b['ecn']:
                    report_lines.append(f"      ECN: {b['ecn']}")
                if b['workflow']:
                    report_lines.append(f"      Workflow: {b['workflow']}")
            report_lines.append("")

        if unreleased:
            report_lines.append(f"UNRELEASED PARTS ({len(unreleased)} total)")
            report_lines.append("-" * 60)
            for u in unreleased:
                lbl = f"{u['item_id']}/{u['rev']}" if u['rev'] else u['item_id']
                report_lines.append(f"  ✗ {lbl} — {u['name']}")
                details = []
                if u['ecn']:
                    details.append(f"ECN: {u['ecn']}")
                if u['release']:
                    details.append(f"Has: {u['release']}")
                if details:
                    report_lines.append(f"      {' | '.join(details)}")
            report_lines.append("")

        with open(report_path, "w", encoding="utf-8") as f:
            f.write("\n".join(report_lines))

        _tc_logger.info(f"BOM tree files saved: {json_path}, {txt_path}, {report_path}")
        return {"json": json_path, "txt": txt_path, "report": report_path}

    def _build_row_dict(self, ecn_id, ecn_name, ecn_desc, sol_data, item_extra):
        """
        Build a row dict that matches the Excel export column names.
        Maps TC property names to VPM workflow_config column names.
        """
        item_id = sol_data.get("item_id", "")
        rev_id = sol_data.get("item_revision_id", "")

        row = {
            # ECN-level data
            "ECN ID": ecn_id,
            "ECN Description": ecn_name,
            "ECN Detail": ecn_desc,

            # Item-level data (from solution item revision)
            "Item ID": item_id,
            "Item ID/Rev": f"{item_id}/{rev_id}" if rev_id else item_id,
            "Item Revision": rev_id,
            "Item Name": sol_data.get("object_name", ""),
            "Item Description": sol_data.get("object_desc", ""),
            "Item Type": sol_data.get("object_type", ""),
            "Item Release Status": sol_data.get("release_status_list", ""),
            "Effectivity": sol_data.get("effectivity_text", ""),
            "Process Stage": sol_data.get("process_stage", ""),
            "PLM Revision": sol_data.get("h4_PLM_Revision", ""),

            # Custom properties from solution item
            "Nomenclature": sol_data.get("h4_Nomenclature", ""),
            "BGN Source": sol_data.get("h4_BGN_Source", ""),
            "BBK Source": sol_data.get("h4_BBK_Source", ""),
            "CNO Source": sol_data.get("h4_CNO_Source", ""),
            "HAB Source": sol_data.get("h4_HAB_Source", ""),
            "MTY Source": sol_data.get("h4_MTY_Source", ""),
            "SWN Source": sol_data.get("h4_SWN_Source", ""),
            "BOM Option Code": sol_data.get("h4_BOM_Option_Code", ""),
            "ECN Number": sol_data.get("h4_ECN_Number", ecn_id),
            "Finish Code": sol_data.get("h4_Finish_Code", ""),
            "Finish Color": sol_data.get("h4_Finish_Color", ""),
            "Risk Level": sol_data.get("h4_Risk_Level", ""),
            "High Level Category": sol_data.get("h4_High_Level_Category", ""),
            "Sub Category": sol_data.get("h4_Sub_Category", ""),
            "Hussmann Item Type": sol_data.get("h4_Hussmann_Item_Type", ""),
            "Template Name": sol_data.get("h4_Template_Name", ""),
            "Plant": sol_data.get("h4_Plant", ""),
            "Plant Coded": sol_data.get("h4_Plant_Coded", ""),
            "Plant Template": sol_data.get("h4_Plant_Template", ""),
            "EAU": sol_data.get("h4_EAU", ""),

            # Item-level properties (from parent Item via "Item..." query)
            "Product Family": item_extra.get("h4_Product_Family", sol_data.get("h4_Product_Family", "")),
            "Product Line": item_extra.get("h4_Product_Line", sol_data.get("h4_Product_Line", "")),
            "Model Group": item_extra.get("h4_Model_Group", sol_data.get("h4_Model_Group", "")),
            "UOM": item_extra.get("uom_tag", ""),
            "Analyst": item_extra.get("analyst_user_id", sol_data.get("analyst_user_id", "")),
            "Owner": item_extra.get("owning_user", sol_data.get("owning_user", "")),

            # Source metadata
            "_source": "teamcenter",
            "_item_uid": sol_data.get("_uid", ""),
        }

        return row


# ============================================================================
# STANDALONE TEST
# ============================================================================

if __name__ == "__main__":
    """Quick test — run this file directly to test TC connectivity."""
    import sys
    from PyQt6.QtWidgets import QApplication

    app = QApplication(sys.argv)

    # Show login dialog
    dialog = TcLoginDialog()
    if dialog.exec() == QDialog.DialogCode.Accepted:
        client = dialog.get_client()
        print(f"Connected as: {client.username}")

        # Show search dialog
        search = TcSearchDialog(client)
        if search.exec() == QDialog.DialogCode.Accepted:
            results = search.get_results()
            print(f"Fetched {len(results)} rows")
            for row in results[:3]:
                print(f"  {row.get('Item ID', '?')} - {row.get('Item Name', '?')}")

        client.logout()
        print("Disconnected")
    else:
        print("Login cancelled")

    sys.exit(0)
