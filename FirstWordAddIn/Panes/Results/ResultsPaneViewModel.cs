using Regy2.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirstWordAddIn.Panes.Results
{
	class ResultsPaneViewModel : BaseViewModel
	{
		public ResultsPaneViewModel(string header, string title,string text, Action goToNextPane)
		{
			this.header = header;
			this.title = title;
			this.text = text;
			//this.goToNextPane = goToNextPane;
		}

		private string header;
		public string Header
		{
			get => header;
		}

		private string title;
		public string Title
		{
			get => title;
		}
		private string text;
		public string Text
		{
			get => text;
		}
		private Action goToNextPane;
		

		private ICommand _closeCommand;
		public ICommand CloseCommand
		{
			get
			{
				return _closeCommand ?? (_closeCommand = new CommandHandler((obj) => Close(), () => true));
			}
		}


		public void Close()
		{
			var controller = TaskPaneController.Instance;
			controller.ClosePane();
			goToNextPane?.Invoke();
		}

	}
}
