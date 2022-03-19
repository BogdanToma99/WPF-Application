using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for EditField.xaml
	/// </summary>
	public partial class EditField : UserControl, Field
	{
		public EditField()
		{
			InitializeComponent();
		}

		public string TitleStr
		{
			get { return (string)GetValue(TitleStrProperty); }
			set { SetValue(TitleStrProperty, value); }
		}

		public static DependencyProperty TitleStrProperty = DependencyProperty.Register("TitleStr", typeof(string), typeof(EditField));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(EditField));

		public string SubStr
		{
			get { return (string)GetValue(SubStrProperty); }
			set { SetValue(SubStrProperty, value); }
		}

		public static DependencyProperty SubStrProperty = DependencyProperty.Register("SubStr", typeof(string), typeof(EditField));

		public int HeightInt
		{
			get { return (int)GetValue(HeightIntProperty); }
			set { SetValue(HeightIntProperty, value); }
		}

		public static DependencyProperty HeightIntProperty = DependencyProperty.Register("HeightInt", typeof(int), typeof(EditField));

		public bool IsMandatoryBool
		{
			get { return (bool)GetValue(IsMandatoryBoolProperty); }
			set { SetValue(IsMandatoryBoolProperty, value); }
		}

		public static DependencyProperty IsMandatoryBoolProperty = DependencyProperty.Register("IsMandatoryBool", typeof(bool), typeof(EditField));

		public string GetText() => !string.IsNullOrEmpty(TextStr) ? TextStr : string.Empty;
		public bool IsMandatory() => IsMandatoryBool;
		public List<JProperty> GetJSON() => new List<JProperty>() { new JProperty(TitleStr, GetText()) };

		public string GetName() => this.TitleStr;
	}
}
