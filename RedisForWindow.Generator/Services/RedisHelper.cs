using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedisForWindow.Generator.Services
{
    public static class RedisHelper
    {
        public static async Task CopyDlfcnFile(string tarDir)
        {
            var source = $"{AppDomain.CurrentDomain.BaseDirectory}dlfcn.h";
            var target = $"{tarDir}\\msys64\\usr\\include\\dlfcn.h";
            File.Copy(source, target, true);
        }

        public static async Task CopyMsysRedisCommandFile(string tarDir)
        {
            var source = $"{AppDomain.CurrentDomain.BaseDirectory}msys_redis.bat";
            var target = $"{tarDir}\\msys64\\msys_redis.bat";
            File.Copy(source, target, true);
        }

        public static async Task CopyRedisConfigFile(string sourceDir,string targetDir)
        {
            var redisConf = $"{AppDomain.CurrentDomain.BaseDirectory}Temp\\redis-{sourceDir}\\redis.conf";
            var sentinelConf = $"{AppDomain.CurrentDomain.BaseDirectory}Temp\\redis-{sourceDir}\\sentinel.conf";
            var msysDll = $"{AppDomain.CurrentDomain.BaseDirectory}msys-2.0.dll";
            if (!Directory.Exists($"{targetDir}\\bin")) Directory.CreateDirectory($"{targetDir}\\bin");
            var redisConfTarget = $"{targetDir}\\bin\\redis.conf";
            var sentinelConfTarget = $"{targetDir}\\bin\\sentinel.conf";
            var msysDllTarget = $"{targetDir}\\bin\\msys-2.0.dll";
            File.Copy(redisConf, redisConfTarget, true);
            File.Copy(sentinelConf, sentinelConfTarget, true);
            File.Copy(msysDll, msysDllTarget, true);
        }

        public static async Task GeneratorRedis(string arguments, string serverPath,Action call)
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
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.AutoFlush = true;
            process.WaitForExit();
            process.Close();
            call.Invoke();
        }
    }
}
