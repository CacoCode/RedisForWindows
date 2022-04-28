using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedisForWindow.Generator.Services
{
    public static class MsysHelper
    {
        public static async Task CopyPacmanFile(string dir)
        {
            var targetDir = $"{dir}\\msys64\\etc\\pacman.d";
            var sourceDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "pacman");
            foreach (var f in sourceDir.GetFileSystemInfos())
            {
                var targetFileName = Path.Combine(targetDir, f.Name);
                File.Copy(f.FullName, targetFileName, true);
            }
        }

        public static async Task CopyMsysCommandFile(string tarMsysDir)
        {
            var source = $"{AppDomain.CurrentDomain.BaseDirectory}msys.bat";
            var target = $"{tarMsysDir}\\msys64\\msys.bat";
            File.Copy(source, target, true);
        }

        public static async Task InstallPackage(string arguments, string serverPath,Action call)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = $"{serverPath}\\msys2.exe",
                Arguments = arguments,
                WorkingDirectory = serverPath,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                Verb = "RunAs"
            };
            var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.AutoFlush = true;
            process.WaitForExit();
            process.Close();
            call.Invoke();
        }
    }
}
