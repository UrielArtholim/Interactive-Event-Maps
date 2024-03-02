using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Models
{
	public class SelectableEvent
	{
		public bool IsNameVisible { get; private set; }
		public string Name { get; private set; }
		public string FormattedName { get; private set; }
		public string Image { get; set; }

		public SelectableEvent()
		{
			Name = string.Empty;
			FormattedName = string.Empty;
			IsNameVisible = true;
			Image = string.Empty;
		}

		public SelectableEvent(string name = "")
		{
			Name = name;
			FormattedName = FormatName(name);
			IsNameVisible= true;
			Image = string.Empty;
		}

		protected string FormatName(string name)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.Replace("-", " de "));
		}
	}

	
}
