using System;
using System.Diagnostics;

namespace UIParadigms.Modules.Proxy
{
    public class WindowsCmdProxy
    {
        private Process _cmd;

        public void StopProcess()
        {
            if (_cmd != null && !_cmd.HasExited)
                _cmd?.Kill();
        }

        private void StartProcess(string workingDirectory)
        {
            _cmd = new Process
            {
                StartInfo =
                {
                    FileName="cmd.exe",
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = string.IsNullOrEmpty(workingDirectory)
                        ? AppDomain.CurrentDomain.BaseDirectory : workingDirectory
        }
            };

            _cmd.Start();
        }

        public string ExecuteCommand(string command, string workingDirectory = null)
        {
            StartProcess(workingDirectory);

            _cmd.StandardInput.WriteLine(command);
            _cmd.StandardInput.Close();

            var output = _cmd.StandardOutput.ReadToEnd();

            StopProcess();

            return output;
        }
    }
}
