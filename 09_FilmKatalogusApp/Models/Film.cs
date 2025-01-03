// Film.cs
using System; // Alapvető osztályok használata

namespace FilmKatalogusApp.Models // Az alkalmazás névtere, amely az adatmodelleket tartalmazza
{
    public class Film // A Film osztály a filmek attribútumait reprezentálja
    {
        public int Id { get; set; } // Egyedi azonosító a filmek számára
        public string Cim { get; set; } // A film címe
        public string Rendező { get; set; } // A film rendezője
        public string Mufaj { get; set; } // A film műfaja (pl. Akció, Dráma)
        public int MegjelenesiEv { get; set; } // A film megjelenési éve
        public double IMDbPontszam { get; set; } // A film IMDb pontszáma 1-től 10-ig terjedő skálán
    }
}
