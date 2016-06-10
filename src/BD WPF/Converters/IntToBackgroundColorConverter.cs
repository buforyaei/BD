using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BD_WPF.Converters
{
    public class IntToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (value == null) return new SolidColorBrush(Colors.White);
            if ((int)value == 2) return new SolidColorBrush(Color.FromArgb(255, 119, 199, 253));
            return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}