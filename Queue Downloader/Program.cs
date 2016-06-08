using System;
using System.IO;
using System.Windows.Forms;
using Syroot.Windows.IO;

namespace Crazy_Software.Downloaders.Queue_Downloader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string _applicationDataPath = Path.Combine(new KnownFolder(KnownFolderType.RoamingAppData).Path, @"Crazy Software\Queue Downloader");

            if (!Directory.Exists(_applicationDataPath))
                Directory.CreateDirectory(_applicationDataPath);

            Settings.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
