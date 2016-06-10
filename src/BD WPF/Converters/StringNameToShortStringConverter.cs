using System;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class StringNameToShortStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (value == null) return DependencyProperty.UnsetValue;
            var text = value.ToString();
            var words = text.Split(' ');
            if (words.Length > 1)
            {
                var shorNameBuilder = new StringBuilder();
                if (words[0].Length > 1)
                {
                    shorNameBuilder.Append(words[0].Substring(0, 1));
                    shorNameBuilder.Append(".");
                }
                else
                {
                    shorNameBuilder.Append(words[0]);
                }
                for (var i = 1; i < words.Length; i++)
                {
                    shorNameBuilder.Append(" ");
                    shorNameBuilder.Append(words[i]);
                }
                return shorNameBuilder.ToString();
            }
            else
            {
                return text;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new InvalidOperationException();
        }
    }
}