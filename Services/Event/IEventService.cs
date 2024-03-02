using Interactive_Event_Maps.Models;

namespace Interactive_Event_Maps.Services.Event
{
	public interface IEventService
	{
		Task<List<SelectableEvent>> GetAvailableEventsAsync();
	}
}
