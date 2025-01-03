// AdatbazisKapcsolat.cs
// Az adatbázishoz való kapcsolódást biztosító osztály

using System; // Alapvető .NET típusok használatához
using System.Data; // Adatbázis műveletekhez
using MySql.Data.MySqlClient; // MySQL adatbázis kliens használatához

namespace EtteremKatalogus // Névterek a projekt struktúrájához
{
    public class AdatbazisKapcsolat // Adatbázis kapcsolatot kezelő osztály
    {
        private readonly string kapcsolatString; // Az adatbázis kapcsolat elérési adatai

        // Konstruktor az adatbáziskapcsolati adatok inicializálásához
        public AdatbazisKapcsolat()
        {
            kapcsolatString = "Server=sql.domain.tld;Port=3306;Database=student_db;Uid=student_user;Pwd=student_pass;"; // Kapcsolati string beállítása
        }

        // Adatok lekérdezése
        public DataTable Lekerdezes(string sql) // SQL lekérdezés végrehajtása
        {
            DataTable eredmenyTabla = new DataTable(); // Eredményeket tároló adattábla létrehozása

            try // Hibakezelési blokk kezdete
            {
                using (MySqlConnection kapcsolat = new MySqlConnection(kapcsolatString)) // MySQL kapcsolat létrehozása
                {
                    kapcsolat.Open(); // Kapcsolat megnyitása
                    using (MySqlCommand parancs = new MySqlCommand(sql, kapcsolat)) // SQL parancs létrehozása
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(parancs)) // Adatok betöltéséhez adapter létrehozása
                        {
                            adapter.Fill(eredmenyTabla); // Az eredmény feltöltése a táblába
                        }
                    }
                }
            }
            catch (Exception ex) // Hiba esetén
            {
                Console.WriteLine("Hiba történt a lekérdezés során: " + ex.Message); // Hibát kiíró üzenet
            }

            return eredmenyTabla; // Eredménytábla visszaadása
        }

        // Adat módosítása (INSERT, UPDATE, DELETE)
        public bool Modositas(string sql) // Adatbázis módosítás végrehajtása
        {
            try // Hibakezelési blokk kezdete
            {
                using (MySqlConnection kapcsolat = new MySqlConnection(kapcsolatString)) // MySQL kapcsolat létrehozása
                {
                    kapcsolat.Open(); // Kapcsolat megnyitása
                    using (MySqlCommand parancs = new MySqlCommand(sql, kapcsolat)) // SQL parancs létrehozása
                    {
                        parancs.ExecuteNonQuery(); // Parancs végrehajtása
                        return true; // Sikeres módosítás visszajelzése
                    }
                }
            }
            catch (Exception ex) // Hiba esetén
            {
                Console.WriteLine("Hiba történt a módosítás során: " + ex.Message); // Hibát kiíró üzenet
                return false; // Sikertelen módosítás visszajelzése
            }
        }
    }
}
