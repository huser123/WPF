// AllatKatalogus.cs
using System.Collections.Generic; // A listák kezeléséhez szükséges névtér

namespace AllatKatalogusApp.Models // Az alkalmazás névtere, amely az adatmodelleket tartalmazza
{
    public class AllatKatalogus // Az AllatKatalogus osztály az állatok gyűjteményét tárolja
    {
        public List<Allat> Allatok { get; set; } = new List<Allat>(); // Egy lista, amely az Allat objektumokat tárolja
    }
}
