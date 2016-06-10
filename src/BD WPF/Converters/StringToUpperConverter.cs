using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
	public class StringToUpperConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
		{
			if (value == null) return DependencyProperty.UnsetValue;
			var text = value.ToString();
			return text.ToUpper();
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
		{
			throw new InvalidOperationException();
		}
	}
}