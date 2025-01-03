using System; // Alapvető típusokhoz
using System.Collections.Generic; // Listák kezeléséhez
using System.Linq; // LINQ műveletekhez
using System.Windows; // WPF alapvető osztályokhoz
using System.Windows.Controls; // WPF vezérlők kezeléséhez
using System.Windows.Data;
using System.Windows.Documents; // Adorner osztályhoz
using System.Windows.Media; // Grafikai elemekhez
using EtteremKatalogus.Logic; // Az üzleti logika eléréséhez
using EtteremKatalogus.Models; // Az adatmodellek eléréséhez
using OxyPlot; // Diagramok megjelenítéséhez
using OxyPlot.Series; // Diagram szériák kezeléséhez

namespace EtteremKatalogus // A fő projekt névtere
{
    public partial class MainWindow : Window // Főablak osztálya
    {
        private readonly EtteremLista etteremLista; // Az étteremlista kezelő objektum

        public MainWindow() // Konstruktor az ablak inicializálásához
        {
            InitializeComponent(); // Felület inicializálása
            etteremLista = new EtteremLista(); // Az étteremlista objektum létrehozása
            AddPlaceholders(); // Helyettesítő szövegek hozzáadása
            Frissites(); // Az adatok betöltése az ablakba
        }

        private void AddPlaceholders() // Helyettesítő szövegek hozzáadása
        {
            AddPlaceholder(tbNev, "Étterem neve"); // Név mező helyettesítő szöveg
            AddPlaceholder(tbVaros, "Város"); // Város mező helyettesítő szöveg
            AddPlaceholder(tbCim, "Cím"); // Cím mező helyettesítő szöveg
            AddPlaceholder(tbSzuresVaros, "Szűrés város szerint"); // Szűrés mező helyettesítő szöveg
        }

        private void AddPlaceholder(TextBox textBox, string placeholderText) // Helyettesítő szöveg hozzáadása egy TextBox-hoz
        {
            var layer = AdornerLayer.GetAdornerLayer(textBox); // Adorner réteg lekérése
            if (layer != null) // Ha az adorner réteg elérhető
            {
                var adorner = new PlaceholderAdorner(textBox, placeholderText); // Új adorner példány
                layer.Add(adorner); // Adorner hozzáadása a réteghez

                textBox.TextChanged += (sender, args) => layer.Update(); // Adorner frissítése szöveg változáskor
            }
        }

        private void Frissites() // Az ablak adatai frissítése
        {
            List<Etterem> ettermek = etteremLista.Lekerdezes(); // Éttermek lekérdezése
            lbEttermek.ItemsSource = ettermek; // ListBox feltöltése az éttermekkel
            MegjelenitesDiagram(ettermek); // Diagram frissítése
        }

        private void MegjelenitesDiagram(List<Etterem> ettermek) // Diagram adatok frissítése
        {
            var varosCsoport = ettermek.GroupBy(e => e.Varos) // Városok szerint csoportosítás
                                        .Select(g => new { Varos = g.Key, Db = g.Count() }) // Város és darabszám párok
                                        .ToList(); // Eredmény lista létrehozása

            var model = new PlotModel { Title = "Város szerinti megoszlás" }; // Diagram modell létrehozása
            var pieSeries = new PieSeries(); // Kördiagram széria létrehozása

            foreach (var item in varosCsoport) // Városcsoportok hozzáadása a diagramhoz
            {
                pieSeries.Slices.Add(new PieSlice(item.Varos, item.Db)); // Szeletek hozzáadása
            }

            model.Series.Add(pieSeries); // Széria hozzáadása a modellhez
            plotView.Model = model; // Diagram megjelenítése az ablakban
        }

        private void btnHozzaadas_Click(object sender, RoutedEventArgs e) // Hozzáadás gomb eseménykezelője
        {
            var ujEtterem = new Etterem // Új étterem létrehozása
            {
                Nev = tbNev.Text.Trim(), // Név beállítása
                Varos = tbVaros.Text.Trim(), // Város beállítása
                Cim = tbCim.Text.Trim(), // Cím beállítása
                Arkategoria = cbArkategoria.Text // Ár kategória beállítása
            };

            if (etteremLista.Hozzaadas(ujEtterem)) // Sikeres hozzáadás ellenőrzése
            {
                MessageBox.Show("Az étterem sikeresen hozzáadva!"); // Sikeres üzenet
                Frissites(); // Adatok frissítése
            }
            else // Sikertelen hozzáadás
            {
                MessageBox.Show("Hiba történt az étterem hozzáadásakor."); // Hibaüzenet
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e) // Törlés gomb eseménykezelője
        {
            if (lbEttermek.SelectedItem is Etterem kivalasztottEtterem) // Kiválasztott étterem ellenőrzése
            {
                if (etteremLista.Torles(kivalasztottEtterem.Id)) // Sikeres törlés ellenőrzése
                {
                    MessageBox.Show("Az étterem sikeresen törölve!"); // Sikeres törlés üzenet
                    Frissites(); // Adatok frissítése
                }
                else // Sikertelen törlés
                {
                    MessageBox.Show("Hiba történt az étterem törlésekor."); // Hibaüzenet
                }
            }
            else // Ha nincs kijelölt elem
            {
                MessageBox.Show("Kérjük, válasszon ki egy éttermet a törléshez!"); // Figyelmeztető üzenet
            }
        }

        private void btnSzures_Click(object sender, RoutedEventArgs e) // Szűrés gomb eseménykezelője
        {
            string varos = tbSzuresVaros.Text.Trim(); // Város szűrő beállítása
            List<Etterem> szurtEttermek = etteremLista.SzuresVarosSzerint(varos); // Szűrt lista lekérdezése
            lbEttermek.ItemsSource = szurtEttermek; // Szűrt lista megjelenítése
            MegjelenitesDiagram(szurtEttermek); // Diagram frissítése a szűrt adatokkal
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e) // Mentés gomb eseménykezelője
        {
            if (lbEttermek.ItemsSource is List<Etterem> szurtEttermek) // Szűrt lista ellenőrzése
            {
                try // Hibakezelés kezdete
                {
                    using (var sw = new System.IO.StreamWriter("szurt.csv")) // CSV fájl írás megkezdése
                    {
                        sw.WriteLine("Id;Nev;Varos;Cim;Arkategoria"); // Fejléc írása
                        foreach (var etterem in szurtEttermek) // Minden szűrt étterem írása
                        {
                            sw.WriteLine($"{etterem.Id};{etterem.Nev};{etterem.Varos};{etterem.Cim};{etterem.Arkategoria}"); // Sor írása
                        }
                    }
                    MessageBox.Show("A szűrt adatok sikeresen mentve a szurt.csv fájlba!"); // Sikeres mentés üzenet
                }
                catch (Exception ex) // Hiba esetén
                {
                    MessageBox.Show("Hiba történt a mentés során: " + ex.Message); // Hibaüzenet
                }
            }
        }

        private void lbEttermek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbEttermek.SelectedItem is Etterem kivalasztottEtterem) // Ellenőrizzük, hogy van-e kijelölt elem
            {
                tbNev.Text = kivalasztottEtterem.Nev; // Név mező kitöltése
                tbVaros.Text = kivalasztottEtterem.Varos; // Város mező kitöltése
                tbCim.Text = kivalasztottEtterem.Cim; // Cím mező kitöltése
                cbArkategoria.SelectedItem = cbArkategoria.Items // Ár kategória kiválasztása
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Content.ToString() == kivalasztottEtterem.Arkategoria);
            }
            else // Ha nincs kijelölt elem
            {
                tbNev.Text = string.Empty; // Név mező törlése
                tbVaros.Text = string.Empty; // Város mező törlése
                tbCim.Text = string.Empty; // Cím mező törlése
                cbArkategoria.SelectedIndex = -1; // Ár kategória törlése
            }
        }
    }

    public class PlaceholderAdorner : Adorner // Adorner osztály a helyettesítő szöveghez
    {
        private readonly TextBlock _placeholder; // A helyettesítő szöveget tartalmazó TextBlock

        public PlaceholderAdorner(UIElement adornedElement, string placeholderText)
            : base(adornedElement) // Alap konstruktor
        {
            _placeholder = new TextBlock
            {
                Text = placeholderText, // Helyettesítő szöveg beállítása
                Foreground = Brushes.Gray, // Szürke szöveg szín
                Margin = new Thickness(5, 0, 0, 0), // Margók beállítása
                VerticalAlignment = System.Windows.VerticalAlignment.Center // Szöveg középre igazítása
            };
            IsHitTestVisible = false; // Nem kattintható
        }

        protected override void OnRender(DrawingContext drawingContext) // Renderelési logika
        {
            if (AdornedElement is TextBox textBox && string.IsNullOrEmpty(textBox.Text)) // Ha a TextBox üres
            {
                var adornedElementRect = new Rect(AdornedElement.RenderSize); // Méret lekérése
                drawingContext.DrawText( // Szöveg renderelése
                    new FormattedText(
                        _placeholder.Text,
                        System.Globalization.CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        new Typeface(_placeholder.FontFamily, _placeholder.FontStyle, _placeholder.FontWeight, _placeholder.FontStretch),
                        _placeholder.FontSize,
                        _placeholder.Foreground,
                        VisualTreeHelper.GetDpi(this).PixelsPerDip),
                    new Point(5, 2)); // Pozíció
            }
        }
    }

    public class ArkategoriaConverter : IValueConverter // Árkategória konverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) // Konvertálás
        {
            if (value is string arkategoria) // Ha string típusú az érték
            {
                switch (arkategoria) // Árkategória alapján
                {
                    case "Alacsony": return Brushes.Green; // Alacsony ár esetén zöld
                    case "Közepes": return Brushes.Orange; // Közepes ár esetén narancssárga
                    case "Magas": return Brushes.Red; // Magas ár esetén piros
                }
            }
            return Brushes.Black; // Alapértelmezett fekete
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) // Visszakonvertálás
        {
            throw new NotImplementedException(); // Nem szükséges
        }
    }

}
