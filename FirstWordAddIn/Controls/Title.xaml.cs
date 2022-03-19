using System.Windows;
using System.Windows.Controls;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for Title.xaml
	/// </summary>
	public partial class Title : UserControl
	{
		public Title()
		{
			InitializeComponent();
		}

		public string TitleStr
		{
			get { return (string)GetValue(TitleStrProperty); }
			set { SetValue(TitleStrProperty, value); }
		}

		public static DependencyProperty TitleStrProperty = DependencyProperty.Register("TitleStr", typeof(string), typeof(Title));
	}
}
