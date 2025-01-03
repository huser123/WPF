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

namespace Rendelés
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float kalkulaltAr = 0; // az árak nyilvántartása
        List<string> arucikkek = new List<string>(); // az árucikkek nyilvántartására szolgáló lista
        List<float> arak = new List<float>(); // az árucikkek árainak nyilvántartására szolgáló lista
        List<float> kivalaszottAr = new List<float>(); // a kiválasztott árucikk árát tartalmazó lista
        List<string> kivalasztottArucikk = new List<string>(); // a kiválasztott árucikket tartalmazó lista
        public MainWindow()
        {
            InitializeComponent();
            
            

            StreamReader sr = new StreamReader("arucikkek.txt"); // beolvassuk az árucikkeket
            lboxArucikkek.Items.Clear(); // a listbox minden addigi elemét törölni
            while (!sr.EndOfStream) // amit nem érünk a sor végére
            {
                string[] adatok = sr.ReadLine().Split(':'); // beolvassuk az adatokat soronként egy tömbbe és törjük a : mentén

                lboxArucikkek.Items.Add($"{adatok[0]} - ár: {adatok[1]}€"); // formázva kiírjuk a listboxba is
                arucikkek.Add(adatok[0]); // elmentjük az árucikket a listába
                arak.Add(float.Parse(adatok[1])); // elmentjük az árat is egy listába külön
                // ezt azért csináljuk, hogy a listboxtól függetlenül tudjuk kezelni ezeket az adatokat de az indexük ugyanaz legyen

            }
            sr.Close(); // lezárjuk a fájl olvasását


        }

        private void btnHozzaad_Click(object sender, RoutedEventArgs e) // árucikkek kiválasztása
        {
            if (lboxArucikkek.SelectedIndex != -1) // ha van kiválasztott elem - ha nincs, akkor -1 az érték
            {
                int kivalasztott = lboxArucikkek.SelectedIndex; // elmentjük a kiválasztott elem indexét

                lboxKivalasztott.Items.Add(lboxArucikkek.SelectedItem); // hozzáadom a kiválasztott elemeket tartalmazó listboxhoz az elemet
                lboxArucikkek.Items.Remove(lboxArucikkek.SelectedItem); // törlöm az elemet az eredeti listboxból

                kalkulaltAr += arak[kivalasztott]; // bekalkulálom az árakat azzal, hogy az árak listának a megfelelő indexű árát adom hozzá

                kivalaszottAr.Add(arak[kivalasztott]); // hozzá adom az új listához a kiálvasztott termék árát -
                                                       // ezáltal lesz egy új listám, aminek az idexei a kiválasztott listbox indexeivel lesznek egyenlőek
                kivalasztottArucikk.Add(arucikkek[kivalasztott]); // szintén létrehozom a fentebbi logika alapján az új listát

                arak.RemoveAt(kivalasztott); // törlöm az eredeti listából a termék árát
                arucikkek.RemoveAt(kivalasztott); // törlöm az eredeti listából a termék árát

                lblAr.Content = $"Az ár eddig: {kalkulaltAr.ToString()}€"; // kiírom a címkébe az eddigi árakat

            }
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e) // töröljük az elmentett elemet
        {
            if (lboxKivalasztott.SelectedIndex != -1) // ha van kiválasztott elem a listboxban
            {
                int kivalasztott = lboxKivalasztott.SelectedIndex; // elmentem a kiválasztott elem indexét

                lboxArucikkek.Items.Add(lboxKivalasztott.SelectedItem); // vissza írom az árucikkek listboxjába az elemet
                lboxKivalasztott.Items.Remove(lboxKivalasztott.SelectedItem); // törlöm a kiválasztott listboxból az elemet

                kalkulaltAr -= kivalaszottAr[kivalasztott]; // kivonom a kalkulált árból az elem árát

                arucikkek.Add(kivalasztottArucikk[kivalasztott]); // visszaírom az árucikkek listába az elemet
                arak.Add(kivalaszottAr[kivalasztott]); // visszaírom az árucikk árát a termékek árának listájába


                kivalaszottAr.RemoveAt(kivalasztott); // törlöm a kiválasztott elemek árai közül az elem árát
                kivalasztottArucikk.RemoveAt(kivalasztott); // törlöm a kiválasztott elemek közül az elemet

                lblAr.Content = $"Az ár eddig: {kalkulaltAr.ToString()}€"; // frissítem az árat a címkében
            }

        }

        private void btnRendel_Click(object sender, RoutedEventArgs e) // a rendelés elmentése
        {
            StreamWriter sw = new StreamWriter("rendeles.txt"); // elkészítem a streamwritert a fájl kiírására

            sw.WriteLine("A felhasználó által rendelt eszközök:"); // beírom az első sort
            sw.WriteLine(""); // írok egy üres sort

            foreach (var tetel in lboxKivalasztott.Items) // végig megyek a kiválasztott elemek listboxjának elemein
            {
                sw.WriteLine(tetel.ToString()); // kiírom azokat soronként a fájlba
            }

            sw.WriteLine(""); // írok egy üres sort
            sw.WriteLine($"Az ár összesen: {kalkulaltAr}€"); // beírom az árat


            sw.Close(); // lezárom a fájl írását

            MessageBox.Show("A rendelés sikeresen leadva!", "Siker!", MessageBoxButton.OK, MessageBoxImage.Information); // értesítem a felhasználót a kész folyamatról
        }
    }
}
