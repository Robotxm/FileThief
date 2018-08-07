namespace FileThief
{
    partial class FrmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.chkSilent = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.fdb = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTip = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.grpProgram = new System.Windows.Forms.GroupBox();
            this.gbHotkey = new System.Windows.Forms.GroupBox();
            this.chkHotkey = new System.Windows.Forms.CheckBox();
            this.hkcHotkey = new FileThief.HotkeyControl();
            this.lblHotkey = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbDriverType = new System.Windows.Forms.GroupBox();
            this.chkROM = new System.Windows.Forms.CheckBox();
            this.chkUSBHD = new System.Windows.Forms.CheckBox();
            this.chkUSBDisk = new System.Windows.Forms.CheckBox();
            this.gbWhitelist = new System.Windows.Forms.GroupBox();
            this.btnCreateWl = new System.Windows.Forms.Button();
            this.txtWlDrive = new System.Windows.Forms.TextBox();
            this.chkWhitelist = new System.Windows.Forms.CheckBox();
            this.btnSelWhitelist = new System.Windows.Forms.Button();
            this.lblWlVolume = new System.Windows.Forms.Label();
            this.lblWhitelistTip = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.txtRegExp = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnBroSP = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbVolume = new System.Windows.Forms.ComboBox();
            this.lblMb = new System.Windows.Forms.Label();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblFileType = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.chkLogInfo = new System.Windows.Forms.CheckBox();
            this.btnBroLog = new System.Windows.Forms.Button();
            this.chkLogErr = new System.Windows.Forms.CheckBox();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.lblLogPath = new System.Windows.Forms.Label();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.grpProgram.SuspendLayout();
            this.gbHotkey.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbDriverType.SuspendLayout();
            this.gbWhitelist.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(22, 52);
            this.chkAutoRun.Margin = new System.Windows.Forms.Padding(8);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(175, 43);
            this.chkAutoRun.TabIndex = 19;
            this.chkAutoRun.Text = "开机运行";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            // 
            // chkSilent
            // 
            this.chkSilent.AutoSize = true;
            this.chkSilent.Location = new System.Drawing.Point(232, 52);
            this.chkSilent.Margin = new System.Windows.Forms.Padding(8);
            this.chkSilent.Name = "chkSilent";
            this.chkSilent.Size = new System.Drawing.Size(175, 43);
            this.chkSilent.TabIndex = 20;
            this.chkSilent.Text = "静默模式";
            this.chkSilent.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(775, 952);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(188, 58);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(571, 952);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(8);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(188, 58);
            this.btnAbout.TabIndex = 22;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(20, 896);
            this.lblTip.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(377, 39);
            this.lblTip.TabIndex = 23;
            this.lblTip.Text = "鼠标移至项目上可查看说明";
            // 
            // grpProgram
            // 
            this.grpProgram.Controls.Add(this.chkAutoRun);
            this.grpProgram.Controls.Add(this.chkSilent);
            this.grpProgram.Location = new System.Drawing.Point(22, 225);
            this.grpProgram.Margin = new System.Windows.Forms.Padding(8);
            this.grpProgram.Name = "grpProgram";
            this.grpProgram.Padding = new System.Windows.Forms.Padding(8);
            this.grpProgram.Size = new System.Drawing.Size(882, 120);
            this.grpProgram.TabIndex = 26;
            this.grpProgram.TabStop = false;
            this.grpProgram.Text = "程序设置";
            // 
            // gbHotkey
            // 
            this.gbHotkey.Controls.Add(this.chkHotkey);
            this.gbHotkey.Controls.Add(this.hkcHotkey);
            this.gbHotkey.Controls.Add(this.lblHotkey);
            this.gbHotkey.Location = new System.Drawing.Point(22, 373);
            this.gbHotkey.Margin = new System.Windows.Forms.Padding(8);
            this.gbHotkey.Name = "gbHotkey";
            this.gbHotkey.Padding = new System.Windows.Forms.Padding(8);
            this.gbHotkey.Size = new System.Drawing.Size(882, 140);
            this.gbHotkey.TabIndex = 28;
            this.gbHotkey.TabStop = false;
            // 
            // chkHotkey
            // 
            this.chkHotkey.AutoSize = true;
            this.chkHotkey.Location = new System.Drawing.Point(22, 2);
            this.chkHotkey.Margin = new System.Windows.Forms.Padding(8);
            this.chkHotkey.Name = "chkHotkey";
            this.chkHotkey.Size = new System.Drawing.Size(175, 43);
            this.chkHotkey.TabIndex = 2;
            this.chkHotkey.Text = "启用热键";
            this.chkHotkey.UseVisualStyleBackColor = true;
            this.chkHotkey.CheckedChanged += new System.EventHandler(this.chkHotkey_CheckedChanged);
            // 
            // hkcHotkey
            // 
            this.hkcHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.hkcHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.hkcHotkey.Location = new System.Drawing.Point(118, 56);
            this.hkcHotkey.Margin = new System.Windows.Forms.Padding(8);
            this.hkcHotkey.Name = "hkcHotkey";
            this.hkcHotkey.Size = new System.Drawing.Size(244, 47);
            this.hkcHotkey.TabIndex = 1;
            this.hkcHotkey.Text = "None";
            // 
            // lblHotkey
            // 
            this.lblHotkey.AutoSize = true;
            this.lblHotkey.Location = new System.Drawing.Point(16, 62);
            this.lblHotkey.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblHotkey.Name = "lblHotkey";
            this.lblHotkey.Size = new System.Drawing.Size(84, 39);
            this.lblHotkey.TabIndex = 0;
            this.lblHotkey.Text = "热键:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(946, 863);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbDriverType);
            this.tabPage1.Controls.Add(this.gbWhitelist);
            this.tabPage1.Controls.Add(this.grpFilter);
            this.tabPage1.Location = new System.Drawing.Point(10, 56);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(926, 797);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "复制设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbDriverType
            // 
            this.gbDriverType.Controls.Add(this.chkROM);
            this.gbDriverType.Controls.Add(this.chkUSBHD);
            this.gbDriverType.Controls.Add(this.chkUSBDisk);
            this.gbDriverType.Location = new System.Drawing.Point(22, 655);
            this.gbDriverType.Margin = new System.Windows.Forms.Padding(8);
            this.gbDriverType.Name = "gbDriverType";
            this.gbDriverType.Padding = new System.Windows.Forms.Padding(8);
            this.gbDriverType.Size = new System.Drawing.Size(882, 124);
            this.gbDriverType.TabIndex = 31;
            this.gbDriverType.TabStop = false;
            this.gbDriverType.Text = "可移动设备类型";
            // 
            // chkROM
            // 
            this.chkROM.AutoSize = true;
            this.chkROM.Location = new System.Drawing.Point(478, 56);
            this.chkROM.Margin = new System.Windows.Forms.Padding(8);
            this.chkROM.Name = "chkROM";
            this.chkROM.Size = new System.Drawing.Size(344, 43);
            this.chkROM.TabIndex = 2;
            this.chkROM.Text = "光盘 (包括挂载的ISO)";
            this.chkROM.UseVisualStyleBackColor = true;
            // 
            // chkUSBHD
            // 
            this.chkUSBHD.AutoSize = true;
            this.chkUSBHD.Location = new System.Drawing.Point(264, 56);
            this.chkUSBHD.Margin = new System.Windows.Forms.Padding(8);
            this.chkUSBHD.Name = "chkUSBHD";
            this.chkUSBHD.Size = new System.Drawing.Size(182, 43);
            this.chkUSBHD.TabIndex = 1;
            this.chkUSBHD.Text = "USB 硬盘";
            this.chkUSBHD.UseVisualStyleBackColor = true;
            // 
            // chkUSBDisk
            // 
            this.chkUSBDisk.AutoSize = true;
            this.chkUSBDisk.Location = new System.Drawing.Point(22, 56);
            this.chkUSBDisk.Margin = new System.Windows.Forms.Padding(8);
            this.chkUSBDisk.Name = "chkUSBDisk";
            this.chkUSBDisk.Size = new System.Drawing.Size(212, 43);
            this.chkUSBDisk.TabIndex = 0;
            this.chkUSBDisk.Text = "USB 闪存盘";
            this.chkUSBDisk.UseVisualStyleBackColor = true;
            // 
            // gbWhitelist
            // 
            this.gbWhitelist.Controls.Add(this.btnCreateWl);
            this.gbWhitelist.Controls.Add(this.txtWlDrive);
            this.gbWhitelist.Controls.Add(this.chkWhitelist);
            this.gbWhitelist.Controls.Add(this.btnSelWhitelist);
            this.gbWhitelist.Controls.Add(this.lblWlVolume);
            this.gbWhitelist.Controls.Add(this.lblWhitelistTip);
            this.gbWhitelist.Location = new System.Drawing.Point(22, 499);
            this.gbWhitelist.Margin = new System.Windows.Forms.Padding(8);
            this.gbWhitelist.Name = "gbWhitelist";
            this.gbWhitelist.Padding = new System.Windows.Forms.Padding(8);
            this.gbWhitelist.Size = new System.Drawing.Size(882, 140);
            this.gbWhitelist.TabIndex = 28;
            this.gbWhitelist.TabStop = false;
            // 
            // btnCreateWl
            // 
            this.btnCreateWl.Location = new System.Drawing.Point(676, 54);
            this.btnCreateWl.Margin = new System.Windows.Forms.Padding(8);
            this.btnCreateWl.Name = "btnCreateWl";
            this.btnCreateWl.Size = new System.Drawing.Size(188, 58);
            this.btnCreateWl.TabIndex = 6;
            this.btnCreateWl.Text = "创建";
            this.btnCreateWl.UseVisualStyleBackColor = true;
            // 
            // txtWlDrive
            // 
            this.txtWlDrive.BackColor = System.Drawing.SystemColors.Window;
            this.txtWlDrive.Location = new System.Drawing.Point(118, 56);
            this.txtWlDrive.Margin = new System.Windows.Forms.Padding(8);
            this.txtWlDrive.Name = "txtWlDrive";
            this.txtWlDrive.ReadOnly = true;
            this.txtWlDrive.Size = new System.Drawing.Size(336, 47);
            this.txtWlDrive.TabIndex = 5;
            // 
            // chkWhitelist
            // 
            this.chkWhitelist.AutoSize = true;
            this.chkWhitelist.Location = new System.Drawing.Point(22, 0);
            this.chkWhitelist.Margin = new System.Windows.Forms.Padding(8);
            this.chkWhitelist.Name = "chkWhitelist";
            this.chkWhitelist.Size = new System.Drawing.Size(265, 43);
            this.chkWhitelist.TabIndex = 4;
            this.chkWhitelist.Text = "启用设备白名单";
            this.chkWhitelist.UseVisualStyleBackColor = true;
            // 
            // btnSelWhitelist
            // 
            this.btnSelWhitelist.Location = new System.Drawing.Point(474, 54);
            this.btnSelWhitelist.Margin = new System.Windows.Forms.Padding(8);
            this.btnSelWhitelist.Name = "btnSelWhitelist";
            this.btnSelWhitelist.Size = new System.Drawing.Size(188, 58);
            this.btnSelWhitelist.TabIndex = 3;
            this.btnSelWhitelist.Text = "选择设备...";
            this.btnSelWhitelist.UseVisualStyleBackColor = true;
            // 
            // lblWlVolume
            // 
            this.lblWlVolume.AutoSize = true;
            this.lblWlVolume.Location = new System.Drawing.Point(16, 70);
            this.lblWlVolume.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblWlVolume.Name = "lblWlVolume";
            this.lblWlVolume.Size = new System.Drawing.Size(84, 39);
            this.lblWlVolume.TabIndex = 1;
            this.lblWlVolume.Text = "设备:";
            // 
            // lblWhitelistTip
            // 
            this.lblWhitelistTip.AutoSize = true;
            this.lblWhitelistTip.Location = new System.Drawing.Point(16, 48);
            this.lblWhitelistTip.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblWhitelistTip.Name = "lblWhitelistTip";
            this.lblWhitelistTip.Size = new System.Drawing.Size(0, 39);
            this.lblWhitelistTip.TabIndex = 0;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.txtRegExp);
            this.grpFilter.Controls.Add(this.lblFileName);
            this.grpFilter.Controls.Add(this.btnBroSP);
            this.grpFilter.Controls.Add(this.cbType);
            this.grpFilter.Controls.Add(this.cbVolume);
            this.grpFilter.Controls.Add(this.lblMb);
            this.grpFilter.Controls.Add(this.cbSize);
            this.grpFilter.Controls.Add(this.txtLabel);
            this.grpFilter.Controls.Add(this.txtPath);
            this.grpFilter.Controls.Add(this.txtSize);
            this.grpFilter.Controls.Add(this.txtType);
            this.grpFilter.Controls.Add(this.lblVolume);
            this.grpFilter.Controls.Add(this.lblSavePath);
            this.grpFilter.Controls.Add(this.lblFileSize);
            this.grpFilter.Controls.Add(this.lblFileType);
            this.grpFilter.Location = new System.Drawing.Point(22, 11);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(8);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(8);
            this.grpFilter.Size = new System.Drawing.Size(882, 472);
            this.grpFilter.TabIndex = 26;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "过滤选项";
            // 
            // txtRegExp
            // 
            this.txtRegExp.Location = new System.Drawing.Point(22, 390);
            this.txtRegExp.Margin = new System.Windows.Forms.Padding(8);
            this.txtRegExp.Name = "txtRegExp";
            this.txtRegExp.Size = new System.Drawing.Size(840, 47);
            this.txtRegExp.TabIndex = 33;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(16, 340);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(353, 39);
            this.lblFileName.TabIndex = 32;
            this.lblFileName.Text = "文件名规则 (正则表达式):";
            // 
            // btnBroSP
            // 
            this.btnBroSP.Location = new System.Drawing.Point(680, 198);
            this.btnBroSP.Margin = new System.Windows.Forms.Padding(8);
            this.btnBroSP.Name = "btnBroSP";
            this.btnBroSP.Size = new System.Drawing.Size(188, 58);
            this.btnBroSP.TabIndex = 31;
            this.btnBroSP.Text = "浏览...";
            this.btnBroSP.UseVisualStyleBackColor = true;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "包含",
            "排除"});
            this.cbType.Location = new System.Drawing.Point(178, 42);
            this.cbType.Margin = new System.Windows.Forms.Padding(8);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(222, 47);
            this.cbType.TabIndex = 30;
            // 
            // cbVolume
            // 
            this.cbVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVolume.FormattingEnabled = true;
            this.cbVolume.Items.AddRange(new object[] {
            "包含",
            "排除"});
            this.cbVolume.Location = new System.Drawing.Point(178, 270);
            this.cbVolume.Margin = new System.Windows.Forms.Padding(8);
            this.cbVolume.Name = "cbVolume";
            this.cbVolume.Size = new System.Drawing.Size(222, 47);
            this.cbVolume.TabIndex = 29;
            // 
            // lblMb
            // 
            this.lblMb.AutoSize = true;
            this.lblMb.Location = new System.Drawing.Point(798, 128);
            this.lblMb.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblMb.Name = "lblMb";
            this.lblMb.Size = new System.Drawing.Size(65, 39);
            this.lblMb.TabIndex = 28;
            this.lblMb.Text = "MB";
            // 
            // cbSize
            // 
            this.cbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Items.AddRange(new object[] {
            "小于",
            "大于"});
            this.cbSize.Location = new System.Drawing.Point(178, 120);
            this.cbSize.Margin = new System.Windows.Forms.Padding(8);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(222, 47);
            this.cbSize.TabIndex = 27;
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(420, 270);
            this.txtLabel.Margin = new System.Windows.Forms.Padding(8);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(442, 47);
            this.txtLabel.TabIndex = 26;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(178, 198);
            this.txtPath.Margin = new System.Windows.Forms.Padding(8);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(482, 47);
            this.txtPath.TabIndex = 25;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(420, 120);
            this.txtSize.Margin = new System.Windows.Forms.Padding(8);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(356, 47);
            this.txtSize.TabIndex = 24;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(420, 48);
            this.txtType.Margin = new System.Windows.Forms.Padding(8);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(442, 47);
            this.txtType.TabIndex = 23;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(16, 284);
            this.lblVolume.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(84, 39);
            this.lblVolume.TabIndex = 22;
            this.lblVolume.Text = "卷标:";
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(16, 212);
            this.lblSavePath.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(144, 39);
            this.lblSavePath.TabIndex = 21;
            this.lblSavePath.Text = "保存路径:";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(16, 140);
            this.lblFileSize.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(144, 39);
            this.lblFileSize.TabIndex = 20;
            this.lblFileSize.Text = "文件大小:";
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(16, 62);
            this.lblFileType.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(144, 39);
            this.lblFileType.TabIndex = 19;
            this.lblFileType.Text = "文件类型:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbLog);
            this.tabPage2.Controls.Add(this.gbHotkey);
            this.tabPage2.Controls.Add(this.grpProgram);
            this.tabPage2.Location = new System.Drawing.Point(10, 56);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(926, 966);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "程序设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.chkLogInfo);
            this.gbLog.Controls.Add(this.btnBroLog);
            this.gbLog.Controls.Add(this.chkLogErr);
            this.gbLog.Controls.Add(this.txtLogPath);
            this.gbLog.Controls.Add(this.lblLogPath);
            this.gbLog.Controls.Add(this.chkLog);
            this.gbLog.Location = new System.Drawing.Point(22, 11);
            this.gbLog.Margin = new System.Windows.Forms.Padding(8);
            this.gbLog.Name = "gbLog";
            this.gbLog.Padding = new System.Windows.Forms.Padding(8);
            this.gbLog.Size = new System.Drawing.Size(882, 198);
            this.gbLog.TabIndex = 16;
            this.gbLog.TabStop = false;
            // 
            // chkLogInfo
            // 
            this.chkLogInfo.AutoSize = true;
            this.chkLogInfo.Location = new System.Drawing.Point(218, 128);
            this.chkLogInfo.Margin = new System.Windows.Forms.Padding(8);
            this.chkLogInfo.Name = "chkLogInfo";
            this.chkLogInfo.Size = new System.Drawing.Size(175, 43);
            this.chkLogInfo.TabIndex = 20;
            this.chkLogInfo.Text = "记录信息";
            this.chkLogInfo.UseVisualStyleBackColor = true;
            // 
            // btnBroLog
            // 
            this.btnBroLog.Location = new System.Drawing.Point(680, 56);
            this.btnBroLog.Margin = new System.Windows.Forms.Padding(8);
            this.btnBroLog.Name = "btnBroLog";
            this.btnBroLog.Size = new System.Drawing.Size(188, 58);
            this.btnBroLog.TabIndex = 19;
            this.btnBroLog.Text = "浏览...";
            this.btnBroLog.UseVisualStyleBackColor = true;
            // 
            // chkLogErr
            // 
            this.chkLogErr.AutoSize = true;
            this.chkLogErr.Location = new System.Drawing.Point(22, 124);
            this.chkLogErr.Margin = new System.Windows.Forms.Padding(8);
            this.chkLogErr.Name = "chkLogErr";
            this.chkLogErr.Size = new System.Drawing.Size(175, 43);
            this.chkLogErr.TabIndex = 19;
            this.chkLogErr.Text = "记录错误";
            this.chkLogErr.UseVisualStyleBackColor = true;
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(232, 56);
            this.txtLogPath.Margin = new System.Windows.Forms.Padding(8);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(426, 47);
            this.txtLogPath.TabIndex = 17;
            // 
            // lblLogPath
            // 
            this.lblLogPath.AutoSize = true;
            this.lblLogPath.Location = new System.Drawing.Point(16, 62);
            this.lblLogPath.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblLogPath.Name = "lblLogPath";
            this.lblLogPath.Size = new System.Drawing.Size(84, 39);
            this.lblLogPath.TabIndex = 16;
            this.lblLogPath.Text = "路径:";
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(18, 0);
            this.chkLog.Margin = new System.Windows.Forms.Padding(8);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(175, 43);
            this.chkLog.TabIndex = 14;
            this.chkLog.Text = "写入日志";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(979, 1035);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileThief 设置";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpProgram.ResumeLayout(false);
            this.grpProgram.PerformLayout();
            this.gbHotkey.ResumeLayout(false);
            this.gbHotkey.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbDriverType.ResumeLayout(false);
            this.gbDriverType.PerformLayout();
            this.gbWhitelist.ResumeLayout(false);
            this.gbWhitelist.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbLog.ResumeLayout(false);
            this.gbLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FolderBrowserDialog fdb;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.CheckBox chkSilent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.GroupBox grpProgram;
        private System.Windows.Forms.GroupBox gbHotkey;
        private System.Windows.Forms.Label lblHotkey;
        private HotkeyControl hkcHotkey;
        private System.Windows.Forms.CheckBox chkHotkey;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbDriverType;
        private System.Windows.Forms.CheckBox chkROM;
        private System.Windows.Forms.CheckBox chkUSBHD;
        private System.Windows.Forms.CheckBox chkUSBDisk;
        private System.Windows.Forms.GroupBox gbWhitelist;
        private System.Windows.Forms.Button btnCreateWl;
        private System.Windows.Forms.TextBox txtWlDrive;
        private System.Windows.Forms.CheckBox chkWhitelist;
        private System.Windows.Forms.Button btnSelWhitelist;
        private System.Windows.Forms.Label lblWlVolume;
        private System.Windows.Forms.Label lblWhitelistTip;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.TextBox txtRegExp;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnBroSP;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbVolume;
        private System.Windows.Forms.Label lblMb;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.CheckBox chkLogInfo;
        private System.Windows.Forms.Button btnBroLog;
        private System.Windows.Forms.CheckBox chkLogErr;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label lblLogPath;
        private System.Windows.Forms.CheckBox chkLog;
    }
}