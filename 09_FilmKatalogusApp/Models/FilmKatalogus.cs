// FilmKatalogus.cs
using System.Collections.Generic; // A listák kezeléséhez szükséges osztályok

namespace FilmKatalogusApp.Models // Az alkalmazás névtere, amely az adatmodelleket tartalmazza
{
    public class FilmKatalogus // A FilmKatalogus osztály a filmek gyűjteményét tárolja
    {
        public List<Film> Filmek { get; set; } = new List<Film>(); // Egy lista, amely a Film objektumokat tárolja
    }
}
