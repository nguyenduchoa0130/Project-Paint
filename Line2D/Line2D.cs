using Contract;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Line2D
{
	public class Line2D : CShape, IShape
	{
		public DoubleCollection StrokeDash { get; set; }

		public SolidColorBrush Brush { get; set; }
		public string Name => "Line";
		public string Icon => "Images/line.png";

		public int Thickness { get; set; }

		public void HandleStart(double x, double y)
		{
			_leftTop = new Point2D() { X = x, Y = y };
		}

		public void HandleEnd(double x, double y)
		{
			_rightBottom = new Point2D() { X = x, Y = y };
		}

	}
}
