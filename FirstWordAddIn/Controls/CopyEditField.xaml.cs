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

namespace Regy2.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CopyEditField : UserControl
    {
        public CopyEditField()
        {
            InitializeComponent();
        }
        public string ImageStr
		{
			get { return (string)GetValue(ImageStrProperty); }
			set { SetValue(ImageStrProperty, value); }
		}

		public static DependencyProperty ImageStrProperty = DependencyProperty.Register("ImageStr", typeof(string), typeof(CopyEditField));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(CopyEditField));

		public string RequestIdStr
		{
			get { return (string)GetValue(RequestIdStrProperty); }
			set { SetValue(RequestIdStrProperty, value); }
		}

		public static DependencyProperty RequestIdStrProperty = DependencyProperty.Register("RequestIdStr", typeof(string), typeof(CopyEditField));

		public ICommand ClickCommand
		{
			get { return (ICommand)GetValue(ClickCommandProperty); }
			set { SetValue(ClickCommandProperty, value);
				Clipboard.SetText(TextStr);
			}
			
		}

		public static DependencyProperty ClickCommandProperty = DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(CopyEditField));
    }
}
