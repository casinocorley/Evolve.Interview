using Evolve.Interview.Question2.Vehicle;

namespace Evolve.Interview.Question2.Parking;

public interface IHaveParking
{
    ParkingVehiclesStatus ParkVehicles(List<IVehicle> vehicles);
}

public struct ParkingVehiclesStatus
{
    public List<IVehicle> VehiclesParked;
    public List<IVehicle> VehiclesRejected;

    public ParkingVehiclesStatus()
    {
        VehiclesParked = new List<IVehicle>();
        VehiclesRejected = new List<IVehicle>();
    }
}



