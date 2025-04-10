//Program.cs

using System;
using System.Windows;

namespace LaborMintak
{
    /// <summary>
    /// Alkalmazás belépési pontja – a Main metódus elindítja a MainWindow-t.
    /// </summary>
    public class Program : Application
    {
        [STAThread]
        public static void Main()
        {
            var app = new Program();      // Létrehozzuk az alkalmazást
            var ablak = new MainWindow(); // Létrehozzuk a főablakot
            app.Run(ablak);               // Elindítjuk az alkalmazást a főablakkal
        }
    }
}
