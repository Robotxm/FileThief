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
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.chkLogInfo = new System.Windows.Forms.CheckBox();
            this.btnBroLog = new System.Windows.Forms.Button();
            this.chkLogErr = new System.Windows.Forms.CheckBox();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.lblLogPath = new System.Windows.Forms.Label();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.chkSilent = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.fdb = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTip = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.gbDriverType = new System.Windows.Forms.GroupBox();
            this.chkROM = new System.Windows.Forms.CheckBox();
            this.chkUSBHD = new System.Windows.Forms.CheckBox();
            this.chkUSBDisk = new System.Windows.Forms.CheckBox();
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
            this.grpProgram = new System.Windows.Forms.GroupBox();
            this.gbWhitelist = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkWhitelist = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblWlVolume = new System.Windows.Forms.Label();
            this.lblWhitelistTip = new System.Windows.Forms.Label();
            this.gbHotkey = new System.Windows.Forms.GroupBox();
            this.chkHotkey = new System.Windows.Forms.CheckBox();
            this.hotkeyControl1 = new FileThief.HotkeyControl();
            this.lblHotkey = new System.Windows.Forms.Label();
            this.gbCopyTo = new System.Windows.Forms.GroupBox();
            this.chkCopyTo = new System.Windows.Forms.CheckBox();
            this.gbLog.SuspendLayout();
            this.gbDriverType.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpProgram.SuspendLayout();
            this.gbWhitelist.SuspendLayout();
            this.gbHotkey.SuspendLayout();
            this.gbCopyTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(7, 0);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(75, 21);
            this.chkLog.TabIndex = 14;
            this.chkLog.Text = "写入日志";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.chkLogInfo);
            this.gbLog.Controls.Add(this.btnBroLog);
            this.gbLog.Controls.Add(this.chkLogErr);
            this.gbLog.Controls.Add(this.txtLogPath);
            this.gbLog.Controls.Add(this.lblLogPath);
            this.gbLog.Controls.Add(this.chkLog);
            this.gbLog.Location = new System.Drawing.Point(374, 12);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(353, 79);
            this.gbLog.TabIndex = 15;
            this.gbLog.TabStop = false;
            // 
            // chkLogInfo
            // 
            this.chkLogInfo.AutoSize = true;
            this.chkLogInfo.Location = new System.Drawing.Point(87, 51);
            this.chkLogInfo.Name = "chkLogInfo";
            this.chkLogInfo.Size = new System.Drawing.Size(75, 21);
            this.chkLogInfo.TabIndex = 20;
            this.chkLogInfo.Text = "记录信息";
            this.chkLogInfo.UseVisualStyleBackColor = true;
            // 
            // btnBroLog
            // 
            this.btnBroLog.Location = new System.Drawing.Point(272, 22);
            this.btnBroLog.Name = "btnBroLog";
            this.btnBroLog.Size = new System.Drawing.Size(75, 23);
            this.btnBroLog.TabIndex = 19;
            this.btnBroLog.Text = "浏览...";
            this.btnBroLog.UseVisualStyleBackColor = true;
            this.btnBroLog.Click += new System.EventHandler(this.btnBroLog_Click);
            // 
            // chkLogErr
            // 
            this.chkLogErr.AutoSize = true;
            this.chkLogErr.Location = new System.Drawing.Point(9, 50);
            this.chkLogErr.Name = "chkLogErr";
            this.chkLogErr.Size = new System.Drawing.Size(75, 21);
            this.chkLogErr.TabIndex = 19;
            this.chkLogErr.Text = "记录错误";
            this.chkLogErr.UseVisualStyleBackColor = true;
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(93, 22);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(173, 23);
            this.txtLogPath.TabIndex = 17;
            // 
            // lblLogPath
            // 
            this.lblLogPath.AutoSize = true;
            this.lblLogPath.Location = new System.Drawing.Point(6, 25);
            this.lblLogPath.Name = "lblLogPath";
            this.lblLogPath.Size = new System.Drawing.Size(35, 17);
            this.lblLogPath.TabIndex = 16;
            this.lblLogPath.Text = "路径:";
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(9, 21);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(75, 21);
            this.chkAutoRun.TabIndex = 19;
            this.chkAutoRun.Text = "开机运行";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            // 
            // chkSilent
            // 
            this.chkSilent.AutoSize = true;
            this.chkSilent.Location = new System.Drawing.Point(93, 21);
            this.chkSilent.Name = "chkSilent";
            this.chkSilent.Size = new System.Drawing.Size(75, 21);
            this.chkSilent.TabIndex = 20;
            this.chkSilent.Text = "静默模式";
            this.chkSilent.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(653, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(572, 270);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 22;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(414, 273);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(152, 17);
            this.lblTip.TabIndex = 23;
            this.lblTip.Text = "鼠标移至项目上可查看说明";
            // 
            // gbDriverType
            // 
            this.gbDriverType.Controls.Add(this.chkROM);
            this.gbDriverType.Controls.Add(this.chkUSBHD);
            this.gbDriverType.Controls.Add(this.chkUSBDisk);
            this.gbDriverType.Location = new System.Drawing.Point(374, 97);
            this.gbDriverType.Name = "gbDriverType";
            this.gbDriverType.Size = new System.Drawing.Size(353, 50);
            this.gbDriverType.TabIndex = 24;
            this.gbDriverType.TabStop = false;
            this.gbDriverType.Text = "可移动设备类型";
            // 
            // chkROM
            // 
            this.chkROM.AutoSize = true;
            this.chkROM.Location = new System.Drawing.Point(191, 22);
            this.chkROM.Name = "chkROM";
            this.chkROM.Size = new System.Drawing.Size(144, 21);
            this.chkROM.TabIndex = 2;
            this.chkROM.Text = "光盘 (包括挂载的ISO)";
            this.chkROM.UseVisualStyleBackColor = true;
            // 
            // chkUSBHD
            // 
            this.chkUSBHD.AutoSize = true;
            this.chkUSBHD.Location = new System.Drawing.Point(106, 22);
            this.chkUSBHD.Name = "chkUSBHD";
            this.chkUSBHD.Size = new System.Drawing.Size(79, 21);
            this.chkUSBHD.TabIndex = 1;
            this.chkUSBHD.Text = "USB 硬盘";
            this.chkUSBHD.UseVisualStyleBackColor = true;
            // 
            // chkUSBDisk
            // 
            this.chkUSBDisk.AutoSize = true;
            this.chkUSBDisk.Location = new System.Drawing.Point(9, 22);
            this.chkUSBDisk.Name = "chkUSBDisk";
            this.chkUSBDisk.Size = new System.Drawing.Size(91, 21);
            this.chkUSBDisk.TabIndex = 0;
            this.chkUSBDisk.Text = "USB 闪存盘";
            this.chkUSBDisk.UseVisualStyleBackColor = true;
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
            this.grpFilter.Location = new System.Drawing.Point(15, 12);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(353, 189);
            this.grpFilter.TabIndex = 25;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "过滤选项";
            // 
            // txtRegExp
            // 
            this.txtRegExp.Location = new System.Drawing.Point(9, 156);
            this.txtRegExp.Name = "txtRegExp";
            this.txtRegExp.Size = new System.Drawing.Size(338, 23);
            this.txtRegExp.TabIndex = 33;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 136);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(143, 17);
            this.lblFileName.TabIndex = 32;
            this.lblFileName.Text = "文件名规则 (正则表达式):";
            // 
            // btnBroSP
            // 
            this.btnBroSP.Location = new System.Drawing.Point(272, 79);
            this.btnBroSP.Name = "btnBroSP";
            this.btnBroSP.Size = new System.Drawing.Size(75, 23);
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
            this.cbType.Location = new System.Drawing.Point(71, 17);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(91, 25);
            this.cbType.TabIndex = 30;
            // 
            // cbVolume
            // 
            this.cbVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVolume.FormattingEnabled = true;
            this.cbVolume.Items.AddRange(new object[] {
            "包含",
            "排除"});
            this.cbVolume.Location = new System.Drawing.Point(71, 108);
            this.cbVolume.Name = "cbVolume";
            this.cbVolume.Size = new System.Drawing.Size(91, 25);
            this.cbVolume.TabIndex = 29;
            // 
            // lblMb
            // 
            this.lblMb.AutoSize = true;
            this.lblMb.Location = new System.Drawing.Point(319, 51);
            this.lblMb.Name = "lblMb";
            this.lblMb.Size = new System.Drawing.Size(28, 17);
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
            this.cbSize.Location = new System.Drawing.Point(71, 48);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(91, 25);
            this.cbSize.TabIndex = 27;
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(168, 108);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(179, 23);
            this.txtLabel.TabIndex = 26;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(71, 79);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(195, 23);
            this.txtPath.TabIndex = 25;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(168, 48);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(145, 23);
            this.txtSize.TabIndex = 24;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(168, 19);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(179, 23);
            this.txtType.TabIndex = 23;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(6, 114);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(35, 17);
            this.lblVolume.TabIndex = 22;
            this.lblVolume.Text = "卷标:";
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(6, 85);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(59, 17);
            this.lblSavePath.TabIndex = 21;
            this.lblSavePath.Text = "保存路径:";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(6, 56);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(59, 17);
            this.lblFileSize.TabIndex = 20;
            this.lblFileSize.Text = "文件大小:";
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(6, 25);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(59, 17);
            this.lblFileType.TabIndex = 19;
            this.lblFileType.Text = "文件类型:";
            // 
            // grpProgram
            // 
            this.grpProgram.Controls.Add(this.chkAutoRun);
            this.grpProgram.Controls.Add(this.chkSilent);
            this.grpProgram.Location = new System.Drawing.Point(374, 153);
            this.grpProgram.Name = "grpProgram";
            this.grpProgram.Size = new System.Drawing.Size(353, 48);
            this.grpProgram.TabIndex = 26;
            this.grpProgram.TabStop = false;
            this.grpProgram.Text = "程序设置";
            // 
            // gbWhitelist
            // 
            this.gbWhitelist.Controls.Add(this.textBox1);
            this.gbWhitelist.Controls.Add(this.chkWhitelist);
            this.gbWhitelist.Controls.Add(this.button1);
            this.gbWhitelist.Controls.Add(this.lblWlVolume);
            this.gbWhitelist.Controls.Add(this.lblWhitelistTip);
            this.gbWhitelist.Location = new System.Drawing.Point(15, 208);
            this.gbWhitelist.Name = "gbWhitelist";
            this.gbWhitelist.Size = new System.Drawing.Size(353, 56);
            this.gbWhitelist.TabIndex = 27;
            this.gbWhitelist.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(102, 23);
            this.textBox1.TabIndex = 5;
            // 
            // chkWhitelist
            // 
            this.chkWhitelist.AutoSize = true;
            this.chkWhitelist.Location = new System.Drawing.Point(9, 0);
            this.chkWhitelist.Name = "chkWhitelist";
            this.chkWhitelist.Size = new System.Drawing.Size(111, 21);
            this.chkWhitelist.TabIndex = 4;
            this.chkWhitelist.Text = "启用设备白名单";
            this.chkWhitelist.UseVisualStyleBackColor = true;
            this.chkWhitelist.CheckedChanged += new System.EventHandler(this.chkWhitelist_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "选择设备...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblWlVolume
            // 
            this.lblWlVolume.AutoSize = true;
            this.lblWlVolume.Location = new System.Drawing.Point(6, 28);
            this.lblWlVolume.Name = "lblWlVolume";
            this.lblWlVolume.Size = new System.Drawing.Size(35, 17);
            this.lblWlVolume.TabIndex = 1;
            this.lblWlVolume.Text = "设备:";
            // 
            // lblWhitelistTip
            // 
            this.lblWhitelistTip.AutoSize = true;
            this.lblWhitelistTip.Location = new System.Drawing.Point(6, 19);
            this.lblWhitelistTip.Name = "lblWhitelistTip";
            this.lblWhitelistTip.Size = new System.Drawing.Size(0, 17);
            this.lblWhitelistTip.TabIndex = 0;
            // 
            // gbHotkey
            // 
            this.gbHotkey.Controls.Add(this.chkHotkey);
            this.gbHotkey.Controls.Add(this.hotkeyControl1);
            this.gbHotkey.Controls.Add(this.lblHotkey);
            this.gbHotkey.Location = new System.Drawing.Point(374, 208);
            this.gbHotkey.Name = "gbHotkey";
            this.gbHotkey.Size = new System.Drawing.Size(353, 56);
            this.gbHotkey.TabIndex = 28;
            this.gbHotkey.TabStop = false;
            // 
            // chkHotkey
            // 
            this.chkHotkey.AutoSize = true;
            this.chkHotkey.Location = new System.Drawing.Point(9, 1);
            this.chkHotkey.Name = "chkHotkey";
            this.chkHotkey.Size = new System.Drawing.Size(75, 21);
            this.chkHotkey.TabIndex = 2;
            this.chkHotkey.Text = "启用热键";
            this.chkHotkey.UseVisualStyleBackColor = true;
            this.chkHotkey.CheckedChanged += new System.EventHandler(this.chkHotkey_CheckedChanged);
            // 
            // hotkeyControl1
            // 
            this.hotkeyControl1.Hotkey = System.Windows.Forms.Keys.None;
            this.hotkeyControl1.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.hotkeyControl1.Location = new System.Drawing.Point(47, 22);
            this.hotkeyControl1.Name = "hotkeyControl1";
            this.hotkeyControl1.Size = new System.Drawing.Size(100, 23);
            this.hotkeyControl1.TabIndex = 1;
            this.hotkeyControl1.Text = "None";
            // 
            // lblHotkey
            // 
            this.lblHotkey.AutoSize = true;
            this.lblHotkey.Location = new System.Drawing.Point(6, 25);
            this.lblHotkey.Name = "lblHotkey";
            this.lblHotkey.Size = new System.Drawing.Size(35, 17);
            this.lblHotkey.TabIndex = 0;
            this.lblHotkey.Text = "热键:";
            // 
            // gbCopyTo
            // 
            this.gbCopyTo.Controls.Add(this.chkCopyTo);
            this.gbCopyTo.Location = new System.Drawing.Point(15, 270);
            this.gbCopyTo.Name = "gbCopyTo";
            this.gbCopyTo.Size = new System.Drawing.Size(353, 100);
            this.gbCopyTo.TabIndex = 29;
            this.gbCopyTo.TabStop = false;
            // 
            // chkCopyTo
            // 
            this.chkCopyTo.AutoSize = true;
            this.chkCopyTo.Location = new System.Drawing.Point(9, 0);
            this.chkCopyTo.Name = "chkCopyTo";
            this.chkCopyTo.Size = new System.Drawing.Size(183, 21);
            this.chkCopyTo.TabIndex = 0;
            this.chkCopyTo.Text = "将复制的文件保存到指定设备";
            this.chkCopyTo.UseVisualStyleBackColor = true;
            this.chkCopyTo.CheckedChanged += new System.EventHandler(this.chkCopyTo_CheckedChanged);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(740, 379);
            this.Controls.Add(this.gbCopyTo);
            this.Controls.Add(this.gbHotkey);
            this.Controls.Add(this.gbWhitelist);
            this.Controls.Add(this.grpProgram);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.gbDriverType);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbLog);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileThief 设置";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.gbLog.ResumeLayout(false);
            this.gbLog.PerformLayout();
            this.gbDriverType.ResumeLayout(false);
            this.gbDriverType.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpProgram.ResumeLayout(false);
            this.grpProgram.PerformLayout();
            this.gbWhitelist.ResumeLayout(false);
            this.gbWhitelist.PerformLayout();
            this.gbHotkey.ResumeLayout(false);
            this.gbHotkey.PerformLayout();
            this.gbCopyTo.ResumeLayout(false);
            this.gbCopyTo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.CheckBox chkLogInfo;
        private System.Windows.Forms.Button btnBroLog;
        private System.Windows.Forms.CheckBox chkLogErr;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label lblLogPath;
        private System.Windows.Forms.FolderBrowserDialog fdb;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.CheckBox chkSilent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.GroupBox gbDriverType;
        private System.Windows.Forms.CheckBox chkROM;
        private System.Windows.Forms.CheckBox chkUSBHD;
        private System.Windows.Forms.CheckBox chkUSBDisk;
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
        private System.Windows.Forms.GroupBox grpProgram;
        private System.Windows.Forms.GroupBox gbWhitelist;
        private System.Windows.Forms.Label lblWhitelistTip;
        private System.Windows.Forms.CheckBox chkWhitelist;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblWlVolume;
        private System.Windows.Forms.GroupBox gbHotkey;
        private System.Windows.Forms.Label lblHotkey;
        private HotkeyControl hotkeyControl1;
        private System.Windows.Forms.CheckBox chkHotkey;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbCopyTo;
        private System.Windows.Forms.CheckBox chkCopyTo;
    }
}