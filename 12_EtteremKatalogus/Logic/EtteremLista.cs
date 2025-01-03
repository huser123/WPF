// EtteremLista.cs
// Az éttermek listáját kezelő osztály

using System.Collections.Generic; // Listák és gyűjtemények használatához
using System.Data; // Adatbázis műveletekhez
using EtteremKatalogus.Models; // Az adatmodell osztály eléréséhez

namespace EtteremKatalogus.Logic // A logikai réteg névtere
{
    public class EtteremLista // Az éttermek kezelésére szolgáló osztály
    {
        private readonly AdatbazisKapcsolat adatbazisKapcsolat; // Adatbázis kapcsolat osztály példánya

        public EtteremLista() // Konstruktor az inicializáláshoz
        {
            adatbazisKapcsolat = new AdatbazisKapcsolat(); // Új adatbázis kapcsolat létrehozása
        }

        // Éttermek lekérdezése az adatbázisból
        public List<Etterem> Lekerdezes() // Az összes étterem lekérdezése
        {
            var etteremLista = new List<Etterem>(); // Az éttermek tárolására szolgáló lista

            string sql = "SELECT id, nev, varos, cim, arkategoriak FROM ettermek;"; // SQL lekérdezés szövege
            DataTable eredmeny = adatbazisKapcsolat.Lekerdezes(sql); // Lekérdezés végrehajtása

            foreach (DataRow sor in eredmeny.Rows) // Az eredmény feldolgozása
            {
                etteremLista.Add(new Etterem // Új étterem példány létrehozása
                {
                    Id = (int)sor["id"], // Az étterem azonosítója
                    Nev = sor["nev"].ToString(), // Az étterem neve
                    Varos = sor["varos"].ToString(), // Az étterem városa
                    Cim = sor["cim"].ToString(), // Az étterem címe
                    Arkategoria = sor["arkategoriak"].ToString() // Az étterem árkategóriája
                });
            }

            return etteremLista; // Az éttermek listájának visszaadása
        }

        // Új étterem hozzáadása
        public bool Hozzaadas(Etterem etterem) // Új étterem hozzáadásának metódusa
        {
            string sql = $"INSERT INTO ettermek (nev, varos, cim, arkategoriak) VALUES (\"{etterem.Nev}\", \"{etterem.Varos}\", \"{etterem.Cim}\", \"{etterem.Arkategoria}\");"; // SQL beszúró lekérdezés
            return adatbazisKapcsolat.Modositas(sql); // Lekérdezés végrehajtása és eredmény visszaadása
        }

        // Étterem törlése azonosító alapján
        public bool Torles(int id) // Egy étterem törlése ID alapján
        {
            string sql = $"DELETE FROM ettermek WHERE id = {id};"; // SQL törlő lekérdezés
            return adatbazisKapcsolat.Modositas(sql); // Lekérdezés végrehajtása és eredmény visszaadása
        }

        // Szűrés város alapján
        public List<Etterem> SzuresVarosSzerint(string varos) // Város szerinti szűrés metódusa
        {
            var szurtLista = new List<Etterem>(); // Szűrt lista létrehozása

            string sql = $"SELECT id, nev, varos, cim, arkategoriak FROM ettermek WHERE varos LIKE \"%{varos}%\";"; // SQL szűrő lekérdezés
            DataTable eredmeny = adatbazisKapcsolat.Lekerdezes(sql); // Lekérdezés végrehajtása

            foreach (DataRow sor in eredmeny.Rows) // Az eredmény feldolgozása
            {
                szurtLista.Add(new Etterem // Új étterem példány létrehozása a szűrt adatokból
                {
                    Id = (int)sor["id"], // Az étterem azonosítója
                    Nev = sor["nev"].ToString(), // Az étterem neve
                    Varos = sor["varos"].ToString(), // Az étterem városa
                    Cim = sor["cim"].ToString(), // Az étterem címe
                    Arkategoria = sor["arkategoriak"].ToString() // Az étterem árkategóriája
                });
            }

            return szurtLista; // A szűrt lista visszaadása
        }
    }
}
