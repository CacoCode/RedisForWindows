using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MaterialSkin2DotNet.Controls;
using RedisForWindow.Generator.Services;

namespace RedisForWindow.Generator
{
    public partial class Index : MaterialForm
    {
        public WebClient WebClient;

        public string MsysFileName;

        public Uri MsysDownloadUri;

        public Index()
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
                installMsysBtn.Text = "Msys已安装，配置以下信息进行生成";
            }
            else
            {
                installMsysBtn.Enabled = true;
                installMsysBtn.Text = "请点击安装Msys，再进行以下操作";
            }
        }

        private async void installMsysBtn_Click(object sender, EventArgs e)
        {
            DownloadMsysFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var path = new FolderBrowserDialog();
            path.ShowDialog();
            textBox2.Text = path.SelectedPath;
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

        private async void DownloadMsysFile()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Temp"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp");
            var path = AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + $"{MsysFileName}.tar.xz";
            WebClient.DownloadProgressChanged += (sender, e) =>
            {
                listBox1.Items.Clear();
                listBox1.Add($"正在下载Msys：{e.ProgressPercentage} %");
            };
            WebClient.DownloadFileCompleted += DownloadFileCompleted;
            WebClient.DownloadFileAsync(MsysDownloadUri, path);
        }

        private async void DownloadRedisFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            listBox1.Add($"Redis_{textBox1.Text} 下载完成");
            var zipFileName = AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + $"{textBox1.Text}.zip";
            var tarDir = AppDomain.CurrentDomain.BaseDirectory + "Temp";
            await FileHelper.Extract(zipFileName, tarDir,listBox1);
            var redisDir = $"{tarDir}\\redis-{textBox1.Text}";
            var disk = redisDir.First().ToString();
            redisDir = redisDir.Replace($"{disk}:", $"/{disk.ToLower()}").Replace("\\", "/");
            var sourceDisk = textBox2.Text.First().ToString();
            var sourceDir = textBox2.Text.Replace($"{sourceDisk}:", $"/{sourceDisk.ToLower()}").Replace("\\", "/");
            await RedisHelper.CopyDlfcnFile(tarDir);
            await RedisHelper.CopyMsysRedisCommandFile(tarDir);
            await RedisHelper.CopyRedisConfigFile(textBox1.Text, textBox2.Text);
            await RedisHelper.GeneratorRedis($"/msys_redis.bat {redisDir} {sourceDir}", $"{tarDir}\\msys64", () =>
            {
                listBox1.Add("等待安装窗口关闭，请勿进行其他操作，无报错信息则生成成功");
                Process.Start("explorer.exe", textBox2.Text);
                if (File.Exists(zipFileName)) File.Delete(zipFileName);
            });
        }

        private async void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            listBox1.Add("Msys 下载完成");
            var sourceZipFile = AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + $"{MsysFileName}.tar.xz";
            var targetDir = AppDomain.CurrentDomain.BaseDirectory + "Temp";
            await FileHelper.Extract(sourceZipFile, targetDir, listBox1);
            await MsysHelper.CopyPacmanFile(targetDir);
            await MsysHelper.CopyMsysCommandFile(targetDir);
            await MsysHelper.InstallPackage("/msys.bat", $"{targetDir}\\msys64", () =>
            {
                listBox1.Add("等待安装窗口关闭，请勿进行其他操作，无报错信息则安装成功");
                installMsysBtn.Enabled = false;
                installMsysBtn.Text = "Msys已安装，配置以下信息进行生成";
                if (File.Exists(sourceZipFile)) File.Delete(sourceZipFile);
            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer","https://github.com/redis/redis/tags");
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            //await FileHelper.Delete(AppDomain.CurrentDomain.BaseDirectory + "Temp\\msys64\\msys2.exe");
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Temp");
            if (directory.Exists)
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp", Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
            }
        }
    }

    public static class ListBoxEx
    {
        public static void Add(this ListBox listBox, string message)
        {
            listBox.Items.Add(message);
            listBox.TopIndex = listBox.Items.Count - (int)(listBox.Height / listBox.ItemHeight);
        }
    }

}
