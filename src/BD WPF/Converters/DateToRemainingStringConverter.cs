using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BD_WPF.Converters
{
	public class DateToRemainingStringConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
		{
			if (!(value is DateTime)) return DependencyProperty.UnsetValue;
			var dateTime = (DateTime)value;
			var timeSpan = DateTime.Now - dateTime;
			if (timeSpan.TotalDays > 365)
			{
				var years = Math.Round(timeSpan.TotalDays/365, 0);
				return string.Format("{0} {1}", years, years > 1 ? "years" : "year");
			}
			if (timeSpan.TotalDays > 30)
			{
				var months = (int)(timeSpan.TotalDays / 30);
				return string.Format("{0} {1}", months, months > 1 ? "months" : "month");
			}
			if (timeSpan.TotalDays >= 2)
			{
				var days = (int)(timeSpan.TotalDays);
				return string.Format("{0} {1}", days, days > 1 ? "days" : "day");
			}
			if (timeSpan.TotalDays > 0)
			{
				return "last day";
			}
			return "0 days";
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
		{
			throw new InvalidOperationException();
		}
	}
}
