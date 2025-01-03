// StatusToColorConverter.cs
using System; // Alapvető osztályok
using System.Globalization; // Kulturális beállításokhoz szükséges
using System.Windows.Data; // Az adatkonverzióhoz szükséges interfészek
using System.Windows.Media; // Színek kezeléséhez szükséges névtér

namespace AllatKatalogusApp // Az alkalmazás névtere
{
    public class StatusToColorConverter : IValueConverter // Az osztály az adatkonverzióért felelős
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                // A státusz szöveget színekhez rendelése
                switch (status.ToLower())
                {
                    case "súlyosan veszélyeztetett":
                        return new SolidColorBrush(Colors.Red);
                    case "veszélyeztetett":
                        return new SolidColorBrush(Colors.Orange);
                    default:
                        return new SolidColorBrush(Colors.Green);
                }
            }
            return new SolidColorBrush(Colors.Gray); // Alapértelmezett szürke szín
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // Visszafelé konverzió nem támogatott
        }
    }
}
