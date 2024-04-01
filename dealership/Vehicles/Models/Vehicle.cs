namespace dealership.Vehicles.Models;

public class Vehicle
{
    public int Id { get; set; }
    public VehicleType Type { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }

    public Vehicle(int id, VehicleType type, int year, string color, string make, string model)
    {
        Id = id;
        Type = type;
        Year = year;
        Color = color;
        Make = make;
        Model = model;
    }

    public Vehicle(string text)
    {
        string[] values = text.Split('/');
        
        Id = int.Parse(values[0]);
        Type = VehicleType.None;
        Year = int.Parse(values[2]);
        Color = values[3];
        Make = values[4];
        Model = values[5];
    }

    public override string ToString()
    {
        string description = "";

        description += $"Id: {Id}\n";
        description += $"Year: {Year}\n";
        description += $"Color: {Color}\n";
        description += $"Make: {Make}\n";
        description += $"Model: {Model}\n";

        return description;
    }
}