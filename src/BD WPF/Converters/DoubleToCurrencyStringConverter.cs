using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class DoubleToCurrencyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (!(value is double)) return DependencyProperty.UnsetValue;
            var valueDouble = (double)value;
            return valueDouble.ToString("C");

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;
            var valueString = (string)value;
            double result;
            double.TryParse(valueString, NumberStyles.Currency, CultureInfo.CurrentCulture, out result);

            return result;
        }
    }
}
