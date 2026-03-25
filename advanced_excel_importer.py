_VPM_VERSION = "3.1.5"  # Robust rejection backtracking (end==start handling)
import pandas as pd
import datetime
from PyQt6.QtWidgets import QFileDialog, QMessageBox, QDialog, QVBoxLayout, QScrollArea, QWidget, QLabel, QHBoxLayout, QFrame, QGridLayout, QProgressBar
from PyQt6.QtGui import QPainter, QColor, QPen, QFont, QBrush, QPolygonF
from PyQt6.QtCore import QRectF, Qt, QSize, QPointF
import os

# --- Data Models for ECN Workflow ---

class Priority:
    MEDIUM = 2

class Item:
    """Represents an ECN Item, now with a full workflow and status logic."""
    def __init__(self, id, pr_number, ecn_number, raw_data):
        self.id, self.pr_number, self.ecn_number = id, pr_number, ecn_number
        self.is_ecn_item, self.name, self.uid = True, str(id), f"{pr_number}-{ecn_number}-{id}"
        self.start, self.finish, self.bar_rect = None, None, QRectF()
        self.progress, self.is_milestone, self.children, self.parent = 0, False, [], None
        self.priority, self.is_active, self.comments = Priority.MEDIUM, True, []
        self.raw_data = raw_data
        
        # Status attributes to be calculated once
        self.is_rejected = False
        self.has_pending_mcn_task = False
        self.needs_attention = False
        self.effective_progress = 0

        # Granular step-based progress tracking
        self.current_step_name = ""
        self.current_step_performer = ""
        self.current_step_start_date = None
        self.completed_steps = 0
        self.total_steps = 0

        # ECN dependency tracking
        self.waiting_on_ecn = False
        self.ecn_peers_behind = 0

    def get_all_subtasks(self): return []

class ECN:
    def __init__(self, name, pr_number):
        self.name, self.pr_number, self.uid = name, pr_number, f"{pr_number}-{name}"
        self.items, self.children, self.is_ecn_item = [], [], True
        self.start, self.finish, self.bar_rect = datetime.datetime.now(), datetime.datetime.now(), QRectF()
        self.progress, self.is_milestone, self.parent = 0, False, None
        self.priority, self.is_active, self.comments = Priority.MEDIUM, True, []
        self.children = self.items

        # Status attributes to be calculated once
        self.is_rejected = False
        self.has_pending_mcn_task = False
        self.needs_attention = False
        self.effective_progress = 0

    def update_dates(self):
        valid_children = [c for c in self.children if c.start and c.finish]
        if valid_children:
            self.start = min(c.start for c in valid_children)
            self.finish = max(c.finish for c in valid_children)
        else:
            self.start = self.start or datetime.datetime.now()
            self.finish = self.finish or datetime.datetime.now()

    def get_all_subtasks(self): return self.children
    
    def get_all_tasks(self):
        flat_list = []
        for task in self.children:
            flat_list.append(task)
            flat_list.extend(task.get_all_subtasks())
        return flat_list

class ProblemReport:
    def __init__(self, name):
        self.name, self.uid, self.ecns, self.root_tasks = name, name, {}, []
        self.children, self.is_ecn_item = self.root_tasks, True
        self.start, self.finish, self.is_milestone = datetime.datetime.now(), datetime.datetime.now(), False
        self.bar_rect, self.progress, self.is_active = QRectF(), 0, True
        self.comments, self.source_plugin, self.parent = [], 'ECN Importer', None
        
        # Status attributes to be calculated once
        self.is_rejected = False
        self.has_pending_mcn_task = False
        self.needs_attention = False
        self.effective_progress = 0

    def update_dates(self):
        for ecn in self.ecns.values():
            if hasattr(ecn, 'update_dates'):
                ecn.update_dates()
                
        self.children = list(self.ecns.values())
        self.root_tasks = self.children
        valid_children = [c for c in self.children if c.start and c.finish]
        if valid_children:
            self.start = min(c.start for c in valid_children)
            self.finish = max(c.finish for c in valid_children)
        else:
            self.start = self.start or datetime.datetime.now()
            self.finish = self.finish or datetime.datetime.now()

    def get_all_tasks(self):
        flat_list = []
        for ecn in self.ecns.values():
            flat_list.append(ecn)
            flat_list.extend(ecn.get_all_tasks())
        return flat_list
        
    def get_all_subtasks(self): return self.children

# --- UI Components for the ECN Workflow ---

class WorkflowFlowchartDialog(QDialog):
    def __init__(self, item, workflow_config, parent=None):
        super().__init__(parent)
        self.item = item
        self.workflow_config = workflow_config
        self.setWindowTitle(f"Workflow Status: {self.item.name}")
        self.setMinimumSize(720, 500)
        self.resize(750, 650)
        self.setStyleSheet("background-color: #fdfefe;")

        dialog_layout = QVBoxLayout(self)
        dialog_layout.setContentsMargins(12, 12, 12, 12)

        # Header with item info
        header = QLabel(f"<h3 style='margin:0;'>Workflow Status — {self.item.name}</h3>")
        dialog_layout.addWidget(header)

        # Progress bar
        pbar = QProgressBar()
        pbar.setValue(int(self.item.effective_progress))
        pbar.setFormat(f"{self.item.effective_progress:.0f}%  ({self.item.completed_steps}/{self.item.total_steps} steps)")
        pbar.setFixedHeight(22)
        pbar.setStyleSheet("""
            QProgressBar { border: 1px solid #ccc; border-radius: 4px; text-align: center; background: #f0f0f0; font-size: 11px; }
            QProgressBar::chunk { background: #3498db; border-radius: 3px; }
        """)
        dialog_layout.addWidget(pbar)

        # On Hold - ECN Pending banner
        if getattr(self.item, 'waiting_on_ecn', False):
            peers = getattr(self.item, 'ecn_peers_behind', 0)
            peer_text = f" — {peers} peer item{'s' if peers != 1 else ''} still in progress" if peers > 0 else ""
            banner = QLabel(f"<b>On Hold — ECN not released{peer_text}</b>")
            banner.setStyleSheet(
                "background-color: #FFF3CD; color: #856404; padding: 6px 10px; "
                "border: 1px solid #ffc107; border-radius: 4px; font-size: 11px;"
            )
            dialog_layout.addWidget(banner)

        dialog_layout.addSpacing(6)

        # Scroll area for step rows
        scroll_area = QScrollArea()
        scroll_area.setWidgetResizable(True)
        scroll_area.setFrameShape(QFrame.Shape.NoFrame)
        container = QWidget()
        self.rows_layout = QVBoxLayout(container)
        self.rows_layout.setContentsMargins(0, 0, 0, 0)
        self.rows_layout.setSpacing(3)

        self.build_workflow_view()

        self.rows_layout.addStretch()
        scroll_area.setWidget(container)
        dialog_layout.addWidget(scroll_area)

    def step_applies(self, config):
        """Check if a workflow step applies to this item using engine logic."""
        engine = self.parent().ecn_engine if hasattr(self.parent(), 'ecn_engine') else None
        if engine:
            return engine.task_applies_to_item(self.item.raw_data, config)
        return True

    def create_step_row(self, config):
        """Create a compact single-row widget for one workflow step."""
        color, performer, status_text = self.get_task_state(config['name'])

        row_frame = QFrame()
        row_frame.setFixedHeight(36)
        h = QHBoxLayout(row_frame)
        h.setContentsMargins(10, 2, 10, 2)
        h.setSpacing(8)

        # Status dot
        dot = QLabel("\u25CF")  # ●
        dot.setStyleSheet(f"color: {color}; font-size: 14px; background: transparent;")
        dot.setFixedWidth(18)
        dot.setAlignment(Qt.AlignmentFlag.AlignCenter)
        h.addWidget(dot)

        # Step name
        name_lbl = QLabel(config['name'])
        name_lbl.setFixedWidth(210)
        name_lbl.setStyleSheet("font-weight: bold; font-size: 11px; background: transparent;")
        h.addWidget(name_lbl)

        # Performer
        perf_lbl = QLabel(performer)
        perf_lbl.setFixedWidth(180)
        perf_lbl.setStyleSheet("color: #555; font-size: 11px; background: transparent;")
        h.addWidget(perf_lbl)

        # Status / date
        status_lbl = QLabel(status_text)
        status_lbl.setMinimumWidth(130)
        status_lbl.setStyleSheet("font-size: 11px; background: transparent;")
        h.addWidget(status_lbl)

        # Row background tint
        bg_map = {"#2ecc71": "#e8f8f0", "#f1c40f": "#fef9e7", "#e74c3c": "#fdedec", "#ecf0f1": "#f5f5f5"}
        bg = bg_map.get(color, "#f8f9fa")
        row_frame.setStyleSheet(f"QFrame {{ background: {bg}; border-radius: 4px; border: 1px solid #e0e0e0; }}")

        return row_frame

    def find_flexible_column(self, columns, base_pattern):
        """
        Find a column that matches the base pattern, allowing for dynamic extensions like (1), (2), etc.
        Examples:
        - base_pattern: "Item SheetMetal Performer" matches "Item SheetMetal Performer (1)"
        - base_pattern: "Item Lead Eng Status" matches "Item Lead Eng Status (2)"
        """
        if not base_pattern:
            return None
            
        # First try exact match
        if base_pattern in columns:
            return base_pattern
            
        # Try case-insensitive exact match
        for col in columns:
            if col.lower() == base_pattern.lower():
                return col
        
        # Try pattern matching with extensions
        base_lower = base_pattern.lower()
        for col in columns:
            col_lower = col.lower()
            # Check if column starts with base pattern and has optional extension
            if col_lower.startswith(base_lower):
                # Check if the rest is just whitespace and optional extension like (1), (2), etc.
                remaining = col_lower[len(base_lower):].strip()
                if not remaining or (remaining.startswith('(') and remaining.endswith(')') and remaining[1:-1].isdigit()):
                    return col
        
        # Try with common variations
        variations = [
            base_pattern.replace(" Performer", " Assignee"),
            base_pattern.replace(" Assignee", " Performer"),
            base_pattern.replace(" End Date Performer", " Performer"),
            base_pattern.replace(" Performer Name", " Performer"),
        ]
        
        for variation in variations:
            if variation in columns:
                return variation
            for col in columns:
                if col.lower() == variation.lower():
                    return col
                if col.lower().startswith(variation.lower()):
                    remaining = col.lower()[len(variation.lower()):].strip()
                    if not remaining or (remaining.startswith('(') and remaining.endswith(')') and remaining[1:-1].isdigit()):
                        return col
        
        return None

    def _iter_cell_values(self, value):
        """Normalize scalar/Series/array-like cell values to a flat list."""
        if isinstance(value, pd.Series):
            return value.tolist()
        if isinstance(value, (list, tuple, set)):
            return list(value)
        if hasattr(value, "tolist") and not isinstance(value, (str, bytes, dict)):
            converted = value.tolist()
            if isinstance(converted, list):
                return converted
            return [converted]
        return [value]

    def _row_value_has_non_null(self, row, col_name):
        """True if any value for col_name is non-null."""
        if not col_name:
            return False
        values = self._iter_cell_values(row.get(col_name))
        return any(pd.notna(v) for v in values)

    def _row_value_has_text(self, row, col_name):
        """True if any value for col_name has non-empty text."""
        if not col_name:
            return False
        values = self._iter_cell_values(row.get(col_name))
        for v in values:
            if pd.notna(v) and str(v).strip():
                return True
        return False

    def get_task_state(self, task_name):
        row = self.item.raw_data
        # Get the engine instance to access conditional logic methods
        engine = self.parent().ecn_engine if hasattr(self.parent(), 'ecn_engine') else None

        for config in self.workflow_config:
            if config['name'] == task_name:
                # Check if task applies to this item (conditional logic)
                if engine and not engine.task_applies_to_item(row, config):
                    return "#ecf0f1", config.get('default_performer', ''), "Not Applicable"

                # Use flexible column matching for all columns
                start_col = self.find_flexible_column(row.keys(), config['start_date_col']) if config['start_date_col'] else None
                end_col = self.find_flexible_column(row.keys(), config['end_date_col']) if config['end_date_col'] else None
                status_col = self.find_flexible_column(row.keys(), config['status_col']) if config['status_col'] else None
                performer_col = self.find_flexible_column(row.keys(), config['performer_col']) if config['performer_col'] else None

                start_date = pd.to_datetime(row.get(start_col), errors='coerce') if start_col else pd.NaT
                end_date = pd.to_datetime(row.get(end_col), errors='coerce') if end_col else pd.NaT
                status = str(row.get(status_col, "")).title() if status_col else ""

                # Get performer, use default if not assigned
                performer = row.get(performer_col, "") if performer_col else ""
                if pd.isna(performer) or performer is None or str(performer).strip() == "":
                    performer = config.get('default_performer', '')
                else:
                    performer = str(performer)

                if "Reject" in status:
                    return "#e74c3c", performer, "Rejected"
                if pd.notna(end_date):
                    return "#2ecc71", performer, f"Completed: {end_date.strftime('%Y-%m-%d')}"
                # Fallback: config expects end_date column but not found in report
                if end_col is None and config['end_date_col'] is not None and status:
                    if any(kw in status.upper() for kw in ['RELEASED', 'COMPLETED', 'APPROVED']):
                        return "#2ecc71", performer, status
                if pd.notna(start_date):
                    if config['end_date_col'] is None:
                        # Event step (creation) — start = done
                        return "#2ecc71", performer, f"Completed: {start_date.strftime('%Y-%m-%d')}"
                    return "#f1c40f", performer, f"In Progress: {start_date.strftime('%Y-%m-%d')}"

                return "#bdc3c7", performer, "Pending"
        return "#bdc3c7", "", "Pending"

    def build_workflow_view(self):
        """Build compact table-based workflow status view organized by phase."""
        # ECN Release Process section
        ecn_header = QLabel("<b style='font-size:13px; color:#2c3e50;'>ECN Release Process</b>")
        ecn_header.setContentsMargins(4, 4, 0, 2)
        self.rows_layout.addWidget(ecn_header)

        # ECN steps are the first 18 entries in workflow_config (PR Created → ECN Completed)
        ecn_step_names = {
            'PR Created', 'PR CS1 Review', 'PR Project Assignment',
            'ECR Created', 'ECR CS2 Review', 'ECN Created',
            'Design Task', 'Item Created Under ECN',
            'Lead Engineer Review 1', 'Lead Engineer Review 2', 'Lead Engineer Review 3',
            'Copper Review', 'Sheetmetal Review', 'Design Released',
            'CFT MFG Review', 'CFT Compliance Review', 'Controller Review', 'ECN Completed'
        }
        for config in self.workflow_config:
            if config['name'] in ecn_step_names and self.step_applies(config):
                self.rows_layout.addWidget(self.create_step_row(config))

        # Separator
        sep = QFrame()
        sep.setFrameShape(QFrame.Shape.HLine)
        sep.setStyleSheet("color: #ccc;")
        sep.setFixedHeight(2)
        self.rows_layout.addSpacing(6)
        self.rows_layout.addWidget(sep)
        self.rows_layout.addSpacing(4)

        # MCN Release Process section
        mcn_header = QLabel("<b style='font-size:13px; color:#2c3e50;'>MCN Release Process</b>")
        mcn_header.setContentsMargins(4, 2, 0, 2)
        self.rows_layout.addWidget(mcn_header)

        for config in self.workflow_config:
            if config['name'] not in ecn_step_names and self.step_applies(config):
                self.rows_layout.addWidget(self.create_step_row(config))

class EcnDashboardEngine:
    def __init__(self, main_window):
        self.main_window = main_window
        self.workflow_config = [
            # PR/ECR/ECN Creation Stages (1-6) - Added to track early workflow stages
            {'name': 'PR Created', 'start_date_col': 'PR Created Date', 'end_date_col': None, 'performer_col': 'PR Creator', 'status_col': 'PR Status', 'default_performer': 'User (Anyone @Hussmann)', 'condition': None},
            {'name': 'PR CS1 Review', 'start_date_col': 'PR CS1 Review Start Date', 'end_date_col': 'PR CS1 Review End Date', 'performer_col': 'PR CS1 Review Performer', 'status_col': 'PR CS1 Review Status', 'default_performer': 'Change Specialist 1', 'condition': None},
            {'name': 'PR Project Assignment', 'start_date_col': 'PR Project Assignment Date', 'end_date_col': None, 'performer_col': None, 'status_col': None, 'default_performer': 'System/Admin', 'condition': None},
            {'name': 'ECR Created', 'start_date_col': 'ECR Created Date', 'end_date_col': None, 'performer_col': 'ECR Creator', 'status_col': 'ECR Status', 'default_performer': 'Change Specialist 1', 'condition': lambda row: self._is_full_track(row)},
            {'name': 'ECR CS2 Review', 'start_date_col': 'ECR CS2 Review Start Date', 'end_date_col': 'ECR CS2 Review End Date', 'performer_col': 'ECR CS2 Review Performer', 'status_col': 'ECR CS2 Review Status', 'default_performer': 'Change Specialist 2', 'condition': lambda row: self._is_full_track(row)},
            {'name': 'ECN Created', 'start_date_col': 'ECN Created Date', 'end_date_col': None, 'performer_col': 'ECN Creator', 'status_col': 'ECN Status', 'default_performer': 'Change Specialist', 'condition': None},

            # Design and Review Stages (7-15)
            {'name': 'Design Task', 'start_date_col': 'ECN Design Task Start Date', 'end_date_col': 'ECN Design Task End Date', 'performer_col': 'ECN Design Task Performer', 'status_col': 'ECN Design Task Status', 'default_performer': 'Design Engineer', 'condition': None},
            {'name': 'Item Created Under ECN', 'start_date_col': 'Item Created Date', 'end_date_col': None, 'performer_col': 'Item Creator', 'status_col': None, 'default_performer': 'Design Engineer', 'condition': None},
            {'name': 'Lead Engineer Review 1', 'start_date_col': 'Item Lead Eng Start Date (1)', 'end_date_col': 'Item Lead Eng End Date (1)', 'performer_col': 'Item Lead Eng Performer (1)', 'status_col': 'Item Lead Eng Status (1)', 'default_performer': 'Lead Engineer', 'condition': None},
            {'name': 'Lead Engineer Review 2', 'start_date_col': 'Item Lead Eng Start Date (2)', 'end_date_col': 'Item Lead Eng End Date (2)', 'performer_col': 'Item Lead Eng Performer (2)', 'status_col': 'Item Lead Eng Status (2)', 'default_performer': 'Lead Engineer', 'condition': lambda row: pd.notna(row.get('Item Lead Eng Performer (2)'))},
            {'name': 'Lead Engineer Review 3', 'start_date_col': 'Item Lead Eng Start Date (3)', 'end_date_col': 'Item Lead Eng End Date (3)', 'performer_col': 'Item Lead Eng Performer (3)', 'status_col': 'Item Lead Eng Status (3)', 'default_performer': 'Lead Engineer', 'condition': lambda row: pd.notna(row.get('Item Lead Eng Performer (3)'))},
            {'name': 'Copper Review', 'start_date_col': 'Item Copper Review Start Date', 'end_date_col': 'Item Copper Review End Date', 'performer_col': 'Item Copper Review Performer', 'status_col': 'Item Copper Review Status', 'default_performer': 'Copper Programmer', 'condition': lambda row: self._is_part(row) and self._is_copper(row)},
            {'name': 'Sheetmetal Review', 'start_date_col': 'Item SheetMetal Start Date', 'end_date_col': 'Item SheetMetal End Date', 'performer_col': 'Item SheetMetal Performer', 'status_col': 'Item SheetMetal Status', 'default_performer': 'Sheetmetal Programmer', 'condition': lambda row: self._is_part(row) and self._is_sheetmetal(row)},
            {'name': 'Design Released', 'start_date_col': None, 'end_date_col': 'Design Released Date', 'performer_col': None, 'status_col': 'Item Release Status', 'default_performer': 'SYSTEM TASK (Not Manual)', 'condition': None},
            {'name': 'CFT MFG Review', 'start_date_col': 'ECN CFT MFG Start Date', 'end_date_col': 'ECN CFT MFG End Date', 'performer_col': 'ECN CFT MFG Performer', 'status_col': 'ECN CFT MFG Status', 'default_performer': 'Manufacturing Engineer', 'condition': lambda row: not self._is_bgn(row)},
            {'name': 'CFT Compliance Review', 'start_date_col': 'ECN CFT Compliance Start Date', 'end_date_col': 'ECN CFT Compliance End Date', 'performer_col': 'ECN CFT Compliance Performer', 'status_col': 'ECN CFT Compliance Status', 'default_performer': 'Compliance Engineer', 'condition': None},
            {'name': 'Controller Review', 'start_date_col': 'ECN Controller Review Start Date', 'end_date_col': 'ECN Controller Review End Date', 'performer_col': 'ECN Controller Review Performer', 'status_col': 'ECN Controller Review Status', 'default_performer': 'Controller', 'condition': None},
            {'name': 'ECN Completed', 'start_date_col': None, 'end_date_col': 'ECN Released Date', 'performer_col': None, 'status_col': None, 'default_performer': 'SYSTEM TASK (Not Manual)', 'condition': None},

            # MCN and Production Implementation Stages (16-28)
            {'name': 'Item Production Released', 'start_date_col': None, 'end_date_col': 'Item Production Released Date', 'performer_col': None, 'status_col': None, 'default_performer': 'SYSTEM TASK (Not Manual)', 'condition': None},
            {'name': 'MCN Created', 'start_date_col': 'MCN Creation Date', 'end_date_col': None, 'performer_col': None, 'status_col': None, 'default_performer': 'SYSTEM TASK (Not Manual)', 'condition': None},
            {'name': 'Supply Chain', 'start_date_col': 'Item Supply Chain Start Date', 'end_date_col': 'Item Supply Chain End Date', 'performer_col': 'Item Supply Chain Performer', 'status_col': 'Item Supply Chain Status', 'default_performer': 'Sourcing Manager', 'condition': lambda row: self._is_buy(row)},
            {'name': 'Analyst Review', 'start_date_col': 'ECN Analyst Review Start Date', 'end_date_col': 'ECN Analyst Review End Date', 'performer_col': 'ECN Analyst Review Performer', 'status_col': 'ECN Analyst Review Status', 'default_performer': 'Design Engineer', 'condition': lambda row: self._is_rejected_by_sourcing(row)},
            {'name': 'MFG Operations', 'start_date_col': 'Item MFG Operations Start Date', 'end_date_col': 'Item MFG Operations End Date', 'performer_col': 'Item MFG Operations Performer', 'status_col': 'Item MFG Operations Status', 'default_performer': 'Manufacturing Operation', 'condition': None},
            {'name': 'MFG ENGG', 'start_date_col': 'Item MFG ENGG Start Date', 'end_date_col': 'Item MFG ENGG End Date', 'performer_col': 'Item MFG ENGG Performer', 'status_col': 'Item MFG ENGG Status', 'default_performer': 'Manufacturing Engineer', 'condition': lambda row: self._is_make(row) and not self._is_part(row) and not self._is_bgn(row)},
            {'name': 'Copper Programmer', 'start_date_col': 'Item Copper Programmer Start Date', 'end_date_col': 'Item Copper Programmer End Date', 'performer_col': 'Item Copper Programmer Performer', 'status_col': 'Item Copper Programmer Status', 'default_performer': 'Copper Programmer', 'condition': lambda row: self._is_make(row) and self._is_part(row) and self._is_copper(row)},
            {'name': 'Sheet Metal Programmer', 'start_date_col': 'Item Sheet Metal Start Date', 'end_date_col': 'Item Sheet Metal End Date', 'performer_col': 'Item Sheet Metal Performer', 'status_col': 'Item Sheet Metal Status', 'default_performer': 'Sheetmetal Programmer', 'condition': lambda row: self._is_make(row) and self._is_part(row) and self._is_sheetmetal(row)},
            {'name': 'Production Control SM', 'start_date_col': 'Item Production Control SM Start Date', 'end_date_col': 'Item Production Control SM End Date', 'performer_col': 'Item Production Control SM Performer', 'status_col': 'Item Production Control SM Status', 'default_performer': 'Production Sheetmetal', 'condition': None},
            {'name': 'First Article (FAI)', 'start_date_col': 'Item FAI Start Date', 'end_date_col': 'Item FAI End Date', 'performer_col': 'Item FAI Performer', 'status_col': 'Item FAI Status', 'default_performer': 'Quality Engineer', 'condition': None},
            {'name': 'Costing', 'start_date_col': 'Item Costing Start Date', 'end_date_col': 'Item Costing End Date', 'performer_col': 'Item Costing Performer', 'status_col': 'Item Costing Status', 'default_performer': 'Finance', 'condition': None},
            {'name': 'Costing Rework', 'start_date_col': 'Costing Rework Start Date', 'end_date_col': 'Costing Rework End Date', 'performer_col': 'Costing Rework Performer', 'status_col': 'Costing Rework Status', 'default_performer': 'Finance', 'condition': lambda row: self._has_costing_rework(row)},
            {'name': 'PPAP Needed', 'start_date_col': 'Item PPAP Needed Start Date', 'end_date_col': 'Item PPAP Needed End Date', 'performer_col': 'Item PPAP Needed Performer', 'status_col': 'Item PPAP Needed Status', 'default_performer': 'Supply Quality Engineer', 'condition': lambda row: self._is_buy(row)},
            {'name': 'PPAP Update', 'start_date_col': 'Item PPAP Update Start Date', 'end_date_col': 'Item PPAP Update End Date', 'performer_col': 'Item PPAP Update Performer', 'status_col': 'Item PPAP Update Status', 'default_performer': 'Supply Quality Engineer', 'condition': None},
            {'name': 'PPAP Update MTY', 'start_date_col': 'Item PPAP Update MTY Start Date', 'end_date_col': 'Item PPAP Update MTY End Date', 'performer_col': 'Item PPAP Update MTY Performer', 'status_col': 'Item PPAP Update MTY Status', 'default_performer': 'Supply Quality Engineer', 'condition': None},
            {'name': 'Sourceability', 'start_date_col': 'Item Sourceability Start Date', 'end_date_col': 'Item Sourceability End Date', 'performer_col': 'Item Sourceability Performer', 'status_col': 'Item Sourceability Status', 'default_performer': 'Sourcing Manager', 'condition': None},
            {'name': 'Plant Coding Sourcing', 'start_date_col': 'Item Plant Coding Sourcing Start Date', 'end_date_col': 'Item Plant Coding Sourcing End Date', 'performer_col': 'Item Plant Coding Sourcing Performer', 'status_col': None, 'default_performer': 'Sourcing Manager', 'condition': None},
            {'name': 'Part Implementation Completed', 'start_date_col': None, 'end_date_col': 'Part Implementation Completed Date', 'performer_col': None, 'status_col': None, 'default_performer': 'SYSTEM TASK (Not Manual)', 'condition': None},
            {'name': 'Set Effectivity', 'start_date_col': 'MCN Set Effectivity Start Date', 'end_date_col': 'MCN Set Effectivity End Date', 'performer_col': 'MCN Set Effectivity Performer', 'status_col': None, 'default_performer': 'Change Specialist', 'condition': None},
            {'name': 'MCN Released', 'start_date_col': None, 'end_date_col': 'MCN Released Date', 'performer_col': None, 'status_col': None, 'default_performer': 'SYSTEM TASK (Not Manual)', 'condition': None},
        ]

    def find_column_matches(self, columns):
        mapped = {}
        lower_columns = {col.lower(): col for col in columns}
        pr_terms = ['pr id', 'problem report', 'pr number']
        ecn_terms = ['ecn id', 'ecn number']
        item_terms = ['item id/rev', 'item id', 'item']
        for term in pr_terms:
            if term in lower_columns: mapped['pr'] = lower_columns[term]; break
        for term in ecn_terms:
            if term in lower_columns: mapped['ecn'] = lower_columns[term]; break
        for term in item_terms:
            if term in lower_columns: mapped['item'] = lower_columns[term]; break
        return mapped

    def find_flexible_column(self, columns, base_pattern):
        """
        Find a column that matches the base pattern, allowing for dynamic extensions like (1), (2), etc.
        Examples:
        - base_pattern: "Item SheetMetal Performer" matches "Item SheetMetal Performer (1)"
        - base_pattern: "Item Lead Eng Status" matches "Item Lead Eng Status (2)"
        """
        if not base_pattern:
            return None
            
        # First try exact match
        if base_pattern in columns:
            return base_pattern
            
        # Try case-insensitive exact match
        for col in columns:
            if col.lower() == base_pattern.lower():
                return col
        
        # Try pattern matching with extensions
        base_lower = base_pattern.lower()
        for col in columns:
            col_lower = col.lower()
            # Check if column starts with base pattern and has optional extension
            if col_lower.startswith(base_lower):
                # Check if the rest is just whitespace and optional extension like (1), (2), etc.
                remaining = col_lower[len(base_lower):].strip()
                if not remaining or (remaining.startswith('(') and remaining.endswith(')') and remaining[1:-1].isdigit()):
                    return col
        
        # Try with common variations
        variations = [
            base_pattern.replace(" Performer", " Assignee"),
            base_pattern.replace(" Assignee", " Performer"),
            base_pattern.replace(" End Date Performer", " Performer"),
            base_pattern.replace(" Performer Name", " Performer"),
        ]
        
        for variation in variations:
            if variation in columns:
                return variation
            for col in columns:
                if col.lower() == variation.lower():
                    return col
                if col.lower().startswith(variation.lower()):
                    remaining = col.lower()[len(variation.lower()):].strip()
                    if not remaining or (remaining.startswith('(') and remaining.endswith(')') and remaining[1:-1].isdigit()):
                        return col
        
        return None

    def _iter_cell_values(self, value):
        """Normalize scalar/Series/array-like cell values to a flat list."""
        if isinstance(value, pd.Series):
            return value.tolist()
        if isinstance(value, (list, tuple, set)):
            return list(value)
        if hasattr(value, "tolist") and not isinstance(value, (str, bytes, dict)):
            converted = value.tolist()
            if isinstance(converted, list):
                return converted
            return [converted]
        return [value]

    def _row_value_has_non_null(self, row, col_name):
        """True if any value for col_name is non-null."""
        if not col_name:
            return False
        values = self._iter_cell_values(row.get(col_name))
        return any(pd.notna(v) for v in values)

    def _row_value_has_text(self, row, col_name):
        """True if any value for col_name has non-empty text."""
        if not col_name:
            return False
        values = self._iter_cell_values(row.get(col_name))
        for v in values:
            if pd.notna(v) and str(v).strip():
                return True
        return False

    # --- Conditional Logic Helper Functions ---

    def _is_full_track(self, row):
        """Check if item is Full Track (FT) process"""
        risk_level = str(row.get('Risk Level', '')).upper()
        process_type = str(row.get('Process Type', '')).upper()
        return 'FT' in risk_level or 'FULL' in risk_level or 'FT' in process_type or 'FULL TRACK' in process_type

    def _is_part(self, row):
        """Check if item type is Part"""
        item_type = str(row.get('Item Type', '')).upper()
        hussmann_type = str(row.get('Item Hussmann Item Type', '')).upper()
        return 'PART' in item_type or 'PART' in hussmann_type

    def _is_copper(self, row):
        """Check if part material is Copper"""
        material = str(row.get('Part Material', '')).upper()
        part_category = str(row.get('Part Category', '')).upper()
        sub_category = str(row.get('Item Sub Category', '')).upper()
        return 'COPPER' in material or 'COPPER' in part_category or 'COPPER' in sub_category

    def _is_sheetmetal(self, row):
        """Check if part material is Sheetmetal"""
        material = str(row.get('Part Material', '')).upper()
        part_category = str(row.get('Part Category', '')).upper()
        sub_category = str(row.get('Item Sub Category', '')).upper()
        return ('SHEET' in material or 'METAL' in material or 'SHEET' in part_category
                or 'SHEET' in sub_category or 'METAL' in sub_category)

    def _is_make(self, row):
        """Check if Make/Buy decision is Make"""
        make_buy = str(row.get('Make/Buy', '')).upper()
        if 'MAKE' in make_buy:
            return True
        for col in ('Item MTY Source', 'Item HAB Source', 'Item BGN Source',
                     'Item SWN Source', 'Item CNO Source', 'Item BBK Source'):
            val = str(row.get(col, '')).upper().strip()
            if val == 'MAKE':
                return True
        return False

    def _is_buy(self, row):
        """Check if Make/Buy decision is Buy"""
        make_buy = str(row.get('Make/Buy', '')).upper()
        if 'BUY' in make_buy:
            return True
        for col in ('Item MTY Source', 'Item HAB Source', 'Item BGN Source',
                     'Item SWN Source', 'Item CNO Source', 'Item BBK Source'):
            val = str(row.get(col, '')).upper().strip()
            if val == 'BUY':
                return True
        return False

    def _is_bgn(self, row):
        """Check if item is BGN (specific category)"""
        bgn_flag = str(row.get('BGN', '')).upper()
        item_category = str(row.get('Item Category', '')).upper()
        bgn_source = str(row.get('Item BGN Source', '')).upper().strip()
        return ('BGN' in bgn_flag or 'BGN' in item_category
                or bgn_flag == 'YES' or bgn_flag == 'TRUE'
                or (bgn_source != '' and bgn_source != 'NAN'))

    def _is_rejected_by_sourcing(self, row):
        """Check if item was rejected by sourcing"""
        sourcing_status = str(row.get('Item Supply Chain Status', '')).upper()
        return 'REJECT' in sourcing_status

    def _has_costing_rework(self, row):
        """Check if item has costing rework"""
        # Check if costing rework start or end date exists
        return (
            self._row_value_has_non_null(row, 'Costing Rework Start Date')
            or self._row_value_has_non_null(row, 'Costing Rework End Date')
        )

    def task_applies_to_item(self, row, task_config):
        """
        Determine if a task applies to a specific item.

        PRIORITY 1: If task has actual data (dates/performer), it applies regardless of attributes
        PRIORITY 2: If no data, use conditional logic to determine if it should be included

        This ensures tasks with real workflow data are never skipped due to missing attribute columns.
        """
        condition = task_config.get('condition')

        # If no condition specified, task always applies
        if condition is None:
            return True

        # Check if task has ANY data in Excel (start date, end date, or performer)
        # This ensures we never skip tasks that have actual workflow activity
        start_col = self.find_flexible_column(row.keys(), task_config['start_date_col']) if task_config['start_date_col'] else None
        end_col = self.find_flexible_column(row.keys(), task_config['end_date_col']) if task_config['end_date_col'] else None
        performer_col = self.find_flexible_column(row.keys(), task_config['performer_col']) if task_config['performer_col'] else None

        has_data = False
        if start_col and self._row_value_has_non_null(row, start_col):
            has_data = True
        if end_col and self._row_value_has_non_null(row, end_col):
            has_data = True
        if performer_col and self._row_value_has_text(row, performer_col):
            has_data = True

        # PRIORITY 1: If task has data, include it regardless of condition
        # Example: Part has Copper Review data but missing "Part Material" attribute
        # → Still include Copper Review because the data exists
        if has_data:
            return True

        # PRIORITY 2: No data exists, check conditional logic
        # Example: Buy item should skip Copper Programmer task (Make-only)
        try:
            return condition(row)
        except Exception as e:
            # If condition evaluation fails (missing attributes), include task (safer default)
            print(f"Warning: Could not evaluate condition for task '{task_config['name']}': {e}")
            return True

    def _auto_complete_design_task(self, item):
        """
        Auto-completes the Design Task if it has no close date but any subsequent task 
        (like Sheetmetal/Copper reviews or Item Production tasks) is active or complete.
        This helps move focus to the next task and ensures summary data reflects actual progress.
        """
        row = item.raw_data
        
        # Find the Design Task configuration
        design_task_config = next((conf for conf in self.workflow_config if conf['name'] == 'Design Task'), None)
        if not design_task_config:
            return
        
        # Check if Design Task has an end date
        design_end_col = self.find_flexible_column(row.keys(), design_task_config['end_date_col']) if design_task_config['end_date_col'] else None
        design_end_date = pd.to_datetime(row.get(design_end_col), errors='coerce') if design_end_col else pd.NaT
        
        # If Design Task already has an end date, no need to auto-complete
        if pd.notna(design_end_date):
            return
        
        # Get the index of Design Task in workflow
        design_task_index = next((i for i, conf in enumerate(self.workflow_config) if conf['name'] == 'Design Task'), -1)
        if design_task_index == -1:
            return
        
        # First check: if any subsequent task has a rejection status
        # (No Decision, Reject), do NOT auto-complete Design Task because
        # the workflow may have looped back to Design after a rejection.
        for i in range(design_task_index + 1, len(self.workflow_config)):
            task_config = self.workflow_config[i]
            status_col_name = task_config.get('status_col')
            if status_col_name:
                status_col = self.find_flexible_column(row.keys(), status_col_name)
                if status_col:
                    status_val = str(row.get(status_col, "")).upper().strip()
                    if status_val and ("REJECT" in status_val or "NO DECISION" in status_val):
                        # Rejection found downstream — don't auto-complete
                        return

        # Check all tasks after Design Task
        for i in range(design_task_index + 1, len(self.workflow_config)):
            task_config = self.workflow_config[i]

            # Skip tasks without start/end date columns
            if not task_config['start_date_col'] and not task_config['end_date_col']:
                continue

            # Use flexible column matching
            start_col = self.find_flexible_column(row.keys(), task_config['start_date_col']) if task_config['start_date_col'] else None
            end_col = self.find_flexible_column(row.keys(), task_config['end_date_col']) if task_config['end_date_col'] else None

            # Check if task has started
            start_date = pd.to_datetime(row.get(start_col), errors='coerce') if start_col else pd.NaT
            end_date = pd.to_datetime(row.get(end_col), errors='coerce') if end_col else pd.NaT

            # If any subsequent task has started or completed, auto-complete Design Task
            if pd.notna(start_date) or pd.notna(end_date):
                # Mark Design Task as complete by setting its end date to its start date or today
                design_start_col = self.find_flexible_column(row.keys(), design_task_config['start_date_col']) if design_task_config['start_date_col'] else None
                design_start_date = pd.to_datetime(row.get(design_start_col), errors='coerce') if design_start_col else pd.NaT

                # Set the end date to the start date (if available) or to the earliest subsequent task date
                if pd.notna(design_start_date):
                    item.raw_data[design_end_col] = design_start_date
                elif pd.notna(start_date):
                    item.raw_data[design_end_col] = start_date
                else:
                    item.raw_data[design_end_col] = datetime.datetime.now()

                # Break after auto-completing
                return

    def _calculate_ecn_statuses(self, prs_dict):
        """
        Pre-calculates all status fields for ECN items using step-based progress.
        For each item, counts completed vs total applicable workflow steps to produce
        a granular progress percentage (0-100%). Called once after all data is loaded.
        """
        for pr in prs_dict.values():
            for ecn in pr.ecns.values():
                for item in ecn.items:
                    row = item.raw_data
                    self._auto_complete_design_task(item)

                    # Step 1: Determine applicable steps.
                    # Include a step if it has actual data, OR if it has a
                    # condition that evaluates to True (the task is expected
                    # for this part type even though it hasn't started yet).
                    applicable_steps = []
                    for config in self.workflow_config:
                        if not self.task_applies_to_item(row, config):
                            continue
                        has_any_data = False
                        for col_key in ['start_date_col', 'end_date_col', 'performer_col', 'status_col']:
                            col_name = config.get(col_key)
                            if col_name:
                                found = self.find_flexible_column(row.keys(), col_name)
                                if found and found in row and self._row_value_has_non_null(row, found):
                                    has_any_data = True
                                    break
                        if has_any_data:
                            applicable_steps.append(config)
                        elif config.get('condition') is not None:
                            # Conditional step whose condition was met but has
                            # no data yet — include so "not started" tasks are
                            # counted toward total progress.
                            try:
                                if config['condition'](row):
                                    applicable_steps.append(config)
                            except Exception:
                                pass

                    # ── Pass 1: Find the highest-position completed step ──
                    # If step N is complete, all steps before N are implicitly
                    # complete even if their data is missing from the report.
                    config_position = {id(cfg): i for i, cfg in enumerate(self.workflow_config)}
                    highest_completed_pos = -1
                    highest_completed_name = ""
                    highest_activity_pos = -1  # Tracks the furthest step with ANY start date
                    for config in applicable_steps:
                        pos = config_position.get(id(config), 0)
                        _end = self.find_flexible_column(row.keys(), config['end_date_col']) if config.get('end_date_col') else None
                        _start = self.find_flexible_column(row.keys(), config['start_date_col']) if config.get('start_date_col') else None
                        if config['end_date_col'] is None:
                            _done = pd.notna(pd.to_datetime(row.get(_start), errors='coerce')) if _start else False
                        elif _end:
                            _done = pd.notna(pd.to_datetime(row.get(_end), errors='coerce'))
                        else:
                            _sc = self.find_flexible_column(row.keys(), config.get('status_col')) if config.get('status_col') else None
                            _sv = str(row.get(_sc, "")).upper() if _sc else ""
                            _done = any(kw in _sv for kw in ['RELEASED', 'COMPLETED', 'APPROVED']) if _sv else (pd.notna(pd.to_datetime(row.get(_start), errors='coerce')) if _start else False)
                        if _done and pos > highest_completed_pos:
                            highest_completed_pos = pos
                            highest_completed_name = config['name']
                        # Track furthest step with a start date — if step N has
                        # started, all steps 0..N-1 are implicitly complete
                        _has_start = pd.notna(pd.to_datetime(row.get(_start), errors='coerce')) if _start else False
                        if _has_start and pos > highest_activity_pos:
                            highest_activity_pos = pos

                    # If a later step has started, all prior steps must be done
                    if highest_activity_pos > highest_completed_pos:
                        highest_completed_pos = highest_activity_pos - 1

                    # ── Pass 2: Count completed steps, find bottleneck ──
                    completed_count = 0
                    current_step_found = False
                    is_rejected = False

                    for config in applicable_steps:
                        pos = config_position.get(id(config), 0)
                        end_col = self.find_flexible_column(row.keys(), config['end_date_col']) if config['end_date_col'] else None
                        start_col = self.find_flexible_column(row.keys(), config['start_date_col']) if config['start_date_col'] else None
                        status_col = self.find_flexible_column(row.keys(), config.get('status_col')) if config.get('status_col') else None

                        end_date = pd.to_datetime(row.get(end_col), errors='coerce') if end_col else pd.NaT
                        start_date = pd.to_datetime(row.get(start_col), errors='coerce') if start_col else pd.NaT
                        status = str(row.get(status_col, "")).upper() if status_col else ""

                        # Determine completion — steps at or before the highest
                        # completed position are implicitly done (gap-skipping).
                        step_complete = False
                        if pos <= highest_completed_pos:
                            step_complete = True
                        elif config['end_date_col'] is None:
                            step_complete = pd.notna(start_date)
                        elif end_col is None:
                            if status:
                                step_complete = any(kw in status for kw in ['RELEASED', 'COMPLETED', 'APPROVED'])
                            else:
                                step_complete = pd.notna(start_date)
                        else:
                            step_complete = pd.notna(end_date)

                        # Check rejection — only flag if the rejected step
                        # is NOT yet complete (issue was fixed and moved past).
                        # "No Decision" also counts as rejection (sends work back)
                        is_rejection_status = (
                            "REJECT" in status or "NO DECISION" in status
                        )
                        if is_rejection_status and not step_complete:
                            is_rejected = True

                        if step_complete:
                            completed_count += 1
                        elif not current_step_found:
                            # Only mark as bottleneck if the step has actually
                            # started (has a start date) or is in progress.
                            # Steps with zero data (no start, no end, no status)
                            # are future steps that haven't begun — skip them.
                            has_any_activity = (
                                pd.notna(start_date) or pd.notna(end_date) or
                                bool(status.strip())
                            )
                            if has_any_activity:
                                current_step_found = True
                                item.current_step_name = config['name']
                                item.current_step_start_date = start_date if pd.notna(start_date) else None
                                performer_col = self.find_flexible_column(row.keys(), config['performer_col']) if config.get('performer_col') else None
                                performer = row.get(performer_col, "") if performer_col else ""
                                if pd.isna(performer) or performer is None or not str(performer).strip():
                                    performer = config.get('default_performer', '')
                                item.current_step_performer = str(performer)

                    # ── Rejection backtracking ──
                    # When a step has a rejection status (No Decision, Reject,
                    # etc.), the workflow loops BACK to an earlier step. Find
                    # the earlier step that has a start date but no end date —
                    # that's where the work actually went.
                    #
                    # Also handles the case where _auto_complete_design_task
                    # set end = start (auto-completed): treat end == start as
                    # "not really complete" when there's a rejection downstream.
                    if current_step_found and is_rejected:
                        try:
                            _match = next(c for c in applicable_steps if c['name'] == item.current_step_name)
                            rejected_step_pos = config_position.get(id(_match), 999)
                        except StopIteration:
                            rejected_step_pos = 999
                        for earlier_cfg in applicable_steps:
                            earlier_pos = config_position.get(id(earlier_cfg), 0)
                            if earlier_pos >= rejected_step_pos:
                                continue  # Only look at steps BEFORE the rejection
                            _e_start_col = self.find_flexible_column(row.keys(), earlier_cfg['start_date_col']) if earlier_cfg.get('start_date_col') else None
                            _e_end_col = self.find_flexible_column(row.keys(), earlier_cfg['end_date_col']) if earlier_cfg.get('end_date_col') else None
                            _e_start = pd.to_datetime(row.get(_e_start_col), errors='coerce') if _e_start_col else pd.NaT
                            _e_end = pd.to_datetime(row.get(_e_end_col), errors='coerce') if _e_end_col else pd.NaT
                            # Step is "open" if: no end date, OR end == start
                            # (auto-completed by _auto_complete_design_task)
                            end_is_missing = pd.isna(_e_end)
                            end_equals_start = (pd.notna(_e_end) and pd.notna(_e_start) and _e_end == _e_start)
                            if pd.notna(_e_start) and (end_is_missing or end_equals_start):
                                # This earlier step is open (restarted or auto-completed)
                                item.current_step_name = earlier_cfg['name']
                                item.current_step_start_date = _e_start
                                # Undo auto-complete: reset end date back to NaT
                                if end_equals_start and _e_end_col:
                                    item.raw_data[_e_end_col] = pd.NaT
                                _e_perf_col = self.find_flexible_column(row.keys(), earlier_cfg['performer_col']) if earlier_cfg.get('performer_col') else None
                                _e_perf = row.get(_e_perf_col, "") if _e_perf_col else ""
                                if pd.isna(_e_perf) or not str(_e_perf).strip():
                                    _e_perf = earlier_cfg.get('default_performer', '')
                                item.current_step_performer = str(_e_perf)
                                break  # Found the backtracked step

                    # Step 3: Calculate progress
                    total = len(applicable_steps)
                    item.completed_steps = completed_count
                    item.total_steps = total
                    item.is_rejected = is_rejected

                    if total > 0:
                        item.effective_progress = round((completed_count / total) * 100, 1)
                    else:
                        item.effective_progress = 0

                    if not current_step_found:
                        if completed_count == total and total > 0:
                            # All applicable steps done — search for next pending
                            # step AFTER the highest completed position only.
                            applicable_set = set(id(s) for s in applicable_steps)
                            next_pending = None
                            for cfg in self.workflow_config[highest_completed_pos + 1:]:
                                if not self.task_applies_to_item(row, cfg):
                                    continue
                                if id(cfg) in applicable_set:
                                    continue
                                next_pending = cfg
                                break
                            if next_pending:
                                p_col = self.find_flexible_column(row.keys(), next_pending['performer_col']) if next_pending.get('performer_col') else None
                                p_val = row.get(p_col, "") if p_col else ""
                                if pd.isna(p_val) or not str(p_val).strip():
                                    p_val = next_pending.get('default_performer', '')
                                item.current_step_name = next_pending['name']
                                item.current_step_performer = str(p_val)
                            else:
                                # Show last completed step name (e.g., "MCN Released")
                                item.current_step_name = highest_completed_name or "Completed"
                                item.current_step_performer = ""
                        else:
                            item.current_step_name = highest_completed_name or "Completed"
                            item.current_step_performer = ""

                    # ECN dependency flag (set in ECN-level pass below)
                    item.waiting_on_ecn = False
                    item.ecn_peers_behind = 0

                    # Pending MCN task: item is deep in workflow but not done
                    item.has_pending_mcn_task = (item.effective_progress >= 80 and item.effective_progress < 100)
                    item.needs_attention = item.is_rejected

                # ECN Level Calculation
                ecn.is_rejected = any(item.is_rejected for item in ecn.items)
                ecn.has_pending_mcn_task = any(item.has_pending_mcn_task for item in ecn.items)
                ecn.needs_attention = ecn.is_rejected

                if ecn.items:
                    ecn.effective_progress = round(
                        sum(item.effective_progress for item in ecn.items) / len(ecn.items), 1
                    )
                else:
                    ecn.effective_progress = 0

                # ── ECN Peer Dependency Check ──
                # If the ECN is not released, items that are individually
                # Production Released are "On Hold - ECN Pending".
                ecn_released = False
                for item in ecn.items:
                    r = item.raw_data
                    ecn_rel_col = self.find_flexible_column(r.keys(), 'ECN Released Date')
                    if ecn_rel_col:
                        ecn_rel_date = pd.to_datetime(r.get(ecn_rel_col), errors='coerce')
                        if pd.notna(ecn_rel_date):
                            ecn_released = True
                            break

                if not ecn_released:
                    # Find the position of "ECN Completed" in workflow config.
                    # Any item whose last completed step is at or past ECN Completed
                    # (or whose current step has no activity) should be on hold.
                    ecn_completed_pos = -1
                    for idx, cfg in enumerate(self.workflow_config):
                        if cfg['name'] == 'ECN Completed':
                            ecn_completed_pos = idx
                            break

                    for item in ecn.items:
                        # Re-derive highest_completed_pos for this item
                        r = item.raw_data
                        item_highest_pos = -1
                        for cfg in self.workflow_config:
                            _e = self.find_flexible_column(r.keys(), cfg['end_date_col']) if cfg.get('end_date_col') else None
                            _s = self.find_flexible_column(r.keys(), cfg['start_date_col']) if cfg.get('start_date_col') else None
                            if cfg['end_date_col'] is None:
                                _d = pd.notna(pd.to_datetime(r.get(_s), errors='coerce')) if _s else False
                            elif _e:
                                _d = pd.notna(pd.to_datetime(r.get(_e), errors='coerce'))
                            else:
                                _d = False
                            if _d:
                                pos = next((i for i, c in enumerate(self.workflow_config) if c is cfg), -1)
                                if pos > item_highest_pos:
                                    item_highest_pos = pos

                        # If item's last completed step is at/past ECN Completed
                        # position, it's waiting on ECN release before MCN can start
                        if item_highest_pos >= ecn_completed_pos and ecn_completed_pos >= 0:
                            peers_behind = sum(
                                1 for i in ecn.items
                                if i.effective_progress < item.effective_progress and i is not item
                            )
                            item.waiting_on_ecn = True
                            item.ecn_peers_behind = peers_behind
                            item.current_step_name = "On Hold - ECN Pending"
                            item.current_step_performer = ""

            # PR Level Calculation
            pr.is_rejected = any(ecn.is_rejected for ecn in pr.ecns.values())
            pr.has_pending_mcn_task = any(ecn.has_pending_mcn_task for ecn in pr.ecns.values())
            pr.needs_attention = pr.is_rejected

            if pr.ecns:
                pr.effective_progress = round(
                    sum(ecn.effective_progress for ecn in pr.ecns.values()) / len(pr.ecns), 1
                )

    def _parse_simple_format(self, df, filename, newly_parsed_prs, all_known_parents):
        """
        Parses the new 'Simple' VPM Excel format (Task Name, Start, End, etc.)
        and maps it to the internal PR -> ECN -> Item structure.
        """
        # Create a dummy PR to hold the project
        project_name = os.path.splitext(filename)[0]
        pr_uid = f"PROJ-{project_name}"
        
        if pr_uid not in newly_parsed_prs:
            pr_obj = ProblemReport(project_name)
            pr_obj.uid = pr_uid
            pr_obj.source_plugin = "Simple VPM Tracker"
            newly_parsed_prs[pr_uid] = pr_obj
        
        pr_obj = newly_parsed_prs[pr_uid]
        
        # Create a dummy ECN to hold the tasks (since the app expects this hierarchy)
        ecn_uid = f"PHASE-1-{project_name}"
        if ecn_uid not in pr_obj.ecns:
            ecn_obj = ECN("Main Phase", project_name)
            ecn_obj.uid = ecn_uid
            ecn_obj.parent = pr_obj
            pr_obj.ecns[ecn_uid] = ecn_obj
        
        ecn_obj = pr_obj.ecns[ecn_uid]
        
        # Parse Tasks
        task_map = {} # ID -> Item Object
        
        for _, row in df.iterrows():
            task_id = row.get("ID")
            if pd.isna(task_id): continue
            
            task_name = str(row.get("Task Name", "Untitled")).strip()
            start_date = pd.to_datetime(row.get("Start Date"), errors='coerce')
            end_date = pd.to_datetime(row.get("End Date"), errors='coerce')
            status = str(row.get("Status", "Not Started"))
            owner = str(row.get("Owner", ""))
            notes = str(row.get("Notes", ""))
            parent_id = row.get("Parent ID")
            
            # Create Item Object
            item_uid = f"{project_name}-{task_id}"
            item_obj = Item(task_id, project_name, "Main Phase", row.to_dict())
            item_obj.uid = item_uid
            item_obj.name = task_name
            item_obj.start = start_date if pd.notna(start_date) else datetime.datetime.now()
            item_obj.finish = end_date if pd.notna(end_date) else datetime.datetime.now()
            item_obj.parent = ecn_obj # Default parent
            
            # Map Status to Progress/Color
            if status == "Completed":
                item_obj.effective_progress = 100
                item_obj.progress = 100
            elif status == "In Progress":
                item_obj.effective_progress = 50
                item_obj.progress = 50
            elif status == "Delayed":
                item_obj.is_rejected = True # Use 'Rejected' flag for red color
                item_obj.effective_progress = 0
            else:
                item_obj.effective_progress = 0
            
            item_obj.comments = [notes] if notes else []
            
            # Store for hierarchy linking
            task_map[task_id] = {'obj': item_obj, 'parent_id': parent_id}
            
            # Add to ECN initially
            ecn_obj.items.append(item_obj)
            self.main_window.task_map[item_uid] = item_obj

        # Reconstruct Hierarchy
        # The app expects ECN -> Items. But Items can have children?
        # The Item class has 'children = []'. Let's use that.
        
        # First, clear the flat list from ECN if we want a tree
        # But the app might expect a flat list in 'ecn.items' for some views?
        # Let's keep them in ecn.items but ALSO build the tree.
        
        for t_id, data in task_map.items():
            item = data['obj']
            p_id = data['parent_id']
            
            if pd.notna(p_id) and p_id in task_map:
                parent_item = task_map[p_id]['obj']
                parent_item.children.append(item)
                item.parent = parent_item
                # Note: We don't remove from ecn.items because that might be the "master list"
            
    def load_and_display_data(self, pr_parent_map, current_parent, all_known_parents, ecn_metadata, file_paths=None, pr_placement_map=None):
        data_path = self.main_window.ecn_config.get("ecn_data_path", "")
        if (not file_paths) and (not data_path or not os.path.exists(data_path)):
            QMessageBox.critical(self.main_window, "Error", "ECN data folder path is not set or not found.")
            return

        newly_parsed_prs = {}
        today = datetime.datetime.now()

        try:
            files_to_process = []
            if file_paths:
                files_to_process = [f for f in file_paths if f and (f.endswith('.xlsx') or f.endswith('.xls')) and not os.path.basename(f).startswith('~$')]
            else:
                for filename in os.listdir(data_path):
                    if not filename.startswith('~$') and (filename.endswith('.xlsx') or filename.endswith('.xls')):
                        files_to_process.append(os.path.join(data_path, filename))

            for file_path in files_to_process:
                df = pd.read_excel(file_path, engine='openpyxl')
                
                # CHECK FOR NEW FORMAT
                if "Task Name" in df.columns and "Start Date" in df.columns:
                    self._parse_simple_format(df, os.path.basename(file_path), newly_parsed_prs, all_known_parents)
                    continue

                # EXISTING LOGIC
                mapped_cols = self.find_column_matches(df.columns)
                if 'pr' not in mapped_cols or 'ecn' not in mapped_cols or 'item' not in mapped_cols:
                    # Only warn if it's NOT the new format
                    if "Task Name" not in df.columns:
                        QMessageBox.warning(self.main_window, f"Skipping file {os.path.basename(file_path)}", f"Could not find required columns.\nLooking for PR, ECN, and Item IDs.")
                    continue

                PR_COL, ECN_COL, ITEM_COL = mapped_cols['pr'], mapped_cols['ecn'], mapped_cols['item']
                
                for _, row in df.iterrows():
                    pr_num = str(row[PR_COL]).strip() if pd.notna(row[PR_COL]) else None
                    ecn_num = str(row[ECN_COL]).strip() if pd.notna(row[ECN_COL]) else None
                    item_id = str(row[ITEM_COL]).strip() if pd.notna(row[ITEM_COL]) else None
                    
                    if not pr_num or not ecn_num or not item_id: continue

                    if pr_num not in newly_parsed_prs: newly_parsed_prs[pr_num] = ProblemReport(pr_num)
                    pr_obj = newly_parsed_prs[pr_num]

                    if ecn_num not in pr_obj.ecns:
                        ecn_obj = ECN(ecn_num, pr_num)
                        ecn_obj.parent = pr_obj
                        pr_obj.ecns[ecn_num] = ecn_obj
                    
                    ecn_obj = pr_obj.ecns[ecn_num]
                    item_obj = Item(item_id, pr_num, ecn_num, row.to_dict())
                    item_obj.parent = ecn_obj
                    
                    all_dates = []
                    for task_conf in self.workflow_config:
                        if task_conf['start_date_col']:
                            s_date = pd.to_datetime(row.get(task_conf['start_date_col']), errors='coerce')
                            if pd.notna(s_date): all_dates.append(s_date)
                        if task_conf['end_date_col']:
                            e_date = pd.to_datetime(row.get(task_conf['end_date_col']), errors='coerce')
                            if pd.notna(e_date): all_dates.append(e_date)
                    
                    if all_dates:
                        item_obj.start = min(all_dates)
                        item_obj.finish = max(all_dates)
                    else:
                        item_obj.start = today
                        item_obj.finish = today

                    if item_obj.uid in ecn_metadata:
                        item_obj.comments = ecn_metadata[item_obj.uid].get('comments', [])

                    # Deduplicate: if same part already exists, MERGE both rows.
                    # TC exports ECN-phase and MCN-phase data as separate rows
                    # for the same item; we need data from both.
                    existing_item = next((i for i in ecn_obj.items if i.uid == item_obj.uid), None)
                    if existing_item:
                        for key, new_val in item_obj.raw_data.items():
                            old_val = existing_item.raw_data.get(key)
                            if pd.notna(new_val) and (not pd.notna(old_val) or not str(old_val).strip()):
                                existing_item.raw_data[key] = new_val
                        # Recalculate date range on merged data
                        merge_dates = []
                        for task_conf in self.workflow_config:
                            if task_conf['start_date_col']:
                                sd = pd.to_datetime(existing_item.raw_data.get(task_conf['start_date_col']), errors='coerce')
                                if pd.notna(sd): merge_dates.append(sd)
                            if task_conf['end_date_col']:
                                ed = pd.to_datetime(existing_item.raw_data.get(task_conf['end_date_col']), errors='coerce')
                                if pd.notna(ed): merge_dates.append(ed)
                        if merge_dates:
                            existing_item.start = min(merge_dates)
                            existing_item.finish = max(merge_dates)
                    else:
                        ecn_obj.items.append(item_obj)
                        self.main_window.task_map[item_obj.uid] = item_obj

            if not newly_parsed_prs:
                QMessageBox.warning(self.main_window, "No Data", "No valid ECN data found in the selected file(s)."); return
            
            # --- Perform all status calculations at once for performance ---
            self._calculate_ecn_statuses(newly_parsed_prs)

            self.main_window.ecn_projects = []

            for pr_num, pr_obj in newly_parsed_prs.items():
                self.main_window.task_map[pr_obj.uid] = pr_obj
                if pr_obj.uid in ecn_metadata:
                    pr_obj.comments = ecn_metadata[pr_obj.uid].get('comments', [])

                for ecn in pr_obj.ecns.values():
                    self.main_window.task_map[ecn.uid] = ecn
                    if ecn.uid in ecn_metadata:
                        ecn.comments = ecn_metadata[ecn.uid].get('comments', [])

                # Use PR placement configuration if available
                parent = None
                if pr_placement_map and pr_num in pr_placement_map:
                    placement = pr_placement_map[pr_num]
                    project_uid = placement.get('project_uid')
                    level_uid = placement.get('level_uid')
                    
                    # Find the target project
                    target_project = all_known_parents.get(project_uid)
                    if target_project:
                        if level_uid == f"{project_uid}_root":
                            # Place at project root
                            parent = target_project
                        else:
                            # Find the specific task/level
                            task_uid = level_uid.split('_', 1)[1] if '_' in level_uid else level_uid
                            parent = all_known_parents.get(int(task_uid)) if task_uid.isdigit() else None
                            
                            # If we couldn't find the specific task, fall back to project root
                            if not parent:
                                parent = target_project
                else:
                    # Fall back to original logic
                    parent_uid = pr_parent_map.get(pr_num)
                    if parent_uid == '__root__':
                         parent = None
                    elif parent_uid:
                        parent = all_known_parents.get(parent_uid)
                    elif current_parent:
                        parent = current_parent
                        self.main_window.update_pr_parent_map(pr_num, getattr(current_parent, 'uid', '__root__'))
                
                pr_obj.parent = parent
                if parent:
                    if hasattr(parent, 'root_tasks') and pr_obj not in parent.root_tasks: parent.root_tasks.append(pr_obj)
                    elif hasattr(parent, 'children') and pr_obj not in parent.children: parent.children.append(pr_obj)
                else:
                    self.main_window.ecn_projects.append(pr_obj)

                pr_obj.update_dates()

            self.main_window.update_project_dates_and_view()
            
        except Exception as e:
            import traceback
            QMessageBox.critical(self.main_window, "Error Loading ECN Data", f"An error occurred: {e}\n\n{traceback.format_exc()}")

    def load_from_tc_data(self, row_dicts, pr_parent_map, current_parent, all_known_parents, ecn_metadata, pr_placement_map=None):
        """
        Load ECN data from TC connector row dicts (same format as Excel rows).
        Reuses the same pipeline as load_and_display_data.
        """
        if not row_dicts:
            QMessageBox.warning(self.main_window, "No Data", "No data received from Teamcenter.")
            return

        newly_parsed_prs = {}
        today = datetime.datetime.now()

        try:
            for row_dict in row_dicts:
                # Extract PR/ECN/Item IDs — TC connector uses known column names
                pr_num = row_dict.get("PR ID", "").strip() or None
                ecn_num = row_dict.get("ECN ID", "").strip() or None
                item_id = row_dict.get("Item ID", "").strip() or None

                # If no PR ID from TC, derive from ECN ID
                if not pr_num and ecn_num:
                    pr_num = ecn_num  # Use ECN as PR placeholder

                if not ecn_num or not item_id:
                    continue

                if pr_num not in newly_parsed_prs:
                    newly_parsed_prs[pr_num] = ProblemReport(pr_num)
                pr_obj = newly_parsed_prs[pr_num]

                if ecn_num not in pr_obj.ecns:
                    ecn_obj = ECN(ecn_num, pr_num)
                    ecn_obj.parent = pr_obj
                    pr_obj.ecns[ecn_num] = ecn_obj

                ecn_obj = pr_obj.ecns[ecn_num]
                item_obj = Item(item_id, pr_num, ecn_num, row_dict)
                item_obj.parent = ecn_obj

                # Extract dates from workflow config columns
                all_dates = []
                for task_conf in self.workflow_config:
                    if task_conf['start_date_col']:
                        s_val = row_dict.get(task_conf['start_date_col'])
                        if s_val:
                            s_date = pd.to_datetime(s_val, errors='coerce')
                            if pd.notna(s_date):
                                all_dates.append(s_date)
                    if task_conf['end_date_col']:
                        e_val = row_dict.get(task_conf['end_date_col'])
                        if e_val:
                            e_date = pd.to_datetime(e_val, errors='coerce')
                            if pd.notna(e_date):
                                all_dates.append(e_date)

                if all_dates:
                    item_obj.start = min(all_dates)
                    item_obj.finish = max(all_dates)
                else:
                    item_obj.start = today
                    item_obj.finish = today

                if item_obj.uid in ecn_metadata:
                    item_obj.comments = ecn_metadata[item_obj.uid].get('comments', [])

                # Deduplicate
                existing_item = next((i for i in ecn_obj.items if i.uid == item_obj.uid), None)
                if existing_item:
                    new_data_count = sum(1 for v in item_obj.raw_data.values() if v)
                    old_data_count = sum(1 for v in existing_item.raw_data.values() if v)
                    if new_data_count > old_data_count:
                        ecn_obj.items.remove(existing_item)
                        ecn_obj.items.append(item_obj)
                        self.main_window.task_map[item_obj.uid] = item_obj
                else:
                    ecn_obj.items.append(item_obj)
                    self.main_window.task_map[item_obj.uid] = item_obj

            if not newly_parsed_prs:
                QMessageBox.warning(self.main_window, "No Data", "No valid ECN data found in TC results.")
                return

            self._calculate_ecn_statuses(newly_parsed_prs)

            self.main_window.ecn_projects = []

            for pr_num, pr_obj in newly_parsed_prs.items():
                self.main_window.task_map[pr_obj.uid] = pr_obj
                if pr_obj.uid in ecn_metadata:
                    pr_obj.comments = ecn_metadata[pr_obj.uid].get('comments', [])

                for ecn in pr_obj.ecns.values():
                    self.main_window.task_map[ecn.uid] = ecn
                    if ecn.uid in ecn_metadata:
                        ecn.comments = ecn_metadata[ecn.uid].get('comments', [])

                parent = None
                if pr_placement_map and pr_num in pr_placement_map:
                    placement = pr_placement_map[pr_num]
                    project_uid = placement.get('project_uid')
                    level_uid = placement.get('level_uid')
                    target_project = all_known_parents.get(project_uid)
                    if target_project:
                        if level_uid == f"{project_uid}_root":
                            parent = target_project
                        else:
                            task_uid = level_uid.split('_', 1)[1] if '_' in level_uid else level_uid
                            parent = all_known_parents.get(int(task_uid)) if task_uid.isdigit() else None
                            if not parent:
                                parent = target_project
                    else:
                        parent_uid = pr_parent_map.get(pr_num)
                        if parent_uid == '__root__':
                            parent = None
                        elif parent_uid:
                            parent = all_known_parents.get(parent_uid)
                        elif current_parent:
                            parent = current_parent
                elif current_parent:
                    parent = current_parent

                pr_obj.parent = parent
                if parent:
                    if hasattr(parent, 'root_tasks') and pr_obj not in parent.root_tasks:
                        parent.root_tasks.append(pr_obj)
                    elif hasattr(parent, 'children') and pr_obj not in parent.children:
                        parent.children.append(pr_obj)
                else:
                    self.main_window.ecn_projects.append(pr_obj)

                pr_obj.update_dates()

            self.main_window.update_project_dates_and_view()

        except Exception as e:
            import traceback
            QMessageBox.critical(self.main_window, "Error Loading TC Data", f"An error occurred: {e}\n\n{traceback.format_exc()}")

    def handle_drill_down(self, item):
        if isinstance(item, Item):
            dialog = WorkflowFlowchartDialog(item, self.workflow_config, self.main_window)
            dialog.exec()
            return

        if not item.children:
            QMessageBox.information(self.main_window, "Empty", f"This item ({item.name}) has no children to display.")
            return

        self.main_window.drill_down_stack.append(item)
        self.main_window.update_view()

    def get_summary_data(self, summary_item):
        all_items = []
        if isinstance(summary_item, ProblemReport):
            all_items = [item for ecn in summary_item.ecns.values() for item in ecn.items]
        elif isinstance(summary_item, ECN):
            all_items = summary_item.items

        summary_list = []
        today = datetime.datetime.now()

        for item in all_items:
            # Use pre-computed attributes from _calculate_ecn_statuses()
            bottleneck_task = item.current_step_name or "Completed"
            assigned_to = item.current_step_performer or ""

            if item.current_step_start_date and pd.notna(item.current_step_start_date):
                task_start_date = item.current_step_start_date.strftime('%Y-%m-%d')
                days_open = (today - item.current_step_start_date).days
            else:
                task_start_date = ""
                days_open = ""

            if item.is_rejected:
                overall_status = "Rejected"
            elif item.effective_progress >= 100:
                overall_status = "Completed"
            else:
                overall_status = "In Progress"

            summary_list.append({
                "PR Number": item.pr_number,
                "ECN Number": item.ecn_number,
                "Item ID": item.name,
                "Item Name": item.raw_data.get('Item Name', ''),
                "Current Task / Name": bottleneck_task,
                "Assigned To": assigned_to,
                "Task Start Date": task_start_date,
                "Days Open": days_open,
                "Overall Status": overall_status,
                "Progress": f"{item.effective_progress:.0f}%"
            })

        return summary_list

