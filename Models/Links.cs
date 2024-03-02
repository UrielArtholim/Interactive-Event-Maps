using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Models
{
	public class Links(string self, string git, string html)
	{
		public string Self { get; set; } = self;
		public string Git { get; set; } = git;
		public string Html { get; set; } = html;
	}
}
