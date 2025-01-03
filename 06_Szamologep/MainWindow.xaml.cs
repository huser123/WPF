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

namespace Szamologep
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

        private void n0_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "0";
        }

        private void nV_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += ",";
        }

        private void nO_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "/";
        }

        private void n1_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "1";
        }

        private void n2_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "2";
        }

        private void n3_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "3";
        }

        private void nSz_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "*";
        }

        private void n4_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "4";
        }

        private void n5_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "5";
        }

        private void n6_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "6";
        }

        private void nM_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "-";
        }

        private void n7_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "7";
        }

        private void n8_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "8";
        }

        private void n9_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "9";
        }

        private void nP_Click(object sender, RoutedEventArgs e)
        {
            tbxBevitel.Text += "+";
        }

        private void nE_Click(object sender, RoutedEventArgs e)
        {
            string input = tbxBevitel.Text;

            if (input.Contains("+"))
            {
                string[] muveletek = input.Split('+');
                double muvelet1 = Convert.ToDouble(muveletek[0]);
                double muvelet2 = Convert.ToDouble(muveletek[1]);

                lblEredmeny.Content = $"Eredmény: {muvelet1 + muvelet2}";
                tbxBevitel.Text = "";
            }
            else if (input.Contains("-"))
            {
                string[] muveletek = input.Split('-');
                double muvelet1 = Convert.ToDouble(muveletek[0]);
                double muvelet2 = Convert.ToDouble(muveletek[1]);

                lblEredmeny.Content = $"Eredmény: {muvelet1 - muvelet2}";
                tbxBevitel.Text = "";
            }
            else if (input.Contains("*"))
            {
                string[] muveletek = input.Split('*');
                double muvelet1 = Convert.ToDouble(muveletek[0]);
                double muvelet2 = Convert.ToDouble(muveletek[1]);

                lblEredmeny.Content = $"Eredmény: {muvelet1 * muvelet2}";
                tbxBevitel.Text = "";
            }
            else if (input.Contains("/"))
            {
                string[] muveletek = input.Split('/');
                double muvelet1 = Convert.ToDouble(muveletek[0]);
                double muvelet2 = Convert.ToDouble(muveletek[1]);

                lblEredmeny.Content = $"Eredmény: {muvelet1 / muvelet2}";
                tbxBevitel.Text = "";
            }
            else
            {
                MessageBox.Show("Érvénytelen művelet!","Hiba!",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
