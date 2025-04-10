//MainWindow.xaml.cs

using KonyvKolcsonzes.Data; // Az AppContext osztály elérése – az adatbázis-kezeléshez szükséges
using KonyvKolcsonzes.Models; // A VendegModel osztály elérése – az adatszerkezetekhez szükséges
using Microsoft.EntityFrameworkCore; // Az EF Core betöltéséhez és lekérdezésekhez szükséges
using System.Collections.ObjectModel; // Az ObservableCollection típushoz, amely automatikusan frissíti a UI-t
using System.Text.RegularExpressions; // A Regex (mintázatvizsgálat) osztály – kártyaszám formátumellenőrzéshez
using System.Windows; // A WPF ablakkezeléshez és UI elemekhez szükséges

// Telepítendő NuGet csomagok (parancssorban futtatandók):
// dotnet add package Microsoft.EntityFrameworkCore --version 8.0.13
// dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.13
// dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.13
// dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.3

namespace KonyvKolcsonzes // A program fő névtere
{
    /// <summary>
    /// A MainWindow a program fő ablaka – tartalmazza a teljes logikát és eseménykezelést.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly KonyvKolcsonzes.Data.AppContext context;        // Az adatbázis-kapcsolat példánya (singleton)

        public ObservableCollection<VendegModel> Vendeg { get; set; } = new(); // A megjelenítendő lista, amely a DataGrid-hez van kötve
        public VendegModel? KivalasztottVendeg { get; set; } = null; // A DataGrid-ből kijelölt vendég

        public MainWindow()
        {
            InitializeComponent(); // A XAML-ben definiált felület inicializálása
            DataContext = this; // Az ablak saját magát használja adatforrásként – a bindolt property-k így elérhetők

            context = KonyvKolcsonzes.Data.AppContext.GetContext();            // Az EF DbContext példányának lekérése

            BetoltVendeg(); // Az adatok betöltése az adatbázisból
        }

        /// <summary>
        /// Betölti az adatbázisból a vendégek listáját az ObservableCollection-be.
        /// </summary>
        private void BetoltVendeg()
        {
            context.Vendeg.Load(); // Betölti az adatokat memóriába EF segítségével
            Vendeg.Clear(); // Töröljük az esetleges korábbi elemeket
            foreach (var vendeg in context.Vendeg.Local.OrderByDescending(v => v.Id)) // Legújabb vendégek előre
            {
                Vendeg.Add(vendeg); // Hozzáadjuk őket a megjelenítendő listához
            }
        }

        /// <summary>
        /// Új vendég hozzáadása a rendszerhez.
        /// </summary>
        private void btnHozzaad_Click(object sender, RoutedEventArgs e)
        {
            // Bemeneti értékek begyűjtése
            string nev = tbNev.Text.Trim();
            string kartya = tbKartya.Text.Trim().ToUpper();
            string konyv = tbKonyv.Text.Trim();

            // Ellenőrzés: a név mező nem lehet üres
            if (string.IsNullOrEmpty(nev))
            {
                MessageBox.Show("A név mező kitöltése kötelező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Ellenőrzés: kártyaszám formátuma (pl. AB123456)
            if (!Regex.IsMatch(kartya, @"^[A-Z]{2}[0-9]{6}$")) // Regex: 2 nagybetű, majd 6 számjegy
            {
                MessageBox.Show("A belépő kártya számának formátuma nem megfelelő!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Ellenőrzés: könyv címe sem lehet üres
            if (string.IsNullOrEmpty(konyv))
            {
                MessageBox.Show("A könyv címe nem lehet üres!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Ellenőrzés: van-e már ilyen kártyaszám az adatbázisban
            if (context.Vendeg.Any(v => v.Kartya == kartya))
            {
                MessageBox.Show("Ez a kártyaszám már szerepel a nyilvántartásban!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Új vendég létrehozása
            var ujVendeg = new VendegModel()
            {
                Nev = nev,
                Kartya = kartya,
                Konyv = konyv,
                Idopont = DateTime.Now // Az aktuális időpont rögzítése
            };

            // Hozzáadás az adatbázishoz és mentés
            context.Vendeg.Add(ujVendeg);
            context.SaveChanges();

            // Frissítjük a táblázatot
            BetoltVendeg();

            // Mezők törlése a felületen
            tbNev.Clear();
            tbKartya.Clear();
            tbKonyv.Clear();
        }

        /// <summary>
        /// A keresőmező változásakor szűri a vendégeket a kártyaszám alapján.
        /// </summary>
        private void tbKereses_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string szuro = tbKereses.Text.Trim().ToUpper(); // Kis- és nagybetű érzéketlenség
            Vendeg.Clear(); // Kiürítjük a jelenlegi listát

            // Betöltjük újra csak azokat, akik megfelelnek a szűrési feltételnek
            foreach (var vendeg in context.Vendeg.Local
                         .Where(v => v.Kartya.Contains(szuro))
                         .OrderByDescending(v => v.Id))
            {
                Vendeg.Add(vendeg); // Hozzáadjuk a szűrésnek megfelelő vendéget
            }
        }

        /// <summary>
        /// A kijelölt vendég törlése megerősítő üzenettel.
        /// </summary>
        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (KivalasztottVendeg == null) // Nincs kijelölve vendég
            {
                MessageBox.Show("Nincs kijelölve vendég a törléshez.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Megerősítés kérés – dinamikusan tartalmazza a nevet és azonosítót
            var result = MessageBox.Show(
                $"Biztosan törölni szeretné a {KivalasztottVendeg.Nev} ({KivalasztottVendeg.Kartya}) nevű vendég felhasználót?",
                "Megerősítés",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (result == MessageBoxResult.Yes)
            {
                context.Vendeg.Remove(KivalasztottVendeg); // Töröljük az adatbázisból
                context.SaveChanges(); // Mentés
                BetoltVendeg(); // Frissítjük a listát
            }
        }
    }
}
