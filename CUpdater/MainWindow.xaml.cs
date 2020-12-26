using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace CUpdater
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WebClient webClient = new WebClient();
            var client = new WebClient();
           string[] files = Directory.GetFiles(@"C:\Users\Youcode\source\repos\Cleaner\Cleaner\bin\Release");

            foreach (string file in files)
            {
                File.Delete(file);
            }

            
            client.DownloadFile("http://download938.mediafire.com/p8tdg1el004g/2ltorpzyofipg3w/mini+logiciel.zip", @"C:\Users\Youcode\source\repos\Cleaner\Cleaner\bin\Release\Cleaner.zip");
                string zipPath = @"C:\Users\Youcode\source\repos\Cleaner\Cleaner\bin\Release\Cleaner.zip";
                string extractPath = @"C:\Users\Youcode\source\repos\Cleaner\Cleaner\bin\Release";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                File.Delete(@"C:\Users\Youcode\source\repos\Cleaner\Cleaner\bin\Release\Cleaner.zip");

            Process.Start(@"C:\Users\Youcode\source\repos\Cleaner\Cleaner\bin\Release\mini logiciel.exe");
            this.Close();
            
          
        }
    }
}
