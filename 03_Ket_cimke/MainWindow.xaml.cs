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

namespace Ket_cimke
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

        int felso = 0, also = 0; // arra figyeljünk, hogy a két változó között vessző van és nem pontos vessző!

        private void Felso_Click(object sender, RoutedEventArgs e)
        {
            if (felso == 0) 
            {
                lbl1.Content = "Első kattintás a fenti gombon";
                felso++;
            }
            else if (felso == 1) 
            {
                lbl1.Content = "Második kattintás a fenti gombon";
                felso++;
            }
            else 
            {
                lbl1.Content = "Harmadik és utolsó";
                felso = 0;
            }
        }
        private void Also_Click(object sender, RoutedEventArgs e)
        {
            if (also == 0)
            {
                lbl2.Content = "Első kattintás a lenti gombon";
                also++;
            }
            else if (also == 1)
            {
                lbl2.Content = "Második kattintás a lenti gombon";
                also++;
            }
            else
            {
                lbl2.Content = "Harmadik és utolsó";
                also = 0;
            }
        }
    }
}