using System.Globalization;
namespace dealership.Vehicles.Models;

public class Airplane : Vehicle
{
    public string MotorType { get; set; }
    public double Wingspan { get; set; }

    public Airplane(int id, VehicleType type, int year, string color, 
        string make, string model, string motorType, double wingspan) : 
        base(id, type, year, color, make, model)
    {
        MotorType = motorType;
        Wingspan = wingspan;
    }

    public Airplane(string text) : base(text)
    {
        string[] values = text.Split('/');

        Type = VehicleType.Airplane;
        MotorType = values[6];
        Wingspan = double.Parse(values[7], CultureInfo.InvariantCulture);
    }

    public override string ToString()
    {
        string description = base.ToString();

        description += $"Type: {MotorType}\n";
        description += $"Wingspan: {Wingspan}m\n";

        return description;
    }
}