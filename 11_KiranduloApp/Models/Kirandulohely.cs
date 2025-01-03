
// Kirandulohely.cs
using System; // Alapvető osztályok használata

namespace KiranduloApp.Models // Az alkalmazás névtere
{
    public class Kirandulohely // A Kirandulohely osztály a kirándulóhelyek attribútumait reprezentálja
    {
        public int Id { get; set; } // Egyedi azonosító az adatbázisból
        public string Nev { get; set; } // A kirándulóhely neve
        public string Helyszin { get; set; } // A kirándulóhely földrajzi régiója
        public string NehezsegiSzint { get; set; } // A kirándulás nehézségi szintje (Könnyű, Közepes, Nehéz)
        public int LatogatokSzama { get; set; } // Az éves látogatószám
        public double Tav { get; set; } // A kirándulás hossza kilométerben

        // ToString() metódus felülírása a megfelelő megjelenítéshez
        public override string ToString()
        {
            return Nev; // Csak a kirándulóhely neve jelenik meg
        }
    }
}
