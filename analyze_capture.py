import json, re, pathlib, collections

p = pathlib.Path(r'C:\PYTHON\VPM-TC\1\tc_proxy_capture.jsonl')
recs = [json.loads(ln) for ln in p.read_text(encoding='utf-8', errors='ignore').splitlines() if ln.strip()]

class_names = collections.Counter()
prop_names = collections.Counter()
rel_names = collections.Counter()
query_names = set()

for r in recs:
    resp = ((r.get('response') or {}).get('body', '')) or ''
    for cn in re.findall('className="([^"]+)"', resp):
        class_names[cn] += 1
    for pn in re.findall('<ns0:properties name="([^"]+)"', resp):
        prop_names[pn] += 1
    for rn in re.findall('relationName="([^"]+)"', resp):
        rel_names[rn] += 1
    req_body = (r.get('request') or {}).get('body', '') or ''
    m = re.search(r'<!\[CDATA\[(.*?)\]\]>', req_body, re.DOTALL)
    inner = m.group(1) if m else req_body
    for qn in re.findall('<queryNames>([^<]+)</queryNames>', inner):
        query_names.add(qn)

print("=== TC OBJECT TYPES IN RESPONSES")
for k, v in class_names.most_common(20):
    print(v, k)

print("\n=== PROPERTIES RETURNED (top 40)")
for k, v in prop_names.most_common(40):
    print(v, k)

print("\n=== RELATION TYPES EXPANDED")
for k, v in rel_names.most_common():
    print(v, k)

print("\n=== SAVED QUERY NAMES SEARCHED")
for qn in sorted(query_names):
    print(" ", qn)
