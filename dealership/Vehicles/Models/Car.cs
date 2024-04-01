namespace dealership.Vehicles.Models;

public class Car : Vehicle
{
    public int Horsepower { get; set; }

    public Car(int id, VehicleType type, int year, string color, 
        string make, string model, int horsepower) :
        base(id, type, year, color, make, model)
    {
        Horsepower = horsepower;
    }

    public Car(string text) : base(text)
    {
        string[] values = text.Split('/');

        Type = VehicleType.Car;
        Horsepower = int.Parse(values[6]);
    }

    public override string ToString()
    {
        string description = base.ToString();
            
        description += $"Horsepower: {Horsepower}\n";

        return description;
    }
}