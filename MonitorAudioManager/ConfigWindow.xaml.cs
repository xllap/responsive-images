using System.Linq;
using System.Windows;
using MonitorAudioManager.Services;

namespace MonitorAudioManager
{
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
            AudioDevicesBox.ItemsSource = AudioManager.GetRenderDevices();
            AudioDevicesBox.DisplayMemberPath = nameof(NAudio.CoreAudioApi.MMDevice.FriendlyName);
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            // Persist settings (not fully implemented)
            Close();
        }
    }
}
