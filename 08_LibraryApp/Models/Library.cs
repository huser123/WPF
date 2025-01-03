using System.Collections.Generic; // using System.Collections.Generic; - A System.Collections.Generic névtérben található osztályokat és interfészeket használjuk ebben a fájlban

namespace LibraryApp.Models // A LibraryApp.Models névtérben található osztályokat és interfészeket definiáljuk ebben a fájlban
{
    public class Library // Library osztályt definiáljuk
    {
        public List<Book> Books { get; set; } = new List<Book>(); // Az osztályban egy Books nevű property-t definiálunk, amely egy Book típusú lista
    }
}
