using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Turing_Smart_Screen.Net
{
    public partial class App : Form
    {
        RegistryKey appPreg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public App()
        {
            InitializeComponent();
            Icon = new Icon("icon.ico");

            if (appPreg.GetValue(Text) == null)
            {
                chkRun.Checked = false;
            }
            else
            {
                chkRun.Checked = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var procs = Process.GetProcessesByName("py");
            foreach (var procsInfo in procs)
            {
                procsInfo.Kill();
            }
            try
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo("py", "main.py")
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on start TSS:\n" + ex.Message, "Turing Smart Screen Controller");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var procs = Process.GetProcessesByName("py");
            foreach (var procsInfo in procs)
            {
                procsInfo.Kill();
            }
        }

        private void chkRun_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRun.Checked)
            {
                appPreg.SetValue(Text, Application.ExecutablePath);
            }
            else
            {
                appPreg.DeleteValue(Text, false);
            }
        }
    }
}
