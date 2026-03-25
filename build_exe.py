"""
Build script to create an executable from the Visual PM application.
Run this script to build the .exe file.

Usage:
    python build_exe.py
"""

import subprocess
import sys
import os

def build_exe():
    """Build the executable using PyInstaller."""
    
    # Check if PyInstaller is installed
    try:
        import PyInstaller
    except ImportError:
        print("PyInstaller is not installed. Installing it now...")
        subprocess.check_call([sys.executable, "-m", "pip", "install", "pyinstaller"])
        print("PyInstaller installed successfully!")
    
    # PyInstaller command
    cmd = [
        "pyinstaller",
        "--name=VisualPM",
        "--onefile",  # Create a single executable file
        "--windowed",  # No console window (GUI app)
        "--icon=NONE",  # You can add an icon file later if needed
        "--add-data=advanced_excel_importer.py;.",  # Include the module
        "--add-data=vpm_config.json;.",  # Include config file if it exists
        "--hidden-import=PyQt6",
        "--hidden-import=PyQt6.QtCore",
        "--hidden-import=PyQt6.QtGui",
        "--hidden-import=PyQt6.QtWidgets",
        "--hidden-import=pandas",
        "--hidden-import=openpyxl",  # If using Excel files
        "--hidden-import=xlrd",  # If using older Excel files
        "--hidden-import=dateutil",
        "--collect-all=PyQt6",  # Collect all PyQt6 data files
        "--noconfirm",  # Overwrite output directory without asking
        "main.py"
    ]
    
    print("Building executable...")
    print("Command:", " ".join(cmd))
    print("\nThis may take a few minutes...\n")
    
    try:
        subprocess.check_call(cmd)
        print("\n" + "="*60)
        print("Build completed successfully!")
        print("="*60)
        print("\nThe executable can be found in the 'dist' folder:")
        print("  dist/VisualPM.exe")
        print("\nYou can distribute this .exe file to other Windows computers.")
        print("Note: The first run may be slower as Windows Defender scans it.")
    except subprocess.CalledProcessError as e:
        print(f"\nError building executable: {e}")
        print("\nTroubleshooting:")
        print("1. Make sure all dependencies are installed:")
        print("   pip install -r requirements.txt")
        print("2. Try running PyInstaller manually:")
        print("   pyinstaller --onefile --windowed main.py")
        sys.exit(1)

if __name__ == "__main__":
    build_exe()

