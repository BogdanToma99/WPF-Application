using System;
using System.Globalization;
using System.Windows.Data;

namespace Regy2.Controls
{
	class BoolToTickSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			var valid = (bool)value;
			if (valid)
				return "pack://application:,,,/Regy2;component/Resources/BigTIck.png";
			else
				return "pack://application:,,,/Regy2;component/Resources/X.png";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var source = (string)value;
			var validSource = "pack://application:,,,/Regy2;component/Resources/BigTIck.png";

			return source.Equals(validSource);
		}
	}
}
