
// MainWindow.xaml.cs
using KiranduloApp.Models; // A modellek elérhetősége
using System.Collections.Generic; // A listák kezeléséhez szükséges névtér
using System.Windows; // WPF alapvető osztályai
using System.Windows.Controls; // WPF vezérlők osztályai
using MySql.Data.MySqlClient; // MySQL adatbázis-kezelő

namespace KiranduloApp // Az alkalmazás névtere
{
    public partial class MainWindow : Window // A főablak osztálya
    {
        private KirandulohelyKatalogus katalogus = new KirandulohelyKatalogus(); // A kirándulóhelyek katalógusa

        public MainWindow() // Konstruktor
        {
            InitializeComponent(); // Felület inicializálása
            AdatokBetoltese(); // Adatok betöltése az adatbázisból
            lbxKirandulohelyek.ItemsSource = katalogus.Kirandulohelyek; // Lista adatforrásának beállítása
        }

        private void AdatokBetoltese() // Adatok betöltése az adatbázisból
        {
            string connectionString = "Server=db.domain.tld;Port=3306;Database=dbname;Uid=dbuser;Pwd=dbuserpass;";
            using (var connection = new MySqlConnection(connectionString)) // Kapcsolat létrehozása
            {
                try
                {
                    connection.Open(); // Kapcsolat megnyitása

                    string query = "SELECT * FROM kirandulohelyek"; // SQL lekérdezés
                    using (var command = new MySqlCommand(query, connection)) // SQL parancs
                    using (var reader = command.ExecuteReader()) // Adatok olvasása
                    {
                        var kirandulohelyek = new List<Kirandulohely>(); // Kirándulóhelyek listája
                        while (reader.Read()) // Adatok bejárása
                        {
                            kirandulohelyek.Add(new Kirandulohely
                            {
                                Id = reader.GetInt32("id"), // Azonosító
                                Nev = reader.GetString("nev"), // Név
                                Helyszin = reader.GetString("helyszin"), // Helyszín
                                NehezsegiSzint = reader.GetString("nehezsegi_szint"), // Nehézségi szint
                                LatogatokSzama = reader.GetInt32("latogatok_szama"), // Látogatók száma
                                Tav = reader.GetDouble("tav") // Távolság
                            });
                        }

                        katalogus.BetoltesAzAdatbazisbol(kirandulohelyek); // Adatok betöltése a katalógusba
                    }
                }
                catch (MySqlException ex) // Hibakezelés
                {
                    MessageBox.Show($"Hiba történt az adatok betöltése közben: {ex.Message}");
                }
            }
        }

        private void lbxKirandulohelyek_SelectionChanged(object sender, SelectionChangedEventArgs e) // Kiválasztott kirándulóhely kezelése
        {
            if (lbxKirandulohelyek.SelectedItem is Kirandulohely kivalasztott) // Ellenőrzés és adattípus konverzió
            {
                tbNev.Text = kivalasztott.Nev; // Név megjelenítése
                tbHelyszin.Text = kivalasztott.Helyszin; // Helyszín megjelenítése
                tbNehezsegiSzint.Text = kivalasztott.NehezsegiSzint; // Nehézségi szint megjelenítése
                tbLatogatokSzama.Text = kivalasztott.LatogatokSzama.ToString(); // Látogatók száma megjelenítése
                tbTav.Text = kivalasztott.Tav.ToString(); // Távolság megjelenítése

                // Progress bar frissítése a látogatószám alapján
                int maxLatogatokSzama = 50000; // Példaérték
                pbLatogatok.Value = (double)kivalasztott.LatogatokSzama / maxLatogatokSzama * 100; // Százalékos érték kiszámítása
            }
        }

        private void btnSzures_Click(object sender, RoutedEventArgs e) // Szűrés gomb eseménykezelő
        {
            var szuresiSzint = tbSzures.Text.Trim(); // Szűrési feltétel beolvasása
            var szurtLista = katalogus.Szures(szuresiSzint); // Szűrés végrehajtása
            lbxKirandulohelyek.ItemsSource = szurtLista; // Szűrt lista megjelenítése
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e) // Szűrt adatok mentése
        {
            try
            {
                var szurtLista = lbxKirandulohelyek.ItemsSource as List<Kirandulohely>; // Szűrt lista beolvasása
                if (szurtLista == null || szurtLista.Count == 0) // Ellenőrzés
                {
                    MessageBox.Show("Nincs menthető adat!");
                    return;
                }

                using (var writer = new System.IO.StreamWriter("szurt.csv")) // Fájl megnyitása
                {
                    writer.WriteLine("Id;Név;Helyszín;Nehézségi szint;Látogatók száma;Táv"); // Fejléc írása
                    foreach (var k in szurtLista) // Lista bejárása
                    {
                        writer.WriteLine($"{k.Id};{k.Nev};{k.Helyszin};{k.NehezsegiSzint};{k.LatogatokSzama};{k.Tav}"); // Adatok írása
                    }
                }

                MessageBox.Show("Adatok sikeresen mentve a szurt.csv fájlba!");
            }
            catch (System.IO.IOException ex) // Hibakezelés
            {
                MessageBox.Show($"Hiba történt a fájl mentésekor: {ex.Message}");
            }
        }
    }
}
