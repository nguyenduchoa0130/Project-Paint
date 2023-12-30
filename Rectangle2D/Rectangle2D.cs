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
        public string Icon => "Images/rectangle.png";
        public string Name => "Rectangle";

        public int Thickness { get; set; }

        public void HandleStart(double x, double y)
        {
            _leftTop = new Point2D() { X = x, Y = y };
        }

       
    }
}
