"""
Top-down Teamcenter BOM test.

Fetch one case BOM recursively from Teamcenter, search for a target item, and
print the path from the case root down to the target.

Usage:
    python test_case_path.py
    python test_case_path.py --case RL5WE --item 0200501
"""

import argparse
import getpass
import logging
import sys

from tc_connector import TcSoaClient, TcEcnDataFetcher, TcAuthError


logging.basicConfig(
    stream=sys.stdout,
    level=logging.INFO,
    format="%(asctime)s  %(message)s",
    datefmt="%H:%M:%S",
)
log = logging.getLogger("test_case_path")


def _node_label(node):
    item_id = str(node.get("item_id", "")).strip()
    rev = str(node.get("item_revision_id", "")).strip()
    if item_id and rev:
        return f"{item_id}/{rev}"
    return item_id or str(node.get("uid", "")).strip()


def _build_parent_map(edges):
    parent_of = {}
    for edge in edges:
        if not isinstance(edge, dict):
            continue
        parent_uid = edge.get("parent_uid")
        child_uid = edge.get("child_uid")
        if parent_uid and child_uid and child_uid not in parent_of:
            parent_of[child_uid] = parent_uid
    return parent_of


def _build_path(node_by_uid, parent_of, target_uid):
    path_uids = []
    current_uid = target_uid
    seen = set()
    while current_uid and current_uid not in seen:
        seen.add(current_uid)
        path_uids.append(current_uid)
        current_uid = parent_of.get(current_uid)
    path_uids.reverse()
    return [node_by_uid[uid] for uid in path_uids if uid in node_by_uid]


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--url", default="http://STLV-HSMWEBTCP1:8080/tc")
    parser.add_argument("--username", default="ccbefb")
    parser.add_argument("--password", default=None)
    parser.add_argument("--case", default="RL5WE")
    parser.add_argument("--item", default="0200501")
    parser.add_argument("--max-depth", type=int, default=25)
    parser.add_argument("--max-nodes", type=int, default=5000)
    args = parser.parse_args()

    password = args.password or getpass.getpass(
        f"TC password for {args.username}@{args.url}: "
    )

    log.info(f"Connecting to {args.url} as {args.username} ...")
    client = TcSoaClient(args.url)
    try:
        client.login(args.username, password)
    except TcAuthError as exc:
        log.error(f"Login failed: {exc}")
        raise SystemExit(1)

    fetcher = TcEcnDataFetcher(client)

    try:
        log.info(f"Fetching recursive BOM for case {args.case} ...")
        bom_result = fetcher.fetch_bom_by_nomenclature(
            args.case,
            recursive=True,
            max_depth=args.max_depth,
            max_nodes=args.max_nodes,
            max_seconds=900,
        )
        bom = bom_result.get("bom", {}) or {}
        nodes = bom.get("nodes", []) or []
        edges = bom.get("edges", []) or []

        log.info(
            f"Fetched {len(nodes)} nodes / {len(edges)} edges "
            f"(visited={bom.get('visited_count', 0)}, truncated={bom.get('truncated', False)})"
        )

        if not nodes:
            log.error(f"No BOM nodes returned for case {args.case}")
            raise SystemExit(2)

        node_by_uid = {
            node.get("uid"): node
            for node in nodes
            if isinstance(node, dict) and node.get("uid")
        }
        parent_of = _build_parent_map(edges)

        matches = [
            node for node in nodes
            if str(node.get("item_id", "")).strip().upper() == args.item.upper()
        ]

        if not matches:
            log.error(f"Item {args.item} was not found in case {args.case}")
            raise SystemExit(3)

        log.info(f"Found {len(matches)} matching node(s) for item {args.item}")
        for idx, match in enumerate(matches, start=1):
            target_uid = match.get("uid")
            path_nodes = _build_path(node_by_uid, parent_of, target_uid)
            path_text = " -> ".join(_node_label(node) for node in path_nodes)
            log.info(f"Path {idx}: {path_text}")

        root_node = next((node for node in nodes if node.get("depth") == 0), nodes[0])
        log.info(f"Highest-level case in fetched BOM: {_node_label(root_node)}")
    finally:
        try:
            client.logout()
        except Exception:
            pass


if __name__ == "__main__":
    main()
