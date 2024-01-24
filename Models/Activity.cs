using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Models
{
	public class Activity
	{
		private string name;
		private string description;
		private DateTime time;

		public Activity(string name, string description, string time)
		{
			this.Name = name;
			this.Description = description;
			this.Time = DateTime.Parse(time);
		}

		public string Name { get => name; set => name = value; }
		public string Description { get => description; set => description = value; }
		public DateTime Time { get => time; set => time = value; }
	}
}
