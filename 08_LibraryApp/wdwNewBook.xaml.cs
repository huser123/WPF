using LibraryApp.Models; // using LibraryApp.Models; - Az alkalmazásban használt osztályokat és interfészeket a LibraryApp.Models névtérből használjuk
using System.Windows;

namespace LibraryApp // A LibraryApp névtérben található osztályokat és interfészeket definiáljuk ebben a fájlban
{
    public partial class wdwNewBook : Window // wdwNewBook osztályt definiáljuk, amely a Window osztályból származik
    {
        public Book Book { get; set; } = new Book(); // Az osztályban egy Book típusú property-t definiálunk, amely egy új Book objektumot tartalmaz

        public wdwNewBook() // wdwNewBook osztály konstruktora
        {
            InitializeComponent(); // Az ablak inicializálása
            DataContext = Book; // A DataContext property-t a Book property-re állítjuk
        } 

        private void btnSave_Click(object sender, RoutedEventArgs e) // btnSave_Click eseménykezelő metódus
        {
            // Ellenőrizzük a bevitt adatokat
            if (string.IsNullOrWhiteSpace(tbTitle.Text) || // Ha a tbTitle TextBox üres vagy csak szóközök vannak benne
                string.IsNullOrWhiteSpace(tbAuthor.Text) || // vagy a tbAuthor TextBox üres vagy csak szóközök vannak benne
                string.IsNullOrWhiteSpace(tbGenre.Text) || // vagy a tbGenre TextBox üres vagy csak szóközök vannak benne
                !int.TryParse(tbYear.Text, out int year))  // vagy a tbYear TextBox nem számot tartalmaz
            {
                MessageBox.Show("Minden mezőt ki kell tölteni, és az évszámnak érvényes számnak kell lennie!"); // Hibaüzenet megjelenítése
                return; // Kilépés a metódusból
            }

            // Adatok mentése
            Book.Title = tbTitle.Text.Trim(); // A Book címét a tbTitle TextBox-ból vesszük. A Trim() metódus eltávolítja a szóközöket a szöveg elejéről és végéről
            Book.Author = tbAuthor.Text.Trim(); // A Book szerzőjét a tbAuthor TextBox-ból vesszük. A Trim() metódus eltávolítja a szóközöket a szöveg elejéről és végéről
            Book.Genre = tbGenre.Text.Trim(); // A Book műfaját a tbGenre TextBox-ból vesszük. A Trim() metódus eltávolítja a szóközöket a szöveg elejéről és végéről
            Book.PublicationYear = year; // A Book kiadási évét a tbYear TextBox-ból vesszük

            DialogResult = true; // A dialógus eredményét igazra állítjuk
            Close(); // Az ablak bezárása
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) // btnCancel_Click eseménykezelő metódus
        {
            DialogResult = false; // A dialógus eredményét hamisra állítjuk
            Close(); // Az ablak bezárása
        }
    }
}
