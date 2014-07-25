using System;
using NUnit.Framework;

namespace RectangleTests
{
    [TestFixture]
    public class RectangleTests
    {
        [TestCase(2, 2, 8)]
        [TestCase(2, 3, 10)]
        public void ShouldCalculateThePerimeterOfARectangle(int width, int height, int expectedPerimeter)
        {
            var rect = new Rectangle(width, height);

            Assert.That(rect.Perimeter, Is.EqualTo(expectedPerimeter));
        }

        [TestCase(2, 2, 4)]
        [TestCase(2, 3, 6)]
        public void ShouldCalculateTheAreaOfARectangle(int width, int height, int expectedArea)
        {
            var rect = new Rectangle(width, height);

            Assert.That(rect.Area, Is.EqualTo(expectedArea));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "width", MatchType = MessageMatch.Contains)]
        public void ShouldNotAllowARectangleWithAnInvalidWidth(int invalidWidth)
        {
            const int validHeight = 1;

            var rect = new Rectangle(invalidWidth, validHeight);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "height", MatchType = MessageMatch.Contains)]
        public void ShouldNotAllowARectangleWithAnInvalidHeight(int invalidHeight)
        {
            const int validWidth = 1;

            var rect = new Rectangle(validWidth, invalidHeight);
        }
    }

    [TestFixture]
    public class SquareTests
    {
        [TestCase(2, 8)]
        [TestCase(3, 12)]
        public void ShouldCalculateThePerimeterOfASquare(int sideLength, int expectedPerimeter)
        {
            var square = new Square(sideLength);

            Assert.That(square.Perimeter, Is.EqualTo(expectedPerimeter));
        }

        [TestCase(2, 4)]
        [TestCase(3, 9)]
        public void ShouldCalculateTheAreaOfASquare(int sideLength, int expectedArea)
        {
            var square = new Square(sideLength);

            Assert.That(square.Area, Is.EqualTo(expectedArea));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "sideLength", MatchType = MessageMatch.Contains)]
        public void ShouldNotAllowASquareWithAnInvalidSideLength(int invalidSideLength)
        {
            var square = new Square(invalidSideLength);
        }
    }

    public class CircleTests
    {
        [TestCase(2, 12.57)]
        [TestCase(3, 18.85)]
        public void ShouldCalculateTheCircumferenceOfACircle(double radius, double expectedCircumference)
        {
            var circle = new Circle(radius);

            Assert.That(circle.Circumference, Is.EqualTo(expectedCircumference).Within(0.1));
        }

        [TestCase(2, 12.57)]
        [TestCase(3, 28.27)]
        public void ShouldCalculateTheAreaOfACircle(double radius, double expectedArea)
        {
            var circle = new Circle(radius);

            Assert.That(circle.Area, Is.EqualTo(expectedArea).Within(0.1));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "radius", MatchType = MessageMatch.Contains)]
        public void ShouldNotAllowACircleWithAnInvalidRadius(int invalidRadius)
        {
            var circle = new Circle(invalidRadius);
        } 
    }

    [Ignore]
    [TestFixture]
    public class CakeCollectionTests
    {
        [Test]
        public void ShouldOutputThePerimeter()
        {
            var cakes = new CakeCollection
                {
                    new Rectangle(2, 3),
                    new Square(2),
                    new Circle(2)
                };

            Assert.That(cakes[0], Is.EqualTo("Cake has perimeter: 10"));
            Assert.That(cakes[1], Is.EqualTo("Cake has perimeter: 8"));
            Assert.That(cakes[2], Is.EqualTo("Cake has perimeter: 12.5663706143592"));
        }
    }

    [TestFixture]
    public class ProbabilityTests
    {
        [TestCase(75)]
        [TestCase(30)]
        public void ShouldBeEqualWhenProbabilityIsTheSame(double willHappen)
        {
            var a = new Probability(willHappen);
            var b = new Probability(willHappen);

            Assert.That(a, Is.EqualTo(b));
        }

        [TestCase(75, 2)]
        [TestCase(30, 2)]
        public void ShouldBeNotEqualWhenProbabilityIsTheDifferent(double willHappen, double differentWillHappen)
        {
            var a = new Probability(willHappen);
            var b = new Probability(differentWillHappen);

            Assert.That(a, Is.Not.EqualTo(b));
        }

        [TestCase(50, 40, 20)]
        [TestCase(30, 15, 4.5)]
        public void ShouldAddTwoProbabilitiesTogetherAndGiveTheProbabilityOfBothHappening(double couldHappen, double couldAlsoHappen, double bothHappening)
        {
            var a = new Probability(couldHappen);
            var b = new Probability(couldAlsoHappen);

            var c = a + b;

            var d = new Probability(bothHappening);

            Assert.That(c, Is.EqualTo(d));
        }

        [TestCase(50, 40, 70)]
        [TestCase(30, 15, 40.5)]
        public void ShouldReturnTheProbabilityOfEitherHappening(double couldHappen, double couldAlsoHappen, double eitherCouldHappen)
        {
            var a = new Probability(couldHappen);
            var b = new Probability(couldAlsoHappen);

            var c = a.Or(b);

            var d = new Probability(eitherCouldHappen);

            Assert.That(c, Is.EqualTo(d));
        }

        [TestCase(75, 25)]
        [TestCase(30, 70)]
        public void ShouldBeEqualToWillNotHappenWhenWillHappenIsInverted(double willHappen, double willNotHappen)
        {
            var probability = new Probability(willHappen);
            var inverseProbability = new Probability(willNotHappen);

            Assert.That(!probability, Is.EqualTo(inverseProbability));
        }

        [TestCase(-1)]
        [TestCase(101)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowAnExceptionWhenProbabilityIsOutOfRange(double willHappen)
        {
            var probability = new Probability(willHappen);
        }
    }
}
