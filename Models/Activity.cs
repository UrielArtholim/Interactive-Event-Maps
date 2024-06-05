using System.Text.Json.Serialization;

namespace Interactive_Event_Maps.Models
{
	public class Activity
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public DateTime StartTime{ get; set; }
		public DateTime EndTime { get; set; }
		
		public Activity(string name, string start, string end, string? description)
		{
			this.Name = name;
			this.Description = description;
			this.StartTime = DateTime.Parse(start);
			this.EndTime = DateTime.Parse(end);
		}
	}
}
