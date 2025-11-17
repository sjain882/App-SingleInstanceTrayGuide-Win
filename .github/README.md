<h1 align="left">
  🚀 <b>Novice-friendly launcher for single-instance Windows apps</b>
  <br>
</h1>

<div align="center">

<img style="width: 100%; height: 100%" src="https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/blob/main/.github/Previews/TrayGuideWindow/Themes.gif?raw=true"/>

<br>
<br>

<p align="center"> <b>
  <a href="https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/releases/latest">📦 Download Now</a> •
  <a href="https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/issues">🐛 Found a Bug?</a> •
  <a href="https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/issues">💡 Share Ideas</a> •
  <a href="https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/pulls">📈 Contribute</a>
</b></p>

[![ISSUES](https://img.shields.io/github/issues/sjain882/App-SingleInstanceTrayGuide-Win?color=F57C00&style=flat)](https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/issues)
[![VERSION](https://img.shields.io/github/v/release/sjain882/App-SingleInstanceTrayGuide-Win?color=26A69A&style=flat&label=version)](https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/releases/latest)
[![DOWNLOAD](https://img.shields.io/github/downloads/sjain882/App-SingleInstanceTrayGuide-Win/total?label=downloads&color=2E7D32)](https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/releases/download/v0.1.0/App-SingleInstanceTrayGuide-Win.v0.1.0.zip)
[![DOTNET9](https://img.shields.io/badge/.NET%20-%209.0-512bd4)](https://dotnet.microsoft.com/en-us/download)

Responsive .NET 9 launcher for single-instance programs, adhering to WPF MVVM principles.

Designed for novice users.
<br>
</div>

‎
‎
<details>
<summary>🖼️ Additional previews</summary>
‎
‎

Static previews are available in each subfolder **[here](https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/tree/main/.github/Previews)**
</details>

## 🖥️ Supported operating systems

- Supported on **Windows 10 1607+**
- Tested on **Windows 10 21H2** and **22H2**
- May work on previous OS versions, but this is **[unsupported](https://github.com/dotnet/core/blob/main/release-notes/9.0/supported-os.md)**.

‎
‎
## ❓ Why

*This program is intended to be deployed by administrators, and used by novice users.*

As someone who administers the system of a forgetful novice user, I constantly seek ways to minimise any required knowledge.

One of the ways I manifest this is by making the Start menu their first port of call for any task. I even stuck a label under it re-iterating this, as it means less GUIs have to be learnt.

This concept perfectly matches the simple tile layout of Windows 10's Start menu.

Some programs, however, do not offer the ability to re-use existing background instances when their executables are launched. 

Instead, they will either present verbose warnings with no way to show the existing UI (OBS recording software), or simply do nothing (Brother ControlCenter4 scanning software).

Others fail to present a GUI even when launched as the first instance, opting to silently create a tray  icon instead.

If the user does not understand the concept of program instances, and that the small tray icon in the corner is a means to control one, it can result in them getting lost or launching several instances of the same program. 

‎
‎
## 💡 How does it work?

This program acts as a middleman to solve this problem.

A copy of it is configured to launch another application.

Then, a shortcut to that copy (with an appropriate icon) is pinned to the Start menu instead of the specified application itself.

When started, it will check if the target program is already running, and:

1. if so - presents the user with a guide on how to use its tray icon
2. if not - launches the program, then presents the same guide (assuming it minimises to tray)
3. if multiple instances - alerts the user to contact their administrator

The guide is displayed near the notification tray area in a frameless and reliably always-on-top state, ensuring the user can't accidentally close, resize or miss it.

‎
‎
## ⚙️ Configuring

The contents of all GUI elements are fully replaceable in the config file, allowing you to finely tailor this program to your user's needs.

The responsive XAML design accommodates text labels of any length, can appear in any four corners of the screen, and auto adjusts to the system's colour theme (light/dark).

The target program can be launched either directly or via Task Scheduler, with full support for working directories, launch arguments and environment variables (such as `QT_SCALE_FACTOR`).

The configuration file is pre-loaded with values for an ideal use case (OBS with [shutdown check bypassed](https://gist.github.com/sjain882/3dddf90024aa4f919c6e4e0aa015885b)), so you have an idea of what to enter.

‎
‎
## 📜 Usage

1. Build the project or [download a release](https://github.com/sjain882/App-SingleInstanceTrayGuide-Win/releases/latest).

2. Copy all files to a directory named after the target application to launch.

3. Open `App-SingleInstanceTrayGuide-Win.dll.config` in a text editor and configure the options.

4. Create a shortcut to `App-SingleInstanceTrayGuide-Win.exe` and name it after the target application to launch.

5. Right click the shortcut > Properties > Change Icon > Select the .exe / .ico file of the target application to launch.

6. Right click the shortcut > Pin to start.

‎
‎
## 📈 Planned features

- Option to highlight target program's tray icon with a red box (via UIAutomation)
- Option to make this a flashing box, with customisable flash rate
- Option to automatically move mouse to the target program's tray icon (via UIAutomation)
- Option to temporarily lock the mouse in this position for a specified time (e.g, 1s)

‎
‎
## ⚒️ Building

> [!IMPORTANT]  
> This project makes use of design-time ViewModels to display UI elements in the WPF designer.
> 
> This functionality is currently unsupported in JetBrains Rider.
>
> It is highly recommended that you use Visual Studio 2022 or above instead.

### Prerequisites

- .NET 9 SDK

### dotnet command line

#### Debug

1. Run `dotnet build` in the project root (`src`).

2. Binaries are located in `App-SingleInstanceTrayGuide-Win\bin\Debug\net9.0-windows`.

#### Release

1. Run `dotnet publish -c Release` in the project root (`src`).

2. Binaries are located in `App-SingleInstanceTrayGuide-Win\bin\Release\net9.0-windows\publish`.

### Visual Studio 2022

#### Debug

1. Open `App-SingleInstanceTrayGuide-Win.sln` from the project root (`sln`).

2. Set the `Configuration` to `Debug` and the `Platform` to `Any CPU`.

3. Select `Build > Build Solution`.

4. Binaries are located in `App-SingleInstanceTrayGuide-Win\bin\Debug\net9.0-windows`.

#### Release

1. Open `App-SingleInstanceTrayGuide-Win.sln` from the project root (`sln`).

2. Set the `Configuration` to `Release` and the `Platform` to `Any CPU`.

3. Select `Build > Build Solution`.

4. Binaries are located in `App-SingleInstanceTrayGuide-Win\bin\Release\net9.0-windows`.

‎
‎
## 🔐 Digital Signing of Release Binaries

All `*.exe` binary files of this project compiled by me are digitally self-signed. The attached certificate should carry this serial number:

`4cedc2fe9c34a68e4c9ea1e2d379fdee`

If the serial number on your copy does not match this, or the digital certificate is missing the file has potentially been tampered with and should be deleted immediately.

You can check this by right clicking on the `App-SingleInstanceTrayGuide-Win` .exe / Application file > Properties > Digital Signatures > Select the one named "sjain882" > Details > View Certificate > Details > Serial Number.

The serial number for this project's binaries will be different to the serial found in my other projects - this is completely normal.

‎
‎
## 💖 Thanks to

- The **[SvgToXaml](https://github.com/BerndK/SvgToXaml)** project for allowing conversion of SVG images to XAML resource dictionaries

- **[Kampa Plays](https://www.youtube.com/@KampaPlays)** for a great set of **[C# WPF tutorials](https://www.youtube.com/playlist?list=PLih2KERbY1HHOOJ2C6FOrVXIwg4AZ-hk1)**

‎
‎
## 🔑 License

This software is licensed under the GNU General Public License v3 (GPL-3) licence. Please see https://www.gnu.org/licenses/gpl-3.0.en.html for more information.

‎
‎
## ℹ️ Disclaimer

This software is provided "As is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. **I cannot be held personally responsible if usage of this software results in loss of work or breakage of your operating system**.
