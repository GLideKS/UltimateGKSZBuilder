#!/usr/bin/env bash
cd "$(dirname "$0")"
mono --server --gc=sgen Builder.exe