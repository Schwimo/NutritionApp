using System;
using System.Globalization;
using Xamarin.Forms;

namespace NutritionApp.Mobile.Converters
{
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                var doubleValue = (double)value;
                string returnValue = doubleValue.ToString();
                return returnValue;
            }

            throw new ArgumentException("Expected a double value.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                if (double.TryParse((string)value, out double result))
                {
                    return result;
                }
            }

            return 0.0;
        }
    }
}
