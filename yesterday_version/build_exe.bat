@echo off
echo Building Visual PM Executable...
echo.

REM Check if Python is available
python --version >nul 2>&1
if errorlevel 1 (
    echo ERROR: Python is not installed or not in PATH
    echo Please install Python 3.8 or later
    pause
    exit /b 1
)

REM Install/upgrade PyInstaller if needed
echo Installing/updating PyInstaller...
python -m pip install --upgrade pyinstaller

REM Build the executable using PyInstaller directly
echo.
echo Building executable (this may take a few minutes)...
pyinstaller --onefile --windowed --name=VisualPM --add-data=advanced_excel_importer.py;. --add-data=vpm_config.json;. --hidden-import=PyQt6 --hidden-import=PyQt6.QtCore --hidden-import=PyQt6.QtGui --hidden-import=PyQt6.QtWidgets --hidden-import=pandas --hidden-import=openpyxl --hidden-import=xlrd --hidden-import=dateutil --collect-all=PyQt6 --noconfirm main.py

echo.
if exist "dist\VisualPM.exe" (
    echo SUCCESS! Executable created: dist\VisualPM.exe
) else (
    echo ERROR: Build failed. Check the output above for errors.
)
echo.
pause
