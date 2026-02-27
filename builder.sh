#!/usr/bin/env bash
cd "$(dirname "$0")"
if [ ! -f "Builder.exe.so" ]; then mono --aot Builder.exe; fi && GTK_DATA_PREFIX= mono Builder.exe
