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

namespace FirstWordAddIn.Panes.Account
{
    /// <summary>
    /// Interaction logic for UserControl4.xaml
    /// </summary>
    public partial class AccountHomeWPF : UserControl
    {
        public AccountHomeWPF()
        {
            InitializeComponent();
            this.DataContext = new AccountViewModel();

        }
        class AccountViewModel : BaseViewModel
        {
            private ICommand _accountCommand;
            private ICommand _licenseCommand;
            private ICommand _contactCommand;

            public ICommand AccountCommand
            {
                get
                {
                    return _accountCommand ?? (_accountCommand = new CommandHandler((obj) => Account(), () => true));
                }
            }
            public ICommand LicenseCommand
            {
                get
                {
                    return _licenseCommand ?? (_licenseCommand = new CommandHandler((obj) => License(), () => true));
                }
            }
            public ICommand ContactCommand
            {
                get
                {
                    return _contactCommand ?? (_contactCommand = new CommandHandler((obj) => Contact(), () => true));
                }
            }
            public async Task Account()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new AccountDetailsWPF();
                controller.DisplayPane(wpf, "Account");
            }
            public async Task License()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new AccountLicenseWPF();
                controller.DisplayPane(wpf, "License");
            }
            public async Task Contact()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new AccountContactWPF();
                controller.DisplayPane(wpf, "Contact");
            }
        }
    }
}
