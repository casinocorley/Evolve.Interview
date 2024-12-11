namespace Evolve.Interview.Question2.Vehicle;

public class Car : Vehicle
{
    public Car(string make, string model, int numberOfWheels, int lengthInFeet, int WeightInPounds, int maxNumOfPassengers)
        : base(make, model, numberOfWheels, lengthInFeet, WeightInPounds, maxNumOfPassengers)
    { }
}