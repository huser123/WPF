//MainWindow.xaml.cs

using LaborMintak.Data; // Az EF adatbázis kontextus elérése
using LaborMintak.Models; // A MintaModel osztály elérése
using Microsoft.EntityFrameworkCore; // Az EF lekérdezésekhez
using System;
using System.Collections.ObjectModel; // Az ObservableCollection típushoz
using System.Linq;
using System.Text.RegularExpressions; // A kód ellenőrzéséhez szükséges
using System.Windows; // A WPF komponensekhez (pl. MessageBox, RoutedEventArgs)

namespace LaborMintak
{
    /// <summary>
    /// A főablak logikája – betöltés, keresés, új minta rögzítése, törlés.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LaborContext adatbazis; // Az EF DbContext példány

        public ObservableCollection<MintaModel> Mintak { get; set; } = new(); // A táblázathoz kötött minta lista

        public MintaModel? KivalasztottMinta { get; set; } = null; // A táblázatból kijelölt minta

        public MainWindow()
        {
            InitializeComponent(); // A vizuális elemek betöltése
            DataContext = this; // Az adatkötések működéséhez az ablak saját magát használja forrásként
            adatbazis = LaborContext.GetContext(); // Az adatbázis kontextus példányának lekérése
            BetoltAdatok(); // A minták betöltése
        }

        /// <summary>
        /// Betölti az adatokat az adatbázisból a táblázatba.
        /// </summary>
        private void BetoltAdatok()
        {
            adatbazis.Minta.Load(); // EF betölti az adatokat memóriába
            Mintak.Clear(); // Kiürítjük a korábbi listát

            foreach (var m in adatbazis.Minta.Local.OrderByDescending(x => x.Id))
            {
                Mintak.Add(m); // Újratöltjük friss sorrendben
            }
        }

        /// <summary>
        /// Új minta rögzítése az adatbázisba.
        /// </summary>
        private void btnHozzaad_Click(object sender, RoutedEventArgs e)
        {
            string kod = tbKod.Text.Trim().ToUpper();
            string nev = tbNev.Text.Trim();
            string tipus = tbTipus.Text.Trim();

            // Alapellenőrzés: minden mező kitöltve?
            if (string.IsNullOrEmpty(kod) || string.IsNullOrEmpty(nev) || string.IsNullOrEmpty(tipus))
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Formátumellenőrzés: 123AB456
            if (!Regex.IsMatch(kod, @"^\d{3}[A-Z]{2}\d{3}$"))
            {
                MessageBox.Show("A kód formátuma érvénytelen! (példa: 123AB456)", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Duplikáció ellenőrzése
            if (adatbazis.Minta.Any(m => m.Kod == kod))
            {
                MessageBox.Show("Ez a kód már szerepel az adatbázisban!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Új minta létrehozása
            var ujMinta = new MintaModel()
            {
                Kod = kod,
                Nev = nev,
                Tipus = tipus,
                Erkezes = DateTime.Now
            };

            // Mentés és frissítés
            adatbazis.Minta.Add(ujMinta);
            adatbazis.SaveChanges();
            BetoltAdatok();

            // Mezők törlése
            tbKod.Clear();
            tbNev.Clear();
            tbTipus.Clear();
        }

        /// <summary>
        /// Élő szűrés a táblázatban kód alapján.
        /// </summary>
        private void tbKereses_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string szuro = tbKereses.Text.Trim().ToUpper();
            Mintak.Clear();

            foreach (var m in adatbazis.Minta.Local.Where(x => x.Kod.Contains(szuro)))
            {
                Mintak.Add(m);
            }
        }

        /// <summary>
        /// Kiválasztott minta törlése, megerősítéssel.
        /// </summary>
        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (KivalasztottMinta == null)
            {
                MessageBox.Show("Nincs kijelölve minta a törléshez!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var megerosites = MessageBox.Show(
                $"Biztosan törölni szeretné a {KivalasztottMinta.Nev} ({KivalasztottMinta.Kod}) mintáját?",
                "Törlés megerősítése",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (megerosites == MessageBoxResult.Yes)
            {
                adatbazis.Minta.Remove(KivalasztottMinta);
                adatbazis.SaveChanges();
                BetoltAdatok();
            }
        }
    }
}
