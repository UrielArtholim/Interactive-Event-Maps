using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Services.Github
{
	public partial class GitHubService
	{
		private async Task SetTokenAsync()
		{
			await SecureStorage.Default.SetAsync("github_token", "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");
		}
		private async Task<string?> GetTokenAsync()
		{
			int counter = 3;
			string? token = null;
			while (token == null && counter > 0)
			{
				token = await SecureStorage.Default.GetAsync("github_token");
			}
			if (counter == 0)
			{
				throw new Exception("token not found");
			}
			return token;
		}
	}
}
