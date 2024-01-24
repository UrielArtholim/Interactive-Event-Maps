using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Models
{
	public class Position
	{
		private double _x;
		private double _y;

		public Position(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double X { get => _x; set => _x = value; }
		public double Y { get => _y; set => _y = value; }
	}
}
