using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for ConnectionDetail.xaml
	/// </summary>
	public partial class ConnectionDetail : UserControl
	{
		public ConnectionDetail()
		{
			InitializeComponent();
		}

		public string DocIdStr
		{
			get { return (string)GetValue(DocIdStrProperty); }
			set { SetValue(DocIdStrProperty, value); }
		}

		public static DependencyProperty DocIdStrProperty = DependencyProperty.Register("DocIdStr", typeof(string), typeof(ConnectionDetail));

		public string LetterStr
		{
			get { return (string)GetValue(LetterStrProperty); }
			set { SetValue(LetterStrProperty, value); }
		}

		public static DependencyProperty LetterStrProperty = DependencyProperty.Register("LetterStr", typeof(string), typeof(ConnectionDetail));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(ConnectionDetail));

		public ICommand DetailsCommand
		{
			get { return (ICommand)GetValue(DetailsCommandProperty); }
			set { SetValue(DetailsCommandProperty, value); }
		}

		public static DependencyProperty DetailsCommandProperty = DependencyProperty.Register("DetailsCommand", typeof(ICommand), typeof(ConnectionDetail));
	}
}
