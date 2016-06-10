using System;
using System.Globalization;
using System.Windows.Data;

namespace BD_WPF.Converters
{
	public class LongMoreThanToBooleanConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
		{
			var valueLong = long.Parse(value.ToString());
			return valueLong > long.Parse(parameter.ToString());
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
		{
			throw new InvalidOperationException();
		}
	}
}