using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace Turing_Smart_Screen_Controller
{
    internal static class Program
    {
        static Form form;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!IsAdministrator())
            {
                /*if (!Program.IsAdministrator())
                {
                    // Restart and run as admin
                    var exeName = Process.GetCurrentProcess().MainModule.FileName;
                    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                    startInfo.Verb = "runas";
                    startInfo.Arguments = "restart";
                    Process.Start(startInfo);
                    Application.Exit();
                }*/

                /*MessageBox.Show("This app need to run as administrator!", "Turing Smart Screen Controller");
                Application.Exit();
                Application.ExitThread();
                return;*/
            }

            var procs = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (procs.Length > 1)
            {
                RunPy.Run(true);
                foreach (var proc in procs)
                {
                    if (proc.Id != Process.GetCurrentProcess().Id)
                        proc.Kill();
                }
            }

            Application.ApplicationExit += Application_ApplicationExit;

            form = new App();
            TryIcon.InitTry(form);

            Application.Run(form);
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            RunPy.Run(true);
            TryIcon.RemoveTry();
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
