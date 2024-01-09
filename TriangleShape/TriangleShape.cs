using Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
namespace TriangleShape
{
    public class TriangleShape : CShape, IShape
    {
        public string Icon => "Images/triangle.png";
        public string Name => "triangle";
        public SolidColorBrush Brush { get; set; }
        public DoubleCollection StrokeDash { get; set; }
        public int Thickness { get; set; }

        public void HandleStart(double x, double y)
        {
            _leftTop.X = x;
            _leftTop.Y = y;
        }

        public void HandleEnd(double x, double y)
        {
            _rightBottom.X = x;
            _rightBottom.Y = y;
        }

        public UIElement Draw(SolidColorBrush brush, int thickness, DoubleCollection dash)
        {
            double width = Math.Abs(_rightBottom.X - _leftTop.X);
            double height = Math.Abs(_rightBottom.Y - _leftTop.Y);

            var triangleDraw = new Polygon()
            {
                Points = new PointCollection()
                {
                    new Point(_leftTop.X + width / 2, _leftTop.Y),
                    new Point(_rightBottom.X, _rightBottom.Y),
                    new Point(_leftTop.X, _rightBottom.Y)
                },
                StrokeThickness = thickness,
                Stroke = brush,
                StrokeDashArray = dash
            };

            RotateTransform transformDraw = new RotateTransform(this._rotateAngle);
            transformDraw.CenterX = _leftTop.X + width / 2;
            transformDraw.CenterY = _leftTop.Y;

            triangleDraw.RenderTransform = transformDraw;

            return triangleDraw;
        }

        public IShape Clone()
        {
            return new TriangleShape();
        }

        public override CShape deepCopy()
        {
            TriangleShape triangle2D = new TriangleShape();

            triangle2D.LeftTop = this._leftTop.deepCopy();
            triangle2D.RightBottom = this._rightBottom.deepCopy();
            triangle2D._rotateAngle = this._rotateAngle;
            triangle2D.Thickness = this.Thickness;

            if (this.Brush != null)
                triangle2D.Brush = this.Brush.Clone();

            if (this.StrokeDash != null)
                triangle2D.StrokeDash = this.StrokeDash.Clone();

            return triangle2D;
        }
    }

}
