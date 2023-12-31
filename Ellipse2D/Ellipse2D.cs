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
        public int Thickness { get; set; }
        public DoubleCollection StrokeDash { get; set; }

        public SolidColorBrush Brush { get; set; }
        public string Name => "Ellipse";
        public string Icon => "Images/ellipse.png";


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

       
    }
}
