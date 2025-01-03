// UjFilm.xaml.cs
using FilmKatalogusApp.Models; // Az adatmodellek elérhetősége
using System.Windows;

namespace FilmKatalogusApp // Az alkalmazás névtere
{
    public partial class UjFilm : Window // Az új film hozzáadására szolgáló ablak
    {
        public Film Film { get; set; } = new Film(); // Egy új Film objektum a bevitt adatok tárolására

        public UjFilm() // Konstruktor
        {
            InitializeComponent(); // Felület inicializálása
            DataContext = Film; // Az adatkontextus beállítása az új Film objektumra
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e) // Mentés gomb eseménykezelő
        {
            // Adatellenőrzés
            if (string.IsNullOrWhiteSpace(tbCim.Text) || // Ha a Cím mező üres vagy csak szóközöket tartalmaz
                string.IsNullOrWhiteSpace(tbRendezo.Text) || // Ha a Rendező mező üres vagy csak szóközöket tartalmaz
                string.IsNullOrWhiteSpace(tbMufaj.Text) || // Ha a Műfaj mező üres vagy csak szóközöket tartalmaz
                !int.TryParse(tbMegjelenesiEv.Text, out int megjelenesiEv) || // Ha a Megjelenési év nem szám
                !double.TryParse(tbIMDbPontszam.Text, out double imdbPontszam) || // Ha az IMDb pontszám nem szám
                imdbPontszam < 1 || imdbPontszam > 10) // Az IMDb pontszámnak 1 és 10 között kell lennie
            {
                MessageBox.Show("Minden mezőt ki kell tölteni, és az értékeknek érvényesnek kell lenniük!"); // Hibaüzenet
                return; // Kilépés a metódusból
            }

            // Adatok mentése a Film objektumba
            Film.Cim = tbCim.Text.Trim(); // A cím mező tartalma
            Film.Rendező = tbRendezo.Text.Trim(); // A rendező mező tartalma
            Film.Mufaj = tbMufaj.Text.Trim(); // A műfaj mező tartalma
            Film.MegjelenesiEv = megjelenesiEv; // A megjelenési év értéke
            Film.IMDbPontszam = imdbPontszam; // Az IMDb pontszám értéke

            DialogResult = true; // Az ablak eredményét igazra állítjuk
            Close(); // Az ablak bezárása
        }

        private void btnMegse_Click(object sender, RoutedEventArgs e) // Mégse gomb eseménykezelő
        {
            DialogResult = false; // Az ablak eredményét hamisra állítjuk
            Close(); // Az ablak bezárása
        }
    }
}
