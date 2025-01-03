// UjAllat.xaml.cs
using AllatKatalogusApp.Models; // Az adatmodellek elérhetősége
using System.Windows;

namespace AllatKatalogusApp // Az alkalmazás névtere
{
    public partial class UjAllat : Window // Az új állat hozzáadására szolgáló ablak
    {
        public Allat Allat { get; set; } = new Allat(); // Egy új Allat objektum a bevitt adatok tárolására

        public UjAllat() // Konstruktor
        {
            InitializeComponent(); // Felület inicializálása
            DataContext = Allat; // Az adatkontextus beállítása az új Allat objektumra
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e) // Mentés gomb eseménykezelő
        {
            // Adatellenőrzés
            if (string.IsNullOrWhiteSpace(tbNev.Text) || // Ha a Név mező üres vagy csak szóközöket tartalmaz
                string.IsNullOrWhiteSpace(tbElohely.Text) || // Ha az Élőhely mező üres vagy csak szóközöket tartalmaz
                !double.TryParse(tbEletkor.Text, out double eletkor) || // Ha az Élettartam nem szám
                string.IsNullOrWhiteSpace(tbVeszelyeztetett.Text) || // Ha a Veszélyeztetett státusz mező üres
                !double.TryParse(tbMeret.Text, out double meret) || // Ha a Méret nem szám
                eletkor <= 0 || meret <= 0) // Ha az Élettartam vagy Méret negatív vagy nulla
            {
                MessageBox.Show("Minden mezőt ki kell tölteni, és az értékeknek érvényesnek kell lenniük!"); // Hibaüzenet
                return; // Kilépés a metódusból
            }

            // Adatok mentése az Allat objektumba
            Allat.Nev = tbNev.Text.Trim(); // A Név mező tartalma
            Allat.Elohely = tbElohely.Text.Trim(); // Az Élőhely mező tartalma
            Allat.Eletkor = eletkor; // Az Élettartam értéke
            Allat.VeszelyeztetettStatusz = tbVeszelyeztetett.Text.Trim(); // A Veszélyeztetett státusz mező tartalma
            Allat.Meret = meret; // A Méret értéke

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
