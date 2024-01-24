using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.ViewModels.Pages
{
	public class EventSelectorViewModel
	{
		private List<string> events;

		public EventSelectorViewModel() 
		{
			this.events = Task.Run(async () => await GetEventsAsync()).GetAwaiter().GetResult();
		}

		public List<string> Events { get => events; set => events = value; }

		private async Task<List<string>> GetEventsAsync() 
		{
			List<string> events = [];	
			return events; 
		}
	}
}
