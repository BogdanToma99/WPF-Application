using System.Windows;
using System.Windows.Controls;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for Viewer.xaml
	/// </summary>
	public partial class Viewer : UserControl
	{
		public Viewer()
		{
			InitializeComponent();
		}

		public string ViewerIdStr
		{
			get { return (string)GetValue(ViewerIdStrProperty); }
			set { SetValue(ViewerIdStrProperty, value); }
		}

		public static DependencyProperty ViewerIdStrProperty = DependencyProperty.Register("ViewerIdStr", typeof(string), typeof(Viewer));

		public string LetterStr
		{
			get { return (string)GetValue(LetterStrProperty); }
			set { SetValue(LetterStrProperty, value); }
		}

		public static DependencyProperty LetterStrProperty = DependencyProperty.Register("LetterStr", typeof(string), typeof(Viewer));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(Viewer));

		public string DateStr
		{
			get { return (string)GetValue(DateStrProperty); }
			set { SetValue(DateStrProperty, value); }
		}

		public static DependencyProperty DateStrProperty = DependencyProperty.Register("DateStr", typeof(string), typeof(Viewer));
	}
}
