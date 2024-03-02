using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Models
{
	public class Activity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Time { get; set; }

		public Activity(string name, string description, string time)
		{
			this.Name = name;
			this.Description = description;
			this.Time = DateTime.Parse(time);
		}
	}
}
