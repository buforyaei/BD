using System;
using System.Globalization;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class StringToStringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            var text = value.ToString();
            return string.Format(parameter.ToString(), text);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new InvalidOperationException();
        }
    }
}