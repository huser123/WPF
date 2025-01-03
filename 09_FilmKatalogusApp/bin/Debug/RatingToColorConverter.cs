// RatingToColorConverter.cs
using System; // Alapvető osztályok használata
using System.Globalization; // Kulturális beállításokhoz szükséges osztályok
using System.Windows.Data; // Az adatkonverzióhoz szükséges interfészek
using System.Windows.Media; // Színek kezeléséhez szükséges osztályok

namespace FilmKatalogusApp // Az alkalmazás névtere
{
    // Ez az osztály alakítja az IMDb értékeléseket színekké
    public class RatingToColorConverter : IValueConverter
    {
        // A konvertálás logikája (IMDb értékelés → Szín)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double rating) // Ellenőrizzük, hogy az érték szám-e
            {
                if (rating >= 9.0) // Zöld szín, ha az értékelés 9.0 vagy nagyobb
                    return new SolidColorBrush(Colors.Green);
                else if (rating >= 8.0) // Narancssárga szín, ha az értékelés 8.0–8.9 közötti
                    return new SolidColorBrush(Colors.Orange);
                else // Piros szín, ha az értékelés 7.0–7.9 közötti
                    return new SolidColorBrush(Colors.Red);
            }
            return new SolidColorBrush(Colors.Gray); // Alapértelmezett szürke szín
        }

        // Nem használjuk a visszafelé konvertálást
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
