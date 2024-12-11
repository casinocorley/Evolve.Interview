using Evolve.Interview.Question2.Vehicle;
using Evolve.Interview.Question2.Parking;
using System.ComponentModel.DataAnnotations;

namespace Evolve.Interview.Question2;

class Program
{
    static void Main(string[] args)
    {
        // Generate some cars, motorcycles, and buses
        var cars = new List<IVehicle> {
            new Car("Honda", "Accord", 4, 15, 3000, 4),
            new Car("Nissan", "Frontier", 4, 18, 4000, 4),
            new Car("Toyota", "Prius", 4, 12, 1400, 4),
            new Car("Ford", "Bronco", 4, 18, 4000, 6),
            new Car("Subaru", "Crosstrek", 4, 15, 2800, 4),
            new Car("Nissan", "Leaf", 4, 12, 1300, 4),
            new Car("Hyundai", "Santa Fe", 4, 18, 400, 6),
            new Car("Ford", "F150", 4, 20, 5000, 6)
        };

        var motorcycles = new List<IVehicle> {
            new Motorcycle("Honda", "CB 1000", 2, 8, 800, 2),
            new Motorcycle("Yamaha", "FJR 1300", 2, 8, 700, 2),
            new Motorcycle("Suzuki", "DR 650", 2, 8, 800, 2),
            new Motorcycle("Harley-Davidson", "Dyna Low Rider", 2, 8, 900, 2),
            new Motorcycle("Moto Guzzi", "V100 Mandello", 2, 8, 700, 2)
        };

        var buses = new List<IVehicle> {
            new Bus("Volvo", "Double Decker", 10, 40, 30000, 80),
            new Bus("Blue Bird", "School Bus", 10, 40, 30000, 40),
            new Bus("Thomas Built", "Short School Bus", 10, 20, 20000, 20),
            new Bus("Nova Bus", "LFS", 10, 40, 30000, 40)
        };

        var allVehicleParked = cars
            .Union(motorcycles)
            .Union(buses)
            .Shuffle()
            .ToList();

        // Try to park all vehicles in a lot
        var parkingFacilities = new List<IHaveParking> {
            new Garage(10, 5),
            new Lot(5)
        };

        var vehiclesToPark = allVehicleParked;
        foreach(var parkingFacility in parkingFacilities)
        {
            var parkingStatus = parkingFacility.ParkVehicles(vehiclesToPark);

            Console.WriteLine();
            Console.WriteLine($"*** {parkingFacility.GetType().Name} ***");
            Console.WriteLine();

            PrintLotStatus(parkingStatus);

            Console.WriteLine();

            vehiclesToPark = parkingStatus.VehiclesRejected;
        }
    }

    private static void PrintLotStatus(ParkingVehiclesStatus status)
    {
        Console.WriteLine($"Vehicles parked: {status.VehiclesParked.Count}");
        Console.WriteLine("--------------------");
        foreach(var vehicle in status.VehiclesParked)
        {
            var description = vehicle.IsCompact() ? $"{vehicle.GetType().Name}, Compact" : $"{vehicle.GetType().Name}";
            Console.WriteLine($"* {vehicle.Make} {vehicle.Model} ({description})");
        }

        Console.WriteLine();
        Console.WriteLine($"Vehicles rejected: {status.VehiclesRejected.Count}");
        Console.WriteLine("--------------------");
        foreach(var vehicle in status.VehiclesRejected)
        {
            var description = vehicle.IsCompact() ? $"{vehicle.GetType().Name}, Compact" : $"{vehicle.GetType().Name}";
            Console.WriteLine($"* {vehicle.Make} {vehicle.Model} ({description})");
        }
    }
}

public static class Extensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        var rnd = new Random();
        return source.OrderBy(x => rnd.Next());
    }
}
