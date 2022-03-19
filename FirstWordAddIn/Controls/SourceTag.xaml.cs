using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SourceTag : UserControl
    {
        public SourceTag()
        {
            InitializeComponent();
        }
		public string TagIdStr
		{
			get { return (string)GetValue(TagIdStrProperty); }
			set { SetValue(TagIdStrProperty, value); }
		}

		public static DependencyProperty TagIdStrProperty = DependencyProperty.Register("TagIdStr", typeof(string), typeof(SourceTag));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(SourceTag));
		public string SubTextStr
		{
			get { return (string)GetValue(SubTextStrProperty); }
			set { SetValue(SubTextStrProperty, value); }
		}

		public static DependencyProperty SubTextStrProperty = DependencyProperty.Register("SubTextStr", typeof(string), typeof(SourceTag));

		public string ColorStr
		{
			get { return (string)GetValue(ColorStrProperty); }
			set { SetValue(ColorStrProperty, value); }
		}

		public static DependencyProperty ColorStrProperty = DependencyProperty.Register("ColorStr", typeof(string), typeof(SourceTag));

		public ICommand CheckedCommand
		{
			get { return (ICommand)GetValue(CheckedCommandProperty); }
			set { SetValue(CheckedCommandProperty, value); }
		}

		public static DependencyProperty CheckedCommandProperty = DependencyProperty.Register("CheckedCommand", typeof(ICommand), typeof(SourceTag));

		public ICommand DeleteCommand
		{
			get { return (ICommand)GetValue(DeleteCommandProperty); }
			set { SetValue(DeleteCommandProperty, value); }
		}

		public static DependencyProperty DeleteCommandProperty = DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(SourceTag));
		public ICommand GoToCommand
		{
			get { return (ICommand)GetValue(GoToCommandProperty); }
			set { SetValue(GoToCommandProperty, value); }
		}

		public static DependencyProperty GoToCommandProperty = DependencyProperty.Register("GoToCommand", typeof(ICommand), typeof(SourceTag));
	}
}

