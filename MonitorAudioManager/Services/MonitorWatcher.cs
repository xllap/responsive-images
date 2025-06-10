using System;
using System.Management;

namespace MonitorAudioManager.Services
{
    public class MonitorWatcher : IDisposable
    {
        private ManagementEventWatcher _arrivalWatcher;

        public event EventHandler? MonitorArrived;

        public MonitorWatcher()
        {
            var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            _arrivalWatcher = new ManagementEventWatcher(query);
            _arrivalWatcher.EventArrived += (s, e) => MonitorArrived?.Invoke(this, EventArgs.Empty);
        }

        public void Start() => _arrivalWatcher.Start();

        public void Stop() => _arrivalWatcher.Stop();

        public void Dispose()
        {
            _arrivalWatcher.Stop();
            _arrivalWatcher.Dispose();
        }
    }
}
