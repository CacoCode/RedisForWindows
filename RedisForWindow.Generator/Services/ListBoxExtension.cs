using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MaterialSkin2DotNet;
using MaterialSkin2DotNet.Controls;

namespace RedisForWindow.Generator.Services
{
    public static class ListBoxExtension
    {
        public static void Add(this ListBox listBox, string message)
        {
            listBox.Items.Add(message);
            listBox.TopIndex = listBox.Items.Count - (int)(listBox.Height / listBox.ItemHeight);
        }
    }
}
