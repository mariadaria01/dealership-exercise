namespace dealership.Vehicles.Models;

public class Boat: Vehicle
{
    public int EngineBlades { get; set; }
    public double MaximumWeightAccepted { get; set; }

    public Boat(int id, VehicleType type, int year, string color,
        string make, string model, int engineBlades,double maximumWeightAccepted) :
        base(id, type, year, color, make, model)
    {
        EngineBlades = engineBlades;
        MaximumWeightAccepted = maximumWeightAccepted;
    }

    public Boat(string text) : base(text)
    {
        string[] values = text.Split('/');

        Type = VehicleType.Boat;
        EngineBlades = int.Parse(values[6]);
        MaximumWeightAccepted = double.Parse(values[7]);
    }

    public override string ToString()
    {
        string description = base.ToString();

        description += $"EngineBlades: {EngineBlades}\n";
        description += $"MaximumWeightAccepted: {MaximumWeightAccepted}\n";
        
        return description;
    }
    
    public override string GetSaveText()
    {
        string text = base.GetSaveText();
        return text + $"/{EngineBlades}/{MaximumWeightAccepted}";
    }

}

