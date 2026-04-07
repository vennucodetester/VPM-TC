# vpm_WIKI_SCHEMA — How to use this wiki

**Audience:** future Claude (or any LLM) sessions working on the VPM project.
**Read this first**, before exploring code.

## Purpose
Stop re-discovering the same Teamcenter / VPM knowledge every session. Every
fact we learn the hard way lives here so the next session starts informed.

## Naming convention
- Every file in this wiki is prefixed with `vpm_` (the project tag).
- Other projects get their own `wiki/` folder with their own prefix
  (e.g. `proj_<name>_...`).
- This makes it trivial for a new LLM to grep `vpm_` and find only this
  project's curated knowledge.

## Read order at session start
1. `wiki/vpm_WIKI_SCHEMA.md` (this file)
2. `wiki/vpm_index.md` — catalog of every page
3. `wiki/vpm_state.md` — current status (TC up/down, last good version, blockers)
4. `wiki/vpm_log.md` — recent attempts (newest at top)
5. Then jump to whichever `entities/`, `concepts/`, or `decisions/` page is
   relevant to the user's request.

**Rule:** before exploring source code or re-reading raw decompilation docs,
check whether a wiki page already exists for the topic. If yes, read it first.

## Page format
Every entity/concept/decision page uses this skeleton:

```
---
status: <active | resolved | blocked | superseded>
last_updated: YYYY-MM-DD
related: [vpm_other_page.md, ...]
---

# <Title>

## Summary
One paragraph. What this is, why it matters.

## Details
The actual knowledge. Include code refs, error codes, exact endpoints, etc.

## Open questions
Things we don't know yet.

## Sources
- path/to/raw_doc.md
- path/to/code.py:line
```

## Update rules (end of every session)
1. **Touched a topic?** Update its entity/concept page.
2. **Tried something new?** Append to `vpm_log.md` (newest at top, never delete).
3. **Status changed?** Update `vpm_state.md`.
4. **New page?** Add a one-liner to `vpm_index.md`.
5. **Concept seen 3+ times across pages?** Promote it to its own page under
   `concepts/`.

## Log format
`vpm_log.md` is append-only, newest at top:
```
## YYYY-MM-DD — <short topic>
**Tried:** ...
**Outcome:** ...
**Links:** vpm_<page>.md, file:line
```
Never delete entries — supersede with a new entry that references the old one.

## What this wiki is NOT
- Not a replacement for git history.
- Not auto-generated. Hand-curated markdown only.
- Not a code-change log (use git for that). It's a *knowledge* log.
