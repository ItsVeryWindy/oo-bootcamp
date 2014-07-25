using System;

namespace CarPark
{
    interface IParkingSpace
    {
        Car RetrieveCar();
    }

    partial class CarPark
    {
        private class ParkingSpace : IParkingSpace
        {
            private Car _car;

            private readonly CarPark _carPark;

            public ParkingSpace(CarPark carPark, Car car)
            {
                _carPark = carPark;
                _car = car;
            }

            public Car RetrieveCar()
            {
                if (_car == null)
                    throw new InvalidOperationException("Car has already been retrieved");

                var car = _car;

                _carPark.RetrieveCar(_car);

                _car = null;

                return car;
            }
        }
    }
}
