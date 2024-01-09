using Contract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SquareShape
{
    public class SquareShape : CShape, IShape
    {


        public string Icon => "Images/square.png";
        public string Name => "Square";
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


            double height = Math.Abs(_rightBottom.Y - _leftTop.Y);
            double width = Math.Abs(_rightBottom.X - _leftTop.X);
            if (width < height)
            {
                if (_rightBottom.Y < _leftTop.Y)
                    _rightBottom.Y = _leftTop.Y - width;
                else
                    _rightBottom.Y = _leftTop.Y + width;
            }
            else
            if (width > height)
            {
                if (_rightBottom.X < _leftTop.X)
                    _rightBottom.X = _leftTop.X - height;
                else _rightBottom.X = _leftTop.X + height;
            }

        }

        public UIElement Draw(SolidColorBrush brush, int thickness, DoubleCollection dash)
        {
            double width = Math.Abs(_rightBottom.X - _leftTop.X);
            double height = Math.Abs(_rightBottom.Y - _leftTop.Y);

            var rectangleDraw = new Rectangle()
            {
                Height = height,
                Width = width,
                StrokeThickness = thickness,
                Stroke = brush,
                StrokeDashArray = dash
            };

            if (_rightBottom.X > _leftTop.X && _rightBottom.Y > _leftTop.Y)
            {
                Canvas.SetLeft(rectangleDraw, _leftTop.X);
                Canvas.SetTop(rectangleDraw, _leftTop.Y);
            }
            else if (_rightBottom.X < _leftTop.X && _rightBottom.Y > _leftTop.Y)
            {
                Canvas.SetLeft(rectangleDraw, _rightBottom.X);
                Canvas.SetTop(rectangleDraw, _leftTop.Y);
            }
            else if (_rightBottom.X > _leftTop.X && _rightBottom.Y < _leftTop.Y)
            {
                Canvas.SetLeft(rectangleDraw, _leftTop.X);
                Canvas.SetTop(rectangleDraw, _rightBottom.Y);
            }
            else
            {
                Canvas.SetLeft(rectangleDraw, _rightBottom.X);
                Canvas.SetTop(rectangleDraw, _rightBottom.Y);
            }

            RotateTransform transformDraw = new RotateTransform(this._rotateAngle);
            transformDraw.CenterX = width * 1.0 / 2;
            transformDraw.CenterY = height * 1.0 / 2;

            rectangleDraw.RenderTransform = transformDraw;

            return rectangleDraw;
        }

        public IShape Clone()
        {
            return new SquareShape();
        }
        override public CShape deepCopy()
        {
            SquareShape square2D = new SquareShape();

            square2D.LeftTop = this._leftTop.deepCopy();
            square2D.RightBottom = this._rightBottom.deepCopy();
            square2D._rotateAngle = this._rotateAngle;
            square2D.Thickness = this.Thickness;

            if (this.Brush != null)
                square2D.Brush = this.Brush.Clone();

            if (this.StrokeDash != null)
                square2D.StrokeDash = this.StrokeDash.Clone();

            return square2D;
        }
    }
}
