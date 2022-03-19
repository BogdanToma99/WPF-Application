using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for CheckBox.xaml
	/// </summary>
	public partial class CheckBox : UserControl
	{
		public CheckBox()
		{
			InitializeComponent();
		}

		public string IdStr
		{
			get { return (string)GetValue(IdStrProperty); }
			set { SetValue(IdStrProperty, value); }
		}

		public static DependencyProperty IdStrProperty = DependencyProperty.Register("IdStr", typeof(string), typeof(CheckBox));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(CheckBox));

		public ICommand CheckedCommand
		{
			get { return (ICommand)GetValue(CheckedCommandProperty); }
			set { SetValue(CheckedCommandProperty, value); }
		}

		public static DependencyProperty CheckedCommandProperty = DependencyProperty.Register("CheckedCommand", typeof(ICommand), typeof(CheckBox));
	}
}
