using Contract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Rectangle2D
{
    public class Rectangle2D : CShape, IShape
    {
        public SolidColorBrush Brush { get; set; }
        public DoubleCollection StrokeDash { get; set; }

        public string Name => "Rectangle";
        public string Icon => "Images/rectangle.png";

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
            var top = Math.Min(_rightBottom.Y, _leftTop.Y);
            var left = Math.Min(_rightBottom.X, _leftTop.X);

            var bottom = Math.Max(_rightBottom.Y, _leftTop.Y);
            var right = Math.Max(_rightBottom.X, _leftTop.X);

            var height = bottom - top;
            var width = right - left;

            var rect = new Rectangle()
            {
                Height = height,
                Width = width,
                Stroke = brush,
                StrokeThickness = thickness,
                StrokeDashArray = dash
            };

            Canvas.SetTop(rect, top);
            Canvas.SetLeft(rect, left);

            RotateTransform transformDraw = new RotateTransform(this._rotateAngle);
            transformDraw.CenterX = width * 1.0 / 2;
            transformDraw.CenterY = height * 1.0 / 2;

            rect.RenderTransform = transformDraw;

            return rect;
        }

        public IShape Clone()
        {
            return new Rectangle2D();
        }

        override public CShape deepCopy()
        {
            Rectangle2D rectangle2D = new Rectangle2D();

            rectangle2D.LeftTop = this._leftTop.deepCopy();
            rectangle2D._rotateAngle = this._rotateAngle;
            rectangle2D.RightBottom = this._rightBottom.deepCopy();
            rectangle2D.Thickness = this.Thickness;

            if (this.Brush != null)
                rectangle2D.Brush = this.Brush.Clone();

            if (this.StrokeDash != null)
                rectangle2D.StrokeDash = this.StrokeDash.Clone();

            return rectangle2D;
        }
    }
}
