using Contract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Ellipse2D
{
    public class Ellipse2D : CShape, IShape
    {
        public DoubleCollection StrokeDash { get; set; }
        public int Thickness { get; set; }

        public SolidColorBrush Brush { get; set; }
        public string Icon => "Images/ellipse.png";
        public string Name => "Ellipse";


        public void HandleStart(double a, double b)
        {
            _leftTop.Y = b;
            _leftTop.X = a;
        }

        public void HandleEnd(double m, double n)
        {
            _rightBottom.X = m;
            _rightBottom.Y = n;
        }

        public UIElement Draw(SolidColorBrush brush, int thickness, DoubleCollection dash)
        {
            var left = Math.Min(_rightBottom.X, _leftTop.X);
            var top = Math.Min(_rightBottom.Y, _leftTop.Y);

            var right = Math.Max(_rightBottom.X, _leftTop.X);
            var bottom = Math.Max(_rightBottom.Y, _leftTop.Y);

            var width = right - left;
            var height = bottom - top;

            var ellipseDraw = new Ellipse()
            {
                Height = height,
                Width = width,
                Stroke = brush,
                StrokeThickness = thickness,
                StrokeDashArray = dash

            };

            Canvas.SetLeft(ellipseDraw, left);
            Canvas.SetTop(ellipseDraw, top);

            RotateTransform transformDraw = new RotateTransform(this._rotateAngle);
            transformDraw.CenterY = height * 1.0 / 2;
            transformDraw.CenterX = width * 1.0 / 2;

            ellipseDraw.RenderTransform = transformDraw;
            return ellipseDraw;
        }

        public IShape Clone()
        {
            return new Ellipse2D();
        }
        override public CShape deepCopy()
        {
            Ellipse2D ellipse2D = new Ellipse2D();
            ellipse2D.RightBottom = this._rightBottom.deepCopy();
            ellipse2D.LeftTop = this._leftTop.deepCopy();
            ellipse2D._rotateAngle = this._rotateAngle;
            ellipse2D.Thickness = this.Thickness;
           
            if (this.StrokeDash != null)
                ellipse2D.StrokeDash = this.StrokeDash.Clone();
            if (this.Brush != null)
                ellipse2D.Brush = this.Brush.Clone();
            return ellipse2D;
        }
    }
}
