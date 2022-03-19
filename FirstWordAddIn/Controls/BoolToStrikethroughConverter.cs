using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Regy2.Controls
{
	class BoolToStrikethroughConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			var valid = (bool)value;
			if (valid)
				return TextDecorations.Strikethrough;
			else
				return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var style = (TextDecorationCollection)value;

			return style == null;
		}
	}
}
