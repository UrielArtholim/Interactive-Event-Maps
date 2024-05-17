using System.Text.Json.Serialization;

namespace Interactive_Event_Maps.Models
{
	public class RepositoryDirectory
	{
		[JsonConstructor]
		public RepositoryDirectory()
		{
			Name = String.Empty;
			Path = String.Empty;
			Sha = String.Empty;
			Size = 0;
			Url = String.Empty;
			Html_url = String.Empty;
			Git_url = String.Empty;
			Download_url = String.Empty;
			Type = String.Empty;
			_Links = new Links(String.Empty, String.Empty, String.Empty);
		}

		public RepositoryDirectory(string name, string path, string sha, double size, string url, string html_url, string git_url,
			string download_url, string type, string self, string git, string html)
		{
			this.Name = name;
			this.Path = path;
			this.Sha = sha;
			this.Size = size;
			this.Url = url;
			this.Html_url = html_url;
			this.Git_url = git_url;
			this.Download_url = download_url;
			this.Type = type;
			this._Links = new Links(self, git, html);
		}

		public string Name { get; set; }
		public string Path { get; set; }
		public string Sha { get; set; }
		public double Size { get; set; }
		public string Url { get; set; }
		public string Html_url { get; set; }
		public string Git_url { get; set; }
		public string Download_url { get; set; }
		public string Type { get; set; }
		public Links _Links { get; set; }
	}
}
