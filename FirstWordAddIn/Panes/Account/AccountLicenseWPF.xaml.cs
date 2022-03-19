using Regy2.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FirstWordAddIn.Panes.Account
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AccountLicenseWPF : UserControl
    {
        public AccountLicenseWPF()
        {
            this.DataContext = new AccountLicenseViewModel();
            InitializeComponent();
        }
        class AccountLicenseViewModel : BaseViewModel
        {
            private ICommand _goToAdminCommand;
            private ICommand _backCommand;
            private ICommand _clickCommand1;
            private ICommand _clickCommand2;
            private ICommand _clickCommand3;
            private string organization;
            public string Organization
            {
                get => organization;
                set
                {
                    organization = value;
                    OnPropertyChanged("Organization");
                }
            }
            private string licenseID;
            public string LicenseID
            {
                get => licenseID;
                set
                {
                    licenseID = value;
                    OnPropertyChanged("LicenseID");
                }
            }
            private string licenseType;
            public string LicenseType
            {
                get => licenseType;
                set
                {
                    licenseType = value;
                    OnPropertyChanged("LicenseType");
                }
            }
            private string expirationDate;
            public string ExpirationDate
            {
                get => expirationDate;
                set
                {
                    expirationDate = value;
                    OnPropertyChanged("ExpirationDate");
                }
            }
            private string usageAvailability;
            public string UsageAvailability
            {
                get => usageAvailability;
                set
                {
                    usageAvailability = value;
                    OnPropertyChanged("UsageAvailability");
                }
            }

            public ICommand NextCommand
            {
                get
                {
                    return _goToAdminCommand ?? (_goToAdminCommand = new CommandHandler((obj) => Next(), () => true));
                }
            }
            public ICommand BackCommand
            {
                get
                {
                    return _backCommand ?? (_backCommand = new CommandHandler((obj) => Back(), () => true));
                }
            }
            public ICommand ClickCommand1
            {
                get
                {
                    return _clickCommand1 ?? (_clickCommand1 = new CommandHandler((obj) => Copy1(), () => true));
                }
            }
            public ICommand ClickCommand2
            {
                get
                {
                    return _clickCommand2 ?? (_clickCommand2 = new CommandHandler((obj) => Copy2(), () => true));
                }
            }
            public ICommand ClickCommand3
            {
                get
                {
                    return _clickCommand3 ?? (_clickCommand3 = new CommandHandler((obj) => Copy3(), () => true));
                }
            }
            

            public async Task Next()
            {
                Process.Start("http://www.google.com");
            }
            public async Task Back()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new AccountHomeWPF();
                controller.DisplayPane(wpf, "Account");
            }
            public async Task Copy1()
            {
                Clipboard.SetText(Organization);
            }
            public async Task Copy2()
            {
                Clipboard.SetText(LicenseID);
            }
            public async Task Copy3()
            {
                Clipboard.SetText(ExpirationDate);
            }
            
            
        }
    }
}
