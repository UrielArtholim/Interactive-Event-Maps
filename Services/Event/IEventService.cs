using Interactive_Event_Maps.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Services.Event
{
	public interface IEventService
	{
		public Task<ObservableCollection<EventInformation>> GetAvailableEventsAsync();
	}
}
