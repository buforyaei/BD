using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
	public class BooleanToOppositeBooleanConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
		{
			if (!(value is bool)) return DependencyProperty.UnsetValue;
			var boolean = (bool)value;
			return !boolean;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
		{
			if (!(value is bool) || targetType != typeof(bool))
				return DependencyProperty.UnsetValue;
			return !(bool)value;
		}
	}
}