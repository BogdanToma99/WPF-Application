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
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class AccountContactWPF : UserControl
    {
        public AccountContactWPF()
        {
            InitializeComponent();
            this.DataContext = new AccountContactViewModel();
        }

        class AccountContactViewModel : BaseViewModel
        {
            private ICommand _sendMessageCommand;
            private ICommand _backCommand;
            private string subject;
            public string Subject
            {
                get => subject;
                set
                {
                    subject = value;
                    OnPropertyChanged("Subject");
                }
            }
            private string message;
            public string Message
            {
                get => message;
                set
                {
                    message = value;
                    OnPropertyChanged("Message");
                }
            }
            private List<string> types = new List<string>() { "Technical issue", "Contract/license issue", "Suggestion","Other" };
            public List<string> Types { get => types; set => types = value; }

            private string type;
            public string Type
            {
                get => type;
                set
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
            public ICommand SendMessageCommand
            {
                get
                {
                    return _sendMessageCommand ?? (_sendMessageCommand = new CommandHandler((obj) => Send(), () => true));
                }
            }
            public ICommand BackCommand
            {
                get
                {
                    return _backCommand ?? (_backCommand = new CommandHandler((obj) => Back(), () => true));
                }
            }
            public async Task Send()
            {
                Process.Start("http://www.google.com");
            }
            public async Task Back()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new AccountHomeWPF();
                controller.DisplayPane(wpf, "Account");
            }

        }
    }
}
