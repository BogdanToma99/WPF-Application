using FirstWordAddIn.Models;
using FirstWordAddIn.Panes.Results;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplicationWord = Microsoft.Office.Interop.Word.Application;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace FirstWordAddIn.Panes.DataSets
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DataSetInputWPF : System.Windows.Controls.UserControl
    {
        public DataSetInputWPF(string source)
        {
            InitializeComponent();
            this.DataContext = new DataSetInputViewModel(source);
        }
    }
    class DataSetInputViewModel : BaseViewModel
    {
        
        
        private bool lastLineSelected = false;
        private bool specificLineSelected = false;
        private bool uniqueSelected = false;
        private ICommand _lastLineCommand;
        private ICommand _specificLineCommand;
        private ICommand _uniqueCommand;
        private ICommand _nextCommand;
        private ICommand _addCommand;
        
        public string DataSetSource;

        public DataSetInputViewModel(string source)
        {

            OldSettingsItems = SettingsService.Instance.DeserializeSettings();
            Sources.Clear();
            foreach (var label in OldSettingsItems.Sources)
            {
                Sources.Add(label.Label);
            }
            
            DataSetSource = source;
        }
        public ObservableCollection<string> Sources
        {
            get;
        } = new ObservableCollection<string>();

        private bool lastLineVisibilityBool;
        public bool LastLineVisibilityBool
        {
            get => lastLineVisibilityBool;
            set
            {
                lastLineVisibilityBool = value;
                OnPropertyChanged("LastLineVisibilityBool");
            }
        }
        private bool specificLineVisibilityBool;
        public bool SpecificLineVisibilityBool
        {
            get => specificLineVisibilityBool;
            set
            {
                specificLineVisibilityBool = value;
                OnPropertyChanged("SpecificLineVisibilityBool");
            }
        }
        private bool uniqueVisibilityBool;
        public bool UniqueVisibilityBool
        {
            get => uniqueVisibilityBool;
            set
            {
                uniqueVisibilityBool = value;
                OnPropertyChanged("UniqueVisibilityBool");
            }
        }
        private UserSettings oldSourceItems;
        public UserSettings OldSettingsItems
        {
            get => oldSourceItems;
            set
            {
                oldSourceItems = value;
            }
        }
        private string source;
        public string Source
        {
            get => source;
            set
            {
                source = value;
                OnPropertyChanged("Source");
                ReferenceColumns.Clear();
                var ColumnsHeaders = SettingsService.Instance.GetColumnHeaders(source);
                foreach (var col in ColumnsHeaders)
                {
                    ReferenceColumns.Add(col);
                }
                OnPropertyChanged("ReferenceColumns");
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "docx",
                Filter = "Word File (.docx ,.doc)|*.docx;*.doc",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Path = openFileDialog1.FileName;
            }
        }
        

        
        private int lineNumber;
        public int LineNumber
        {
            get => lineNumber;
            set
            {
                lineNumber = value;
                OnPropertyChanged("LineNumber");
            }
        }
        private string path;
        public string Path
        {
            get => path;
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }
        private string referenceValue;
        public string ReferenceValue
        {
            get => referenceValue;
            set
            {
                referenceValue = value;
                OnPropertyChanged("ReferenceValue");
            }
        }
        public ObservableCollection<string> ReferenceColumns { get; } = new ObservableCollection<string>();
        private string referenceColumn;
        public string ReferenceColumn
        {
            get => referenceColumn;
            set
            {
                referenceColumn = value;
                OnPropertyChanged("Column");
            }
        }
        public ICommand LastLineCommand
        {
            get
            {
                return _lastLineCommand ?? (_lastLineCommand = new CommandHandler((obj) => LastLineChecked(), () => true));
            }

        }
        public ICommand SpecificLineCommand
        {
            get
            {
                return _specificLineCommand ?? (_specificLineCommand = new CommandHandler((obj) => SpecificLineChecked(), () => true));
            }
        }
        public ICommand UniqueCommand
        {
            get
            {
                return _uniqueCommand ?? (_uniqueCommand = new CommandHandler((obj) => UniqueChecked(), () => true));
            }
        }
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new CommandHandler((obj) => Next(), () => true));
            }
        }
        public async Task LastLineChecked()
        {
            lastLineSelected = !lastLineSelected;
            specificLineSelected = uniqueSelected = false;
            SpecificLineVisibilityBool = false;
            UniqueVisibilityBool = false;
        }
        public async Task SpecificLineChecked()
        {
            specificLineSelected = !specificLineSelected;
            lastLineSelected = uniqueSelected = false;
            SpecificLineVisibilityBool = !SpecificLineVisibilityBool;
            UniqueVisibilityBool = false;
        }
        public async Task UniqueChecked()
        {
            uniqueSelected = !uniqueSelected;
            lastLineSelected = specificLineSelected = false;
            UniqueVisibilityBool = !UniqueVisibilityBool;
            SpecificLineVisibilityBool = false;
        }
        public async Task Next()
        {

            SettingsService.Instance.InsertData(lastLineSelected,LineNumber, Path, DataSetSource, ReferenceValue);
            var controller = TaskPaneController.Instance;
            var wpf = new SuccessPaneWPF("ID Scanner", "ID Scanner added successfully", "All you need to do is to install the ID Scanner drivers. If you need to purchase a new device, please contact us at contact@unfolding.ro", controller.ClosePane);
            controller.DisplayPane(wpf, "Sources");
            

        }
    }
}
