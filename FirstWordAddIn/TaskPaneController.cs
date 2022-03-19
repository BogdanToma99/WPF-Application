

using System;
using System.Collections.Generic;
using Core = Microsoft.Office.Core;
using WPF = System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Tools;
using FirstWordAddIn.Panes;
using FirstWordAddIn.Panes.MergeTags;
using FirstWordAddIn.Panes.DataSets;
using FirstWordAddIn.Panes.Sources;
using FirstWordAddIn.Service;
using FirstWordAddIn.Panes.Results;
using FirstWordAddIn.Models;
using FirstWordAddIn.Services;
using FirstWordAddIn.Panes.Account;

namespace FirstWordAddIn
{
	public class TaskPaneController
	{
		private static Lazy<TaskPaneController> lazy;
		private CustomTaskPaneCollection taskPaneCollection;
		private CustomTaskPane lastAddedPane;
		private Core.DocumentProperties properties;
		private string authToken;

		public string EntryId { get; set; }
		public string RegistryId { get; set; }
		public static TaskPaneController CreateInstance(CustomTaskPaneCollection taskPaneCollection, Core.DocumentProperties properties)
		{
			if (lazy == null)
				lazy = new Lazy<TaskPaneController>(() => new TaskPaneController(taskPaneCollection, properties));
			return lazy.Value;
		}

		public static TaskPaneController Instance
		{
			get => lazy.Value;
		}

		private string ReadDocumentProperty(string propertyName)
		{
			foreach (Core.DocumentProperty prop in properties)
			{
				if (prop.Name == propertyName)
				{
					return prop.Value.ToString();
				}
			}
			return null;
		}

		public void RegisterStamp(string id)
		{
			var propVal = ReadDocumentProperty("stamp");
			if (propVal == null)
				properties.Add("stamp", false, Core.MsoDocProperties.msoPropertyTypeString, id);
		}

		private TaskPaneController(CustomTaskPaneCollection taskPaneCollection, Core.DocumentProperties properties)
		{
			this.taskPaneCollection = taskPaneCollection;
			this.properties = properties;
		}

		public void ClosePane()
		{
			taskPaneCollection.Remove((Microsoft.Office.Tools.CustomTaskPane)lastAddedPane);
		}

		public void DisplayPane(WPF.UserControl displayPane, string title)
		{
			if (lastAddedPane != null)
				taskPaneCollection.Remove((Microsoft.Office.Tools.CustomTaskPane)lastAddedPane);

			var hostController = new TaskPaneHostController();
			hostController.WpfElementHost.HostContainer.Children.Add(displayPane);
			lastAddedPane = taskPaneCollection.Add(hostController, title);
			lastAddedPane.Width = 620;
			lastAddedPane.Visible = true;
		}
		public async Task ShowMerge()
		{
			List<MergeTag> mergeTags = SettingsService.Instance.DeserializeSettings().MergeTags;
			if (mergeTags?.Any()!= true)
            {
				var mergeWpf = new MergeTagNoMergeTagWPF();
				DisplayPane(mergeWpf, "Merge tag");
			}
            else
            {
				var mergeWpf = new MergeTagListWPF();
				DisplayPane(mergeWpf, "Merge tag");
			}
		}

		public async Task ShowDataSet()
		{
            List<DataSet> dataSets = SettingsService.Instance.DeserializeSettings().DataSets;
            if (dataSets?.Any() != true)
            {
                var dataSetWpf = new DataSetNoDataSetWPF();
                DisplayPane(dataSetWpf, "Data Set");
            }
            else
            {
                var dataSetWpf = new DataSetListWPF();
                DisplayPane(dataSetWpf, "Data Set");
            }
        }
		public async Task ShowSources()
		{
			List<Source> sources = SettingsService.Instance.DeserializeSettings().Sources;
			if (sources?.Any() != true)
			{
				var sourceWpf = new SourcesNoSourceWPF();
				DisplayPane(sourceWpf, "Sources");
			}
			else
			{
				var sourceWpf = new SourcesListWPF();
				DisplayPane(sourceWpf, "Sources");
			}
		}
		
		public async Task ShowAccount()
        {
			var accountWpf = new AccountHomeWPF();
			DisplayPane(accountWpf, "Account");
        }


	}
}
