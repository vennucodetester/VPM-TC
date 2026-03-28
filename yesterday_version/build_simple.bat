@echo off
echo Building Visual Project Manager executable (Simple Version)...
echo.

REM Set Python path
set PYTHON_PATH=C:\Users\ccbefb\AppData\Local\Programs\Python\Python313\python.exe

REM Clean previous builds
if exist dist rmdir /s /q dist
if exist build rmdir /s /q build

echo Running PyInstaller with minimal options...
%PYTHON_PATH% -m PyInstaller --onefile --console --name VPM main.py

echo.
echo Build completed. Checking for executable...
if exist dist\VPM.exe (
    echo SUCCESS: Executable created at dist\VPM.exe
    echo File size:
    dir dist\VPM.exe
    echo.
    echo Testing executable...
    echo dist\VPM.exe
) else (
    echo ERROR: Executable was not created
    dir dist
)

pause

