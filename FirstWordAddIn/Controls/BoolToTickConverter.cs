using System;
using System.Globalization;
using System.Windows.Data;

namespace Regy2.Controls
{
	public class BoolToTickConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			
			var valid = (bool)value;
			if (valid)
				return "#17CF8D";
			else
				return "#D86344";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var color = (string)value;
			var validColor = "#17CF8D";

			return color.Equals(validColor);
		}
	}
}
