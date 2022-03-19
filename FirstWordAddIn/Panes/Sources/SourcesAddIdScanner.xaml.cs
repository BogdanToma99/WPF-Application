using FirstWordAddIn.Models;
using FirstWordAddIn.Panes.Results;
using FirstWordAddIn.Service;
using FirstWordAddIn.Services;
using IDScanDevicesLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Regy2.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class SourcesAddIdScannerWPF : UserControl
    {
        
        public SourcesAddIdScannerWPF()
        {
            InitializeComponent();
            this.DataContext = new SourcesAddIdScannerViewModel();
            
        }

        
    }
    class SourcesAddIdScannerViewModel : BaseViewModel
    {
        IDScanDevices client;
        public SourcesAddIdScannerViewModel()
        {
            OldSettingsItems = SettingsService.Instance.DeserializeSettings();
            client = new IDScanDevices();
            client.StartScanIDHandler += Client_StartScanIDHandler;
            client.ResetScannerHandler += Client_ResetScannerHandler;
            client.RestartAssureIDHandler += Client_RestartAssureIDHandler;
        }

        private void Client_RestartAssureIDHandler(object sender, ScanEventArgs e)
        {
            
        }

        private void Client_ResetScannerHandler(object sender, ScanEventArgs e)
        {
           
        }

        private void Client_StartScanIDHandler(object sender, ScanEventArgs e)
        {
            
        }
        private ICommand _haveCommand;
        private ICommand _purchaseCommand;
        private ICommand _nextCommand;
        private bool haveSelected = false;
        private bool purchaseSelected = false;

        private UserSettings oldSourceItems;
        public UserSettings OldSettingsItems
        {
            get => oldSourceItems;
            set
            {
                oldSourceItems = value;
            }
        }
        public ICommand HaveCommand
        {
            get
            {
                return _haveCommand ?? (_haveCommand = new CommandHandler((obj) => HasChecked(), () => true));
            }
        }
        public ICommand PurchaseCommand
        {
            get
            {
                return _purchaseCommand ?? (_purchaseCommand = new CommandHandler((obj) => PurchaseChecked(), () => true));
            }
        }
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new CommandHandler((obj) => Next(), () => true));
            }
        }
        public async Task HasChecked()
        {
            haveSelected = !haveSelected;
        }
        public async Task PurchaseChecked()
        {
            purchaseSelected = !purchaseSelected;
        }
        public void  Next()
        {

            client.StartScanID("34", 0);
            var controller = TaskPaneController.Instance;
            if (haveSelected == true)
            {
                purchaseSelected = false;
                List<Source> sources = new List<Source>();
                Source source = new IdScanner()
                {
                    Label = "idscaner 100",
                    HasScanner = haveSelected,
                    Type = 1,
                };
                sources.Add(source);
                oldSourceItems.Sources.Add(source);
                SettingsService.Instance.SerialiazeSettings(oldSourceItems);
                
                var wpf = new SuccessPaneWPF("ID Scanner", "ID Scanner added successfully", "All you need to do is to install the ID Scanner drivers. If you need to purchase a new device, please contact us at contact@unfolding.ro",controller.ClosePane);
                controller.DisplayPane(wpf, "Sources");

            }
            else if (purchaseSelected == true)
            {
                haveSelected = false;
                var wpf = new SourcesPurchaseWPF();
                controller.DisplayPane(wpf, "ID Scanner purchase order");
            }

        }
    }
}
