using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
	public class DateTimeToStringFormatConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
		{
			if (!(value is DateTime)) return DependencyProperty.UnsetValue;
			var dateTime = (DateTime)value;
			return dateTime.ToString(parameter == null ? string.Empty : parameter.ToString());
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
		{
			throw new InvalidOperationException();
		}
	}
}
