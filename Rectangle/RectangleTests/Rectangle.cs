using System;

namespace RectangleTests
{
    class Rectangle : IPerimeter
    {
        private readonly double _width;
        private readonly double _height;

        public Rectangle(double width, double height)
        {
            if (width <= 0)
                throw new ArgumentException("width should be greater than 0", "width");

            if (height <= 0)
                throw new ArgumentException("height should be greater than 0", "height");

            _width = width;
            _height = height;
        }

        public double Perimeter { get { return (_width + _height) * 2; } }

        public double Area { get { return _width * _height; } }
    }
}
