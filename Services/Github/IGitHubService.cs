using Interactive_Event_Maps.Models;
using Octokit;

namespace Interactive_Event_Maps.Services.GitHub
{
	public interface IGitHubService
	{
		public bool IsAuthenticated();
		public Task AuthenticateAsync();
		public Task<List<string>> GetAvailableEventsAsync();
	}
}
