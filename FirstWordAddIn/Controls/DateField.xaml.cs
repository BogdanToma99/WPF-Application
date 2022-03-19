using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Regy2.Controls
{
	/// <summary>
	/// Interaction logic for DateField.xaml
	/// </summary>
	public partial class DateField : UserControl, Field
	{
		public DateField()
		{
			InitializeComponent();
		}

		public string DateFormat { get; set; }

		public string TitleStr
		{
			get { return (string)GetValue(TitleStrProperty); }
			set { SetValue(TitleStrProperty, value); }
		}

		public static DependencyProperty TitleStrProperty = DependencyProperty.Register("TitleStr", typeof(string), typeof(DateField));

		public string TextStr
		{
			get { return (string)GetValue(TextStrProperty); }
			set { SetValue(TextStrProperty, value); }
		}

		public static DependencyProperty TextStrProperty = DependencyProperty.Register("TextStr", typeof(string), typeof(DateField));

		public string SubStr
		{
			get { return (string)GetValue(SubStrProperty); }
			set { SetValue(SubStrProperty, value); }
		}

		public static DependencyProperty SubStrProperty = DependencyProperty.Register("SubStr", typeof(string), typeof(DateField));

		public bool IsMandatoryBool
		{
			get { return (bool)GetValue(IsMandatoryBoolProperty); }
			set { SetValue(IsMandatoryBoolProperty, value); }
		}

		public static DependencyProperty IsMandatoryBoolProperty = DependencyProperty.Register("IsMandatoryBool", typeof(bool), typeof(DateField));

		public string GetText() => !string.IsNullOrEmpty(TextStr) ? DateTime.Parse(TextStr).ToString(DateFormat) : string.Empty;
		public bool IsMandatory() => IsMandatoryBool;
		public List<JProperty> GetJSON() => new List<JProperty>() { new JProperty(TitleStr, GetText()) };

		public string GetName() => this.TitleStr;
	}
}
