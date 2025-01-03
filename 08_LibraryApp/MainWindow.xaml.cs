using LibraryApp.Models; // using LibraryApp.Models; - Az alkalmazásban használt osztályokat és interfészeket a LibraryApp.Models névtérből használjuk
using Newtonsoft.Json; // using Newtonsoft.Json; - Az alkalmazásban a JSON fájlok kezeléséhez a Newtonsoft.Json névtérből származó osztályokat és interfészeket használjuk
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
// using System.Xml;

namespace LibraryApp // A LibraryApp névtérben található osztályokat és interfészeket definiáljuk ebben a fájlban
{
    public partial class MainWindow : Window // MainWindow osztályt definiáljuk, amely a Window osztályból származik
    {
        private Library library;  // Az osztályban egy library nevű Library típusú property-t definiálunk
        private Book selectedBook; // Az osztályban egy selectedBook nevű Book típusú property-t definiálunk

        public MainWindow() // MainWindow osztály konstruktora
        {
            InitializeComponent(); // Az ablak inicializálása

            // JSON fájl betöltése
            var json = File.ReadAllText("books.json"); // A books.json fájl tartalmát beolvassuk egy változóba
            library = JsonConvert.DeserializeObject<Library>(json) ?? new Library(); // A beolvasott JSON fájlt deszerializáljuk Library típusú objektummá

            // Adatok kötése
            lbxBooks.ItemsSource = library.Books; // A lbxBooks listaelemhez a library.Books listát rendeljük
        }

        private void lbxBooks_SelectionChanged(object sender, SelectionChangedEventArgs e) // lbxBooks_SelectionChanged eseménykezelő metódus
        {
            if (lbxBooks.SelectedItem != null) // Ha a lbxBooks listaelem ki van választva
            {
                selectedBook = (Book)lbxBooks.SelectedItem; // A kiválasztott könyvet a selectedBook változóba mentjük
                tbTitle.Text = selectedBook.Title; // A kiválasztott könyv címét a tbTitle TextBox-ba írjuk
                tbAuthor.Text = selectedBook.Author; // A kiválasztott könyv szerzőjét a tbAuthor TextBox-ba írjuk
                tbGenre.Text = selectedBook.Genre; // A kiválasztott könyv műfaját a tbGenre TextBox-ba írjuk
                tbYear.Text = selectedBook.PublicationYear.ToString(); // A kiválasztott könyv kiadási évét a tbYear TextBox-ba írjuk
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) // btnDelete_Click eseménykezelő metódus
        {
            if (selectedBook != null) // Ha a kiválasztott könyv nem null
            {
                library.Books.Remove(selectedBook); // A kiválasztott könyvet eltávolítjuk a library.Books listából
                lbxBooks.Items.Refresh(); // A lbxBooks listaelemek frissítése
            }
        }

        private void btnNewBook_Click(object sender, RoutedEventArgs e) // btnNewBook_Click eseménykezelő metódus
        {
            var newBookWindow = new wdwNewBook(); // Egy új wdwNewBook ablakot hozunk létre
            if (newBookWindow.ShowDialog() == true) // Ha az ablakot sikeresen bezárják
            {
                // Az ID-t egyedivé tesszük
                newBookWindow.Book.Id = library.Books.Any() // Ha a library.Books lista nem üres
                    ? library.Books.Max(b => b.Id) + 1 // A könyv ID-ja a lista legnagyobb ID-jához hozzáadunk 1-et
                    : 1; // Egyébként az ID 1

                library.Books.Add(newBookWindow.Book); // A newBookWindow könyvet hozzáadjuk a library.Books listához
                lbxBooks.Items.Refresh(); // A lbxBooks listaelemek frissítése
            } 
        }


        private void btnSave_Click(object sender, RoutedEventArgs e) // btnSave_Click eseménykezelő metódus
        {
            try // Próbáljuk meg
            {
                var json = JsonConvert.SerializeObject(library, Formatting.Indented); // A library objektumot JSON formátumba alakítjuk
                File.WriteAllText("books.json", json); // A JSON formátumú adatokat a books.json fájlba írjuk
                MessageBox.Show("Adatok sikeresen mentve!"); // Sikeres mentés esetén üzenetablak jelenik meg
            }
            catch (Exception ex) // Ha hiba történik
            {
                MessageBox.Show($"Hiba történt: {ex.Message}"); // Hibaüzenet jelenik meg
            }
        }
    }
}
