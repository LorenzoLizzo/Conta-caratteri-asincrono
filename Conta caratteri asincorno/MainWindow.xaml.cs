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
                string file;
                using (StreamReader sr = new StreamReader("Data.txt"))
                {
                    file = sr.ReadToEnd();
                }
                AvanzamentoProgessBar(file);
                int tmp = 0;
                while (caratteriContati < file.Length)
                {
                    Thread.Sleep(r.Next(0, 61));
                    tmp = 0;
                    do
                    {
                        tmp = caratteriContati + r.Next(0, file.Length / 150);

                    } while (tmp > file.Length);
                    caratteriContati = tmp;

                }
                MessageBox.Show("a");
            });
        }

        private async void AvanzamentoProgessBar(string file)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    progressBar.Maximum = file.Length;
                }));

                while (caratteriContati < file.Length)
                {
                    Thread.Sleep(r.Next(0, 701));
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        progressBar.Value = caratteriContati;
                    }));
                }

            });
        }



    }
}
