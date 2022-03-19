using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for CounterField.xaml
	/// </summary>
	public partial class CounterField : UserControl, Field
	{
		private List<ComboField> comboFields;
		private List<ComboField> visibleFields;
		public CounterField(List<ComboField> comboFields)
		{
			InitializeComponent();
			this.comboFields = comboFields;
			this.visibleFields = new List<ComboField>();
			foreach (var cf in comboFields)
			{
				cf.Margin = new Thickness(0, 0, 0, 18);
				if (!((cf.ItemsList.Count == 1 && cf.ItemsList.First().Equals("index")) || (cf.ItemsList.Count == 1 && cf.ItemsList.First().Equals("none"))))
				{
					this.panel.Children.Add(cf);
					visibleFields.Add(cf);
				}
			}
		}

		public string GetText() 
		{
			if (!IsMandatory())
				return null;
			var composedStrList = new List<string>();
			foreach (var field in visibleFields)
				composedStrList.Add(field.GetText());
			return string.Join("/", composedStrList);
		}

		public bool IsMandatory() 
		{
			if (this.panel.Children.Count == 0)
				return false;
			return true;
		}

		public List<JProperty> GetJSON()
		{
			var combos = new List<JProperty>();
			foreach (var combo in comboFields)
			{
				var json = combo.GetJSON();
				if (json != null)
					combos.AddRange(json);
			}

			return combos;
		}

		public string GetName() => this.Name;
	}
}
