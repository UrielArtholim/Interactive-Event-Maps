using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Models
{
	public class Place
	{
		private int id;
		private string name;
		private string description;
		private Position position;
		private List<Activity> activities;
		
		public Place(int id, string name, string description, double x, double y, List<Activity>? activities)
		{
			this.Id = id;
			this.Name = name;	
			this.Description = description;
			this.Position = new Position(x, y);
			this.activities = activities ?? [];
		}

		public int Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public string Description { get => description; set => description = value; }
		public Position Position { get => position; set => position = value; }
		public List<Activity> Activities { get => activities; set => activities = value; }
	}
}
