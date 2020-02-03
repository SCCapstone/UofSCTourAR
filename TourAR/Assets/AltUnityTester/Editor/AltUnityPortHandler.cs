﻿

public class AltUnityPortHandler {


    public static int idIproxyProcess=0;

#if UNITY_EDITOR_OSX
    public static string ForwardIos(string id="",int localPort=13000,int remotePort=13000) {
        var argument=localPort+" "+remotePort+" "+id;
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
        {
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError=true,
            FileName = AltUnityTesterEditor.EditorConfiguration.IProxyPath,
            Arguments = argument
        };
        process.StartInfo = startInfo;
        process.Start();
        idIproxyProcess = process.Id;

        System.Threading.Thread.Sleep(1000);
        if(process.HasExited){
            return process.StandardError.ReadToEnd();
        }
        
        return "Ok "+process.Id;
               
    }

    public static void KillIProxy(int id) {
        var process= System.Diagnostics.Process.GetProcessById(id);
        if(process!=null){
        process.Kill();
        process.WaitForExit();
        }
    }
#endif

    public static string ForwardAndroid(string deviceId="",int localPort=13000,int remotePort=13000) {
        string adbFileName;
        string argument;
        if (deviceId.Equals(""))
            argument = "forward tcp:" + localPort + " tcp:" + remotePort;
        else
            {
            
                argument = "-s "+ deviceId +" forward" + " tcp:" + localPort + " tcp:" + remotePort;
            }


#if UNITY_EDITOR_WIN
        adbFileName = "adb.exe";
#elif UNITY_EDITOR
        adbFileName = AltUnityTesterEditor.EditorConfiguration.AdbPath;
        #endif

        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
        {
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError=true,
            FileName = adbFileName,
            Arguments = argument
        };
        process.StartInfo = startInfo;
        process.Start();
        string stdout=process.StandardError.ReadToEnd();
        process.WaitForExit();
        if(stdout.Length>0){
            return stdout;
        }
        return "Ok";

    }

    public static void RemoveForwardAndroid(int localPort=-1,string deviceId="") {
        string argument;
        if (localPort == -1)
        {
            argument = "forward --remove-all";
        }
        else
        {
            argument = "-s "+ deviceId +" forward --remove tcp:" + localPort;
        }
        string adbFileName;
#if UNITY_EDITOR_WIN
        adbFileName = "adb.exe";
#elif UNITY_EDITOR
        adbFileName = AltUnityTesterEditor.EditorConfiguration.AdbPath;
#endif
        var process = new System.Diagnostics.Process();
        var startInfo = new System.Diagnostics.ProcessStartInfo
        {
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError=true,
            FileName = adbFileName,
            Arguments = argument
        };
        process.StartInfo = startInfo;
        process.Start();
        process.WaitForExit();
    }


    public static System.Collections.Generic.List<MyDevices> GetDevicesAndroid()
    {
       
        string adbFileName;
#if UNITY_EDITOR_WIN
        adbFileName = "adb.exe";
#elif UNITY_EDITOR
        adbFileName = AltUnityTesterEditor.EditorConfiguration.AdbPath;
#endif
        var process = new System.Diagnostics.Process();
        var startInfo = new System.Diagnostics.ProcessStartInfo
        {
            CreateNoWindow = true,
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError=true,
            FileName = adbFileName,
            Arguments = "devices"
        };
        process.StartInfo = startInfo;
        process.Start();
        System.Collections.Generic.List<MyDevices> devices = new System.Collections.Generic.List<MyDevices>();
        while (!process.StandardOutput.EndOfStream)
        {
            string line = process.StandardOutput.ReadLine();
            if (line.Length > 0 && !line.StartsWith("List "))
            {
                var parts = line.Split('\t');
                string deviceId = parts[0];                
                devices.Add(new MyDevices(deviceId));
            }
        }
        process.WaitForExit();
        return devices;
    }
    public static System.Collections.Generic.List<MyDevices> GetForwardedDevicesAndroid()
    {
        string adbFileName;
#if UNITY_EDITOR_WIN
        adbFileName = "adb.exe";
#elif UNITY_EDITOR
        adbFileName = AltUnityTesterEditor.EditorConfiguration.AdbPath;
#endif
        var process = new System.Diagnostics.Process();
        var startInfo = new System.Diagnostics.ProcessStartInfo
        {
            CreateNoWindow=true,
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError=true,
            FileName = adbFileName,
            Arguments = "forward --list"
        };
        process.StartInfo = startInfo;
        process.Start();
        System.Collections.Generic.List<MyDevices> devices = new System.Collections.Generic.List<MyDevices>();
        while (!process.StandardOutput.EndOfStream)
        {
            string line = process.StandardOutput.ReadLine();
            if (line.Length > 0)
            {
                try{
                var parts = line.Split(' ');
                string deviceId = parts[0];
                int localPort = int.Parse(parts[1].Split(':')[1]);
                int remotePort = int.Parse(parts[2].Split(':')[1]);
                devices.Add(new MyDevices(deviceId, localPort, remotePort,true));
                }catch(System.FormatException)
                {
                    UnityEngine.Debug.Log("adb forward also has: "+line+" but we did not included in the list");
                }
            }
        }
        process.WaitForExit();
        return devices;
    }
#if UNITY_EDITOR_OSX
     public static System.Collections.Generic.List<MyDevices> GetConnectediOSDevices()
    {
    
        var xcrun = "/usr/bin/xcrun";
        var process = new System.Diagnostics.Process();
        var startInfo = new System.Diagnostics.ProcessStartInfo
        {
            CreateNoWindow=true,
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError=true,
            FileName = xcrun,
            Arguments = "instruments -s devices"
        };
        process.StartInfo = startInfo;
        process.Start();
        System.Collections.Generic.List<MyDevices> devices = new System.Collections.Generic.List<MyDevices>();
        string line = process.StandardOutput.ReadLine();//Known devices: line
        line = process.StandardOutput.ReadLine();//mac's id
        while (!process.StandardOutput.EndOfStream)
        {
            line = process.StandardOutput.ReadLine();
            if (line.Length > 0 && !line.Contains("(Simulator)"))
            {
                var parts = line.Split('[');
                string deviceId = parts[1].Split(']')[0];
                devices.Add(new MyDevices(deviceId,13000,13000,false,Platform.iOS));
            }
        }
        process.WaitForExit();
        return devices;
    }
#endif



}
