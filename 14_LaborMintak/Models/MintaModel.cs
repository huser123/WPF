//Models/MintaModel.cs

using System; // A DateTime típushoz szükséges
using System.ComponentModel.DataAnnotations; // Az adatérvényesítő attribútumokhoz ([Key], [Required] stb.)
using System.ComponentModel.DataAnnotations.Schema; // Az [Table] attribútumhoz, ami a táblanevet adja meg

namespace LaborMintak.Models // A modelleket tartalmazó névtér
{
    /// <summary>
    /// Ez az osztály egy laboratóriumi mintát reprezentál.
    /// Az Entity Framework a Minta nevű adatbázis-táblához rendeli.
    /// </summary>
    [Table("Minta")] // Az EF a "Minta" nevű SQL táblát fogja ehhez az osztályhoz kötni
    public class MintaModel
    {
        [Key] // Az elsődleges kulcs az adatbázisban
        public int Id { get; set; } // Egyedi, automatikusan generált azonosító

        [Required(ErrorMessage = "A minta kódja kötelező!")] // A mező kitöltése kötelező
        [StringLength(8, MinimumLength = 8, ErrorMessage = "A kódnak pontosan 8 karakterből kell állnia!")]
        public string Kod { get; set; } = string.Empty; // Egyedi kód, pl. 123AB456 formátumban

        [Required(ErrorMessage = "A beteg neve kötelező!")]
        [StringLength(100)] // Maximum 100 karakter hosszúság
        public string Nev { get; set; } = string.Empty; // A minta leadójának neve (pl. beteg)

        [Required(ErrorMessage = "A minta típusa kötelező!")]
        [StringLength(100)]
        public string Tipus { get; set; } = string.Empty; // A minta típusa (vér, nyál, vizelet stb.)

        public DateTime Erkezes { get; set; } = DateTime.Now; // A minta beérkezési időpontja – automatikusan mostani
    }
}
