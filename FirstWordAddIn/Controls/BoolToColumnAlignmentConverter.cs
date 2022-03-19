using System;
using System.Globalization;
using System.Windows.Data;

namespace Regy2.Controls
{
	class BoolToColumnAlignmentConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			var valid = (bool)value;
			if (valid)
				return 1;
			else
				return 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var alignment = (int)value;
			var validAlignment = 1;

			return alignment.Equals(validAlignment);
		}
	}
}
