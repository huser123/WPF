using System; // using System; - A System névtérben található osztályokat és interfészeket használjuk ebben a fájlban

namespace LibraryApp.Models // A LibraryApp.Models névtérben található osztályokat és interfészeket definiáljuk ebben a fájlban
{
    public class Book // Book osztályt definiáljuk
    {
        public int Id { get; set; } // Az osztályban egy Id nevű property-t definiálunk, amely egy egész számot tárol
        public string Title { get; set; } // Az osztályban egy Title nevű property-t definiálunk, amely egy szöveget tárol
        public string Author { get; set; } // Az osztályban egy Author nevű property-t definiálunk, amely egy szöveget tárol
        public string Genre { get; set; } // Az osztályban egy Genre nevű property-t definiálunk, amely egy szöveget tárol
        public int PublicationYear { get; set; } // Az osztályban egy PublicationYear nevű property-t definiálunk, amely egy egész számot tárol
    }
}
