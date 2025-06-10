using System;
using System.Windows;
using MonitorAudioManager.Services;
using MonitorAudioManager.UI;

namespace MonitorAudioManager
{
    public partial class App : Application
    {
        private TrayIcon? _tray;
        private MonitorWatcher? _watcher;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            _tray = new TrayIcon();
            _watcher = new MonitorWatcher();
            _watcher.MonitorArrived += (s, args) => _tray?.Dispose();
            _watcher.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _watcher?.Dispose();
            _tray?.Dispose();
            base.OnExit(e);
        }
    }
}
