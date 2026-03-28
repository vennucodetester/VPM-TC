@echo off
echo ========================================
echo Building Visual PM Executable
echo ========================================
echo.

REM Check if Python is available
python --version >nul 2>&1
if errorlevel 1 (
    echo ERROR: Python is not installed or not in PATH
    echo Please install Python 3.8 or later
    pause
    exit /b 1
)

echo Step 1: Installing/updating PyInstaller...
python -m pip install --upgrade pyinstaller
if errorlevel 1 (
    echo ERROR: Failed to install PyInstaller
    pause
    exit /b 1
)

echo.
echo Step 2: Cleaning previous builds...
if exist dist rmdir /s /q dist
if exist build rmdir /s /q build

echo.
echo Step 3: Building executable (this may take 2-5 minutes)...
echo Please wait...
echo.

pyinstaller ^
    --onefile ^
    --windowed ^
    --name=VisualPM ^
    --add-data="advanced_excel_importer.py;." ^
    --add-data="vpm_config.json;." ^
    --hidden-import=PyQt6 ^
    --hidden-import=PyQt6.QtCore ^
    --hidden-import=PyQt6.QtGui ^
    --hidden-import=PyQt6.QtWidgets ^
    --hidden-import=pandas ^
    --hidden-import=openpyxl ^
    --hidden-import=xlrd ^
    --hidden-import=dateutil ^
    --hidden-import=dateutil.relativedelta ^
    --collect-all=PyQt6 ^
    --noconfirm ^
    main.py

echo.
echo ========================================
if exist "dist\VisualPM.exe" (
    echo SUCCESS! Executable created successfully!
    echo.
    echo Location: dist\VisualPM.exe
    echo.
    echo You can now:
    echo   1. Test the executable by running it
    echo   2. Copy it to any Windows computer
    echo   3. Distribute it to other users
    echo.
    echo Note: The first run may be slower as Windows scans it.
) else (
    echo ERROR: Build failed!
    echo.
    echo Please check the error messages above.
    echo Common issues:
    echo   - Missing dependencies: pip install -r requirements.txt
    echo   - PyInstaller not installed: pip install pyinstaller
    echo   - File path issues: Make sure you're in the correct directory
)
echo ========================================
echo.
pause

