using System;

namespace RectangleTests
{
    class Square : IPerimeter
    {
        private readonly Rectangle _square;

        public Square(int sideLength)
        {
            try
            {
                _square = new Rectangle(sideLength, sideLength);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("sideLength should be greater than 0", "sideLength");
            }
        }

        public double Perimeter
        {
            get { return _square.Perimeter; }
        }

        public double Area
        {
            get { return _square.Area; }
        }
    }
}
