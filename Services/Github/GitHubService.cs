using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;

namespace Interactive_Event_Maps.Services.Github
{
	public partial class GitHubService: IGitHubService
	{
		private string Token { get; set; }
		private HttpClient httpClient;
		private JsonSerializerOptions jsonSerializerOptions;
		private Dictionary<string, string> textRequestHeaders;
		private Dictionary<string, string> repoFileRequestHeaders;

		public GitHubService() 
		{
			Task.Run(SetTokenAsync);
			Token = Task.Run(GetTokenAsync).GetAwaiter().GetResult() ?? String.Empty;
			httpClient = new HttpClient();
			jsonSerializerOptions = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
				WriteIndented = true,
			};

			textRequestHeaders = new Dictionary<string, string>();
			textRequestHeaders.Add("Accept", "application/json");
			textRequestHeaders.Add("Authorization", "Bearer " + Token);
			textRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");

			repoFileRequestHeaders = new Dictionary<string, string>();
			repoFileRequestHeaders.Add("Accept", "application/vnd.github+json");
			repoFileRequestHeaders.Add("Authorization", "Bearer " + Token);
			repoFileRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");


		}

		public async Task<string?> SendTextAPIRequestAsync(string endpoint, string? body = null, bool isNewItem = false)
		{
			string? data = default;
			Uri uri = new(endpoint);
			try
			{
				HttpRequestMessage? request = null;
				HttpResponseMessage? response = null;
				if(body == null)
				{
					request = new HttpRequestMessage(HttpMethod.Get, uri);
					foreach(KeyValuePair<string,string> kvp in textRequestHeaders)
					{
						request.Headers.Add(kvp.Key, kvp.Value);
					}
					response = await httpClient.SendAsync(request);
					if (response.IsSuccessStatusCode)
					{
						Debug.WriteLine(@"\tRequest sent successfully");
						data = await response.Content.ReadAsStringAsync();
					}
				}
				else
				{
					StringContent bodyContent = new StringContent(JsonSerializer.Serialize(body, jsonSerializerOptions),Encoding.UTF8, "application/json");
					if(isNewItem)
					{
						request = new HttpRequestMessage(HttpMethod.Post, uri);
						foreach (KeyValuePair<string, string> kvp in textRequestHeaders)
						{
							request.Headers.Add(kvp.Key, kvp.Value);
						}
						response = await httpClient.SendAsync(request);
					}else
					{
						request = new HttpRequestMessage(HttpMethod.Put, uri);
						foreach (KeyValuePair<string, string> kvp in textRequestHeaders)
						{
							request.Headers.Add(kvp.Key, kvp.Value);
						}
						response = await httpClient.PostAsync(endpoint, bodyContent);
					}
					if(response.IsSuccessStatusCode)
					{
						Debug.WriteLine(@"\tRequest sent successfully");
						data = await response.Content.ReadAsStringAsync();
					}
				}				
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}
			return data;
		}

		public async Task<byte[]?> SendFileAPIRequestAsync(string endpoint, string? body, bool isNewItem )
		{
			byte[]? data = default;
			Uri uri = new(endpoint);
			try
			{
				HttpRequestMessage? request = null;
				HttpResponseMessage? response = null;
				if (body == null)
				{
					request = new HttpRequestMessage(HttpMethod.Get, uri);
					foreach (KeyValuePair<string, string> kvp in repoFileRequestHeaders)
					{
						request.Headers.Add(kvp.Key, kvp.Value);
					}
					response = await httpClient.SendAsync(request);
					if (response.IsSuccessStatusCode)
					{
						Debug.WriteLine(@"\tRequest sent successfully");
						data = await response.Content.ReadAsByteArrayAsync();
					}
				}
				else
				{
					StringContent bodyContent = new StringContent(JsonSerializer.Serialize(body, jsonSerializerOptions), Encoding.UTF8, "application/json");
					if (isNewItem)
					{
						request = new HttpRequestMessage(HttpMethod.Post, uri);
						foreach (KeyValuePair<string, string> kvp in repoFileRequestHeaders)
						{
							request.Headers.Add(kvp.Key, kvp.Value);
						}
						response = await httpClient.SendAsync(request);
					}
					else
					{
						request = new HttpRequestMessage(HttpMethod.Put, uri);
						foreach (KeyValuePair<string, string> kvp in repoFileRequestHeaders)
						{
							request.Headers.Add(kvp.Key, kvp.Value);
						}
						response = await httpClient.PostAsync(endpoint, bodyContent);
					}
					if (response.IsSuccessStatusCode)
					{
						Debug.WriteLine(@"\tRequest sent successfully");
						data = await response.Content.ReadAsByteArrayAsync();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}
			return data;
		}

	}
}
