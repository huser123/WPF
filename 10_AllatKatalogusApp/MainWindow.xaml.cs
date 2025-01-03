// MainWindow.xaml.cs
using AllatKatalogusApp.Models; // Az adatmodellek elérhetősége
using Newtonsoft.Json; // JSON fájl kezeléséhez szükséges névtér
using System; // Általános osztályok használata
using System.Linq; // LINQ használata a listaelemeken
using System.Windows; // WPF alapvető osztályai
using System.Windows.Controls; // WPF vezérlők osztályai
using System.Windows.Media; // Színek és egyéb vizuális elemek kezelése

namespace AllatKatalogusApp // Az alkalmazás névtere
{
    public partial class MainWindow : Window // A főablak osztálya
    {
        private AllatKatalogus katalogus; // Az állatkatalógus példánya
        private Allat kivalasztottAllat; // Az aktuálisan kiválasztott állat

        public MainWindow() // Konstruktor
        {
            InitializeComponent(); // Felület inicializálása

            // JSON fájl betöltése
            var json = System.IO.File.ReadAllText("allatok.json"); // Az allatok.json fájl beolvasása
            katalogus = JsonConvert.DeserializeObject<AllatKatalogus>(json) ?? new AllatKatalogus(); // JSON deszerializálása

            // Állatok megjelenítése a ListBox-ban
            lbxAllatok.ItemsSource = katalogus.Allatok;
        }

        private void lbxAllatok_SelectionChanged(object sender, SelectionChangedEventArgs e) // ListBox elem kiválasztása
        {
            if (lbxAllatok.SelectedItem != null)
            {
                kivalasztottAllat = (Allat)lbxAllatok.SelectedItem; // Kiválasztott elem tárolása
                tbNev.Text = kivalasztottAllat.Nev; // Név megjelenítése
                tbElohely.Text = kivalasztottAllat.Elohely; // Élőhely megjelenítése
                tbEletkor.Text = kivalasztottAllat.Eletkor.ToString(); // Élettartam megjelenítése
                tbVeszelyeztetett.Text = kivalasztottAllat.VeszelyeztetettStatusz; // Veszélyeztetett státusz megjelenítése
                tbMeret.Text = kivalasztottAllat.Meret.ToString(); // Méret megjelenítése

                // ProgressBar beállítása a veszélyeztetett státusz szerint
                switch (kivalasztottAllat.VeszelyeztetettStatusz.ToLower())
                {
                    case "súlyosan veszélyeztetett":
                        pbVeszely.Value = 100;
                        pbVeszely.Foreground = new SolidColorBrush(Colors.Red);
                        break;
                    case "veszélyeztetett":
                        pbVeszely.Value = 70;
                        pbVeszely.Foreground = new SolidColorBrush(Colors.Orange);
                        break;
                    default:
                        pbVeszely.Value = 30;
                        pbVeszely.Foreground = new SolidColorBrush(Colors.Green);
                        break;
                }
            }
        }

        private void btnUjAllat_Click(object sender, RoutedEventArgs e) // Új állat hozzáadása
        {
            var ujAllatAblak = new UjAllat(); // ÚjAllat ablak példányosítása
            if (ujAllatAblak.ShowDialog() == true) // Ha az ablak mentéssel zárult
            {
                ujAllatAblak.Allat.Id = katalogus.Allatok.Any() // Egyedi azonosító létrehozása
                    ? katalogus.Allatok.Max(a => a.Id) + 1 // Ha már vannak állatok
                    : 1; // Ha ez az első állat
                katalogus.Allatok.Add(ujAllatAblak.Allat); // Az új állat hozzáadása a listához
                lbxAllatok.Items.Refresh(); // ListBox frissítése
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e) // Állat törlése
        {
            if (kivalasztottAllat != null) // Ellenőrzés, hogy van-e kiválasztott állat
            {
                katalogus.Allatok.Remove(kivalasztottAllat); // Állat eltávolítása a listából
                lbxAllatok.Items.Refresh(); // ListBox frissítése
            }
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e) // Adatok mentése
        {
            try // Hibakezelés
            {
                var json = JsonConvert.SerializeObject(katalogus, Formatting.Indented); // JSON formátumú szöveg generálása
                System.IO.File.WriteAllText("allatok.json", json); // JSON fájlba írás
                MessageBox.Show("Adatok sikeresen mentve!"); // Sikeres mentés üzenet
            }
            catch (Exception ex) // Hibakezelés, ha valami rosszul sül el
            {
                MessageBox.Show($"Hiba történt: {ex.Message}"); // Hibaüzenet megjelenítése
            }
        }

        private void btnSzures_Click(object sender, RoutedEventArgs e) // Szűrés gomb eseménykezelő
        {
            var szuresiElohely = tbSzuresElohely.Text.Trim(); // Szűrési kritérium az élőhely alapján
            var szuresiLista = katalogus.Allatok
                .Where(a => a.Elohely.IndexOf(szuresiElohely, StringComparison.OrdinalIgnoreCase) >= 0) // LINQ feltétel
                .ToList(); // Az eredmény lista

            lbxAllatok.ItemsSource = szuresiLista; // Szűrt lista megjelenítése
        }

        private void btnSzuresMentes_Click(object sender, RoutedEventArgs e) // Szűrt adatok mentése
        {
            try
            {
                var szuresiElohely = tbSzuresElohely.Text.Trim(); // Szűrési kritérium
                var szurtLista = katalogus.Allatok
                    .Where(a => a.Elohely.IndexOf(szuresiElohely, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                var szurtKatalogus = new AllatKatalogus { Allatok = szurtLista }; // Új katalógus csak a szűrt elemekkel
                var json = JsonConvert.SerializeObject(szurtKatalogus, Formatting.Indented); // JSON szöveg generálása
                System.IO.File.WriteAllText("szurt.json", json); // JSON fájlba írás
                MessageBox.Show("Szűrt adatok sikeresen mentve!"); // Sikerüzenet
            }
            catch (Exception ex) // Hibakezelés
            {
                MessageBox.Show($"Hiba történt: {ex.Message}"); // Hibaüzenet megjelenítése
            }
        }
    }
}
