using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
    public class DateStringToDateStringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;
            DateTime dateTime = DateTime.MinValue;
            var valueString = value.ToString();

            try
            {
                string dateTimeString = valueString;
                string shortUsDateFormatString = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                dateTime = DateTime.ParseExact(dateTimeString, shortUsDateFormatString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
            catch (Exception ex)
            {
                Debugger.Break();
            }
            //CultureInfo.InvariantCulture,DateTimeStyles.None

            return dateTime.ToString();
            // Jeżeli value to nei string to zwracasz DependencyProperty.UnsetValue
            // value konwertujesz na DateTime
            // jeżeli się nie da (coś typu TryParse) to zwracasz DependencyProperty.UnsetValue
            // dateTime.ToString(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new InvalidOperationException();
        }
    }
}