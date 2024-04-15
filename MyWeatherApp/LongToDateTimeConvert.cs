using System;
using System.Globalization;
//using Xamarin.Forms;

namespace MyWeatherApp
{
    public class LongToDateTimeConverter : IValueConverter
    {
        DateTime _time = new DateTime(2024, 1, 1, 0, 0, 0);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long dateTime = (long)value; 
            return $"{_time.AddSeconds(dateTime).ToString()} UTC"; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
