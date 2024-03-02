using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Models
{
	public class Place(int id, string name, string description, double x, double y, List<Activity>? activities)
	{
		public int Id { get; set; } = id;
		public string Name { get; set; } = name;
		public string Description { get; set; } = description;
		public Position Position { get; set; } = new Position(x, y);
		public List<Activity> Activities { get; set; } = activities ?? [];

	}
}
