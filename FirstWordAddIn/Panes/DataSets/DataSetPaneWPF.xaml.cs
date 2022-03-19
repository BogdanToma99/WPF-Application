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

namespace FirstWordAddIn.Panes.DataSets
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DataSetPaneWPF : System.Windows.Controls.UserControl
    {
        public DataSetPaneWPF()
        {
            InitializeComponent();
            this.DataContext = new DataSetPaneViewModel();

        }
        class DataSetPaneViewModel : BaseViewModel
        {
            public DataSetPaneViewModel()
            {
                OldSettingsItems = SettingsService.Instance.DeserializeSettings();
                List<Source> SourceItems = new List<Source>();
                List<string> Labels = new List<string>();
                SourceItems = SettingsService.Instance.DeserializeSettings().Sources;
                foreach (var label in SourceItems)
                {
                    Labels.Add(label.Label);
                }
                Sources = Labels;
            }
            private ICommand _saveDataSetCommand;

            private UserSettings oldSourceItems;
            public UserSettings OldSettingsItems
            {
                get => oldSourceItems;
                set
                {
                    oldSourceItems = value;
                }
            }
            private string label;
            public string Label
            {
                get => label;
                set
                {
                    label = value;
                    OnPropertyChanged("Label");
                }
            }
            private List<string> sources;
            public List<string> Sources { get => sources; set => sources = value; }
            private string source;
            public string Source
            {
                get => source;
                set
                {
                    source = value;
                    OnPropertyChanged("Source");
                }
            }
            private string dataSet;
            public string DataSet
            {
                get => dataSet;
                set
                {
                    dataSet = value;
                    OnPropertyChanged("DataSet");
                }
            }
            public ICommand SaveDataSetCommand
            {
                get
                {
                    return _saveDataSetCommand ?? (_saveDataSetCommand = new CommandHandler((obj) => SaveData(), () => true));
                }
            }
            public async Task SaveData()
            {
                var controller = TaskPaneController.Instance;
                List<DataSet> dataSets = new List<DataSet>();
                DataSet dataSet = new DataSet()
                {
                    DataSetId = Guid.NewGuid().ToString(),
                    Label = Label,
                    Source = Source,
                    DataSetMember = DataSet

                };
                dataSets.Add(dataSet);
                oldSourceItems.DataSets.Add(dataSet);
                SettingsService.Instance.SerialiazeSettings(oldSourceItems);
                var wpf = new SuccessPaneWPF("Add data set", "Data set added successfully"," ",controller.ClosePane);
                controller.DisplayPane(wpf, "Data Set");
            }
        }
    }
}
