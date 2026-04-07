# vpm_index — VPM Wiki Catalog

Read `vpm_WIKI_SCHEMA.md` first if you're a new session.

## Top-level
- **vpm_WIKI_SCHEMA.md** — how to read and update this wiki
- **vpm_state.md** — current status: TC server, last good version, blockers
- **vpm_log.md** — append-only log of what's been tried (newest first)

## Entities (concrete things)
- **entities/vpm_whereUsed.md** — the `whereUsed` SOA op, every binding tried, status
- **entities/vpm_error_1003.md** — "Failed to assign a server" — TC web-tier failure
- **entities/vpm_error_214086.md** — "invalid syntax" — JsonRest binding mismatch
- **entities/vpm_siemens_bridge.md** — pythonnet + Siemens TC DLL approach
- **entities/vpm_checksheet_app.md** — decompiled reference VB.NET app
- **entities/vpm_rl5we.md** — known test items / sample part numbers
- **entities/vpm_tc_server.md** — STLV-HSMWEBTCP1, ports, paths, VPN reqs

## Concepts (how things work)
- **concepts/vpm_tc_soa_protocol.md** — REST vs JsonRest, namespaces, op versions
- **concepts/vpm_bom_top_down.md** — createBOMWindows + expandPSOneLevel (works)
- **concepts/vpm_bom_bottom_up.md** — whereUsed (broken) and alternatives
- **concepts/vpm_pythonnet_quirks.md** — CAS policy, interface subclassing, AnyCPU

## Decisions (ADRs)
- **decisions/vpm_ADR-001-no-reverse-lookup.md** — why no reverse lookup table
- **decisions/vpm_ADR-002-siemens-dll-bridge.md** — why pivot to .NET DLL bridge
- **decisions/vpm_ADR-003-llm-wiki.md** — why this wiki exists
