using Evolve.Interview.Question2.Vehicle;

namespace Evolve.Interview.Question2.Parking;

public class Garage : IHaveParking
{
    int _maxCapacity;
    int _compactVehiclesCapacity;
    
    List<IVehicle> _compactVehiclesParked;
    List<IVehicle> _vehiclesParked;

    public Garage(int maxCapacity, int compactVehiclesCapacity)
    {
        if (maxCapacity <= 0)
        {
            throw new ArgumentException("Max capacity must be greater than 0");
        }

        if (compactVehiclesCapacity <= 0)
        {
            throw new ArgumentException("Compact vehicles capacity must be greater than 0");
        }

        if (maxCapacity <= compactVehiclesCapacity)
        {
            throw new ArgumentException("Compact vehicles capacity cannot be greater than max capacity");
        }

        _maxCapacity = maxCapacity;
        _compactVehiclesCapacity = compactVehiclesCapacity;

        _vehiclesParked = new List<IVehicle>();
        _compactVehiclesParked = new List<IVehicle>();
    }

    public ParkingVehiclesStatus ParkVehicles(List<IVehicle> vehicles)
    {
        // Can only park cars and motorcycles
        var vehiclesToPark = vehicles
            .Where(x => x is Car || x is Motorcycle)
            .ToList();

        // Park compact vehicles
        var compactAvailableSpace = GetCompactAvailableSpaces();
        var compactVehiclesToPark = vehiclesToPark
            .Where(x => x.WeightInPounds <= 1500)
            .Take(compactAvailableSpace)
            .ToList();

        _compactVehiclesParked.AddRange(compactVehiclesToPark);

        // Park remaining vehicles
        var availableSpace = GetNonCompactAvailableSpaces();
        var remainingVehicleToPark = vehiclesToPark
            .Except(compactVehiclesToPark)
            .Take(availableSpace)
            .ToList();

        _vehiclesParked.AddRange(remainingVehicleToPark);

        // Return status
        var allVehicleParked = _compactVehiclesParked
            .Union(_vehiclesParked)
            .ToList();
        
        var allVehiclesNotParked = vehicles
            .Except(allVehicleParked)
            .ToList();

        var status = new ParkingVehiclesStatus
        {
            VehiclesParked = allVehicleParked,
            VehiclesRejected = allVehiclesNotParked
        };

        return status;
    }

    private int GetCompactAvailableSpaces()
    {
        return _compactVehiclesCapacity - _compactVehiclesParked.Count;
    }

    private int GetNonCompactAvailableSpaces()
    {
        // A number of total available spaces are reserved for compact vehicles
        return _maxCapacity - _compactVehiclesCapacity - _vehiclesParked.Count;
    }
}