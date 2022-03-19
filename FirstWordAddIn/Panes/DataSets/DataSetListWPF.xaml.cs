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
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using FirstWordAddIn.Service;

namespace FirstWordAddIn.Panes.DataSets
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class DataSetListWPF : UserControl
    {
        public DataSetListWPF()
        {
            InitializeComponent();
            this.DataContext = new DataSetListViewModel();
        }
        class DataSetListViewModel : BaseViewModel
        {
            public DataSetListViewModel()
            {
                OldSettingsItems = SettingsService.Instance.DeserializeSettings();
                DataSetItems = OldSettingsItems.DataSets;
                foreach (var dataSet in DataSetItems)
                {
                    FilteredDataSets.Add(dataSet);
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
            
            private List<DataSet> DataSetItems;
            private ICommand _newDataSetCommand;
            private ICommand _searchDataCommand;
            private ICommand _deleteCommand;
            private ICommand _goToCommand;
            private string searchData;
            public string SearchData
            {
                get => searchData;
                set
                {
                    searchData = value;
                    OnPropertyChanged("SearchData");
                    FilteredDataSets.Clear();
                    var foundSources = DataSetItems.Where(s => s.Label.Contains(SearchData)).ToList();
                    foreach (var source in foundSources)
                    {
                        FilteredDataSets.Add(source);
                    }
                    OnPropertyChanged("MergeTagItems");
                }
            }
            public ObservableCollection<DataSet> FilteredDataSets { get; } = new ObservableCollection<DataSet>();
            
            public ICommand NewDataSetCommand
            {
                get
                {
                    return _newDataSetCommand ?? (_newDataSetCommand = new CommandHandler((obj) => NewDataSet(), () => true));
                }
            }
            public ICommand DeleteCommand
            {
                get
                {
                    return _deleteCommand ?? (_deleteCommand = new CommandHandler((id) => Delete((string)id), () => true));
                }
            }
            public ICommand GoToCommand
            {
                get
                {
                    return _goToCommand ?? (_goToCommand = new CommandHandler((id) => GoTo((string)id), () => true));
                }
            }
            public async Task NewDataSet()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new DataSetPaneWPF();
                controller.DisplayPane(wpf, "Data Set");
            }
            
            public async Task Delete(string dataSetId)
            {

                var ItemToBeRemoved = FilteredDataSets.Single(r => r.DataSetId == dataSetId);
                FilteredDataSets.Remove(ItemToBeRemoved);
                OldSettingsItems.DataSets = FilteredDataSets.ToList();
                SettingsService.Instance.SerialiazeSettings(OldSettingsItems);
            }
            public async Task GoTo(string dataSetId)
            {
                var ItemToBeInserted = FilteredDataSets.Single(r => r.DataSetId == dataSetId).DataSetMember;
                object word;
                var dataSetSource = FilteredDataSets.Single(r => r.DataSetId == dataSetId).Source;
               
                //try
                //{
                //    word = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                //    Microsoft.Office.Interop.Word.Application app = (Microsoft.Office.Interop.Word.Application)word;
                //    var doc = app.ActiveDocument;
                //    doc.Content.Text += ItemToBeInserted;

                //}
                //catch (COMException)
                //{
                    
                //    Type type = Type.GetTypeFromProgID("Word.Application");
                //    word = System.Activator.CreateInstance(type);
                //}
                var controller = TaskPaneController.Instance;
                var wpf = new DataSetInputWPF(dataSetSource);
                controller.DisplayPane(wpf, "Data Set");
                //Clipboard.SetText(ItemToBeInserted);
                //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                //Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(@"C:\Users\Bogdan\Desktop\proiect word\test.docx");
                //object missing = System.Reflection.Missing.Value;
                //doc.Content.Text += ItemToBeInserted;
                //app.Visible = true;
                //doc.Save();
               
            }
        }
    }
}
