using Evolve.Interview.Question2.Vehicle;

namespace Evolve.Interview.Question2.Parking;

public class Lot : IHaveParking
{
    int _maxCapacity;
    List<IVehicle> _vehiclesParked;

    public Lot(int maxCapacity)
    {
        if (maxCapacity <= 0)
        {
            throw new ArgumentException("Max capacity must be greater than 0");
        }

        _maxCapacity = maxCapacity;
        _vehiclesParked = new List<IVehicle>();
    }

    public ParkingVehiclesStatus ParkVehicles(List<IVehicle> vehicles)
    {
        if (_vehiclesParked.Count > _maxCapacity)
        {
            return new ParkingVehiclesStatus
            {
                VehiclesParked = new List<IVehicle>(),
                VehiclesRejected = vehicles
            };
        }

        var spaceAvailable = _maxCapacity - _vehiclesParked.Count;
        var vehiclesToPark = vehicles.Take(spaceAvailable).ToList();
        _vehiclesParked.AddRange(vehiclesToPark);

        return new ParkingVehiclesStatus
        {
            VehiclesParked = vehiclesToPark,
            VehiclesRejected = vehicles.Except(vehiclesToPark).ToList()
        };
    }
}