using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Contract
{
	public class CShape
	{
        protected Point2D _rightBottom = new Point2D();
		protected Point2D _leftTop = new Point2D();
        protected double _rotateAngle = 0;
        public Point2D RightBottom
        {
            get { return _rightBottom; } 
            set { _rightBottom = value; }
        }
        public Point2D LeftTop   // property
        {
            get { return _leftTop; } 
            set { _leftTop = value; }
        }



        public double getRotateAngle()
		{
            return this._rotateAngle;
		}
        public void setRotateAngle(double angle)
		{
            this._rotateAngle = angle;
		}

        virtual public Point2D getCenterPoint()
		{
            Point2D centerPoint2D = new Point2D();
            var top = Math.Min(_rightBottom.Y, _leftTop.Y);
            var left = Math.Min(_rightBottom.X, _leftTop.X);

            centerPoint2D.Y = ((_leftTop.Y + _rightBottom.Y) / 2);
            centerPoint2D.X = ((_leftTop.X + _rightBottom.X) / 2);
            return centerPoint2D; 
		}

        virtual public bool isHovering(double a, double b)
		{
            return util.isBetween(a, this._rightBottom.X, this._leftTop.X)
                && util.isBetween(b, this._rightBottom.Y, this._leftTop.Y);
		}

        virtual public List<controlPoint> GetControlPoints()
		{
            List<controlPoint> controlPointsDraw = new List<controlPoint>();
            
            controlPoint diagPointTopLeft = new diagPoint();
            diagPointTopLeft.setPoint(_leftTop.X, _leftTop.Y);

            controlPoint diagPointBottomLeft = new diagPoint();
            diagPointBottomLeft.setPoint(_leftTop.X, RightBottom.Y);

            controlPoint diagPointTopRight = new diagPoint();
            diagPointTopRight.setPoint(_rightBottom.X, _leftTop.Y);

            controlPoint diagPointBottomRight = new diagPoint();
            diagPointBottomRight.setPoint(_rightBottom.X, _rightBottom.Y);

            //one way control Point

            controlPoint diagPointRight2D = new oneSidePoint();
            diagPointRight2D.setPoint(_rightBottom.X, (_rightBottom.Y + _leftTop.Y) / 2);

    
            controlPoint diagPointTop = new oneSidePoint();
            diagPointTop.setPoint((_leftTop.X + _rightBottom.X) / 2, _leftTop.Y);

            controlPoint diagPointLeft = new oneSidePoint();
            diagPointLeft.setPoint(_leftTop.X, (_rightBottom.Y + _leftTop.Y) / 2);
            controlPoint diagPointBottom = new oneSidePoint();
            diagPointBottom.setPoint((_leftTop.X + _rightBottom.X) / 2, _rightBottom.Y);


            controlPoint angleControlPoint2D = new rotatePoint();
            angleControlPoint2D.setPoint((_rightBottom.X + _leftTop.X)/2, Math.Min(_rightBottom.Y, _leftTop.Y) - 50);

            controlPoint moveControlPoint2D = new controlPoint();
            moveControlPoint2D.setPoint((_leftTop.X + _rightBottom.X) / 2, (_leftTop.Y + _rightBottom.Y) / 2);
            moveControlPoint2D.type = "move";

            controlPointsDraw.Add(diagPointTopLeft);
            controlPointsDraw.Add(diagPointTopRight);
            controlPointsDraw.Add(diagPointBottomLeft);
            controlPointsDraw.Add(diagPointBottomRight);

            controlPointsDraw.Add(diagPointRight2D);
            controlPointsDraw.Add(diagPointLeft);
            controlPointsDraw.Add(diagPointBottom);
            controlPointsDraw.Add(diagPointTop);

            controlPointsDraw.Add(angleControlPoint2D);
            controlPointsDraw.Add(moveControlPoint2D);

            return controlPointsDraw;
		}

        virtual public UIElement controlOutline()
		{

            var right = Math.Max(_rightBottom.X, _leftTop.X);
            var bottom = Math.Max(_rightBottom.Y, _leftTop.Y);
            var left = Math.Min(_rightBottom.X, _leftTop.X);
            var top = Math.Min(_rightBottom.Y, _leftTop.Y);

            var height = bottom - top;
            var width = right - left;

            var rectDraw = new Rectangle()
            {
                Stroke = Brushes.Black,
                Width = width,
                Height = height,
                StrokeThickness = 2,
                StrokeDashArray = { 4, 2, 4 }
            };

            Canvas.SetLeft(rectDraw, left);
            Canvas.SetTop(rectDraw, top);

            RotateTransform transform = new RotateTransform(this._rotateAngle);
            transform.CenterX = width * 1.0 / 2;
            transform.CenterY = height * 1.0 / 2;

            rectDraw.RenderTransform = transform;

            return rectDraw;
		}

        virtual public CShape deepCopy()
		{
            return new CShape()
            {
                LeftTop = this._leftTop,
                RightBottom = this._rightBottom,
                _rotateAngle = this._rotateAngle,
            };
		}
	}
}
