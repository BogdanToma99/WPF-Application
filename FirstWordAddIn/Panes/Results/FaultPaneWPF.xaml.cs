using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstWordAddIn.Panes.Results
{
	/// <summary>
	/// Interaction logic for UserControl2.xaml
	/// </summary>
	public partial class FaultPaneWPF : UserControl
	{
		public FaultPaneWPF(string header, string title,string text, Action goToNextPane)
		{
			InitializeComponent();
			this.DataContext = new ResultsPaneViewModel(header, title,text,goToNextPane);
		}
	}
}
