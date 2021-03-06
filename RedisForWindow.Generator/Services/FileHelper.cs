using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin2DotNet.Controls;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace RedisForWindow.Generator.Services
{
    public class FileHelper
    {
        public static async Task Extract(string fileName, string extractDir, ListBox listBox)
        {
            await Task.Run(() =>
            {
                if (!Directory.Exists(extractDir)) Directory.CreateDirectory(extractDir);
                using (Stream stream = File.OpenRead(fileName))
                using (var reader = ReaderFactory.Open(stream))
                {
                    while (reader.MoveToNextEntry())
                    {
                        listBox.Add($"正在解压：{reader.Entry.Key}");
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
                listBox.Add("解压完成");
            });
        }

        public static async Task DeleteDir(string filepath)
        {
            try
            {
                var info = new DirectoryInfo(filepath)
                {
                    Attributes = FileAttributes.Normal & FileAttributes.Directory
                };
                File.SetAttributes(filepath, FileAttributes.Normal);
                if (Directory.Exists(filepath))
                {
                    foreach (var file in Directory.GetFileSystemEntries(filepath))
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                        else
                        {
                            await DeleteDir(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static async Task Delete(string filePath)
        {
            if(File.Exists(filePath)) File.Delete(filePath);
        }
    }
}
