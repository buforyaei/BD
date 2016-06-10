using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
	public class StringToLowerConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
		{
			if (value == null) return DependencyProperty.UnsetValue;
			var text = value.ToString();
			return text.ToLower();
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
		{
			throw new InvalidOperationException();
		}
	}
}