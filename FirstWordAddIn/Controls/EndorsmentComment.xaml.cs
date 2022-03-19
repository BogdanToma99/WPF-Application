using System.Windows;
using System.Windows.Controls;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for EndorsmentComment.xaml
	/// </summary>
	public partial class EndorsmentComment : UserControl
	{
		public EndorsmentComment()
		{
			InitializeComponent();
		}

		public bool IsValidBool
		{
			get { return (bool)GetValue(IsValidBoolProperty); }
			set { SetValue(IsValidBoolProperty, value); }
		}

		public static DependencyProperty IsValidBoolProperty = DependencyProperty.Register("IsValidBool", typeof(bool), typeof(EndorsmentComment));

		public string AuthorStr
		{
			get { return (string)GetValue(AuthorStrProperty); }
			set { SetValue(AuthorStrProperty, value); }
		}

		public static DependencyProperty AuthorStrProperty = DependencyProperty.Register("AuthorStr", typeof(string), typeof(EndorsmentComment));

		public string DateStr
		{
			get { return (string)GetValue(DateStrProperty); }
			set { SetValue(DateStrProperty, value); }
		}

		public static DependencyProperty DateStrProperty = DependencyProperty.Register("DateStr", typeof(string), typeof(EndorsmentComment));

		public string CommentStr
		{
			get { return (string)GetValue(CommentStrProperty); }
			set { SetValue(CommentStrProperty, value); }
		}

		public static DependencyProperty CommentStrProperty = DependencyProperty.Register("CommentStr", typeof(string), typeof(EndorsmentComment));
	}
}
