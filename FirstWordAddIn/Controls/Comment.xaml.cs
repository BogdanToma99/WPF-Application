using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for Comment.xaml
	/// </summary>
	public partial class Comment : UserControl
	{
		public Comment()
		{
			InitializeComponent();
		}

		public bool IsRightBool
		{
			get { return (bool)GetValue(IsRightBoolProperty); }
			set { SetValue(IsRightBoolProperty, value); }
		}

		public static DependencyProperty IsRightBoolProperty = DependencyProperty.Register("IsRightBool", typeof(bool), typeof(Comment));

		public string CommentIdStr
		{
			get { return (string)GetValue(CommentIdStrProperty); }
			set { SetValue(CommentIdStrProperty, value); }
		}

		public static DependencyProperty CommentIdStrProperty = DependencyProperty.Register("CommentIdStr", typeof(string), typeof(Comment));

		public string TitleStr
		{
			get { return (string)GetValue(TitleStrProperty); }
			set { SetValue(TitleStrProperty, value); }
		}

		public static DependencyProperty TitleStrProperty = DependencyProperty.Register("TitleStr", typeof(string), typeof(Comment));

		public string DateStr
		{
			get { return (string)GetValue(DateStrProperty); }
			set { SetValue(DateStrProperty, value); }
		}

		public static DependencyProperty DateStrProperty = DependencyProperty.Register("DateStr", typeof(string), typeof(Comment));

		public string MessageStr
		{
			get { return (string)GetValue(MessageStrProperty); }
			set { SetValue(MessageStrProperty, value); }
		}

		public static DependencyProperty MessageStrProperty = DependencyProperty.Register("MessageStr", typeof(string), typeof(Comment));

		public ICommand LikeCommand
		{
			get { return (ICommand)GetValue(LikeCommandProperty); }
			set { SetValue(LikeCommandProperty, value); }
		}

		public static DependencyProperty LikeCommandProperty = DependencyProperty.Register("LikeCommand", typeof(ICommand), typeof(Comment));

		public ICommand DislikeCommand
		{
			get { return (ICommand)GetValue(DislikeCommandProperty); }
			set { SetValue(DislikeCommandProperty, value); }
		}

		public static DependencyProperty DislikeCommandProperty = DependencyProperty.Register("DislikeCommand", typeof(ICommand), typeof(Comment));

		public ICommand ReplyCommand
		{
			get { return (ICommand)GetValue(ReplyCommandProperty); }
			set { SetValue(ReplyCommandProperty, value); }
		}

		public static DependencyProperty ReplyCommandProperty = DependencyProperty.Register("ReplyCommand", typeof(ICommand), typeof(Comment));
	}
}
