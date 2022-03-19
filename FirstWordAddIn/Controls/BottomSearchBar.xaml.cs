using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for BottomSearchBar.xaml
	/// </summary>
	public partial class BottomSearchBar : UserControl
	{
		public BottomSearchBar()
		{
			InitializeComponent();
		}

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(BottomSearchBar));

		public string ImageResStr
		{
			get { return (string)GetValue(ImageResStrProperty); }
			set { SetValue(ImageResStrProperty, value); }
		}

		public static DependencyProperty ImageResStrProperty = DependencyProperty.Register("ImageResStr", typeof(string), typeof(BottomSearchBar));

		public ICommand ClickCommand
		{
			get { return (ICommand)GetValue(ClickCommandProperty); }
			set { SetValue(ClickCommandProperty, value); }
		}

		public static DependencyProperty ClickCommandProperty = DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(BottomSearchBar));
	}
}
