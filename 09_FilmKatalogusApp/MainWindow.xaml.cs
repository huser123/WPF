// MainWindow.xaml.cs
using FilmKatalogusApp.Models; // Az adatmodellek elérhetősége
using Newtonsoft.Json; // JSON fájl kezeléséhez szükséges névtér
using System; // Általános osztályok használata
using System.Linq; // LINQ használata a listaelemeken
using System.Windows; // WPF alapvető osztályai
using System.Windows.Controls; // WPF vezérlők osztályai

namespace FilmKatalogusApp // Az alkalmazás névtere
{
    public partial class MainWindow : Window // A főablak osztálya
    {
        private FilmKatalogus katalogus; // A filmkatalógus példánya
        private Film kivalasztottFilm; // Az aktuálisan kiválasztott film

        public MainWindow() // Konstruktor
        {
            InitializeComponent(); // Felület inicializálása

            // JSON fájl betöltése
            var json = System.IO.File.ReadAllText("films.json"); // A films.json fájl beolvasása
            katalogus = JsonConvert.DeserializeObject<FilmKatalogus>(json) ?? new FilmKatalogus(); // JSON deszerializálása

            // Filmek megjelenítése a ListBox-ban
            lbxFilmek.ItemsSource = katalogus.Filmek;
        }

        private void lbxFilmek_SelectionChanged(object sender, SelectionChangedEventArgs e) // ListBox elem kiválasztása
        {
            if (lbxFilmek.SelectedItem != null) // Ellenőrzés, hogy van-e kiválasztott elem
            {
                kivalasztottFilm = (Film)lbxFilmek.SelectedItem; // Kiválasztott elem tárolása
                tbCim.Text = kivalasztottFilm.Cim; // Cím megjelenítése
                tbRendezo.Text = kivalasztottFilm.Rendező; // Rendező megjelenítése
                tbMufaj.Text = kivalasztottFilm.Mufaj; // Műfaj megjelenítése
                tbMegjelenesiEv.Text = kivalasztottFilm.MegjelenesiEv.ToString(); // Megjelenési év megjelenítése
                tbIMDbPontszam.Text = kivalasztottFilm.IMDbPontszam.ToString(); // IMDb pontszám megjelenítése
            }
        }

        private void btnUjFilm_Click(object sender, RoutedEventArgs e) // Új film hozzáadása
        {
            var ujFilmAblak = new UjFilm(); // ÚjFilm ablak példányosítása
            if (ujFilmAblak.ShowDialog() == true) // Ha az ablak mentéssel zárult
            {
                ujFilmAblak.Film.Id = katalogus.Filmek.Any() // Egyedi azonosító létrehozása
                    ? katalogus.Filmek.Max(f => f.Id) + 1 // Ha már vannak filmek
                    : 1; // Ha ez az első film
                katalogus.Filmek.Add(ujFilmAblak.Film); // Az új film hozzáadása a listához
                lbxFilmek.Items.Refresh(); // ListBox frissítése
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e) // Film törlése
        {
            if (kivalasztottFilm != null) // Ellenőrzés, hogy van-e kiválasztott film
            {
                katalogus.Filmek.Remove(kivalasztottFilm); // Film eltávolítása a listából
                lbxFilmek.Items.Refresh(); // ListBox frissítése
            }
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e) // Adatok mentése
        {
            try // Hibakezelés
            {
                var json = JsonConvert.SerializeObject(katalogus, Formatting.Indented); // JSON formátumú szöveg generálása
                System.IO.File.WriteAllText("films.json", json); // JSON fájlba írás
                MessageBox.Show("Adatok sikeresen mentve!"); // Sikeres mentés üzenet
            }
            catch (Exception ex) // Hibakezelés, ha valami rosszul sül el
            {
                MessageBox.Show($"Hiba történt: {ex.Message}"); // Hibaüzenet megjelenítése
            }
        }
    }
}
