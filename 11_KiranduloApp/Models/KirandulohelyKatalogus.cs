
// KirandulohelyKatalogus.cs
using System.Collections.Generic; // A listák kezeléséhez szükséges névtér

namespace KiranduloApp.Models // Az alkalmazás névtere
{
    public partial class KirandulohelyKatalogus // A KirandulohelyKatalogus osztály a kirándulóhelyek gyűjteményét tárolja
    {
        public List<Kirandulohely> Kirandulohelyek { get; set; } = new List<Kirandulohely>(); // Kirándulóhelyek listája

        // Adatok betöltése az adatbázisból
        public void BetoltesAzAdatbazisbol(IEnumerable<Kirandulohely> kirandulohelyAdatok)
        {
            Kirandulohelyek.Clear(); // Előző adatok törlése
            Kirandulohelyek.AddRange(kirandulohelyAdatok); // Új adatok hozzáadása
        }

        // Kirándulóhelyek szűrése egy adott nehézségi szint alapján
        public List<Kirandulohely> Szures(string nehezsegiSzint)
        {
            return Kirandulohelyek.FindAll(k => k.NehezsegiSzint == nehezsegiSzint); // Szűrt lista visszaadása
        }
    }
}
