using Interactive_Event_Maps.Models;
using System.Text.Json;

namespace Interactive_Event_Maps.Services.Event
{
	public partial class EventService
	{
		
		private string baseUri = "https://api.github.com/repos/UrielArtholim/Interactive-Event-Maps/";
		
		private List<SelectableEvent> GetEventsFromJson(string json)
		{
			List<SelectableEvent> events = [];
			RepositoryDirectory[]? repoEvents = null;
			try
			{
				repoEvents = JsonSerializer.Deserialize<RepositoryDirectory[]>(json, new JsonSerializerOptions() { IncludeFields = true, PropertyNameCaseInsensitive = true });
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			if (repoEvents != null)
			{
				foreach(RepositoryDirectory repoDir in repoEvents) 
				{
					events.Add(new SelectableEvent(repoDir.Name));
				}
			}
			return events;
		}
	}
}
