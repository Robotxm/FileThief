using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileThief
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            var verStr = Application.ProductVersion.Split('.');
            string verType="";
            switch (verStr[2][0])
            {
                case '1':
                    verType = "";
                    break;
                case '2':
                    verType = " Beta "+ verStr[2].Remove(0,1);
                    break;
                case '3':
                    verType = " Dev " + verStr[2].Remove(0, 1);
                    break;
            }
            label1.Text = "FileThief - 可移动设备文件复制工具\r\n\r\n" +
                          "版本: " + verStr[0] + "." + verStr[1] + verType + " (Build " + verStr[3] +", 内部版本 "+Application.ProductVersion+")\r\n" +
                          "Copyright © 2014-2017 MoeFactory All Rights Reserved.\r\n\r\n\r\n" +
                          "本程序仅供学习、研究交流使用，严禁用于非法用途。\r\n" +
                          "对于不正确地使用造成的任何后果，由用户负责。\r\n\r\n" +
                          "FileThief 在 GPL v3 协议下开放源代码。\r\n" +
                          "更多信息请访问 GitHub: ";
        }

        private void btnOpenSource_Click(object sender, EventArgs e)
        {
            if (rtbeOpenSource .Visible)
            {
                rtbeOpenSource.Visible = false;
                btnOpenSource.Text = "开源项目";
            }
            else
            {
                rtbeOpenSource.Visible = true;
                btnOpenSource.Text = "程序信息";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void rtbeOpenSource_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
        
    }
}
