using Interactive_Event_Maps.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.ViewModels.Pages
{
	public class EventPageViewModel: BaseViewModel
	{
		public string Name { get; private set; }
		public string FormattedName { get; private set; }


		public EventPageViewModel(string selectedEvent) 
		{ 
			Name = selectedEvent;
			FormattedName = FormatName(selectedEvent);
		}

		private string FormatName(string name)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.Replace("-", " de "));
		}
	}
}
