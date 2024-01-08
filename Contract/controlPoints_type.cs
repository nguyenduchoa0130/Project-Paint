using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Contract
{
	public class diagPoint : controlPoint
	{
		public override string type => "diag";
	}
	public class rotatePoint : controlPoint
	{
		public override string type => "rotate";
	}

	public class oneSidePoint : controlPoint
	{
		public override string type => "diag";
		public override string getEdge(double angleDraw)
		{
			string[] edge = { "top", "right", "bottom", "left" };
			int idx = 0;
			if (centrePoint.X == point.X)
				if (centrePoint.Y > point.Y)
					idx = 0;
				else
					idx = 2;
			else
				if(centrePoint.Y == point.Y)
					if (centrePoint.X > point.X)
						idx = 3;
					else
						idx = 1;

			double rot = angleDraw;

			if(rot > 0)
				while(true)
				{
					rot -= 90;
					if (rot < 0)
						break;
					idx++;

					if (idx == 4)
						idx = 0;
				}
			else
				while(true)
				{
					rot += 90;
					if (rot > 0)
						break;
					idx--;
					if (idx == -1)
						idx = 3;
				};
			return edge[idx];
		}

	}

}
