#!/usr/bin/env bash
cd "$(dirname "$0")"
mono --aot=full -O=all Builder.exe && mono --server --gc=sgen Builder.exe