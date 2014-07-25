using System;

namespace RectangleTests
{
    class Circle : IPerimeter
    {
        private double _radius;

        public Circle(double radius)
        {
            if(radius <= 0)
                throw new ArgumentException("radius should be greater than 0", "radius");

            _radius = radius;
        }

        public double Area { get { return Math.PI * Math.Pow(_radius, 2); } }

        public double Circumference { get { return 2 * Math.PI * _radius; } }

        double IPerimeter.Perimeter
        {
            get { return Circumference; }
        }
    }
}
