using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for RadioButton.xaml
	/// </summary>
	public partial class RadioButton : UserControl
	{
		public RadioButton()
		{
			InitializeComponent();
		}

		public int IndexInt
		{
			get { return (int)GetValue(IndexIntProperty); }
			set { SetValue(IndexIntProperty, value); }
		}

		public static DependencyProperty IndexIntProperty = DependencyProperty.Register("IndexInt", typeof(int), typeof(RadioButton));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(RadioButton));

		public string GroupStr
		{
			get { return (string)GetValue(GroupStrProperty); }
			set { SetValue(GroupStrProperty, value); }
		}

		public static DependencyProperty GroupStrProperty = DependencyProperty.Register("GroupStr", typeof(string), typeof(RadioButton));

		public ICommand CheckedCommand
		{
			get { return (ICommand)GetValue(CheckedCommandProperty); }
			set { SetValue(CheckedCommandProperty, value); }
		}

		public static DependencyProperty CheckedCommandProperty = DependencyProperty.Register("CheckedCommand", typeof(ICommand), typeof(RadioButton));
	}
}
