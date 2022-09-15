using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Turing_Smart_Screen.Net
{
    internal static class Program
    {
        static Form form;
        static NotifyIcon notifyIcon1;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("Another instance of this app is already running!", "Turing Smart Screen Controller");
                Application.Exit();
                Application.ExitThread();
                return;
            }

            Application.ApplicationExit += Application_ApplicationExit;
            form = new App();
            notifyIcon1 = new NotifyIcon
            {
                Icon = new Icon("icon.ico"),
                BalloonTipIcon = ToolTipIcon.Info,
                BalloonTipText = "Turing Smart Screen Monitor is running.\nDouble click on icon to show!",
                BalloonTipTitle = "Turing Smart Screen",
                Text = "Turing Smart Screen Controller",
                Visible = true
            };
            notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
                        
            ExecuteCommand("main.py");

            if (!args.Contains("show"))
            {
                notifyIcon1.ShowBalloonTip(5);
                Application.Run();
            }
            else
            {
                if (form.IsDisposed)
                {
                    form = new App();
                }
                Application.Run(form);
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            var procs = Process.GetProcessesByName("py");
            foreach (var procsInfo in procs)
            {
                procsInfo.Kill();
            }
            notifyIcon1.Visible = false;
        }

        private static void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (form.IsDisposed)
            {
                form = new App();
            }
            form.Show();
        }

        public static void ExecuteCommand(string command)
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
            } catch (Exception ex)
            {
                MessageBox.Show("Error on start TSS:\n" + ex.Message, "Turing Smart Screen Controller");
            }            
        }
    }
}
