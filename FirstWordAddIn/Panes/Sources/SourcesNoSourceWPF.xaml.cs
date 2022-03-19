using Regy2.Controls;
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

namespace FirstWordAddIn.Panes.Sources
{
    /// <summary>
    /// Interaction logic for UserControl4.xaml
    /// </summary>
    public partial class SourcesNoSourceWPF : UserControl
    {
        public SourcesNoSourceWPF()
        {
            InitializeComponent();
            this.DataContext = new SourceNoSourceViewModel();

        }
        class SourceNoSourceViewModel : BaseViewModel
        {
            private ICommand _idScannerCommand;
            private ICommand _excelCommand;
            private ICommand _googleSheetCommand;

            public ICommand IdScannerCommand
            {
                get
                {
                    return _idScannerCommand ?? (_idScannerCommand = new CommandHandler((obj) => IdScanner(), () => true));
                }
            }
            public ICommand ExcelCommand
            {
                get
                {
                    return _excelCommand ?? (_excelCommand = new CommandHandler((obj) => Excel(), () => true));
                }
            }
            public ICommand GoogleCommand
            {
                get
                {
                    return _googleSheetCommand ?? (_googleSheetCommand = new CommandHandler((obj) => Google(), () => true));
                }
            }
            public async Task IdScanner()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new SourcesAddIdScannerWPF();
                controller.DisplayPane(wpf, "Sources");
            }
            public async Task Excel()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new SourcesAddExcelWPF();
                controller.DisplayPane(wpf, "Sources");
            }
            public async Task Google()
            {
                var controller = TaskPaneController.Instance;
                
            }
        }
    }
}
