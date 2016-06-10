using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
	public class BooleanToVisibilityConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
		{
			if (!(value is bool)) return DependencyProperty.UnsetValue;
			var boolean = (bool)value;
			return boolean ? Visibility.Visible : Visibility.Collapsed;
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
		{
			if (!(value is Visibility)) return DependencyProperty.UnsetValue;
			return (Visibility)value == Visibility.Visible;
		}
	}
}