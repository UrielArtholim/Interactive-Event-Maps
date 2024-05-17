using Interactive_Event_Maps.Helpers.Service;
using Interactive_Event_Maps.Services.Files;
using Interactive_Event_Maps.Services.Settings.SettingsService;
using Octokit;

namespace Interactive_Event_Maps.Services.GitHub
{
	public partial class GitHubService
	{
		private bool isAuthenticated;
		private SettingsService settingsService { get; set; }
		private IFileService fileService { get; set; }
		private GitHubClient gitHubClient { get; set; }
		private readonly Dictionary<string, string> headers;
		public GitHubService()
		{
			this.settingsService = ServiceHelper.GetService<SettingsService>() ?? throw new Exception("Service not available: SettingsService");
			this.fileService = ServiceHelper.GetService<IFileService>() ?? throw new Exception("Service not available: FileService");
			this.gitHubClient = new GitHubClient(new ProductHeaderValue("Interactive-Event-Maps"));
			this.isAuthenticated = false;
			this.headers = new Dictionary<string, string>()
			{
				{"Accept", "application/vnd.github.raw+json" },
				{"Authorization", $"Bearer {settingsService.GetToken()}"},
				{"X-GitHub-Api-Version", "2022-11-28" }
			};
		}
	}
}
