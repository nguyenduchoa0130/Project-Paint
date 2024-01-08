using System;
using System.Collections.Generic;
using System.Windows;

namespace Contract
{
    public static class VectorTranform
    {
        public static Point Rotate(this Point pt, double angle, Point center)
        {
			Vector v = new Vector(pt.X - center.X, pt.Y - center.Y).Rotate(angle);
            return new Point(v.X + center.X, v.Y + center.Y);
        }

        public static Vector Rotate(this Vector v, double degrees)
        {
            return v.RotateRadians(degrees * Math.PI / 180);
        }

        public static Vector RotateRadians(this Vector v, double radians)
        {
            double sinMath = Math.Sin(radians);
            double cosMath = Math.Cos(radians);
            return new Vector(cosMath * v.X - sinMath * v.Y, sinMath * v.X + cosMath * v.Y);
        }
    }


}
