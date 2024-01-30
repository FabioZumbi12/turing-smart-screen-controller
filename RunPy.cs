using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace Turing_Smart_Screen_Controller
{
    internal static class RunPy
    {
        static string logs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tssc_logs.txt");
        static string procFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pid");
        static bool errors = false;
        internal static string Run(bool onlyKill)
        {
            string result = "";

            if (File.Exists(procFile))
            {
                try
                {
                    var procs = Process.GetProcessById(int.Parse(File.ReadAllText(procFile)));
                    procs.Kill();
                } catch { }
                File.Delete(procFile);
            }

            if (!onlyKill)
            {
                errors = false;
                File.WriteAllText(logs, result);

                try
                {
                    if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "main.py")))
                    {
                        File.AppendAllText(logs, "main.py not found!");                        
                        return "main.py not found!";
                    }

                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo("py", "main.py")
                        {
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
                        }
                    };
                    process.OutputDataReceived += (sender, args) => {
                        try { File.AppendAllText(logs, args.Data); }
                        catch { }
                    };
                    process.ErrorDataReceived += (sender, args) => {
                        var data = args.Data;
                        try { 
                            File.AppendAllText(logs, data); 
                        } 
                        catch { }
                        if (data != null && data.ToLower().Contains("exception")) {
                            errors = true;
                        }
                    };
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    File.WriteAllText(procFile, process.Id.ToString());
                }
                catch (Exception ex)
                {
                    File.AppendAllText(logs, "Error on start TSS:\n" + ex.Message);
                    result = ex.Message;
                }
            }

            return result;
        }

        internal static string RunPreReqs()
        {            
            var result = "";
            try
            {
                ProcessStartInfo infoReqs = new ProcessStartInfo("py", "-m pip install -r requirements.txt")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
                };
                using (Process proc = Process.Start(infoReqs))
                {
                    using (StreamReader reader = proc.StandardOutput)
                    {
                        File.AppendAllText(logs, reader.ReadToEnd());
                    }
                    using (StreamReader reader = proc.StandardError)
                    {
                        var err = reader.ReadToEnd();
                        File.AppendAllText(logs, reader.ReadToEnd());
                        if (err.ToLower().Contains("exception"))
                        {
                            result = "Errors on run python pre-requisites. Check logs!";
                        }
                    }
                }
            }
            catch (Exception ex) {
                File.AppendAllText(logs, ex.Message);
                result = "Errors on run python pre-requisites. Check logs!";
            }

            return result;
        }

        internal static string OpenConfig()
        {
            return OpenPy("configure.py", "");
        }

        internal static string OpenThemeEdit()
        {
            var config = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.yaml"));
            var theme = config.Where(s => s.ToLower().Trim().StartsWith("theme:")).ToList()[0].Split(':')[1].Trim();
            return OpenPy("theme-editor.py", theme);
        }

        private static string OpenPy(string file, string args)
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file)))
            {
                File.AppendAllText(logs, file + " not found!");
                return file + " not found!";
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo("py", file + " " + args)
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
                }
            };
            proc.Start();
            return "";
        }

        internal static void StopPy()
        {
            var procs = Process.GetProcessesByName("py");
            foreach (var procsInfo in procs)
            {
                procsInfo.Kill();
            }
        }

        internal static bool Running()
        {
            if (File.Exists(procFile))
            {
                try
                {
                    var proc = Process.GetProcessById(int.Parse(File.ReadAllText(procFile)));                    
                } catch {
                    File.Delete(procFile);
                    return false;
                }
            }
            return !errors;
        }

        internal static void OpenLogs()
        {
            Process.Start(logs);
        }
    }
}
