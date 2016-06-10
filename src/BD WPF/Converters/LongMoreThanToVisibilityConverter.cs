using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class LongMoreThanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
		{
			var valueLong = long.Parse(value.ToString());
			return valueLong > long.Parse(parameter.ToString()) ? Visibility.Visible : Visibility.Collapsed;
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
		{
			throw new InvalidOperationException();
		}
	}
}