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

namespace FirstWordAddIn.Panes.Sources
{
    /// <summary>
    /// Interaction logic for UserControl5.xaml
    /// </summary>
    public partial class SourcesPurchaseWPF : UserControl
    {
        public SourcesPurchaseWPF()
        {
            InitializeComponent();
            this.DataContext = new SourcesPurchaseViewModel();
        }
    }
    class SourcesPurchaseViewModel : BaseViewModel 
    {
        private ICommand _nextCommand;
        private ICommand _dataCommand;
        private ICommand _authCommand;
        private bool dataBool = false;
        private bool authBool = false;
        public bool DataBool
        {
            get => dataBool;
            set
            {
                dataBool = value;
                OnPropertyChanged("DataBool");
            }
        }
        public bool AuthBool
        {
            get => authBool;
            set
            {
                authBool = value;
                OnPropertyChanged("AuthBool");
            }
        }
        private string pieceNo;
        public string PieceNo
        {
            get => pieceNo;
            set
            {
                pieceNo = value;
                OnPropertyChanged("PieceNo");
            }
        }
        private string person;
        public string Person
        {
            get => person;
            set
            {
                person = value;
                OnPropertyChanged("Person");
            }
        }
        private string phone;
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        private string address;
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public ICommand DataCommand
        {
            get
            {
                return _dataCommand ?? (_dataCommand = new CommandHandler((obj) => DataSelected(), () => true));
            }
        }
        public ICommand AuthCommand
        {
            get
            {
                return _authCommand ?? (_authCommand = new CommandHandler((obj) => AuthSelected(), () => true));
            }
        }
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new CommandHandler((obj) => Next(), () => true));
            }
        }
        public async Task DataSelected()
        {
           dataBool = !dataBool;
        }
        public async Task AuthSelected()
        {
            authBool = !authBool;
        }
        public async Task Next()
        {
            var controller = TaskPaneController.Instance;
            var wpf = new SuccessPaneWPF("ID Scanner purchase order", "Request sent successfully!", "Your request was sent. You will be soon be contacted by someone with the quote details",controller.ClosePane);
            controller.DisplayPane(wpf, "Sources");
        }
    }
}
