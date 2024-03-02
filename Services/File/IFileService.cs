namespace Interactive_Event_Maps.Services.File
{
	public interface IFileService
	{
		public void CopyDirectory(string sourcePath, string targetPath, bool recursive = true);
		public void RemoveDirectory(string path, bool recursive = true);
		public Task RefreshEventFiles(string eventName, byte[] data);
	}
}
