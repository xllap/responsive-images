# MonitorAudioManager

A simple utility for enabling or disabling a TV display and switching the default audio device when the monitor is detected. It relies on NirSoft's **MultiMonitorTool** and NAudio.

## Building

1. Install the .NET 6 SDK on Windows.
2. Restore NuGet packages and build:

```bash
dotnet build MonitorAudioManager/MonitorAudioManager.csproj
```

## Usage

1. Download `MultiMonitorTool` from NirSoft and place `mmt.exe` next to the application or adjust the path in `appsettings.json` (not included).
2. Run the built `MonitorAudioManager.exe`. It will start in the system tray.
3. Use the tray icon to enable/disable the TV monitor and set the audio output. The settings window allows choosing which monitor name and audio endpoint to control.

Monitor arrival is detected via WMI (`ManagementEventWatcher`). When a monitor is plugged in, the tool can automatically enable the display and set the audio device.

Starting in this version you can also change the monitor's resolution and refresh rate programmatically. The `DisplayManager.SetResolution` helper uses the Win32 API to update the display settings.

The tray menu includes a **Run at startup** option. When enabled, the application registers itself under `HKCU\Software\Microsoft\Windows\CurrentVersion\Run` so it launches automatically when you sign in.
