using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Diagnostics;

namespace Cleaner
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           

            DirectoryInfo di = new DirectoryInfo("c:\\Users\\Youcode\\Desktop\\Nouveau dossier");
            FileInfo[] fiArr = di.GetFiles();
            // Display the names and sizes of the files.
             long b = 0;
            foreach (var item in fiArr)
            {
                b += item.Length;
            }

           title1.Content = $"The size of your file is: {b}";

            string line = DateTime.UtcNow.ToString("f");
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"c:\\Users\\Youcode\\Desktop\\historique\\test.txt", true))
            {
                file.WriteLine(line);
                
            }


            lbl_analyse.Content = "Analyse En Cours...";
            //MessageBox.Show("Commencer l'analyse ?");

            buttonNetoyage.Visibility = Visibility.Hidden;
            buttonHistorique.Visibility = Visibility.Hidden;
            ButtonAjour.Visibility = Visibility.Hidden;
            btnVue.Visibility = Visibility.Hidden;
            btnAnalyser.Visibility = Visibility.Hidden;
            btnHistorique.Visibility= Visibility.Hidden;
            bntOption.Visibility = Visibility.Hidden;
            title1.Visibility = Visibility.Hidden;
            title2.Visibility = Visibility.Hidden;
            title3.Visibility = Visibility.Hidden;
            buttonAnalyse.Content = "Analyse en cours";

            Progress.Visibility = Visibility.Visible;

            Thread.Sleep(1000);
            Progress.Value = 0;

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        Progress.Value = i;
                        if (i == 99)
                        {
                            lbl_analyse.Content = "Analyse terminer!";
                            //btn_analyse.IsEnabled = true;
                            buttonAnalyse.Content = "Analyser";
                            btnVue.Visibility = Visibility.Visible;
                            ButtonAjour.Visibility = Visibility.Visible;
                            buttonHistorique.Visibility = Visibility.Visible;
                            buttonNetoyage.Visibility = Visibility.Visible;
                            btnAnalyser.Visibility = Visibility.Visible;
                            btnHistorique.Visibility = Visibility.Visible;
                            bntOption.Visibility = Visibility.Visible;
                            title1.Visibility = Visibility.Visible;
                            title2.Visibility = Visibility.Visible;
                            title3.Visibility = Visibility.Hidden;
                            Progress.Visibility = Visibility.Hidden;
                        }
                    });
                }
            });
          }  
        private void buttonNetoyage_Click(object sender, RoutedEventArgs e)
        {

           
            long b = 0;
          
            
            try
                {
                    // Make a reference to a directory.
                    DirectoryInfo di = new DirectoryInfo(@"C:\\Users\\Youcode\\Desktop\\Nouveau dossier");
                    // Get a reference to each file in that directory.
                    FileInfo[] fiArr = di.GetFiles();
                    // Display the names and sizes of the files.
                    foreach (var item in fiArr)
                    {
                        item.Delete();
                    b += item.Length;
                }

                using (System.IO.StreamWriter file =
              new System.IO.StreamWriter(@"c:\\Users\\Youcode\\Desktop\\historique\\test.txt", true))
                {
                    file.WriteLine(b);

                }

                title1.Content = $" your file is delted";
                }
                catch (Exception)
                {
                    title1.Content = "your file is empty!";
                }

            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            title2.Content = $"the last analyse: {System.IO.File.ReadLines(@"c:\\Users\\Youcode\\Desktop\\historique\\test.txt").Last()}";

        }

        private void buttonAnalyser_Click(object sender, RoutedEventArgs e)
        {
            lbl_analyse.Content = "Analyse En Cours...";
        }

        private void BtnAjour_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();

            try
            {
                if (!webClient.DownloadString("https://pastebin.com/raw/2t2GK1C8").Contains("1.0"))
                {
                    if (MessageBox.Show("Looks like there is an update! Do you want to download it?", "Demo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        using (var client = new WebClient())
                        {
                            Process.Start(@"C:\Users\Youcode\source\repos\Cleaner\CUpdater\bin\Release\CUpdater.exe");
                            this.Close();
                        }
                }
            }
            catch
            {

            }
        }

        private void btnSiteweb_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is our Web Site");
        }

       
    }
}
