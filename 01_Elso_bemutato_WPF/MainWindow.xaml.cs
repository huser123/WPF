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

namespace _01_Elso_bemutato
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

        int elem = 0;

        private void Hozzaad_Click(object sender, RoutedEventArgs e)
        {
            string szoveg = VeletlenSzoveg(15);
            lbox1.Items.Add(szoveg);

            if (elem == 10) 
            {
                lbox1.Items.Clear();
                elem = 0;
            }
            else 
            {
                elem++;
            }

            
        }

        private void Torol_Click(object sender, RoutedEventArgs e)
        {
            lbox1.Items.Remove(lbox1.SelectedItem);
        }

        private void Modosit_Click(object sender, RoutedEventArgs e)
        {
            int kivalasztott = lbox1.SelectedIndex;

            lbox1.Items[kivalasztott] = tbx1.Text;
        }

        public static string VeletlenSzoveg(int hossz)
        {
            // Azok a karekterek, amiből választhat
            const string karakterek = "ABCDEFGHIJKLMNOPQRSTXYZabcdefghijklmnopqrstxyz0123456789";
            Random rnd = new Random();
            char[] szoveg = new char[hossz];

            // Generáljunk véletlen szöveget
            for (int i = 0; i < hossz; i++)
            {
                szoveg[i] = karakterek[rnd.Next(karakterek.Length)];
            }
            return new string(szoveg);
        }


    }
}
