using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RectangleTests
{
    struct Probability
    {
        private const double MaxPercentage = 100;

        private double _itWillHappen;

        public Probability(double itWillHappen)
        {
            if (itWillHappen < 0 || itWillHappen > MaxPercentage)
                throw new ArgumentOutOfRangeException("itWillHappen", itWillHappen, "itWillHappen is less than 0 or greater than 100");

            _itWillHappen = Math.Round(itWillHappen, 2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Probability))
                return false;

            var b = (Probability)obj;

            return _itWillHappen == b._itWillHappen;
        }

        public static bool operator ==(Probability a, Probability b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Probability a, Probability b)
        {
            return !Equals(a, b);
        }

        public static Probability operator +(Probability a, Probability b)
        {
            return new Probability((a._itWillHappen * b._itWillHappen) / 100);
        }

        public static Probability operator !(Probability a)
        {
            return new Probability(MaxPercentage - a._itWillHappen);
        }

        public override int GetHashCode()
        {
            return _itWillHappen.GetHashCode();
        }

        public Probability Or(Probability b)
        {
            return !(!this + !b);
        }
    }
}
