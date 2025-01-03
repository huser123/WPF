// Etterem.cs
// Az étterem adatmodelljének definíciója

namespace EtteremKatalogus.Models // Az adatmodell névtere
{
    public class Etterem // Az étterem osztály
    {
        public int Id { get; set; } // Az étterem egyedi azonosítója
        public string Nev { get; set; } // Az étterem neve
        public string Varos { get; set; } // Az étterem városa
        public string Cim { get; set; } // Az étterem címe
        public string Arkategoria { get; set; } // Az étterem árkategóriája (Alacsony, Közepes, Magas)
    }
}
