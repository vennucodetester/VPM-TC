import pandas as pd
import datetime
import os

# Define the plugin interface expected by main.py
# Based on inspection of main.py and advanced_excel_importer.py

def get_importer_name():
    return "Simple Project Tracker Importer"

def run_importer():
    """
    Opens a file dialog to select the new VPM Excel file and parses it.
    Returns a list of project dictionaries compatible with the VPM app.
    """
    from PyQt6.QtWidgets import QFileDialog, QMessageBox
    
    # 1. Select File
    file_path, _ = QFileDialog.getOpenFileName(None, "Select VPM Project Tracker", "", "Excel Files (*.xlsx *.xlsm)")
    if not file_path:
        return None
        
    try:
        # 2. Read Excel
        df = pd.read_excel(file_path, engine='openpyxl')
        
        # Check for required columns
        required_cols = ["ID", "Task Name", "Start Date", "End Date"]
        missing = [col for col in required_cols if col not in df.columns]
        if missing:
            QMessageBox.warning(None, "Invalid Format", f"The selected file is missing columns: {', '.join(missing)}")
            return None
            
        # 3. Parse Data into VPM Structure
        # The VPM app expects a list of project dictionaries
        # Structure: [{'name': 'Project Name', 'tasks': [root_tasks...]}]
        
        # We'll treat the whole file as one project for now, or use the first root task as project name
        project_name = os.path.splitext(os.path.basename(file_path))[0]
        
        tasks = []
        task_map = {} # ID -> Task Dict
        
        # Sort by ID to ensure parents are processed before children (usually)
        # But since we have Parent ID, we can build a map first
        
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
            
            # Create Task Object (Dictionary format for internal VPM creation)
            task_dict = {
                'name': task_name,
                'start': start_date if pd.notna(start_date) else None,
                'finish': end_date if pd.notna(end_date) else None,
                'progress': 100 if status == "Completed" else (50 if status == "In Progress" else 0),
                'status': status,
                'owner': owner,
                'notes': notes,
                'children': [],
                'id': task_id # Keep original ID for linking
            }
            
            task_map[task_id] = task_dict
            
            # Link to Parent
            if pd.notna(parent_id) and parent_id in task_map:
                parent = task_map[parent_id]
                parent['children'].append(task_dict)
            else:
                # Root task
                tasks.append(task_dict)
        
        # If the first task is a "Project Root" (Level 1), maybe we use that as the project container
        # But for now, returning all root tasks is safer
        
        return [{
            'name': project_name,
            'tasks': tasks
        }]

    except Exception as e:
        QMessageBox.critical(None, "Import Error", f"Failed to import file:\n{e}")
        return None
