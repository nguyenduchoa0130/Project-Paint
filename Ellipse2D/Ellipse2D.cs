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
        
    }
}
