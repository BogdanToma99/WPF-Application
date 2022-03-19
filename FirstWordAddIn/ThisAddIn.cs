using Office = Microsoft.Office.Core;
using FirstWordAddIn.Ribbon;
using FirstWordAddIn.Services;

namespace FirstWordAddIn
{
    public partial class ThisAddIn
    {
        private Ribbon1 ribbon;
        protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            ribbon = new Ribbon1();
            return ribbon;
        }
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            if (Globals.ThisAddIn != null && Globals.ThisAddIn.Application != null)
            {
                Globals.ThisAddIn.Application.DocumentChange += Application_DocumentChange;
            }
        }

        private void Application_DocumentChange()
        {
            if (Application.Documents.Count >= 1)
            {
                ribbon.UpdateTaskPaneContext(CustomTaskPanes, (Office.DocumentProperties)Application.ActiveDocument.CustomDocumentProperties);
                SettingsService.Instance.DeserializeSettings();
            }
            
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
