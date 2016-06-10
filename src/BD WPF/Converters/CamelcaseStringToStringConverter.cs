using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class CamelcaseStringToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (value == null) return DependencyProperty.UnsetValue;
            var text = value.ToString();
            return Regex.Replace(text, @"(\B[A-Z]+?(?=[A-Z][^A-Z])|\B[A-Z]+?(?=[^A-Z]))", " $1");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new InvalidOperationException();
        }
    }
}