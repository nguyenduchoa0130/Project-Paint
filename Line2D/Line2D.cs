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

		public UIElement Draw(SolidColorBrush brush, int thickness, DoubleCollection dash)
		{
			Line line = new Line()
			{
				X1 = _leftTop.X,
				Y1 = _leftTop.Y,
				X2 = _rightBottom.X,
				Y2 = _rightBottom.Y,
				StrokeThickness = thickness,
				Stroke = brush,
				StrokeDashArray = dash
			};

			var width = Math.Abs(_leftTop.X - _rightBottom.X);
			var height = Math.Abs(_leftTop.Y - _rightBottom.Y);

			RotateTransform transform = new RotateTransform(this._rotateAngle);

			line.RenderTransform = transform;
			return line;
		}
		
		public IShape Clone()
		{
			return new Line2D();
		}
		override public CShape deepCopy()
		{
			Line2D temp = new Line2D();

			temp.LeftTop = this._leftTop.deepCopy();
			temp.RightBottom = this._rightBottom.deepCopy();
			temp._rotateAngle = this._rotateAngle;
			temp.Thickness = this.Thickness;

			if (this.Brush != null)
				temp.Brush = this.Brush.Clone();

			if (this.StrokeDash != null)
				temp.StrokeDash = this.StrokeDash.Clone();

			return temp;
		}
	}
}
