@echo off
echo Building GitHelper.exe ...
pyinstaller --onefile --windowed --name=GitHelper ^
    --hidden-import=PyQt6 ^
    --hidden-import=PyQt6.QtCore ^
    --hidden-import=PyQt6.QtGui ^
    --hidden-import=PyQt6.QtWidgets ^
    --collect-all=PyQt6 ^
    --noconfirm git_helper.py
echo.
if exist dist\GitHelper.exe (
    echo SUCCESS: dist\GitHelper.exe
) else (
    echo FAILED — check output above
)
pause
