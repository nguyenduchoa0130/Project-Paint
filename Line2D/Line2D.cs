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
		public SolidColorBrush Brush { get; set; }
		public DoubleCollection StrokeDash { get; set; }
		public string Icon => "Images/line.png";
		public string Name => "Line";

		public int Thickness { get; set; }

		public void HandleStart(double a, double b)
		{
			_leftTop = new Point2D() { X = a, Y = b };
		}

		public void HandleEnd(double a, double b)
		{
			_rightBottom = new Point2D() { X = a, Y = b };
		}

		public UIElement Draw(SolidColorBrush brush, int thickness, DoubleCollection dash)
		{
			Line line = new Line()
			{
				X1 = _leftTop.X,
				X2 = _rightBottom.X,
				Y1 = _leftTop.Y,
				Y2 = _rightBottom.Y,
				Stroke = brush,
				StrokeThickness = thickness,
				StrokeDashArray = dash
			};

			var height = Math.Abs(_leftTop.Y - _rightBottom.Y);
			var width = Math.Abs(_leftTop.X - _rightBottom.X);

			RotateTransform transformDraw = new RotateTransform(this._rotateAngle);

			line.RenderTransform = transformDraw;
			return line;
		}
		override public List<controlPoint> GetControlPoints()
		{
			List<controlPoint> controlPointsDraw = new List<controlPoint>();

			controlPoint diagPointTopLeft2D = new diagPoint();
			diagPointTopLeft2D.setPoint(_leftTop.X, _leftTop.Y);

			controlPoint diagPointBottomLeft2D = new diagPoint();
			diagPointBottomLeft2D.setPoint(_leftTop.X, RightBottom.Y);

			controlPoint diagPointTopRight2D = new diagPoint();
			diagPointTopRight2D.setPoint(_rightBottom.X, _leftTop.Y);

			controlPoint diagPointBottomRight2D = new diagPoint();
			diagPointBottomRight2D.setPoint(_rightBottom.X, _rightBottom.Y);

			//one way control Point

			controlPoint diagPointRight = new oneSidePoint();
			diagPointRight.setPoint(_rightBottom.X, (_rightBottom.Y + _leftTop.Y) / 2);

			controlPoint diagPointLeft = new oneSidePoint();
			diagPointLeft.setPoint(_leftTop.X, (_rightBottom.Y + _leftTop.Y) / 2);

			controlPoint diagPointTop = new oneSidePoint();
			diagPointTop.setPoint((_leftTop.X + _rightBottom.X) / 2, _leftTop.Y);

			controlPoint diagPointBottom = new oneSidePoint();
			diagPointBottom.setPoint((_leftTop.X + _rightBottom.X) / 2, _rightBottom.Y);

			controlPoint moveControlPoint2D = new controlPoint();
			moveControlPoint2D.setPoint((_leftTop.X + _rightBottom.X) / 2, (_leftTop.Y + _rightBottom.Y) / 2);
			moveControlPoint2D.type = "move";

			controlPointsDraw.Add(diagPointTopLeft2D);
			controlPointsDraw.Add(diagPointTopRight2D);
			controlPointsDraw.Add(diagPointBottomLeft2D);
			controlPointsDraw.Add(diagPointBottomRight2D);

			controlPointsDraw.Add(diagPointRight);
			controlPointsDraw.Add(diagPointLeft);
			controlPointsDraw.Add(diagPointBottom);
			controlPointsDraw.Add(diagPointTop);

			controlPointsDraw.Add(moveControlPoint2D);

			return controlPointsDraw;
		}

		public IShape Clone()
		{
			return new Line2D();
		}
		override public CShape deepCopy()
		{
			Line2D line2D = new Line2D();

			line2D.RightBottom = this._rightBottom.deepCopy();
			line2D.LeftTop = this._leftTop.deepCopy();
			line2D._rotateAngle = this._rotateAngle;
			line2D.Thickness = this.Thickness;

			if (this.Brush != null)
				line2D.Brush = this.Brush.Clone();

			if (this.StrokeDash != null)
				line2D.StrokeDash = this.StrokeDash.Clone();

			return line2D;
		}
	}
}
