using System;
using NUnit.Framework;

namespace CarPark
{
    [TestFixture]
    public class Tests
    {
        private Valet _valet;

        private const int CarParkSize = 1;

        [SetUp]
        public void SetupValet()
        {
            var carPark = new CarPark(CarParkSize);

            _valet = new Valet(carPark);
        }

        [Test]
        public void ShouldParkCarAndGetCarBackWithParkingSpace()
        {
            var car = new Car();

            var parkingSpace = _valet.ParkCar(car);

            var returnedCar = parkingSpace.RetrieveCar();

            Assert.That(returnedCar, Is.EqualTo(car));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldAlwaysHaveACarParkForAValet()
        {
            var valet = new Valet(null);
        }

        [Test]
        public void ShouldAllowParkingOfTwoCarsWhenThereAreTwoCarParks()
        {
            _valet.AddCarParkManager(new CarPark(1));

            _valet.ParkCar(new Car());

            Assert.DoesNotThrow(() => _valet.ParkCar(new Car()));
        }

        [Test]
        public void ShouldAllowParkingOfTwoCarsWhenThereIsAnotherValet()
        {
            var anotherValet = new Valet(new CarPark(1));

            _valet.AddCarParkManager(anotherValet);

            _valet.ParkCar(new Car());

            Assert.DoesNotThrow(() => _valet.ParkCar(new Car()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotAllowTheSameCarToBeParkedTwice()
        {
            var car = new Car();

            _valet.ParkCar(car);
            _valet.ParkCar(car);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldNotAllowNothingToBeParked()
        {
            _valet.ParkCar(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldNotAllowMoreCarsThanCanBeParked()
        {
            const int totalCarsToBeParked = CarParkSize + 1;

            for (var i = 0; i < totalCarsToBeParked; i++)
                _valet.ParkCar(new Car());
        }
    }
}
