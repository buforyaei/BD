using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class IsParameterEqualToIntEnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (value == null || parameter == null) return Visibility.Collapsed;
            return ((int)value).Equals(parameter) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new InvalidOperationException();
        }
    }
}