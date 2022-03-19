using FirstWordAddIn.Properties;
using Microsoft.Office.Core;
using Microsoft.Office.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon1();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace FirstWordAddIn.Ribbon
{
    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private TaskPaneController controller;
        private DocumentProperties properties;

        public Ribbon1()
        {

        }
        public void UpdateTaskPaneContext(CustomTaskPaneCollection taskPaneCollection, DocumentProperties properties) => this.controller = TaskPaneController.CreateInstance(taskPaneCollection, properties);
        public Bitmap GetLogo(IRibbonControl control) => Resources.Account;
        public Bitmap GetMergeImage(IRibbonControl control) => Resources.Merge;
        public Bitmap GetDataImage(IRibbonControl control) => Resources.Data;
        public Bitmap GetSourcesImage(IRibbonControl control) => Resources.Sources;
        //public void GoToRegy(IRibbonControl control) => Process.Start("https://unfolding.ro/");

        [STAThread]
        public async void Merge(IRibbonControl control)
        {
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            await controller.ShowMerge();
        }

        [STAThread]
        public async void Data(IRibbonControl control)
        {
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            await controller.ShowDataSet();
        }

        [STAThread]
        public async void Sources(IRibbonControl control)
        {
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            await controller.ShowSources();
        }

        [STAThread]
        public async void Account(IRibbonControl control)
        {
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            await controller.ShowAccount();
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("FirstWordAddIn.Ribbon1.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
