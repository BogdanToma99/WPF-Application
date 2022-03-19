using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Regy2.Controls
{
	class BoolToAlignmentConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			var valid = (bool)value;
			if (valid)
				return HorizontalAlignment.Right;
			else
				return HorizontalAlignment.Left;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var alignment = (HorizontalAlignment)value;
			var validAlignment = HorizontalAlignment.Right;

			return alignment.Equals(validAlignment);
		}
	}
}
