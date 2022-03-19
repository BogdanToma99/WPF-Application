using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for Tag.xaml
	/// </summary>
	public partial class Tag : UserControl
	{
		public Tag()
		{
			InitializeComponent();
		}
		public bool GoToVisibilityBool
		{
			get { return (bool)GetValue(GoToVisibilityBoolProperty); }
			set { SetValue(GoToVisibilityBoolProperty, value); }
		}

		public static DependencyProperty GoToVisibilityBoolProperty = DependencyProperty.Register("GoToVisibilityBool", typeof(bool), typeof(Tag),new PropertyMetadata(true));
		public string TagIdStr
		{
			get { return (string)GetValue(TagIdStrProperty); }
			set { SetValue(TagIdStrProperty, value); }
		}

		public static DependencyProperty TagIdStrProperty = DependencyProperty.Register("TagIdStr", typeof(string), typeof(Tag));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(Tag));
		public string SubTextStr
		{
			get { return (string)GetValue(SubTextStrProperty); }
			set { SetValue(SubTextStrProperty, value); }
		}

		public static DependencyProperty SubTextStrProperty = DependencyProperty.Register("SubTextStr", typeof(string), typeof(Tag));

		public string ColorStr
		{
			get { return (string)GetValue(ColorStrProperty); }
			set { SetValue(ColorStrProperty, value); }
		}

		public static DependencyProperty ColorStrProperty = DependencyProperty.Register("ColorStr", typeof(string), typeof(Tag));

		public ICommand CheckedCommand
		{
			get { return (ICommand)GetValue(CheckedCommandProperty); }
			set { SetValue(CheckedCommandProperty, value); }
		}

		public static DependencyProperty CheckedCommandProperty = DependencyProperty.Register("CheckedCommand", typeof(ICommand), typeof(Tag));

		public ICommand DeleteCommand
		{
			get { return (ICommand)GetValue(DeleteCommandProperty); }
			set { SetValue(DeleteCommandProperty, value); }
		}

		public static DependencyProperty DeleteCommandProperty = DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(Tag));
		public ICommand GoToCommand
		{
			get { return (ICommand)GetValue(GoToCommandProperty); }
			set { SetValue(GoToCommandProperty, value); }
		}

		public static DependencyProperty GoToCommandProperty = DependencyProperty.Register("GoToCommand", typeof(ICommand), typeof(Tag));
	}
}
