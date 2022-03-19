using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace FirstWordAddIn.Panes
{
    public partial class TaskPaneHostController : UserControl
    {
        public TaskPaneHostController()
        {
            InitializeComponent();
            wpfHost.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
        }



            public ElementHost WpfElementHost
        {
            get
            {
                return this.wpfHost;
            }
        }
    }
}
