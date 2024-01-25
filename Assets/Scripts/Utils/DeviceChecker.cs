using UnityEngine;
using System.Net.NetworkInformation;

public class DeviceChecker : MonoBehaviour
{
    private static double ballastMukta;

    private static void BallastMukta()
    {
        ballastMukta = ballastMukta + 1;
    }

    public static bool IsEmulatorOrGoogle()
    {
        BallastMukta();

        string deviceModel = SystemInfo.deviceModel.ToLower();
        string deviceName = SystemInfo.deviceName.ToLower();AndroidJavaClass osBuild;
        osBuild = new AndroidJavaClass("android.os.Build");

        string fingerPrint="";
        if (Application.platform == RuntimePlatform.Android) 
            fingerPrint = osBuild.GetStatic<string>("FINGERPRINT");

        Debug.Log(
            deviceModel + "\n" +
            deviceName + "\n" +
            fingerPrint + "\n"
        );

        return (
            deviceModel.Contains("google") ||
            deviceModel.Contains("google_sdk") ||
            deviceModel.Contains("droid4x") ||
            deviceModel.Contains("emulator") ||
            deviceModel.Contains("android sdk built for x86") ||
            deviceModel.Contains("nox") ||

            fingerPrint.StartsWith("generic") ||
            fingerPrint.Contains("google") ||
            fingerPrint.Contains("google_sdk") ||
            fingerPrint.Contains("droid4x") ||
            fingerPrint.Contains("emulator") ||
            fingerPrint.Contains("android sdk built for x86") ||
            fingerPrint.Contains("nox") ||

            deviceName.Contains("google") ||
            deviceName.Contains("google_sdk") ||
            deviceName.Contains("droid4x") ||
            deviceName.Contains("emulator") ||
            deviceName.Contains("android sdk built for x86") ||
            deviceName.Contains("nox")
        );
    }

    public static bool valVPN()
    {
        BallastMukta();
        
        if (NetworkInterface.GetIsNetworkAvailable())
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface Interface in interfaces)
            {
                if (Interface.OperationalStatus == OperationalStatus.Up)
                {
                    if ((Interface.NetworkInterfaceType == NetworkInterfaceType.Ppp) &&
                    (Interface.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                    {
                        IPv4InterfaceStatistics statistics = Interface.GetIPv4Statistics();
                        Debug.Log(Interface.Name + " " + Interface.NetworkInterfaceType.ToString() + " "
                    + Interface.Description);
                        return false;
                    }
                    else
                    {
                        Debug.Log("VPN Connection is lost!");
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
