using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class DoubleToRatioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (!(value is double) || !(parameter is double)) return DependencyProperty.UnsetValue;
            var valueDouble = (double)value;
            var parameterDouble = (double)parameter;
            return valueDouble / parameterDouble;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new InvalidOperationException();
        }
    }
}