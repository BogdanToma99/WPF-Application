using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for ComboField.xaml
	/// </summary>
	public partial class ComboField : UserControl, Field
	{
		public ComboField()
		{
			InitializeComponent();
		}

		public string TitleStr
		{
			get { return (string)GetValue(TitleStrProperty); }
			set { SetValue(TitleStrProperty, value); }
		}

		public static DependencyProperty TitleStrProperty = DependencyProperty.Register("TitleStr", typeof(string), typeof(ComboField));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(ComboField));

		public List<string> ItemsList
		{
			get { return (List<string>)GetValue(ItemsListProperty); }
			set { SetValue(ItemsListProperty, value); }
		}

		public static DependencyProperty ItemsListProperty = DependencyProperty.Register("ItemsList", typeof(List<string>), typeof(ComboField));

		public string SubStr
		{
			get { return (string)GetValue(SubStrProperty); }
			set { SetValue(SubStrProperty, value); }
		}

		public static DependencyProperty SubStrProperty = DependencyProperty.Register("SubStr", typeof(string), typeof(ComboField));

		public bool IsMandatoryBool
		{
			get { return (bool)GetValue(IsMandatoryBoolProperty); }
			set { SetValue(IsMandatoryBoolProperty, value); }
		}

		public static DependencyProperty IsMandatoryBoolProperty = DependencyProperty.Register("IsMandatoryBool", typeof(bool), typeof(ComboField));

		public string GetText() => !string.IsNullOrEmpty(TextStr) ? TextStr : string.Empty;
		public bool IsMandatory() => IsMandatoryBool;
		public List<JProperty> GetJSON() 
		{
			if (TextStr == null)
				return new List<JProperty>() { new JProperty(TitleStr, ItemsList.First()) };
			else
				return new List<JProperty>() { new JProperty(TitleStr, GetText()) };
		}

		public string GetName() => this.TitleStr;
	}
}
