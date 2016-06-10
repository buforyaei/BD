using System;
using System.Globalization;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class EmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new InvalidOperationException();
        }
    }
}