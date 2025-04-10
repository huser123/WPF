//Data/AppContext.cs

using KonyvKolcsonzes.Models; // A VendegModel osztály használatához szükséges
using Microsoft.EntityFrameworkCore; // Az EF Core DbContext és konfigurációs osztályaihoz szükséges
using System.Configuration; // A kapcsolati string beolvasásához szükséges
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // <- fontos!

namespace KonyvKolcsonzes.Data
{
    /// <summary>
    /// Az AppContext az EF adatbázis-kezelője, mely az adatbázis és a modell között biztosít kapcsolatot.
    /// </summary>
    public class AppContext : DbContext // -> public!
    {
        public DbSet<VendegModel> Vendeg { get; set; } // A Vendeg tábla C# megfelelője

        public AppContext() { } // Alapértelmezett konstruktor – szükséges az EF számára

        public AppContext(DbContextOptions options) : base(options) { }
        // Opcionális konstruktor – ha paraméteresen akarjuk példányosítani.
        // Ez a konstruktor egy DbContextOptions típusú paramétert vár (ez tartalmazza pl. az adatbázis típusát, kapcsolat sztringet stb.).

        // FIGYELEM: Az OnConfiguring metódust teljesen elhagyjuk, mert a kapcsolat az App.config-ból jön!

        private static AppContext? context = null; // Privát példány a singleton működéshez -> ? jelentése -> lehet null is az értéke

        /// <summary>
        /// A GetContext metódus visszaadja az AppContext példányt, és betölti a kapcsolatot az App.config fájlból.
        /// </summary>
        public static AppContext GetContext() // Statikus metódus, ami egy AppContext példányt ad vissza (singleton módon)
        {
            if (context == null) // Ha még nem jött létre a context (azaz még nem példányosítottuk az adatbáziskapcsolatot)...
            {
                string constStr = ConfigurationManager
                    .ConnectionStrings["KonyvKolcsonzesdb"] // Kikeressük a nevünk alapján a connection stringet az App.config fájlból
                    ?.ConnectionString ?? throw new InvalidOperationException("Hiányzó connection string az App.config fájlban.");
                    // Ha nem találjuk, kivételt dobunk, így nem megyünk tovább hibás állapottal

                var optionsBuilder = new DbContextOptionsBuilder<AppContext>() // Létrehozunk egy DbContextOptionsBuilder-t, AppContext típusra
                    .UseMySql(constStr, ServerVersion.AutoDetect(constStr));   // Beállítjuk, hogy MySQL-t használunk, a szerver verzióját automatikusan felismeri

                context = new AppContext(optionsBuilder.Options); // Létrehozzuk az AppContext példányt a beállított opciókkal
                context.Database.EnsureCreated(); // Ellenőrizzük, hogy az adatbázis létezik-e, ha nem, akkor automatikusan létrehozza
            }

            return context; // Visszatérünk az AppContext példánnyal (akár új, akár korábban létrehozott)
        }

    }
}
