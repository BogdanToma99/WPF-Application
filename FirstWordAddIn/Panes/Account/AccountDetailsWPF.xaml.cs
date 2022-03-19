using FirstWordAddIn.Panes.Results;
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
    /// Interaction logic for UserControl5.xaml
    /// </summary>
    public partial class AccountDetailsWPF : UserControl
    {
        public AccountDetailsWPF()
        {
            InitializeComponent();
            this.DataContext = new AccountDetailsViewModel();
        }
    }
    class AccountDetailsViewModel : BaseViewModel 
    {
        private ICommand _goToAdminCommand;
        private ICommand _clickCommand1;
        private ICommand _clickCommand2;
        private ICommand _clickCommand3;
        private ICommand _clickCommand4;
        private ICommand _backCommand;

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
        private string userID;
        public string UserID
        {
            get => userID;
            set
            {
                userID = value;
                OnPropertyChanged("UserID");
            }
        }
        private string userEmail;
        public string UserEmail
        {
            get => userEmail;
            set
            {
                userEmail = value;
                OnPropertyChanged("UserEmail");
            }
        }
        private string signUpDate;
        public string SignUpDate
        {
            get => signUpDate;
            set
            {
                signUpDate = value;
                OnPropertyChanged("SignUpDate");
            }
        }
        
        public ICommand NextCommand
        {
            get
            {
                return _goToAdminCommand ?? (_goToAdminCommand = new CommandHandler((obj) => Next(), () => true));
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
        public ICommand ClickCommand4
        {
            get
            {
                return _clickCommand4 ?? (_clickCommand4 = new CommandHandler((obj) => Copy4(), () => true));
            }
        }
        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new CommandHandler((obj) => Back(), () => true));
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
            Clipboard.SetText(UserID);
        }
        public async Task Copy3()
        {
            Clipboard.SetText(UserEmail);
        }
        public async Task Copy4()
        {
            Clipboard.SetText(SignUpDate);
        }
    }
}
