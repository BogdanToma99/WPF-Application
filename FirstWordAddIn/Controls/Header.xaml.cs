using System.Windows;
using System.Windows.Controls;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for Header.xaml
	/// </summary>
	public partial class Header : UserControl
	{
		public Header()
		{
			InitializeComponent();
		}

		public string HeaderStr
		{
			get { return (string)GetValue(HeaderStrProperty); }
			set { SetValue(HeaderStrProperty, value); }
		}

		public static DependencyProperty HeaderStrProperty = DependencyProperty.Register("HeaderStr", typeof(string), typeof(Header));
	}
}
