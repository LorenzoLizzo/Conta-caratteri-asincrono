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
using System.Threading;
using System.IO;

namespace Conta_caratteri_asincorno
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r;
        int caratteriContati = 0;
        public MainWindow()
        {
            InitializeComponent();
            r = new Random();
            ContaCaratteri();
        }

        private async void ContaCaratteri()
        {
            await Task.Run(() =>
            {
                using (StreamReader sr = new StreamReader("Data.txt"))
                {
                    string file = sr.ReadToEnd();
                    int tmp = 0;
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        progressBar.Maximum = file.Length;
                    }));
                    while (caratteriContati < file.Length)
                    {
                        Thread.Sleep(r.Next(0,81));
                        tmp = 0;
                        do
                        {
                            tmp = caratteriContati + r.Next(0, file.Length / 200);

                        } while (tmp > file.Length );
                        caratteriContati = tmp;
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            progressBar.Value = caratteriContati;
                        }));
                      
                    }
                    MessageBox.Show("a");

                }
            });
        }


        
    }
}
