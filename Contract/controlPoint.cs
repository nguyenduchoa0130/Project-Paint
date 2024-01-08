using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Contract
{
	public class controlPoint
	{
		protected const int size = 12;
		protected Point2D point;
		protected Point2D centrePoint;

		virtual public string edge { get; set; }
		virtual public string type { get; set; }
		public controlPoint()
		{
			point = new Point2D();
		}

		public void setPoint(double a, double b)
		{
			point.Y = b;
			point.X = a;
		}

		public Point2D getPoint()
		{
			return point;
		}

		virtual public UIElement drawPoint(double angle, Point2D centrePoint)
		{
            UIElement elementPoint = new Ellipse()
			{
				Width = size,
				Fill = Brushes.White,
				Height = size,
				StrokeThickness = size / 5,
				Stroke = Brushes.Black,
			};

			this.centrePoint = centrePoint;

			//elementPoint.RenderTransform = rotateTransform;
			Point pos = new Point(point.X, point.Y);
			Point centre = new Point(centrePoint.X, centrePoint.Y);

			Point afterTransform = VectorTranform.Rotate(pos, angle, centre);

			Canvas.SetLeft(elementPoint, afterTransform.X - size / 2);
			Canvas.SetTop(elementPoint, afterTransform.Y - size / 2);

			return elementPoint;
		}
		virtual public bool isHovering(double angle, double x, double y)
		{
			Point centre = new Point(centrePoint.X, centrePoint.Y);
			Point pos = new Point(point.X, point.Y);

			Point transform = VectorTranform.Rotate(pos, angle, centre);

			return util.isBetween(x, transform.X + 15, transform.X - 15)
				&& util.isBetween(y, transform.Y + 15, transform.Y - 15);
		}

		virtual public string getEdge(double angleDraw)
		{
			int idx;
			string[] edge = { "topleft", "topright", "bottomright", "bottomleft" };
			if (point.X > centrePoint.X)
				if (point.Y > centrePoint.Y)
					idx = 2;
				else
					idx = 1;
			else
				if (point.Y > centrePoint.Y)
				idx = 3;
			else
				idx = 0;

			double rot = angleDraw;

			if (rot > 0)
				while (true)
				{
					rot -= 90;
					if (rot < 0)
						break;
					idx++;

					if (idx == 4)
						idx = 0;
				}
			else
				while (true)
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

		virtual public Point2D handle(double angle, double a, double b)
		{
			Point2D poin2ds = new Point2D();
			poin2ds.Y = b;
			poin2ds.X = a;

			return poin2ds;
		}
	}
}
