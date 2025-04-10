//Data/LaborContext.cs

using LaborMintak.Models; // A MintaModel osztály elérhetősége
using Microsoft.EntityFrameworkCore; // Az EF Core DbContext, DbSet, konfigurációk stb.
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // A ServerVersion.AutoDetect() metódushoz szükséges
using System;
using System.Configuration; // Az App.config beolvasásához szükséges névtér

namespace LaborMintak.Data // Az adatbázis-kezeléssel kapcsolatos osztályokat tartalmazó névtér
{
    /// <summary>
    /// Az EF DbContext leszármazottja, amely összeköti az alkalmazást az adatbázissal.
    /// </summary>
    public class LaborContext : DbContext
    {
        // A Minta tábla EF leképzése. Ezáltal lehet lekérdezni, módosítani, törölni.
        public DbSet<MintaModel> Minta { get; set; }

        public LaborContext() { } // Üres konstruktor az EF számára

        public LaborContext(DbContextOptions options) : base(options) { } // Konfigurációs konstruktor

        private static LaborContext? peldany = null; // Singleton minta – csak egy példány használata

        /// <summary>
        /// Visszaadja a DbContext egyetlen példányát.
        /// </summary>
        public static LaborContext GetContext()
        {
            if (peldany == null)
            {
                // Az App.config fájlból beolvassuk a kapcsolatot
                string kapcsolat = ConfigurationManager
                    .ConnectionStrings["labormintakdb"]
                    ?.ConnectionString ?? throw new InvalidOperationException("Hiányzó kapcsolat az App.config fájlban!");

                // EF konfiguráció MySQL szerverhez, automatikus verziófelismeréssel
                var beallitas = new DbContextOptionsBuilder<LaborContext>()
                    .UseMySql(kapcsolat, ServerVersion.AutoDetect(kapcsolat));

                // Kontextus példány létrehozása és adatbázis biztosítása
                peldany = new LaborContext(beallitas.Options);
                peldany.Database.EnsureCreated(); // Ha nincs, létrehozza a táblákat is
            }

            return peldany;
        }
    }
}
