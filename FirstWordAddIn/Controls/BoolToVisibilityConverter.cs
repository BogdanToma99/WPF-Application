using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Regy2.Controls
{
	public class BoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			var valid = (bool)value;
			if (valid)
				return Visibility.Visible;
			else
				return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var source = (Visibility)value;
			var validSource = Visibility.Visible;

			return source.Equals(validSource);
		}
	}
}
