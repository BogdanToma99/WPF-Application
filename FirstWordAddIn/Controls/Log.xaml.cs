using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for Log.xaml
	/// </summary>
	public partial class Log : UserControl
	{
		public Log()
		{
			InitializeComponent();
		}

		
		public string ImageStr
		{
			get { return (string)GetValue(ImageStrProperty); }
			set { SetValue(ImageStrProperty, value); }
		}

		public static DependencyProperty ImageStrProperty = DependencyProperty.Register("ImageStr", typeof(string), typeof(Log));

		public string TitleStr
		{
			get { return (string)GetValue(TitleStrProperty); }
			set { SetValue(TitleStrProperty, value); }
		}

		public static DependencyProperty TitleStrProperty = DependencyProperty.Register("TitleStr", typeof(string), typeof(Log));

		public string DateStr
		{
			get { return (string)GetValue(DateStrProperty); }
			set { SetValue(DateStrProperty, value); }
		}

		public static DependencyProperty DateStrProperty = DependencyProperty.Register("DateStr", typeof(string), typeof(Log));

		public string MessageStr
		{
			get { return (string)GetValue(MessageStrProperty); }
			set { SetValue(MessageStrProperty, value); }
		}

		public static DependencyProperty MessageStrProperty = DependencyProperty.Register("MessageStr", typeof(string), typeof(Log));
	}
}
