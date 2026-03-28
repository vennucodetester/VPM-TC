import openpyxl
import os

file_path = r'c:\Users\silam\OneDrive\Documents\GitHub\VPM-1\DG-2.0.xlsm'
repaired_path = r'c:\Users\silam\OneDrive\Documents\GitHub\VPM-1\DG-2.0_repaired.xlsm'

print(f"Attempting to repair: {file_path}")

try:
    # Load workbook with keep_vba=True to preserve macros
    print("Loading workbook with openpyxl (keep_vba=True)...")
    wb = openpyxl.load_workbook(file_path, keep_vba=True)
    
    print(f"Saving to {repaired_path}...")
    wb.save(repaired_path)
    print("Success! Repaired file saved.")
    
except Exception as e:
    print(f"Error during repair: {e}")
