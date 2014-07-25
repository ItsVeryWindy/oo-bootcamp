using System;
using System.Collections.Generic;

namespace CarPark
{
    partial class CarPark : ICarParkManager
    {
        private readonly int _parkingSpaces;

        readonly HashSet<Car> _parkedCars = new HashSet<Car>();

        public CarPark(int parkingSpaces)
        {
            _parkingSpaces = parkingSpaces;
        }

        public bool HasSpaces
        {
            get { return _parkedCars.Count < _parkingSpaces; }
        }

        public bool HasCar(Car car)
        {
            return _parkedCars.Contains(car);
        }

        public IParkingSpace ParkCar(Car car)
        {
            const string carParam = "car";

            if (car == null)
                throw new ArgumentNullException(carParam);

            if (_parkedCars.Contains(car))
                throw new ArgumentException("Car is already parked", carParam);

            if (_parkedCars.Count >= _parkingSpaces)
                throw new InvalidOperationException("Car park is full");

            _parkedCars.Add(car);

            var parkingSpace = new ParkingSpace(this, car);

            return parkingSpace;
        }

        public void RetrieveCar(Car car)
        {
            if (car == null)
                throw new ArgumentNullException("car");

            _parkedCars.Remove(car);
        }
    }
}
