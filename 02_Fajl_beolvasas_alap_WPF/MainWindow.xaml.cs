using System;
using System.Collections.Generic;
using System.IO;
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

namespace _02_Fajl_beolvasas_alap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StreamReader sr = new StreamReader("vers.txt"); // új fájlbeolvasás a bemasolni.txt-re.
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Fetolt_Click(object sender, RoutedEventArgs e)
        {
            while (!sr.EndOfStream)  // amig végig nem olvasta a fájlt, addig tart a ciklus
            { 
                string sor = sr.ReadLine(); // soronként olvassuk a fájlt a sor nevű változóba
                lbox1.Items.Add(sor);
            }
        }
    }
}
