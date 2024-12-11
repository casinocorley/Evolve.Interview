namespace Evolve.Interview.Question2.Vehicle;

public interface IVehicle
{
    string Make { get; }
    string Model { get; }
    int LengthInFeet { get; }
    int WeightInPounds { get; }
    int MaxNumOfPassengers { get; }
    bool IsCompact();
}

public abstract class Vehicle : IVehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int NumberOfWheels { get; set; }
    public int LengthInFeet { get; set; }
    public int WeightInPounds { get; set; }
    public int MaxNumOfPassengers { get; set; }

    protected Vehicle(string make, string model, int numOfWheels, int lengthInFeet, int weightInPounds, int maxNumOfPassengers)
    {
        Make = make;
        Model = model;
        NumberOfWheels = numOfWheels;
        LengthInFeet = lengthInFeet;
        WeightInPounds = weightInPounds;
        MaxNumOfPassengers = maxNumOfPassengers;
    }

    public bool IsCompact() => WeightInPounds <= 1500;
}