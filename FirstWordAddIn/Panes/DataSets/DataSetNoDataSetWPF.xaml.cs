using FirstWordAddIn.Services;
using Microsoft.Office.Interop.Word;
using Regy2.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Application = Microsoft.Office.Interop.Word.Application;
using Paragraph = Microsoft.Office.Interop.Word.Paragraph;

namespace FirstWordAddIn.Panes.DataSets
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class DataSetNoDataSetWPF : UserControl
    {
        public DataSetNoDataSetWPF()
        {
            InitializeComponent();
            this.DataContext = new DataSetNoDataSetViewModel();
        }
    }
    class DataSetNoDataSetViewModel : BaseViewModel
    {
        private ICommand _newDataSetCommand;
        public ICommand NewDataSetCommand
        {
            get
            {
                return _newDataSetCommand ?? (_newDataSetCommand = new CommandHandler((obj) => NewData(), () => true));
            }
        }
        public async System.Threading.Tasks.Task NewData()
        {
            var controller = TaskPaneController.Instance;
            var wpf = new DataSetPaneWPF();
            controller.DisplayPane(wpf, "Data set");
        }
    }
}
