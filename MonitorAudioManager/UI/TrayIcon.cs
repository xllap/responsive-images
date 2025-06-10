using System;
using System.Linq;
using System.Windows.Forms;
using MonitorAudioManager.Services;

namespace MonitorAudioManager.UI
{
    public class TrayIcon : IDisposable
    {
        private readonly NotifyIcon _icon;

        public TrayIcon()
        {
            _icon = new NotifyIcon
            {
                Icon = System.Drawing.SystemIcons.Application,
                Text = "Monitor Audio Manager",
                Visible = true
            };
            BuildMenu();
        }

        private void BuildMenu()
        {
            var menu = new ContextMenuStrip();
            var enableItem = new ToolStripMenuItem("Enable TV && Audio", null, (s, e) => EnableTv());
            menu.Items.Add(enableItem);

            var resItem = new ToolStripMenuItem("Set TV 1080p60", null, (s, e) => SetTvResolution());
            menu.Items.Add(resItem);

            var disableItem = new ToolStripMenuItem("Disable TV", null, (s, e) => DisableTv());
            menu.Items.Add(disableItem);

            menu.Items.Add(new ToolStripSeparator());

            var configItem = new ToolStripMenuItem("Settings", null, (s, e) => OpenConfig());
            menu.Items.Add(configItem);

            menu.Items.Add(new ToolStripSeparator());
            var startupItem = new ToolStripMenuItem("Run at startup") { CheckOnClick = true };
            startupItem.Checked = StartupManager.IsEnabled();
            startupItem.CheckedChanged += (s, e) => StartupManager.SetEnabled(startupItem.Checked);
            menu.Items.Add(startupItem);

            menu.Items.Add(new ToolStripMenuItem("Exit", null, (s, e) => System.Windows.Application.Current.Shutdown()));

            _icon.ContextMenuStrip = menu;
        }

        private void EnableTv()
        {
            DisplayManager.SetMonitorEnabled("TV", true);
            DisplayManager.SetResolution("TV", 1920, 1080, 60);
            var devices = AudioManager.GetRenderDevices();
            var tv = devices.FirstOrDefault(d => d.FriendlyName.Contains("TV"));
            if (tv != null)
                AudioManager.SetDefaultDevice(tv.ID);
        }

        private void DisableTv()
        {
            DisplayManager.SetMonitorEnabled("TV", false);
        }

        private void OpenConfig()
        {
            var wnd = new ConfigWindow();
            wnd.Show();
        }

        private void SetTvResolution()
        {
            DisplayManager.SetResolution("TV", 1920, 1080, 60);
        }

        public void Dispose()
        {
            _icon.Dispose();
        }
    }
}
