using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using SharpCompress.Common;
using SharpCompress.Readers;
using LibGit2Sharp;

namespace RedisForWindow.Generator
{
    public partial class Form1 : Form
    {
        public WebClient WebClient;

        public string MsysFileName;

        public Uri MsysDownloadUri;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            WebClient = new WebClient();
            WebClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36");
            MsysFileName = "msys2-base-x86_64-20220319";
            //MsysDownloadUri = new Uri($"https://mirrors.tuna.tsinghua.edu.cn/msys2/distrib/x86_64/{MsysFileName}.tar.xz");
            MsysDownloadUri = new Uri($"{AppDomain.CurrentDomain.BaseDirectory}msys2-base-x86_64-20220319.tar.xz");
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}Temp\\msys64\\msys2.exe"))
            {
                installMsysBtn.Enabled = false;
                installMsysBtn.Text = "Msys已安装";
            }
            else {
                installMsysBtn.Enabled = true;
                installMsysBtn.Text = "请安装Msys";
            }
        }

        private async void installMsysBtn_Click(object sender, EventArgs e)
        {
            DownloadMsysFile();
        }

        private async void DownloadMsysFile()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory+ "Temp\\" + $"{MsysFileName}.tar.xz";
            WebClient.DownloadProgressChanged += (sender, e) =>
            {
                listBox1.Items.Clear();
                listBox1.Add($"正在下载Msys：{e.ProgressPercentage} %");
            };
            WebClient.DownloadFileCompleted += DownloadFileCompleted;
            WebClient.DownloadFileAsync(MsysDownloadUri, path);
        }

        private async void DownloadFileCompleted(object sender,AsyncCompletedEventArgs e)
        {
            listBox1.Add("Msys 下载完成");
            var zipMsysFileName = AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + $"{MsysFileName}.tar.xz";
            var tarMsysDir = AppDomain.CurrentDomain.BaseDirectory + "Temp";
            await Extract(zipMsysFileName, tarMsysDir);
            await CopyPacmanFile(tarMsysDir);
            await CopyMsysFile(tarMsysDir);
            InstallGCC_MAKE("/msys.bat", $"{tarMsysDir}\\msys64");
        }

        private async Task Extract(string fileName,string extractDir)
        {
            await Task.Run(() =>
            {
                if (!Directory.Exists(extractDir)) Directory.CreateDirectory(extractDir);
                using (Stream stream = File.OpenRead(fileName))
                using (var reader = ReaderFactory.Open(stream))
                {
                    while (reader.MoveToNextEntry())
                    {
                        listBox1.Add($"正在解压：{reader.Entry.Key}");
                        if (!reader.Entry.IsDirectory)
                        {
                            Console.WriteLine(reader.Entry.Key);
                            reader.WriteEntryToDirectory(extractDir, new ExtractionOptions()
                            {
                                ExtractFullPath = true,
                                Overwrite = true
                            });
                        }
                    }
                }
                listBox1.Add($"解压完成");
            });

        }

        private async Task CopyPacmanFile(string tarMsysDir)
        {
            var dir = $"{tarMsysDir}\\msys64\\etc\\pacman.d";
            var dinfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "pacman");
            foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
            {
                var destName = Path.Combine(dir, f.Name);
                File.Copy(f.FullName, destName, true);
            }
        }

        private async Task CopyMsysFile(string tarMsysDir)
        {
            var bat = $"{AppDomain.CurrentDomain.BaseDirectory}msys.bat";
            var dest = $"{tarMsysDir}\\msys64\\msys.bat";
            File.Copy(bat, dest, true);
        }

        private async Task InstallGCC_MAKE(string arguments, string serverpath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = $"{serverpath}\\msys2.exe";
            startInfo.Arguments = arguments;
            startInfo.WorkingDirectory = serverpath;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.Verb = "RunAs";
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.AutoFlush = true;
            process.WaitForExit();
            process.Close();
            listBox1.Add($"安装gcc完成");
            listBox1.Add($"安装make完成");
            installMsysBtn.Enabled = false;
            installMsysBtn.Text = "Msys已安装";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadRedisFile();
        }

        private async void DownloadRedisFile()
        {
            if (string.IsNullOrEmpty(textBox1.Text)) MessageBox.Show("请输入Redis 版本");
            var path = AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + $"{textBox1.Text}.zip";
            WebClient.DownloadProgressChanged += (sender, e) =>
            {
                listBox1.Items.Clear();
                listBox1.Add($"正在下载Redis_{textBox1.Text}：{e.ProgressPercentage} %");
            };
            WebClient.DownloadFileCompleted -= DownloadFileCompleted;
            WebClient.DownloadFileCompleted += DownloadRedisFileCompleted;
            WebClient.DownloadFileAsync(new Uri($"https://github.com/redis/redis/archive/refs/tags/{textBox1.Text}.zip"), path);
        }

        private async void DownloadRedisFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            listBox1.Add($"Redis_{textBox1.Text} 下载完成");
            var zipFileName = AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + $"{textBox1.Text}.zip";
            var tarDir = AppDomain.CurrentDomain.BaseDirectory + "Temp";
            await Extract(zipFileName, tarDir);
            var redisDir = $"{tarDir}\\redis-{textBox1.Text}";
            var disk = redisDir.First().ToString();
            redisDir = redisDir.Replace($"{disk}:", $"/{disk.ToLower()}").Replace("\\", "/");
            var sourceDisk = textBox2.Text.First().ToString();
            var sourceDir = textBox2.Text.Replace($"{sourceDisk}:", $"/{sourceDisk.ToLower()}").Replace("\\", "/");
            await CopyDlfcnFile(tarDir);
            await CopyMsysRedisFile(tarDir);
            await CopyRedisConfigFile();
            GeneratorRedis($"/msys_redis.bat {redisDir} {sourceDir}", $"{tarDir}\\msys64");
        }

        private async Task CopyDlfcnFile(string tarDir)
        {
            var bat = $"{AppDomain.CurrentDomain.BaseDirectory}dlfcn.h";
            var dest = $"{tarDir}\\msys64\\usr\\include\\dlfcn.h";
            File.Copy(bat, dest, true);
        }

        private async Task CopyMsysRedisFile(string tarDir)
        {
            var bat = $"{AppDomain.CurrentDomain.BaseDirectory}msys_redis.bat";
            var dest = $"{tarDir}\\msys64\\msys_redis.bat";
            File.Copy(bat, dest, true);
        }

        private async Task CopyRedisConfigFile()
        {
            var redisConf = $"{AppDomain.CurrentDomain.BaseDirectory}Temp\\redis-{textBox1.Text}\\redis.conf";
            var sentinelConf = $"{AppDomain.CurrentDomain.BaseDirectory}Temp\\redis-{textBox1.Text}\\sentinel.conf";
            if(!Directory.Exists($"{textBox2.Text}\\bin")) Directory.CreateDirectory($"{textBox2.Text}\\bin");
            var redisConfDest = $"{textBox2.Text}\\bin\\redis.conf";
            var sentinelConfDest = $"{textBox2.Text}\\bin\\sentinel.conf";
            File.Copy(redisConf, redisConfDest, true);
            File.Copy(sentinelConf, sentinelConfDest, true);
        }

        private async Task GeneratorRedis(string arguments, string serverpath)
        {
            listBox1.Add($"Window Redis 正在生成");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = $"{serverpath}\\msys2.exe";
            startInfo.Arguments = arguments;
            startInfo.WorkingDirectory = serverpath;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.Verb = "RunAs";
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.AutoFlush = true;
            process.WaitForExit();
            process.Close();
            listBox1.Add($"Window Redis 生成成功");
            Process.Start("explorer.exe", textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            textBox2.Text = path.SelectedPath;
        }
    }

    public static class ListBoxEx
    {
        public static void Add(this ListBox listBox,string message)
        {
            listBox.Items.Add(message);
            listBox.TopIndex = listBox.Items.Count - (int)(listBox.Height / listBox.ItemHeight);
        }
    }

}
