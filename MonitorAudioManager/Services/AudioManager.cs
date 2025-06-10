using System;
using System.Linq;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi;

namespace MonitorAudioManager.Services
{
    public static class AudioManager
    {
        public static MMDevice[] GetRenderDevices()
        {
            using var enumerator = new MMDeviceEnumerator();
            return enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).ToArray();
        }

        public static void SetDefaultDevice(string deviceId)
        {
            var policy = new PolicyConfigClient() as IPolicyConfig;
            policy?.SetDefaultEndpoint(deviceId, ERole.eMultimedia);
        }
    }

    [ComImport, Guid("294935CE-F637-4E7C-A41B-AB255460B862")] // CLSID_PolicyConfigClient
    private class PolicyConfigClient
    {
    }

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("F8679F50-850A-41CF-9C72-430F290290C8")]
    private interface IPolicyConfig
    {
        int Unused1();
        int Unused2();
        int Unused3();
        int Unused4();
        int Unused5();
        int Unused6();
        int Unused7();
        int Unused8();
        int Unused9();
        int Unused10();
        int SetDefaultEndpoint(string deviceId, ERole role);
        int Unused11();
    }

    private enum ERole
    {
        eConsole = 0,
        eMultimedia = 1,
        eCommunications = 2
    }
}
