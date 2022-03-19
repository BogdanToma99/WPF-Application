using FirstWordAddIn.Panes.Results;
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
using Newtonsoft.Json;
using FirstWordAddIn.Service;
using FirstWordAddIn.Services;
using FirstWordAddIn.Models;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using FirstWordAddIn.Panes.Sources;
using System.Collections.ObjectModel;

namespace FirstWordAddIn.Panes.MergeTags
{

    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MergeTagAddWPF : UserControl
    {
        public MergeTagAddWPF()
        {
            InitializeComponent();
            this.DataContext = new MergeTagAddViewModel();

        }
    }

    class MergeTagAddViewModel : BaseViewModel
    {
        public MergeTagAddViewModel()
        {

            OldSettingsItems = SettingsService.Instance.DeserializeSettings();
            Sources.Clear();
            foreach(var label in OldSettingsItems.Sources)
            {
                Sources.Add(label.Label);
            }
        }


        private ICommand _saveMergeCommand;


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
        

        public ObservableCollection<string> Sources
        {
            get;
        } = new ObservableCollection<string>();

        
        private string source;
        public string Source
        {
            get => source;
            set
            {
                source = value;
                OnPropertyChanged("Source");
                Columns.Clear();
                var ColumnsHeaders = SettingsService.Instance.GetColumnHeaders(source);
                foreach(var col in ColumnsHeaders)
                {
                    Columns.Add(col);
                }
                OnPropertyChanged("Columns");
            }
        }


        public ObservableCollection<string> Columns { get; } = new ObservableCollection<string>();
        private string column;
        public string Column
        {
            get => column;
            set
            {
                column = value;
                OnPropertyChanged("Column");
            }
        }

        public ICommand SaveMergeCommand
        {
            get
            {
                return _saveMergeCommand ?? (_saveMergeCommand = new CommandHandler((obj) => Save(), () => true));
            }
        }

        

        public async Task Save()
        {
            var controller = TaskPaneController.Instance;
            List<MergeTag> mergeTags = new List<MergeTag>();
            MergeTag mergeTag = new MergeTag()
            {
                MergeTagId = Guid.NewGuid().ToString(),
                Label = Label,
                Source = Source,
                Column = Column
            };
            mergeTags.Add(mergeTag);
            oldSourceItems.MergeTags.Add(mergeTag);
            SettingsService.Instance.SerialiazeSettings(oldSourceItems);
            var wpf = new SuccessPaneWPF("Add new merge tag", "Merge tag  added successfully", "",controller.ClosePane);
            controller.DisplayPane(wpf, "Merge tag");


        }
    }
}
