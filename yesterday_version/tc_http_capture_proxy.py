"""
Simple Teamcenter HTTP capture proxy.

Use this to capture the exact payload shape sent by CHECKSHEET.exe without
modifying the EXE.

Typical usage:
    python tc_http_capture_proxy.py --listen-port 8899 --upstream-base http://STLV-HSMWEBTCP1:8080

Then, in CHECKSHEET.exe, set server URL to:
    http://127.0.0.1:8899

The proxy forwards requests to the upstream base and logs request/response
details to tc_proxy_capture.jsonl in this folder.
"""

from __future__ import annotations

import argparse
import datetime as dt
import http.client
import json
import os
import socketserver
import sys
from http.server import BaseHTTPRequestHandler
from urllib.parse import urlsplit


CAPTURE_FILE = os.path.join(os.path.dirname(os.path.abspath(__file__)), "tc_proxy_capture.jsonl")
FOCUS_ENDPOINTS = ("createBOMWindows", "expandPSOneLevel")


def _now_iso() -> str:
    return dt.datetime.now().isoformat(timespec="milliseconds")


def _safe_text(data: bytes, encoding: str = "utf-8") -> str:
    try:
        return data.decode(encoding, errors="replace")
    except Exception:
        return repr(data[:4000])


def _json_or_text(raw: bytes):
    text = _safe_text(raw)
    try:
        return json.loads(text)
    except Exception:
        return text


def _write_capture(record: dict) -> None:
    line = json.dumps(record, ensure_ascii=True)
    with open(CAPTURE_FILE, "a", encoding="utf-8") as f:
        f.write(line + "\n")


class ThreadingHTTPServer(socketserver.ThreadingMixIn, socketserver.TCPServer):
    allow_reuse_address = True
    daemon_threads = True


class ProxyHandler(BaseHTTPRequestHandler):
    upstream_scheme = "http"
    upstream_host = ""
    upstream_port = 80

    protocol_version = "HTTP/1.1"

    def do_GET(self):
        self._proxy()

    def do_POST(self):
        self._proxy()

    def do_PUT(self):
        self._proxy()

    def do_DELETE(self):
        self._proxy()

    def do_PATCH(self):
        self._proxy()

    def log_message(self, fmt, *args):
        sys.stdout.write("[%s] %s\n" % (_now_iso(), fmt % args))

    def _proxy(self):
        try:
            content_length = int(self.headers.get("Content-Length", "0") or "0")
            req_body = self.rfile.read(content_length) if content_length > 0 else b""

            conn_cls = http.client.HTTPSConnection if self.upstream_scheme == "https" else http.client.HTTPConnection
            conn = conn_cls(self.upstream_host, self.upstream_port, timeout=120)

            hop_by_hop = {
                "connection",
                "proxy-connection",
                "keep-alive",
                "transfer-encoding",
                "te",
                "trailer",
                "proxy-authenticate",
                "proxy-authorization",
                "upgrade",
            }
            fwd_headers = {}
            for key, value in self.headers.items():
                if key.lower() in hop_by_hop:
                    continue
                fwd_headers[key] = value
            fwd_headers["Host"] = f"{self.upstream_host}:{self.upstream_port}"

            conn.request(self.command, self.path, body=req_body, headers=fwd_headers)
            resp = conn.getresponse()
            resp_body = resp.read()
            resp_headers = dict(resp.getheaders())
            conn.close()

            self.send_response(resp.status, resp.reason)
            for k, v in resp_headers.items():
                lk = k.lower()
                if lk in hop_by_hop:
                    continue
                if lk == "content-length":
                    continue
                self.send_header(k, v)
            self.send_header("Content-Length", str(len(resp_body)))
            self.end_headers()
            if resp_body:
                self.wfile.write(resp_body)

            req_payload = _json_or_text(req_body) if req_body else ""
            resp_payload = _json_or_text(resp_body) if resp_body else ""

            record = {
                "timestamp": _now_iso(),
                "method": self.command,
                "path": self.path,
                "upstream": f"{self.upstream_scheme}://{self.upstream_host}:{self.upstream_port}",
                "request": {
                    "headers": {k: v for k, v in self.headers.items()},
                    "body": req_payload,
                },
                "response": {
                    "status": resp.status,
                    "reason": resp.reason,
                    "headers": resp_headers,
                    "body": resp_payload,
                },
            }
            _write_capture(record)

            if any(ep in self.path for ep in FOCUS_ENDPOINTS):
                print(f"[{_now_iso()}] Captured focus endpoint: {self.command} {self.path} -> {resp.status}")

        except Exception as exc:
            self.send_error(502, f"Proxy error: {exc}")
            _write_capture(
                {
                    "timestamp": _now_iso(),
                    "method": self.command,
                    "path": self.path,
                    "error": str(exc),
                }
            )


def parse_args():
    p = argparse.ArgumentParser(description="Capture and forward Teamcenter HTTP traffic")
    p.add_argument("--listen-host", default="127.0.0.1", help="Host to bind proxy listener")
    p.add_argument("--listen-port", type=int, default=8899, help="Port to bind proxy listener")
    p.add_argument(
        "--upstream-base",
        required=True,
        help="Upstream Teamcenter base URL, e.g. http://STLV-HSMWEBTCP1:8080",
    )
    return p.parse_args()


def main():
    args = parse_args()
    up = urlsplit(args.upstream_base)
    if up.scheme not in ("http", "https") or not up.hostname:
        raise ValueError("Invalid --upstream-base. Example: http://STLV-HSMWEBTCP1:8080")

    ProxyHandler.upstream_scheme = up.scheme
    ProxyHandler.upstream_host = up.hostname
    ProxyHandler.upstream_port = up.port or (443 if up.scheme == "https" else 80)

    print("Teamcenter HTTP capture proxy")
    print(f"  Listen:   http://{args.listen_host}:{args.listen_port}")
    print(f"  Upstream: {ProxyHandler.upstream_scheme}://{ProxyHandler.upstream_host}:{ProxyHandler.upstream_port}")
    print(f"  Capture:  {CAPTURE_FILE}")
    print("Point CHECKSHEET.exe server URL to the Listen address above.")

    with ThreadingHTTPServer((args.listen_host, args.listen_port), ProxyHandler) as httpd:
        try:
            httpd.serve_forever()
        except KeyboardInterrupt:
            print("\nStopping proxy.")


if __name__ == "__main__":
    main()

