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

namespace Jelzolampa
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

        int allapot = 1; // azért egy, mert az első ellenőrzés a sárgára vonatkozik, mivel a lámpa alapból piros

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (allapot == 0) // piros
            {
                piros.Fill = Brushes.Red;
                sarga.Fill = Brushes.White;
                zold.Fill = Brushes.White;
                allapot++;
            }
            else if (allapot == 1) // sarga
            {
                piros.Fill = Brushes.White;
                sarga.Fill = Brushes.Yellow;
                zold.Fill = Brushes.White;
                allapot++;
            }
            else if (allapot == 2) // zold
            {
                piros.Fill = Brushes.White;
                sarga.Fill = Brushes.White;
                zold.Fill = Brushes.Green;
                allapot++;
            }
            else if (allapot == 3) // piros+sarga
            {
                piros.Fill = Brushes.Red;
                sarga.Fill = Brushes.Yellow;
                zold.Fill = Brushes.White;
                allapot = 0;
            }
        }
    }
}
