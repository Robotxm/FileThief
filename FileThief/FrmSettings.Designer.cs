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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbVolume = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegExp = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.chkLogInfo = new System.Windows.Forms.CheckBox();
            this.btnBroLog = new System.Windows.Forms.Button();
            this.chkLogErr = new System.Windows.Forms.CheckBox();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBroSP = new System.Windows.Forms.Button();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.chkSilent = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.fdb = new System.Windows.Forms.FolderBrowserDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.gbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件类型:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "文件大小:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "保存路径:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "卷标:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(205, 12);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(163, 23);
            this.txtType.TabIndex = 4;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(205, 41);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(129, 23);
            this.txtSize.TabIndex = 5;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(108, 72);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(179, 23);
            this.txtPath.TabIndex = 6;
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(205, 101);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(163, 23);
            this.txtLabel.TabIndex = 7;
            // 
            // cbSize
            // 
            this.cbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Items.AddRange(new object[] {
            "小于",
            "大于"});
            this.cbSize.Location = new System.Drawing.Point(108, 41);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(91, 25);
            this.cbSize.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "MB";
            // 
            // cbVolume
            // 
            this.cbVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVolume.FormattingEnabled = true;
            this.cbVolume.Items.AddRange(new object[] {
            "包含",
            "排除"});
            this.cbVolume.Location = new System.Drawing.Point(108, 101);
            this.cbVolume.Name = "cbVolume";
            this.cbVolume.Size = new System.Drawing.Size(91, 25);
            this.cbVolume.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "文件名规则 (正则表达式):";
            // 
            // txtRegExp
            // 
            this.txtRegExp.Location = new System.Drawing.Point(15, 153);
            this.txtRegExp.Name = "txtRegExp";
            this.txtRegExp.Size = new System.Drawing.Size(353, 23);
            this.txtRegExp.TabIndex = 12;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "包含",
            "排除"});
            this.cbType.Location = new System.Drawing.Point(108, 10);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(91, 25);
            this.cbType.TabIndex = 13;
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
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.chkLogInfo);
            this.gbLog.Controls.Add(this.btnBroLog);
            this.gbLog.Controls.Add(this.chkLogErr);
            this.gbLog.Controls.Add(this.txtLogPath);
            this.gbLog.Controls.Add(this.label7);
            this.gbLog.Controls.Add(this.chkLog);
            this.gbLog.Location = new System.Drawing.Point(15, 182);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(353, 79);
            this.gbLog.TabIndex = 15;
            this.gbLog.TabStop = false;
            // 
            // chkLogInfo
            // 
            this.chkLogInfo.AutoSize = true;
            this.chkLogInfo.Location = new System.Drawing.Point(69, 51);
            this.chkLogInfo.Name = "chkLogInfo";
            this.chkLogInfo.Size = new System.Drawing.Size(51, 21);
            this.chkLogInfo.TabIndex = 20;
            this.chkLogInfo.Text = "信息";
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
            this.chkLogErr.Location = new System.Drawing.Point(6, 51);
            this.chkLogErr.Name = "chkLogErr";
            this.chkLogErr.Size = new System.Drawing.Size(51, 21);
            this.chkLogErr.TabIndex = 19;
            this.chkLogErr.Text = "错误";
            this.chkLogErr.UseVisualStyleBackColor = true;
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(93, 22);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(173, 23);
            this.txtLogPath.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "路径:";
            // 
            // btnBroSP
            // 
            this.btnBroSP.Location = new System.Drawing.Point(293, 72);
            this.btnBroSP.Name = "btnBroSP";
            this.btnBroSP.Size = new System.Drawing.Size(75, 23);
            this.btnBroSP.TabIndex = 18;
            this.btnBroSP.Text = "浏览...";
            this.btnBroSP.UseVisualStyleBackColor = true;
            this.btnBroSP.Click += new System.EventHandler(this.btnBroSP_Click);
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(15, 267);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(75, 21);
            this.chkAutoRun.TabIndex = 19;
            this.chkAutoRun.Text = "开机运行";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            // 
            // chkSilent
            // 
            this.chkSilent.AutoSize = true;
            this.chkSilent.Location = new System.Drawing.Point(15, 294);
            this.chkSilent.Name = "chkSilent";
            this.chkSilent.Size = new System.Drawing.Size(75, 21);
            this.chkSilent.TabIndex = 20;
            this.chkSilent.Text = "静默模式";
            this.chkSilent.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(293, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(212, 321);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 22;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "鼠标移至项目上可查看说明";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 357);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkSilent);
            this.Controls.Add(this.chkAutoRun);
            this.Controls.Add(this.btnBroSP);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.txtRegExp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbVolume);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cbVolume;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRegExp;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.CheckBox chkLogInfo;
        private System.Windows.Forms.Button btnBroLog;
        private System.Windows.Forms.CheckBox chkLogErr;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FolderBrowserDialog fdb;
        private System.Windows.Forms.Button btnBroSP;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.CheckBox chkSilent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}