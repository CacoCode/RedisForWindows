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
            Control.CheckForIllegalCrossThreadCalls = false;
            WebClient = new WebClient();
            WebClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36");
            MsysFileName = "msys2-base-x86_64-20220319";
            //MsysDownloadUri = new Uri($"https://mirrors.tuna.tsinghua.edu.cn/msys2/distrib/x86_64/{MsysFileName}.tar.xz");
            MsysDownloadUri = new Uri($"D:\\Codes\\RedisForWindow\\RedisForWindow.Generator\\msys2-base-x86_64-20220319.tar.xz");
            
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
            ExecuteWithOutputAdmin("", $"{tarMsysDir}\\msys64");
            //ExecuteWithOutputAdmin("pacman -Sy", $"{tarMsysDir}\\msys64");
            //ExecuteWithOutputAdmin("pacman -S gcc make", $"{tarMsysDir}\\msys64");

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
                        listBox1.Add($"正在解压Msys：{reader.Entry.Key}");
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

                listBox1.Add($"Msys 解压完成");
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

        public static string ExecuteWithOutputAdmin(string command,string serverpath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = $"{serverpath}\\msys2.exe";
            startInfo.WorkingDirectory = serverpath;
            startInfo.RedirectStandardInput = true;//设置输入
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.Verb = "RunAs";
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.WriteLine(command);//追加的命令这里是 bat文件运行
            process.StandardInput.WriteLine(""); //回车
            process.StandardInput.WriteLine("exit");
            process.StandardInput.AutoFlush = true;
            string strRst = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            process.Close();
            return strRst;
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
