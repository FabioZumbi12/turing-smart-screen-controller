using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Turing_Smart_Screen_Controller
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;

            var task = ProcessStart("SCHTASKS /query /tn \"Turing Smart Screen Controller\"");
            checkBox1.Checked = task.Length > 0;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                TryIcon.ShowBaloon();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunTimer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblAlerts.Text = RunPy.Run(true);
            timer.Stop();

            btnPrereq.Enabled = true;
            btnEditConfig.Enabled = true;
            btnTheme.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RunPy.StopPy();
            btnStop.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblAlerts.Text = RunPy.OpenConfig();
        }

        readonly Timer timer = new Timer();
        private void App_Shown(object sender, EventArgs e)
        {
            RunTimer();
        }

        private void RunTimer()
        {
            timer.Stop();
            lblAlerts.Text = "Running prereqs...";
            lblAlerts.Text = RunPy.Run(false);
            if (RunPy.Running())
            {
                time = 5;
                timer.Interval = 1000;
                timer.Start();

                btnPrereq.Enabled = false;
                btnEditConfig.Enabled = false;
                btnTheme.Enabled = false;
            } else
            {
                lblAlerts.Text = "Errors on running, check logs!";

                btnPrereq.Enabled = true;
                btnEditConfig.Enabled = true;
                btnTheme.Enabled = true;
            }
        }

        int time = 5;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                lblAlerts.Text = "Minimizing in " + time + "...";
                time--;
            }
            else
            {
                if (!RunPy.Running())
                {
                    lblAlerts.Text = "Errors on running, check logs!";

                    btnPrereq.Enabled = true;
                    btnEditConfig.Enabled = true;
                    btnTheme.Enabled = true;
                } else
                {
                    lblAlerts.Text = "";

                    Hide();
                    TryIcon.ShowBaloon();
                }
                timer.Stop();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RunPy.OpenLogs();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ProcessStart("SCHTASKS /create /sc ONLOGON /tn \"Turing Smart Screen Controller\" /tr %cd%\\" + AppDomain.CurrentDomain.FriendlyName + " /rl HIGHEST");
                lblAlerts.Text = "Added on Task Scheduler";
            } else
            {
                ProcessStart("SCHTASKS /delete /tn \"Turing Smart Screen Controller\" /f");
                lblAlerts.Text = "Removed from Task Scheduler";
            }
        }

        private string ProcessStart(string args)
        {
            try{
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo("cmd.exe", "/c " + args)
                    {
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true
                    }
                };
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output;
            }
            catch { }
            return "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lblAlerts.Text = RunPy.OpenThemeEdit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnRestart.Enabled = false;
            btnEditConfig.Enabled = false;
            btnTheme.Enabled = false;

            lblAlerts.Text = RunPy.RunPreReqs();

            btnRestart.Enabled = true;
            btnEditConfig.Enabled = true;
            btnTheme.Enabled = true;
            Cursor = Cursors.Default;
        }
    }
}
