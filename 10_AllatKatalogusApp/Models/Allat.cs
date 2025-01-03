// Allat.cs
using System; // Az alapvető osztályok használatához szükséges névtér

namespace AllatKatalogusApp.Models // Az alkalmazás névtere, amely az adatmodelleket tartalmazza
{
    public class Allat // Az Allat osztály az állatok attribútumait reprezentálja
    {
        public int Id { get; set; } // Egyedi azonosító az állatok számára
        public string Nev { get; set; } // Az állat neve
        public string Elohely { get; set; } // Az állat természetes élőhelye (pl. erdő, óceán)
        public double Eletkor { get; set; } // Az állat átlagos élettartama években
        public string VeszelyeztetettStatusz { get; set; } // Az állat veszélyeztetett státusza (pl. nem veszélyeztetett, veszélyeztetett)
        public double Meret { get; set; } // Az állat átlagos mérete centiméterben
    }
}
