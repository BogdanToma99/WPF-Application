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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace FirstWordAddIn.Panes.MergeTags
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class MergeTagListWPF : UserControl
    {
        public MergeTagListWPF()
        {
            InitializeComponent();
            this.DataContext = new MergeTagListViewModel();

        }
        class MergeTagListViewModel : BaseViewModel
        {
            public MergeTagListViewModel()
            {
                OldSettingsItems = SettingsService.Instance.DeserializeSettings();
                MergeTagItems = OldSettingsItems.MergeTags;
                foreach (var mergeTag in MergeTagItems)
                {
                    FilteredMergeTags.Add(mergeTag);
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


            private List<MergeTag> MergeTagItems;
            
            private ICommand _deleteCommand;
            private ICommand _newMergeCommand;
            private ICommand _goToCommand;
            private string searchMergeTag;
            public string SearchMergeTag
            {
                get => searchMergeTag;
                set
                {
                    searchMergeTag = value;
                    OnPropertyChanged("SearchMergeTag");
                    FilteredMergeTags.Clear();
                    var foundSources = MergeTagItems.Where(s => s.Label.Contains(SearchMergeTag)).ToList();
                    foreach (var source in foundSources)
                    {
                        FilteredMergeTags.Add(source);
                    }
                    OnPropertyChanged("MergeTagItems");
                }
            }
            public ObservableCollection<MergeTag> FilteredMergeTags { get; } = new ObservableCollection<MergeTag>();
            public ICommand NewMergeCommand
            {
                get
                {
                    return _newMergeCommand ?? (_newMergeCommand = new CommandHandler((obj) => NewMerge(), () => true));
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
            public async Task NewMerge()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new MergeTagAddWPF();
                controller.DisplayPane(wpf, "Merge tag");
            }
            public async Task Delete(string dataSetId)
            {

                var ItemToBeRemoved = FilteredMergeTags.Single(r => r.MergeTagId == dataSetId);
                FilteredMergeTags.Remove(ItemToBeRemoved);
                OldSettingsItems.MergeTags = FilteredMergeTags.ToList();
                SettingsService.Instance.SerialiazeSettings(OldSettingsItems);
            }
            public async Task GoTo(string dataSetId)
            {
                var ItemToBeInserted = FilteredMergeTags.Single(r => r.MergeTagId == dataSetId).Column;
                object word;
                try
                {
                    word = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                    Microsoft.Office.Interop.Word.Application app = (Microsoft.Office.Interop.Word.Application)word;
                    var doc = app.ActiveDocument;
                    doc.Content.Text += $"{{{ItemToBeInserted}}}";
                    //If there is a running Word instance, it gets saved into the word variable
                }
                catch (COMException)
                {
                    //If there is no running instance, it creates a new one
                    Type type = Type.GetTypeFromProgID("Word.Application");
                    word = System.Activator.CreateInstance(type);
                }
                //Clipboard.SetText($"{{{ItemToBeInserted}}}");
                //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                //Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(@"C:\Users\Bogdan\Desktop\proiect word\test.docx");
                //object missing = System.Reflection.Missing.Value;
                //doc.Content.Text += $"{{{ItemToBeInserted}}}";
                //app.Visible = true;
                //doc.Save();
            }
        }

    }
}
