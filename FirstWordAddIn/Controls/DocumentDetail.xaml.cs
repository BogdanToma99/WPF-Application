using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for TaskDetail.xaml
	/// </summary>
	public partial class DocumentDetail : UserControl
	{
		public DocumentDetail()
		{
			InitializeComponent();
		}

		public string TaskIdStr
		{
			get { return (string)GetValue(TaskIdStrProperty); }
			set { SetValue(TaskIdStrProperty, value); }
		}

		public static DependencyProperty TaskIdStrProperty = DependencyProperty.Register("TaskIdStr", typeof(string), typeof(DocumentDetail));

		public bool IsDeletedBool
		{
			get { return (bool)GetValue(IsDeletedBoolProperty); }
			set { SetValue(IsDeletedBoolProperty, value); }
		}

		public static DependencyProperty IsDeletedBoolProperty = DependencyProperty.Register("IsDeletedBool", typeof(bool), typeof(DocumentDetail));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(DocumentDetail));

		public ICommand DetailsCommand
		{
			get { return (ICommand)GetValue(DetailsCommandProperty); }
			set { SetValue(DetailsCommandProperty, value); }
		}

		public static DependencyProperty DetailsCommandProperty = DependencyProperty.Register("DetailsCommand", typeof(ICommand), typeof(DocumentDetail));
	}
}
