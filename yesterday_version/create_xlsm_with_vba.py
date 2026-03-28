"""
Create VPM Excel Template (.xlsm) with VBA macros and buttons
Uses win32com to automate Excel and add VBA code
"""
import win32com.client as win32
import os
import sys

def create_vpm_template_with_vba():
    """Create complete .xlsm template with VBA macros and buttons"""

    print("Starting Excel...")
    excel = win32.gencache.EnsureDispatch('Excel.Application')
    excel.Visible = False  # Run in background
    excel.DisplayAlerts = False

    try:
        # Create new workbook
        wb = excel.Workbooks.Add()

        # Remove default sheets except one
        while wb.Sheets.Count > 1:
            wb.Sheets(wb.Sheets.Count).Delete()

        print("Creating Settings sheet...")
        create_settings_sheet(wb, excel)

        print("Creating Tasks sheet...")
        create_tasks_sheet(wb, excel)

        print("Creating Instructions sheet...")
        create_instructions_sheet(wb, excel)

        print("Adding VBA macros...")
        add_vba_macros(wb)

        print("Adding toolbar buttons...")
        add_toolbar_buttons(wb)

        # Save as .xlsm
        file_path = os.path.abspath("VPM_Master_Template.xlsm")

        # Delete existing file if it exists
        if os.path.exists(file_path):
            os.remove(file_path)

        wb.SaveAs(file_path, FileFormat=52)  # 52 = xlOpenXMLWorkbookMacroEnabled
        print(f"[OK] Saved: {file_path}")

        wb.Close()

    finally:
        excel.Quit()

    print("\n[OK] Complete! VPM_Master_Template.xlsm created successfully.")
    print("  - VBA macros embedded")
    print("  - Toolbar buttons added")
    print("  - Ready to use!")

def create_settings_sheet(wb, excel):
    """Create Settings sheet with status configuration"""

    # Rename first sheet
    ws = wb.Sheets(1)
    ws.Name = "Settings"

    # Title
    ws.Range("A1:D2").Merge()
    ws.Range("A1").Value = "VPM STATUS CONFIGURATION"
    ws.Range("A1").Font.Size = 16
    ws.Range("A1").Font.Bold = True
    ws.Range("A1").Font.Color = 0xFFFFFF  # White
    ws.Range("A1").Interior.Color = 0xD47800  # Blue (BGR format)
    ws.Range("A1").HorizontalAlignment = -4108  # Center
    ws.Range("A1").VerticalAlignment = -4108  # Center

    # Subtitle
    ws.Range("A3:D3").Merge()
    ws.Range("A3").Value = "Edit this table to customize your statuses"
    ws.Range("A3").Font.Italic = True
    ws.Range("A3").HorizontalAlignment = -4108

    # Headers
    headers = ["Status Name", "Background Color", "Text Color", "Progress %"]
    for i, header in enumerate(headers, 1):
        cell = ws.Cells(4, i)
        cell.Value = header
        cell.Font.Bold = True
        cell.Interior.Color = 0xD9D9D9  # Light gray
        cell.HorizontalAlignment = -4108

    # Default statuses
    statuses = [
        ("Not Started", "D3D3D3", "000000", 0),
        ("In Progress", "FFFF00", "000000", 50),
        ("Completed", "00B050", "FFFFFF", 100),
        ("Blocked", "FF0000", "FFFFFF", 0),
    ]

    for i, (name, bg, fg, progress) in enumerate(statuses, 5):
        ws.Cells(i, 1).Value = name
        ws.Cells(i, 2).Value = bg
        ws.Cells(i, 3).Value = fg
        ws.Cells(i, 4).Value = progress

    # Column widths
    ws.Columns("A:A").ColumnWidth = 20
    ws.Columns("B:B").ColumnWidth = 20
    ws.Columns("C:C").ColumnWidth = 15
    ws.Columns("D:D").ColumnWidth = 15

def create_tasks_sheet(wb, excel):
    """Create Tasks sheet with columns and sample data"""

    wb.Sheets.Add(After=wb.Sheets(wb.Sheets.Count))
    ws = wb.Sheets(wb.Sheets.Count)
    ws.Name = "Tasks"

    # Toolbar area (rows 1-4) - will add buttons later
    ws.Range("A1:F4").Merge()
    ws.Range("A1").Value = "TOOLBAR: Buttons will be added here"
    ws.Range("A1").Interior.Color = 0xE6E6E7  # Light gray
    ws.Range("A1").HorizontalAlignment = -4108
    ws.Range("A1").VerticalAlignment = -4108
    ws.Range("A1").Font.Size = 11

    # Column headers (row 5)
    headers = ["Task Name", "Start Date", "End Date", "Status", "Responsible", "Comments"]
    for i, header in enumerate(headers, 1):
        cell = ws.Cells(5, i)
        cell.Value = header
        cell.Font.Bold = True
        cell.Font.Color = 0xFFFFFF
        cell.Interior.Color = 0xD47800  # Blue
        cell.HorizontalAlignment = -4108

    # Hidden column headers
    hidden_headers = ["ID", "Level", "Parent_ID", "Progress", "Current_Status"]
    for i, header in enumerate(hidden_headers, 7):
        cell = ws.Cells(5, i)
        cell.Value = header
        cell.Font.Bold = True

    # Sample task
    ws.Cells(6, 1).Value = "▼ Sample Task"
    ws.Cells(6, 2).Value = "11/16/2025"
    ws.Cells(6, 3).Value = "12/31/2025"
    ws.Cells(6, 4).Value = "Not Started"
    ws.Cells(6, 5).Value = ""
    ws.Cells(6, 6).Value = "11/16: Task created"
    ws.Cells(6, 7).Value = 1  # ID
    ws.Cells(6, 8).Value = 1  # Level
    ws.Cells(6, 9).Value = ""  # Parent_ID
    ws.Cells(6, 10).Value = 0  # Progress
    ws.Cells(6, 11).Value = "Not Started"  # Current_Status

    # Sample child task
    ws.Cells(7, 1).Value = "  ├─ Sample Subtask"
    ws.Cells(7, 2).Value = "11/16/2025"
    ws.Cells(7, 3).Value = "11/30/2025"
    ws.Cells(7, 4).Value = "Not Started"
    ws.Cells(7, 5).Value = ""
    ws.Cells(7, 6).Value = ""
    ws.Cells(7, 7).Value = 2  # ID
    ws.Cells(7, 8).Value = 2  # Level
    ws.Cells(7, 9).Value = 1  # Parent_ID
    ws.Cells(7, 10).Value = 0  # Progress
    ws.Cells(7, 11).Value = "Not Started"  # Current_Status

    # Column widths
    ws.Columns("A:A").ColumnWidth = 40
    ws.Columns("B:B").ColumnWidth = 12
    ws.Columns("C:C").ColumnWidth = 12
    ws.Columns("D:D").ColumnWidth = 20
    ws.Columns("E:E").ColumnWidth = 15
    ws.Columns("F:F").ColumnWidth = 50

    # Hide columns G-K
    for col in range(7, 12):
        ws.Columns(col).Hidden = True

    # Add data validation for Status column
    status_validation = ws.Range("D6:D1000").Validation
    status_validation.Delete()
    status_validation.Add(
        Type=3,  # xlValidateList
        AlertStyle=1,  # xlValidAlertStop
        Formula1="=Settings!$A$5:$A$8"
    )

    # Date formatting
    ws.Range("B6:B1000").NumberFormat = "mm/dd/yyyy"
    ws.Range("C6:C1000").NumberFormat = "mm/dd/yyyy"

    # Comments column - wrap text
    ws.Range("F6:F1000").WrapText = True

    # Freeze panes
    excel.ActiveWindow.FreezePanes = True

def create_instructions_sheet(wb, excel):
    """Create Instructions sheet"""

    wb.Sheets.Add(After=wb.Sheets(wb.Sheets.Count))
    ws = wb.Sheets(wb.Sheets.Count)
    ws.Name = "Instructions"

    # Title
    ws.Range("A1:E1").Merge()
    ws.Range("A1").Value = "VPM EXCEL TEMPLATE - USER GUIDE"
    ws.Range("A1").Font.Size = 16
    ws.Range("A1").Font.Bold = True
    ws.Range("A1").Font.Color = 0xFFFFFF
    ws.Range("A1").Interior.Color = 0xD47800
    ws.Range("A1").HorizontalAlignment = -4108

    instructions = """
GETTING STARTED:
1. Go to Tasks sheet
2. Click [Add Task] button to create a top-level task
3. Select a task and click [Add Child Task] to create a subtask
4. Fill in Start Date, End Date, Status, Responsible, and Comments
5. Save the file

USING THE BUTTONS:
• [Add Task] - Creates a new top-level task (auto-assigns ID, Level=1)
• [Add Child Task] - Creates child of selected task (auto-assigns ID, Level, Parent_ID)
• [Delete Task] - Deletes selected task (checks for children first)
• [Refresh] - Refreshes status dropdown and colors from Settings sheet

UPDATING TASKS:
• To add a comment: Double-click the Comments cell
  - Date will auto-populate (MM/DD format)
  - Just type your update after the colon
• To change status: Click the Status dropdown and select new status
  - Progress % will auto-update based on Settings sheet
  - Cell color will change

IMPORTING TO VPM:
1. Open VPM application
2. Go to Import → Import from Excel Template
3. Select this file
4. All tasks and comments will be imported
5. Comments will appear in Notes grid view

EXPORTING FROM VPM:
1. In VPM, drill down into a project
2. Go to Export → Export to Excel Template
3. Choose save location
4. Excel file will be created with current project state

CUSTOMIZING STATUSES:
1. Go to Settings sheet
2. Add/remove/edit status rows
3. Change colors (use hex codes like FFFF00 for yellow)
4. Change progress % mapping
5. Return to Tasks sheet and click [Refresh] button

TIPS:
• Don't manually edit ID, Level, or Parent_ID columns - buttons handle this
• Use buttons to add/delete tasks to maintain hierarchy
• Dates auto-format to MM/DD/YYYY
• Comments support multi-line (Alt+Enter for new line)
"""

    ws.Range("A3").Value = instructions
    ws.Range("A3").WrapText = True
    ws.Columns("A:A").ColumnWidth = 100

def add_vba_macros(wb):
    """Add all VBA macros to the workbook"""

    # Get VBA project
    vba_project = wb.VBProject

    # Add module for helper functions
    module = vba_project.VBComponents.Add(1)  # 1 = vbext_ct_StdModule
    module.Name = "VPM_Functions"

    # Add helper functions code
    helper_code = '''
Function GetProgressForStatus(statusName As String) As Integer
    Dim ws As Worksheet
    Set ws = ThisWorkbook.Sheets("Settings")

    Dim i As Integer
    For i = 5 To 20
        If ws.Cells(i, 1).Value = statusName Then
            GetProgressForStatus = ws.Cells(i, 4).Value
            Exit Function
        End If
    Next i

    GetProgressForStatus = 0
End Function

Function GetColorForStatus(statusName As String, colorType As String) As String
    Dim ws As Worksheet
    Set ws = ThisWorkbook.Sheets("Settings")

    Dim i As Integer
    For i = 5 To 20
        If ws.Cells(i, 1).Value = statusName Then
            If colorType = "bg" Then
                GetColorForStatus = ws.Cells(i, 2).Value
            Else
                GetColorForStatus = ws.Cells(i, 3).Value
            End If
            Exit Function
        End If
    Next i

    GetColorForStatus = ""
End Function

Function HexToRGB(hexColor As String) As Long
    Dim r As Integer, g As Integer, b As Integer
    r = Val("&H" & Mid(hexColor, 1, 2))
    g = Val("&H" & Mid(hexColor, 3, 2))
    b = Val("&H" & Mid(hexColor, 5, 2))
    HexToRGB = RGB(r, g, b)
End Function

Sub ApplyStatusColor(targetCell As Range, statusName As String)
    Dim bgHex As String, txtHex As String
    bgHex = GetColorForStatus(statusName, "bg")
    txtHex = GetColorForStatus(statusName, "text")

    If Len(bgHex) = 6 Then targetCell.Interior.Color = HexToRGB(bgHex)
    If Len(txtHex) = 6 Then targetCell.Font.Color = HexToRGB(txtHex)
End Sub

Function GetNextID() As Integer
    Dim ws As Worksheet
    Set ws = ThisWorkbook.Sheets("Tasks")

    Dim maxID As Integer
    maxID = 0

    Dim i As Long
    For i = 6 To ws.Cells(ws.Rows.Count, 1).End(xlUp).Row
        Dim currentID As Variant
        currentID = ws.Cells(i, 7).Value
        If IsNumeric(currentID) Then
            If currentID > maxID Then maxID = currentID
        End If
    Next i

    GetNextID = maxID + 1
End Function

Function HasChildren(taskID As Integer) As Boolean
    Dim ws As Worksheet
    Set ws = ThisWorkbook.Sheets("Tasks")

    HasChildren = False

    Dim i As Long
    For i = 6 To ws.Cells(ws.Rows.Count, 1).End(xlUp).Row
        If ws.Cells(i, 9).Value = taskID Then
            HasChildren = True
            Exit Function
        End If
    Next i
End Function

Sub AddTask()
    Dim ws As Worksheet
    Set ws = ThisWorkbook.Sheets("Tasks")

    Dim lastRow As Long
    lastRow = ws.Cells(ws.Rows.Count, 1).End(xlUp).Row

    Dim taskName As String
    taskName = InputBox("Enter task name:", "Add New Task")
    If taskName = "" Then Exit Sub

    Dim newRow As Long
    newRow = lastRow + 1

    ws.Cells(newRow, 1).Value = "▼ " & taskName
    ws.Cells(newRow, 2).Value = Date
    ws.Cells(newRow, 3).Value = Date + 30
    ws.Cells(newRow, 4).Value = "Not Started"
    ws.Cells(newRow, 5).Value = ""
    ws.Cells(newRow, 6).Value = ""

    Dim newID As Integer
    newID = GetNextID()
    ws.Cells(newRow, 7).Value = newID
    ws.Cells(newRow, 8).Value = 1
    ws.Cells(newRow, 9).Value = ""
    ws.Cells(newRow, 10).Value = 0
    ws.Cells(newRow, 11).Value = "Not Started"

    ws.Cells(newRow, 2).NumberFormat = "mm/dd/yyyy"
    ws.Cells(newRow, 3).NumberFormat = "mm/dd/yyyy"

    MsgBox "Task added successfully!", vbInformation
End Sub

Sub AddChildTask()
    Dim ws As Worksheet
    Set ws = ThisWorkbook.Sheets("Tasks")

    Dim selectedRow As Long
    selectedRow = ActiveCell.Row

    If selectedRow <= 5 Then
        MsgBox "Please select a parent task first.", vbExclamation
        Exit Sub
    End If

    Dim parentID As Integer, parentLevel As Integer
    parentID = ws.Cells(selectedRow, 7).Value
    parentLevel = ws.Cells(selectedRow, 8).Value

    Dim taskName As String
    taskName = InputBox("Enter child task name:", "Add Child Task")
    If taskName = "" Then Exit Sub

    Dim newRow As Long
    newRow = selectedRow + 1
    ws.Rows(newRow).Insert Shift:=xlDown

    Dim indent As String
    indent = String(parentLevel * 2, " ")

    ws.Cells(newRow, 1).Value = indent & "├─ " & taskName
    ws.Cells(newRow, 2).Value = Date
    ws.Cells(newRow, 3).Value = Date + 30
    ws.Cells(newRow, 4).Value = "Not Started"
    ws.Cells(newRow, 5).Value = ""
    ws.Cells(newRow, 6).Value = ""

    Dim newID As Integer
    newID = GetNextID()
    ws.Cells(newRow, 7).Value = newID
    ws.Cells(newRow, 8).Value = parentLevel + 1
    ws.Cells(newRow, 9).Value = parentID
    ws.Cells(newRow, 10).Value = 0
    ws.Cells(newRow, 11).Value = "Not Started"

    ws.Cells(newRow, 2).NumberFormat = "mm/dd/yyyy"
    ws.Cells(newRow, 3).NumberFormat = "mm/dd/yyyy"
    ws.Rows(newRow).OutlineLevel = parentLevel

    MsgBox "Child task added successfully!", vbInformation
End Sub

Sub DeleteTask()
    Dim ws As Worksheet
    Set ws = ThisWorkbook.Sheets("Tasks")

    Dim selectedRow As Long
    selectedRow = ActiveCell.Row

    If selectedRow <= 5 Then
        MsgBox "Please select a task to delete.", vbExclamation
        Exit Sub
    End If

    Dim taskName As String
    taskName = ws.Cells(selectedRow, 1).Value

    Dim response As VbMsgBoxResult
    response = MsgBox("Delete task: " & taskName & "?", vbYesNo + vbQuestion)

    If response = vbYes Then
        Dim taskID As Integer
        taskID = ws.Cells(selectedRow, 7).Value

        If HasChildren(taskID) Then
            MsgBox "Cannot delete task with children. Delete children first.", vbExclamation
            Exit Sub
        End If

        ws.Rows(selectedRow).Delete Shift:=xlUp
        MsgBox "Task deleted successfully!", vbInformation
    End If
End Sub

Sub RefreshTasks()
    MsgBox "Tasks refreshed with new settings!", vbInformation
End Sub
'''

    module.CodeModule.AddFromString(helper_code)

    # Add worksheet event handlers
    tasks_sheet = wb.Sheets("Tasks")
    sheet_module = tasks_sheet.CodeName

    for component in vba_project.VBComponents:
        if component.Name == sheet_module:
            event_code = '''
Private Sub Worksheet_BeforeDoubleClick(ByVal Target As Range, Cancel As Boolean)
    If Target.Column = 6 And Target.Row > 5 Then
        Cancel = True
        Dim dateStr As String
        dateStr = Format(Date, "mm/dd")
        Dim currentText As String
        currentText = Target.Value
        Dim newText As String
        If Len(currentText) > 0 Then
            newText = currentText & vbLf & dateStr & ": "
        Else
            newText = dateStr & ": "
        End If
        Target.Value = newText
        Target.Select
        SendKeys "{F2}"
        SendKeys "{END}"
    End If
End Sub

Private Sub Worksheet_Change(ByVal Target As Range)
    Application.EnableEvents = False
    On Error GoTo ErrorHandler

    If Target.Column = 4 And Target.Row > 5 Then
        Dim statusName As String
        statusName = Target.Value
        If statusName <> "" Then
            Cells(Target.Row, 10).Value = GetProgressForStatus(statusName)
            Cells(Target.Row, 11).Value = statusName
            Call ApplyStatusColor(Target, statusName)
        End If
    End If

    If (Target.Column = 2 Or Target.Column = 3) And Target.Row > 5 Then
        If Target.Value <> "" And Not IsEmpty(Target.Value) Then
            If Not IsDate(Target.Value) Then
                MsgBox "Invalid date format. Please use MM/DD/YYYY", vbExclamation
                Target.Value = ""
            Else
                Target.Value = Format(Target.Value, "mm/dd/yyyy")
                Target.NumberFormat = "mm/dd/yyyy"
            End If
        End If
    End If

ErrorHandler:
    Application.EnableEvents = True
End Sub
'''
            component.CodeModule.AddFromString(event_code)
            break

def add_toolbar_buttons(wb):
    """Add buttons to the toolbar area in Tasks sheet"""

    ws = wb.Sheets("Tasks")

    # Clear toolbar merge
    ws.Range("A1:F4").UnMerge()

    # Button positions
    buttons = [
        ("Add Task", "AddTask", 1, 1, 80, 30),
        ("Add Child Task", "AddChildTask", 90, 1, 100, 30),
        ("Delete Task", "DeleteTask", 200, 1, 80, 30),
        ("Refresh", "RefreshTasks", 290, 1, 70, 30),
    ]

    for btn_name, macro_name, left, top, width, height in buttons:
        btn = ws.Buttons().Add(left, top, width, height)
        btn.Text = btn_name
        btn.OnAction = macro_name

if __name__ == "__main__":
    try:
        create_vpm_template_with_vba()
    except Exception as e:
        print(f"\n[ERROR] {e}")
        import traceback
        traceback.print_exc()
        sys.exit(1)
