using Interactive_Event_Maps.Helpers.Service;
using Interactive_Event_Maps.Models;
using Interactive_Event_Maps.Services.Files;
using Interactive_Event_Maps.Services.GitHub;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Services.Event
{
	public class EventService: IEventService
	{
		private IGitHubService github;

		public EventService() 
		{
			this.github = ServiceHelper.GetService<IGitHubService>() ?? throw new Exception("Service not available: IGitHubService");
		}

		public async Task<ObservableCollection<EventInformation>> GetAvailableEventsAsync()
		{
			ObservableCollection<EventInformation> events = new ObservableCollection<EventInformation>();
			if (!github.IsAuthenticated())
			{
				await MainThread.InvokeOnMainThreadAsync(github.AuthenticateAsync);
			}
			List<string> eventList = await MainThread.InvokeOnMainThreadAsync(github.GetAvailableEventsAsync);
			foreach(string name in eventList)
			{
				events.Add(new EventInformation(name));
			}
			return events; 
		}
	}
}
