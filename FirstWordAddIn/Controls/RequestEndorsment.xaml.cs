using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for RequestEndorsment.xaml
	/// </summary>
	public partial class RequestEndorsment : UserControl
	{
		public RequestEndorsment()
		{
			InitializeComponent();
		}

		public string ImageStr
		{
			get { return (string)GetValue(ImageStrProperty); }
			set { SetValue(ImageStrProperty, value); }
		}

		public static DependencyProperty ImageStrProperty = DependencyProperty.Register("ImageStr", typeof(string), typeof(RequestEndorsment));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(RequestEndorsment));

		public string RequestIdStr
		{
			get { return (string)GetValue(RequestIdStrProperty); }
			set { SetValue(RequestIdStrProperty, value); }
		}

		public static DependencyProperty RequestIdStrProperty = DependencyProperty.Register("RequestIdStr", typeof(string), typeof(RequestEndorsment));

		public ICommand ClickCommand
		{
			get { return (ICommand)GetValue(ClickCommandProperty); }
			set { SetValue(ClickCommandProperty, value); }
		}

		public static DependencyProperty ClickCommandProperty = DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(RequestEndorsment));
	}
}
