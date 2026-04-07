---
status: accepted
last_updated: 2026-04-06
related: [vpm_WIKI_SCHEMA.md]
---

# ADR-003 — Maintain an LLM wiki under `wiki/`

## Context
Every Claude session re-discovers the same Teamcenter knowledge from
scratch: which SOA endpoints exist, which whereUsed bindings have been
tried, why error 1003 happens, what the checksheet decompilation
revealed, which version was last known-good. This burns tokens and
loses continuity. Existing markdown notes are effectively proto-wiki
pages but are not indexed, cross-linked, or maintained.

## Decision
Create a small, hand-curated `wiki/` tree, inspired by Karpathy's LLM
Wiki gist. Three layers:
1. Raw sources (existing decompilation/trial docs, code).
2. Curated wiki pages (`entities/`, `concepts/`, `decisions/`).
3. `vpm_WIKI_SCHEMA.md` telling future Claude sessions how to read and
   update the wiki.

All files prefixed with `vpm_` so other projects can have their own
wikis without collisions.

## Rationale
- Stops re-discovery loop, saves tokens session-over-session.
- Hand-curated markdown is the lowest-friction format for both humans
  and LLMs.
- Append-only `vpm_log.md` preserves history of attempts so old
  failures don't get retried.
- ADR pattern records *why* we did/didn't do things.

## Consequences
- Small ongoing maintenance cost: end of every session, update touched
  pages + append to log.
- Wiki must be read at the start of every TC-related session (rule
  enforced by `vpm_WIKI_SCHEMA.md`).
- Not a replacement for git history or memory files; complements both.

## Status
Initial scaffold created 2026-04-06.

## Sources
- https://gist.github.com/karpathy/442a6bf555914893e9891c11519de94f
- `vpm_WIKI_SCHEMA.md`
