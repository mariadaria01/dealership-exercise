namespace dealership.Vehicles.Models;

public class Boat: Vehicle
{
    public string EngineBlades { get; set; }
    public string MaximumWeightAccepted { get; set; }

    public Boat(int id, VehicleType type, int year, string color,
        string make, string model, string engineBlades,string maximumWeightAccepted) :
        base(id, type, year, color, make, model)
    {
        EngineBlades = engineBlades;
        MaximumWeightAccepted = maximumWeightAccepted;
    }

    public Boat(string text) : base(text)
    {
        string[] values = text.Split('/');

        Type = VehicleType.Boat;
        EngineBlades = (values[6]);
        MaximumWeightAccepted = values[7];
    }

    public override string ToString()
    {
        string description = base.ToString();

        description += $"EngineBlades: {EngineBlades}\n";
        description += $"MaximumWeightAccepted: {MaximumWeightAccepted}\n";
        
        return description;
    }
    

}

