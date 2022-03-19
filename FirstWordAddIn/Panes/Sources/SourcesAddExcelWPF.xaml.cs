using FirstWordAddIn.Models;
using FirstWordAddIn.Panes.Results;
using FirstWordAddIn.Service;
using FirstWordAddIn.Services;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstWordAddIn.Panes.Sources
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SourcesAddExcelWPF : System.Windows.Controls.UserControl
    {
        public SourcesAddExcelWPF()
        {
            InitializeComponent();
            this.DataContext = new SourcesAddExcelViewModel();

        }
    }
    class SourcesAddExcelViewModel : BaseViewModel
    {
        public SourcesAddExcelViewModel()
        {
            OldSettingsItems = SettingsService.Instance.DeserializeSettings();
        }

        private ICommand _okCommand;
        private ICommand _addCommand;
        private UserSettings oldSourceItems;
        public UserSettings OldSettingsItems
        {
            get => oldSourceItems;
            set
            {
                oldSourceItems = value;
            }
        }
        private string filePath;
        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }
        private string sourceLabel;
        public string SourceLabel
        {
            get => sourceLabel;
            set
            {
                sourceLabel = value;
                OnPropertyChanged("SourceLabel");
            }
        }
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler((obj) => Ok(), () => true));
            }
        }
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new CommandHandler((obj) => BrowseButton_Click(), () => true));
            }
        }
        private void BrowseButton_Click()
        {
            //System.Windows.MessageBox.Show("test");
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "Spreadsheet (.xls ,.xlsx)|  *.xls ;*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog1.FileName;
            }
        }
        public async Task Ok()
        {    
            var controller = TaskPaneController.Instance;
            List<Source> sources = new List<Source>();
            Source source = new ExcelSheet()
            {
                SourceId = Guid.NewGuid().ToString(),
                Label = SourceLabel,
                FilePath = FilePath,
                Type = 2,
            };
            sources.Add(source);
            oldSourceItems.Sources?.Add(source);
            SettingsService.Instance.SerialiazeSettings(oldSourceItems);
            var wpf = new SuccessPaneWPF("Microsoft Excel", "Source added successfully", "",controller.ClosePane);
            controller.DisplayPane(wpf, "Sources");
            //SettingsService.Instance.ReadExcelFile(FilePath);
        }
    }
}
