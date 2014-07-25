namespace CarPark
{
    interface ICarParkManager
    {
        IParkingSpace ParkCar(Car car);

        bool HasSpaces { get; }

        bool HasCar(Car car);
    }
}
