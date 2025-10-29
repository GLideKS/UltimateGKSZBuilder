# Ultimate GKSZ Builder

## System requirements
- 2.4 GHz CPU or faster (multi-core recommended)
- Windows 7, 8, 10, or 11
- Graphics card with OpenGL 3.2 support

### Required software on Windows
- [Microsoft .Net Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)

## Building on Linux
These instructions are for Debian-based distros and were tested with Ubuntu 24.04 LTS and Arch.

__Note:__ this is experimental. None of the main developers are using Linux as a desktop OS, so you're pretty much on your own if you encounter any problems with running the application.

- Install Mono
  - **Ubuntu:** The `mono-complete` package from the Debian repo doesn't include `msbuild`, so you have to install `mono-complete` by following the instructions on the Mono project's website: https://www.mono-project.com/download/stable/#download-lin
  - **Arch:** mono (and msbuild which is also required) is in the *extra/* repo, which is enabled by default. `sudo pacman -S mono mono-msbuild`
- Install additional required packages
  - **Ubuntu:** `sudo apt install make g++ git libx11-dev libxfixes-dev mesa-common-dev`
  - **Arch:** `sudo pacman -S base-devel`
    - If you're using X11 display manager you may need to install these packages: `libx11 libxfixes`
    - If you are not using the proprietary nvidia driver you may need to install `mesa`
- Go to a directory of your choice and clone the repository (it'll automatically create an `UltimateGKSZBuilder` directory in the current directory): `git clone https://github.com/GLideKS/UltimateGKSZBuilder.git`
- Compile UZB: `cd UltimateDoomBuilder && make`
- Run UZB: `cd Build && ./builder`
- Alternatively, to compile UZB in debug mode:
  - Run `make BUILDTYPE=Debug` in the root project directory
  - This includes a debug output terminal in the bottom panel

Ultimate Doom Builder:
- [UDB repository](https://github.com/UltimateDoomBuilder/UltimateDoomBuilder)
- [Original forum.zdoom.org thread](https://forum.zdoom.org/viewtopic.php?f=232&t=66745)

Ultimate Zone Builder:
- [UZB Repository](https://git.do.srb2.org/STJr/UltimateZoneBuilder)
- [Original SRB2MB thread](https://mb.srb2.org/addons/ultimate-zone-builder.6126/)

More detailed info can be found in the **editor documentation** (Refmanual.chm)
