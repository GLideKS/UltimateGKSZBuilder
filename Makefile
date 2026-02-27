
BUILDTYPE ?= Release

all: linux

run:
	cd Build && GTK_DATA_PREFIX= mono Builder.exe

linux: builder native

mac: builder nativemac

builder:
	msbuild /nologo /verbosity:minimal -p:Configuration=$(BUILDTYPE) BuilderMono.sln
	cp builder.sh Build/builder
	chmod +x Build/builder && mono --aot Build/*.dll && mono --aot Build/Builder.exe

nativemac:
	g++ -O2 --shared -g3 -o Build/libBuilderNative.so -fPIC -I Source/Native Source/Native/*.cpp Source/Native/OpenGL/*.cpp Source/Native/OpenGL/gl_load/*.c -ldl

native:
	g++ -O2 --shared -g3 -o Build/libBuilderNative.so -fPIC -I Source/Native Source/Native/*.cpp Source/Native/OpenGL/*.cpp Source/Native/OpenGL/gl_load/*.c -DUDB_LINUX=1 -lX11 -lXfixes -ldl
