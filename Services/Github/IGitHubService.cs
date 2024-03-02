using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Services.Github
{
	public interface IGitHubService
	{
		public Task<string?> SendTextAPIRequestAsync(string endpoint, string? body = null, bool isNewItem = false);
		public Task<byte[]?> SendFileAPIRequestAsync(string endpoint, string? body = null, bool isNewItem = false);
	}
}
