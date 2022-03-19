using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for GeneralButton.xaml
	/// </summary>
	public partial class GeneralButton : UserControl
	{
		public GeneralButton()
		{
			InitializeComponent();
		}

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(GeneralButton));

		public ICommand ClickCommand
		{
			get { return (ICommand)GetValue(ClickCommandProperty); }
			set { SetValue(ClickCommandProperty, value); }
		}

		public static DependencyProperty ClickCommandProperty = DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(GeneralButton));
	}
}
