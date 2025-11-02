BUILDTYPE ?= Release

ifdef MINGW
TARGET_EXEC := BuilderNative.dll
else
TARGET_EXEC := libBuilderNative.so
endif

BUILD_DIR := ./Build.Native
SRC_DIRS := ./Source/Native

SRCS := $(shell find $(SRC_DIRS) -name '*.cpp' -or -name '*.c' -or -name '*.s')

OBJS := $(SRCS:%=$(BUILD_DIR)/%.o)

DEPS := $(OBJS:.o=.d)

INC_DIRS := ./Source/Native

INC_FLAGS := $(addprefix -I,$(INC_DIRS))

CPPFLAGS_ := $(INC_FLAGS) -MMD -MP

CFLAGS_ = -O2 -g3 -fPIC -Wall -Wextra -Wno-unused-parameter -Werror

ifdef MINGW
CFLAGS_ += -msse2
endif

CXXFLAGS_ = -std=c++14 $(CFLAGS_)

ifdef MINGW
LDFLAGS_ = -lopengl32 -lgdi32 -shared -Wl,--subsystem,windows
else
LDFLAGS_ = -lX11 -ldl -shared
endif

all: builder Build/$(TARGET_EXEC)

$(BUILD_DIR)/%.c.o: %.c
	@mkdir -p $(dir $@)
	$(CC) $(CPPFLAGS_) $(CPPFLAGS) $(CFLAGS_) $(CFLAGS) -c $< -o $@

$(BUILD_DIR)/%.cpp.o: %.cpp
	@mkdir -p $(dir $@)
	$(CXX) $(CPPFLAGS_) $(CPPFLAGS) $(CXXFLAGS_) $(CXXFLAGS) -c $< -o $@

$(BUILD_DIR)/$(TARGET_EXEC): $(OBJS)
	$(CXX) $(OBJS) $(LDFLAGS_) $(LDFLAGS) -o $@

Build/$(TARGET_EXEC): $(BUILD_DIR)/$(TARGET_EXEC)
	cp $< $@

.PHONY: clean
clean:
	-rm --force --recursive $(BUILD_DIR)/Source $(BUILD_DIR)/$(TARGET_EXEC) $(BUILD_DIR)/builder $(BUILD_DIR)/Builder.exe Build/libBuilderNative.so

run:
	cd Build && mono --aot=full -O=all Builder.exe && mono --server --gc=sgen Builder.exe

linux: builder native

mac: builder nativemac

builder: $(BUILD_DIR)/Builder.exe Build/builder

$(BUILD_DIR)/Builder.exe: BuilderMono.sln Build/builder
	msbuild /nologo /verbosity:minimal -p:Configuration=$(BUILDTYPE) -p:Optimize=true -m -p:Platform=x86 BuilderMono.sln

Build/builder:
	cp builder.sh Build/builder
	chmod +x Build/builder

nativemac:
	$(CXX) -std=c++14 -O2 --shared -g3 -o Build/libBuilderNative.so -fPIC -I Source/Native Source/Native/*.cpp Source/Native/OpenGL/*.cpp Source/Native/OpenGL/gl_load/*.c -ldl

native:
	$(CXX) -std=c++14 -O2 --shared -g3 -o Build/libBuilderNative.so -fPIC -I Source/Native Source/Native/*.cpp Source/Native/OpenGL/*.cpp Source/Native/OpenGL/gl_load/*.c -DUDB_LINUX=1 -lX11 -ldl

-include $(DEPS)
