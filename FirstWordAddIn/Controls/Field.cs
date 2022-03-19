using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Regy2.Controls
{
	public interface Field
	{
		string GetText();
		bool IsMandatory();

		string GetName();
		List<JProperty> GetJSON();
	}
}
