---
status: active
last_updated: 2026-04-06
related: [vpm_whereUsed.md]
---

# vpm_rl5we — Known test items

## Summary
Sample part numbers used to manually validate TC connectivity, BOM
expansion, and whereUsed.

## Items
- **`0200501`** — primary test item used in `test_siemens_bridge.py`
  default args. Should return parents via `WhereUsed()` when TC is healthy.
- (add more here as we discover them)

## How to use
```
python test_siemens_bridge.py --user X --password Y --item 0200501
```

## Sources
- `test_siemens_bridge.py` default `--item`
- Past test runs in `test_hierarchy.py`
