import sys
from cx_Freeze import setup, Executable

# Dependencies are automatically detected, but it might need fine tuning.
build_options = {
    'packages': [
        'PyQt6', 
        'PyQt6.QtCore', 
        'PyQt6.QtGui', 
        'PyQt6.QtWidgets',
        'pandas', 
        'openpyxl',
        'xml.etree.ElementTree',
        'json',
        'csv',
        'datetime',
        'calendar',
        'dateutil.relativedelta',
        'functools',
        'os',
        'importlib.util',
        'sys',
        'enum'
    ],
    'excludes': ['tkinter', 'unittest', 'pydoc', 'difflib', 'inspect'],
    'include_files': [
        'vpm_config.json',
        'plugins/',
        'advanced_excel_importer.py'
    ]
}

base = None
if sys.platform == "win32":
    base = "Win32GUI"  # Use this for GUI applications on Windows

executables = [
    Executable('main.py', 
               base=base, 
               target_name='VisualProjectManager.exe',
               icon=None)  # Add icon path if you have one
]

setup(
    name='Visual Project Manager',
    version='1.0',
    description='Visual Project Manager with ECN Workflow Support',
    options={'build_exe': build_options},
    executables=executables
)

