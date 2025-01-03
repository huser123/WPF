
// KirandulohelyFelvitel.xaml.cs
using KiranduloApp.Models; // A modellek elérhetősége
using System.Windows; // WPF alapvető osztályai

namespace KiranduloApp // Az alkalmazás névtere
{
    public partial class KirandulohelyFelvitel : Window // Az új kirándulóhely hozzáadására szolgáló ablak
    {
        public Kirandulohely Kirandulohely { get; set; } = new Kirandulohely(); // Új kirándulóhely adatai

        public KirandulohelyFelvitel() // Konstruktor
        {
            InitializeComponent(); // Felület inicializálása
            DataContext = Kirandulohely; // Az adatkontextus beállítása
        }

        private void btnMentés_Click(object sender, RoutedEventArgs e) // Mentés gomb eseménykezelő
        {
            // Adatok érvényesítése
            if (string.IsNullOrWhiteSpace(tbNev.Text) || // Név ellenőrzése
                string.IsNullOrWhiteSpace(tbHelyszin.Text) || // Helyszín ellenőrzése
                string.IsNullOrWhiteSpace(tbNehezsegiSzint.Text) || // Nehézségi szint ellenőrzése
                !int.TryParse(tbLatogatokSzama.Text, out int latogatokSzama) || latogatokSzama <= 0 || // Látogatószám ellenőrzése
                !double.TryParse(tbTav.Text, out double tav) || tav <= 0) // Távolság ellenőrzése
            {
                MessageBox.Show("Minden mezőt érvényesen kell kitölteni!"); // Hibaüzenet
                return; // Kilépés a metódusból
            }

            // Adatok mentése a Kirandulohely objektumba
            Kirandulohely.Nev = tbNev.Text.Trim(); // Név
            Kirandulohely.Helyszin = tbHelyszin.Text.Trim(); // Helyszín
            Kirandulohely.NehezsegiSzint = tbNehezsegiSzint.Text.Trim(); // Nehézségi szint
            Kirandulohely.LatogatokSzama = latogatokSzama; // Látogatószám
            Kirandulohely.Tav = tav; // Távolság

            DialogResult = true; // Az ablak eredményét igazra állítjuk
            Close(); // Ablak bezárása
        }

        private void btnMegse_Click(object sender, RoutedEventArgs e) // Mégse gomb eseménykezelő
        {
            DialogResult = false; // Az ablak eredményét hamisra állítjuk
            Close(); // Ablak bezárása
        }
    }
}
