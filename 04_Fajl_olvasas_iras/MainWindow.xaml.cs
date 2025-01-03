using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fajl_olvasas_iras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Feltolt_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("vers.txt");

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                lbox1.Items.Add(sor);
            }
            sr.Close();
        }

        private void Modosit_Click(object sender, RoutedEventArgs e)
        {
            tbx1.Text = lbox1.SelectedItem as string;
            // A textbox szövege a listbox kiválasztott eleme lesz
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            int kivalasztott = lbox1.SelectedIndex;
            // létrehoztam egy változót a kiválasztott elem indexének tárolására

            lbox1.Items[kivalasztott] = tbx1.Text;
            // A kiválasztott indexű elemet cserélem le a textbox szövegére
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StreamWriter sw = new StreamWriter("mentes.txt");

            foreach (string s in lbox1.Items) 
            { 
                sw.WriteLine(s);
            }
            sw.Close();
        }
    }
}