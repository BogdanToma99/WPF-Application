using FirstWordAddIn.Panes.Sources;
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

namespace FirstWordAddIn.Panes.MergeTags
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class MergeTagNoMergeTagWPF : UserControl
    {
        public MergeTagNoMergeTagWPF()
        {
            InitializeComponent();
            this.DataContext = new MergeNoMergeTagViewModel();


        }
        class MergeNoMergeTagViewModel : BaseViewModel
        {
            private ICommand _newMergeCommand;
            public ICommand NewMergeCommand
            {
                get
                {
                    return _newMergeCommand ?? (_newMergeCommand = new CommandHandler((obj) => NewMerge(), () => true));
                }
            }
            public async Task NewMerge()
            {
                var controller = TaskPaneController.Instance;
                var wpf = new MergeTagAddWPF();
                controller.DisplayPane(wpf, "Merge tag");
            }
        }
    }

}
