using FirstWordAddIn.Models;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace FirstWordAddIn.Panes.Sources
{
    /// <summary>
    /// Interaction logic for UserControl3.xaml
    /// </summary>
    public partial class SourcesListWPF : UserControl
    {
        public SourcesListWPF()
        {
            InitializeComponent();
            this.DataContext = new SourcesListViewModel();
        }

        class SourcesListViewModel : BaseViewModel
        {
            public SourcesListViewModel()
            {
                OldSettingsItems = SettingsService.Instance.DeserializeSettings();
                SourceItems = OldSettingsItems.Sources;
                foreach (var source in SourceItems)
                {
                    FilteredSources.Add(source);
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
            private List<Source> SourceItems;
            private ICommand _addNewSourceCommand;
            private ICommand _deleteCommand;
            private string searchSource;
            public string SearchSource
            {
                get => searchSource;
                set
                {

                    searchSource = value;
                    OnPropertyChanged("SearchSource");
                    FilteredSources.Clear();
                    var foundSources = SourceItems.Where(s => s.Label.Contains(SearchSource)).ToList();
                    foreach(var source in foundSources)
                    {
                        FilteredSources.Add(source);
                    }
                    OnPropertyChanged("SourceItems");
                }
            }
            public ObservableCollection<Source> FilteredSources { get; } = new ObservableCollection<Source>();
            


            public ICommand DeleteCommand
            {
                get
                {
                    return _deleteCommand ?? (_deleteCommand = new CommandHandler((id) => Delete((string)id), () => true));
                }
            }

            public ICommand AddNewSourceCommand
            {
                get
                {
                    return _addNewSourceCommand ?? (_addNewSourceCommand = new CommandHandler((obj) => NewSourceSet(), () => true));
                }
            }
            public async Task NewSourceSet()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new SourcesNoSourceWPF();
                controller.DisplayPane(wpf, "Sources");
                object word;
                
                try
                {
                    word = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                    Microsoft.Office.Interop.Word.Application app = (Microsoft.Office.Interop.Word.Application)word;
                    var a = app.ActiveDocument.FullName;
                    //If there is a running Word instance, it gets saved into the word variable
                }
                catch (COMException)
                {
                    //If there is no running instance, it creates a new one
                    Type type = Type.GetTypeFromProgID("Word.Application");
                    word = System.Activator.CreateInstance(type);
                }
            }
            public void Delete(string sourceId)
            {
                var ItemToBeRemoved = FilteredSources.Single(r => r.SourceId == sourceId);
                FilteredSources.Remove(ItemToBeRemoved);
                OldSettingsItems.Sources = FilteredSources.ToList();
                SettingsService.Instance.SerialiazeSettings(OldSettingsItems);
            }
        }
    }
}
