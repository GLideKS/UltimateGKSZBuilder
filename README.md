# Ultimate GKSZ Builder

> [!IMPORTANT]
> As for April 25th 2026, most of Ultimate GKSZ Builder changes has been moved and merged into [STJr/Ultimate Zone Builder](https://git.do.srb2.org/STJr/UltimateZoneBuilder) (Official Repository), Ultimate GKSZ Builder repository is archived and no longer receive updates, making it obsolete now.
>
> Reason: "I've been promoted to maintainer officialy in Ultimate Zone Builder repository. So I moved all my changes and I'll keep maintaining UZB there."

Ultimate GKSZ Builder was a fork of [Ultimate Zone Builder](https://git.do.srb2.org/STJr/UltimateZoneBuilder) focused to Linux users with the purpose to make it usable. Since the official repository hasn't been updated for years.

Aside from having parity with [Ultimate Doom Builder](https://github.com/UltimateDoomBuilder/UltimateDoomBuilder)'s latest fixes and changes, it also brings fixes and improvements for Linux specifically.

If you're a Windows user, you could try to use this fork as well, but I (GLide KS) don't promise if it equally works on Windows since this fork is aimed for Linux. My recommendation is to use Ultimate Zone Builder instead.

Includes also a few changes from:

- [NepDisk's Ultimate Lowee Builder](https://codeberg.org/NepDisk/UltimateLoweeBuilder)
- [Kart Krew's High Voltage Ring](https://git.do.srb2.org/KartKrew/high-voltage-ring)
- SRB2 configuration fixes and UI adjustments from GLide KS (fork owner)
- Pull requests leaved in the limbo on the UZB repository

## System requirements
- 2.4 GHz CPU or faster (multi-core recommended)
- Windows 7, 8, 10, or 11
- Graphics card with OpenGL 3.2 support

### Required software on Windows
- [Microsoft .Net Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)

## Building through srb2bld (Windows/Linux)

For an easier compiling process, Ultimate GKSZ Builder is also available to build on [Bijman's srb2bld](https://mb.srb2.org/threads/srb2bld-srb2-build-package-manager-cli.34623/), a build/package manager through cli. **Please follow the instructions there instead**.

## Building Manually (Linux)

These instructions are for Debian-based distros and were tested with Ubuntu 24.04 LTS and Arch.

__Note:__ this is experimental. None of the main developers are using Linux as a desktop OS, so you're pretty much on your own if you encounter any problems with running the application.

- Install Mono
  - **Ubuntu:** The `mono-complete` package from the Debian repo doesn't include `msbuild`, so you have to install `mono-complete` by following the instructions on the Mono project's website: https://www.mono-project.com/download/stable/#download-linux
  - **Arch:** mono (and msbuild which is also required) is in the *extra/* repo, which is enabled by default. `sudo pacman -S mono mono-msbuild`
- Install additional required packages
  - **Ubuntu:** `sudo apt install make g++ git libx11-dev libxfixes-dev mesa-common-dev`
  - **Arch:** `sudo pacman -S base-devel`
    - If you're using X11 display manager you may need to install these packages: `libx11 libxfixes`
    - If you are not using the proprietary nvidia driver you may need to install `mesa`
- Go to a directory of your choice and clone the repository (it'll automatically create an `UltimateGKSZBuilder` directory in the current directory): `git clone https://github.com/GLideKS/UltimateGKSZBuilder.git`
- Compile Ultimate GKSZ Builder: `cd UltimateGKSZBuilder && make`
- Run Ultimate GKSZ Builder: `cd Build && ./builder`
- Alternatively, to compile Ultimate GKSZ Builder in debug mode:
  - Run `make BUILDTYPE=Debug` in the root project directory
  - This includes a debug output terminal in the bottom panel
- If you experience freezing when saving or backing up a map, change the Nodebuilders to their Linux variants under **Game Configurations - Nodebuilder** (stated as `[Linux]` in the name)

Ultimate Doom Builder:
- [UDB repository](https://github.com/UltimateDoomBuilder/UltimateDoomBuilder)
- [Original forum.zdoom.org thread](https://forum.zdoom.org/viewtopic.php?f=232&t=66745)

Ultimate Zone Builder:
- [UZB Repository](https://git.do.srb2.org/STJr/UltimateZoneBuilder)
- [Original SRB2MB thread](https://mb.srb2.org/addons/ultimate-zone-builder.6126/)

More detailed info can be found in the **editor documentation** (Refmanual.chm)

## Credits:
- BlueStaggo (Minor fixes)
- NepDisk (Minor fixes, some [Ultimate Lowee Builder](https://codeberg.org/NepDisk/UltimateLoweeBuilder) changes)
- Sphere and LJ Sonik (Ultimate Zone Builder, additional scripts)
- Ultimate Doom Builder
