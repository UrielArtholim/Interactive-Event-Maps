using Interactive_Event_Maps.Models;
using Interactive_Event_Maps.Services.File;
using Interactive_Event_Maps.Services.Github;
using System.Text.Json;

namespace Interactive_Event_Maps.Services.Event
{
	public partial class EventService : IEventService
	{
		private readonly IGitHubService gitHubService;
		private readonly IFileService fileService;
		

		public EventService(IGitHubService gitHubService, IFileService fileService)
		{
			this.gitHubService = gitHubService;
			this.fileService = fileService;
		}

		public async Task<List<SelectableEvent>> GetAvailableEventsAsync()
		{
			List<SelectableEvent> events = [];
			string endpoint = baseUri + "contents/Events";
			string? data = await this.gitHubService.SendTextAPIRequestAsync(endpoint, null, false);
			if(data != null)
			{
				events = GetEventsFromJson(data);
			}			
			return events;
		}		

		
	}
}
