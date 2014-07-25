using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPark
{
    class Valet : ICarParkManager
    {
        private readonly HashSet<ICarParkManager> _carParkManagers = new HashSet<ICarParkManager>();

        public Valet(ICarParkManager carPark)
        {
            if(carPark == null)
                throw new ArgumentNullException("carPark");

            _carParkManagers.Add(carPark);
        }

        public void AddCarParkManager(ICarParkManager carPark)
        {
            _carParkManagers.Add(carPark);
        }

        public IParkingSpace ParkCar(Car car)
        {
            if(HasCar(car))
                throw new ArgumentException("Car has already been parked", "car");

            foreach (ICarParkManager carPark in _carParkManagers)
            {
                if (carPark.HasSpaces)
                {
                    var parkingSpace = carPark.ParkCar(car);

                    return parkingSpace; 
                }
            }

            throw new InvalidOperationException("Car parks are full");
        }

//        public Car UnparkCar(IParkingSpace parkingSpace)
//        {
//            if (parkingSpace == null)
//                throw new ArgumentNullException("parkingSpace");
//
//            var properTicket = parkingSpace as ParkingSpace;
//
//            if (properTicket == null || properTicket.Car == null)
//                throw new ArgumentException("parkingSpace is invalid", "parkingSpace");
//
//            var car = properTicket.Car;
//
//            properTicket.UnparkCar();
//
//            return car;
//        }

        public bool HasSpaces
        {
            get
            {
                return _carParkManagers.Any(e => e.HasSpaces);
            }
        }

        public bool HasCar(Car car)
        {
            foreach (var carPark in _carParkManagers)
            {
                var hasCar = carPark.HasCar(car);

                if (hasCar)
                    return true;
            }

            return false;
        }
    }
}
