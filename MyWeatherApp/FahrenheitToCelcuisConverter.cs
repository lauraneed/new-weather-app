using System.Globalization;

namespace MyWeatherApp
{
    public class FahrenheitToCelcuisConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            double fahrenheit = (double)value;
            double celcius = (fahrenheit - 32) * 5 / 9;

            return Math.Round(celcius).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
