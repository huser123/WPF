//Models/VendegModel.cs

using System; // A DateTime típushoz szükséges névtér
using System.ComponentModel.DataAnnotations; // Attribútumokhoz szükséges névtér (pl. [Key], [Required])

namespace KonyvKolcsonzes.Models // A modell osztály a projekt Models névterébe tartozik
{
    /// <summary>
    /// Ez az osztály reprezentál egy vendéget a kölcsönzési rendszerben.
    /// Az Entity Framework automatikusan leképezi ezt az osztályt az adatbázisban lévő Vendeg táblára.
    /// </summary>
    public class VendegModel // A vendég adatait tartalmazó osztály
    {
        [Key] // Ez az attribútum jelzi az EF-nek, hogy az Id mező az elsődleges kulcs (primary key)
        public int Id { get; set; } // Egyedi azonosító – automatikusan növekvő érték az adatbázisban

        [Required(ErrorMessage = "A név megadása kötelező!")] // Az EF-nek jelzi, hogy ez a mező nem lehet null
        public string Nev { get; set; } = string.Empty; // A vendég neve – alapértelmezésben üres string

        [Required(ErrorMessage = "A kártyaszám megadása kötelező!")] // A kártyaszám is kötelező mező
        [StringLength(8, MinimumLength = 8, ErrorMessage = "A kártyaszámnak pontosan 8 karakterből kell állnia!")]
        public string Kartya { get; set; } = string.Empty; // A belépőkártya azonosítója (pl. AB123456) – pontosan 8 karakter

        [Required(ErrorMessage = "A könyv címe nem lehet üres!")] // A könyvcím is kötelező
        public string Konyv { get; set; } = string.Empty; // A kölcsönzött könyv címe

        public DateTime Idopont { get; set; } = DateTime.Now; // A kölcsönzés időpontja – automatikusan a jelenlegi időponttal töltődik ki
    }
}
