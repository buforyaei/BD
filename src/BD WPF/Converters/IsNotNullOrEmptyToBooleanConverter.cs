using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class IsNotNullOrEmptyToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return value != null && (((value is string) && value.ToString() != string.Empty) || ((value is IEnumerable<object>) && ((IEnumerable<object>)value).Any()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new InvalidOperationException();
        }
    }
}