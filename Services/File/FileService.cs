using System.IO.Compression;
using System.Text;

namespace Interactive_Event_Maps.Services.File
{
	public partial class FileService : IFileService
	{
		private readonly string baseFolder = FileSystem.Current.AppDataDirectory;
		private string tempFolder;
		private string eventRootFolder;

		public FileService()
		{
			tempFolder = Path.Combine(baseFolder, "temp");
			eventRootFolder = Path.Combine(baseFolder, "events");
		}

		public void CopyDirectory(string sourcePath, string targetPath, bool recursive)
		{
			DirectoryInfo sourceInfo = new DirectoryInfo(sourcePath);
			if (!sourceInfo.Exists)
				throw new DirectoryNotFoundException($"Source directory not found: {sourceInfo.FullName}");
			
			DirectoryInfo[] directories = sourceInfo.GetDirectories();
			Directory.CreateDirectory(targetPath);
			foreach (FileInfo file in sourceInfo.GetFiles())
			{
				string targetFilePath = Path.Combine(targetPath, file.Name);
				file.CopyTo(targetFilePath);
			}

			if (recursive)
			{
				foreach (DirectoryInfo subdirectory in directories)
				{
					string newTargetDir = Path.Combine(targetPath, subdirectory.Name);
					CopyDirectory(subdirectory.FullName, newTargetDir, true);
				}
			}
		}

		public async Task RefreshEventFiles(string eventName, byte[] data)
		{
			LocateTemporalData(data);
			await UpdateEventData(eventName);
			RemoveDirectory(tempFolder, true);
		}
		private void LocateTemporalData(byte[] data) 
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(data, 0, data.Length);
			ZipFile.ExtractToDirectory(memoryStream, tempFolder, Encoding.UTF8, true);
		}

		private async Task UpdateEventData(string eventName) 
		{
			List<string> tempDirectories = Directory.EnumerateDirectories(tempFolder).ToList();
			Console.WriteLine(tempDirectories);
		}

		public void RemoveDirectory(string path, bool recursive)
		{
			if (Directory.Exists(path))
				Directory.Delete(path, recursive);
		}
	}
}
