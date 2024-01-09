using Contract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CircleShape
{
    public class CircleShape : CShape, IShape
    {

        public DoubleCollection StrokeDash { get; set; }


        public SolidColorBrush Brush { get; set; }
        public int Thickness { get; set; }
        public string Icon => "Images/circle.png";
        public string Name => "Circle";

        public void HandleStart(double a, double b)
        {
            _leftTop.Y = b;
            _leftTop.X = a;
        }
        public void HandleEnd(double a, double b)
        {
            _rightBottom.Y = b;
            _rightBottom.X = a;
            double heightEnd = Math.Abs(_rightBottom.Y - _leftTop.Y);
            double widthEnd = Math.Abs(_rightBottom.X - _leftTop.X);
            if (widthEnd < heightEnd)
            {
                if (_rightBottom.Y >= _leftTop.Y)
                    _rightBottom.Y = _leftTop.Y + widthEnd;
                else
                    _rightBottom.Y = _leftTop.Y - widthEnd;
            }
            else
                if (widthEnd > heightEnd)
            {
                if (_rightBottom.X >= _leftTop.X)
                    _rightBottom.X = _leftTop.X + heightEnd;
                else
                    _rightBottom.X = _leftTop.X - heightEnd;
            }
        }

        public UIElement Draw(SolidColorBrush brush, int thickness, DoubleCollection dash)
        {
            double height = Math.Abs(_rightBottom.Y - _leftTop.Y);
            double width = Math.Abs(_rightBottom.X - _leftTop.X);

            var circleToDraw = new Ellipse()
            {
                Width = width,
                StrokeThickness = thickness,
                Stroke = brush,
                StrokeDashArray = dash,
                Height = height,
            };

            if (_rightBottom.X > _leftTop.X && _rightBottom.Y > _leftTop.Y)
            {
                Canvas.SetTop(circleToDraw, _leftTop.Y);
                Canvas.SetLeft(circleToDraw, _leftTop.X);
            }
            else if (_rightBottom.X < _leftTop.X && _rightBottom.Y > _leftTop.Y)
            {
                Canvas.SetTop(circleToDraw, _leftTop.Y);
                Canvas.SetLeft(circleToDraw, _rightBottom.X);
            }
            else if (_rightBottom.X > _leftTop.X && _rightBottom.Y < _leftTop.Y)
            {
                Canvas.SetTop(circleToDraw, _rightBottom.Y);
                Canvas.SetLeft(circleToDraw, _leftTop.X);
            }
            else
            {
                Canvas.SetTop(circleToDraw, _rightBottom.Y);
                Canvas.SetLeft(circleToDraw, _rightBottom.X);
            }

            return circleToDraw;
        }

        public IShape Clone()
        {
            return new CircleShape();
        }

        override public CShape deepCopy()
        {
            CircleShape tempDraw = new CircleShape();

            tempDraw.LeftTop = this._leftTop.deepCopy();
            tempDraw.Thickness = this.Thickness;
            tempDraw._rotateAngle = this._rotateAngle;
            tempDraw.RightBottom = this._rightBottom.deepCopy();
            if (this.StrokeDash != null)
                tempDraw.StrokeDash = this.StrokeDash.Clone();

            if (this.Brush != null)
                tempDraw.Brush = this.Brush.Clone();
            return tempDraw;
        }
    }
}
