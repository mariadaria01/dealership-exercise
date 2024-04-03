using dealership.Vehicles.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dealership.Vehicles.Converters;

public class VehicleConverter : JsonConverter<Vehicle>
{
    public override void WriteJson(JsonWriter writer, Vehicle? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override Vehicle? ReadJson(JsonReader reader, Type objectType, Vehicle? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        JObject jsonObject = JObject.Load(reader);

        switch ((int)jsonObject["Type"])
        {
            case 1:
                return new Car(
                    (int)jsonObject["Id"],
                    (VehicleType)(int)jsonObject["Type"],
                    (int)jsonObject["Year"],
                    (string)jsonObject["Color"],
                    (string)jsonObject["Make"],
                    (string)jsonObject["Model"],
                    (int)jsonObject["Horsepower"]);
            case 2:
                return new Airplane(
                    (int)jsonObject["Id"],
                    (VehicleType)(int)jsonObject["Type"],
                    (int)jsonObject["Year"],
                    (string)jsonObject["Color"],
                    (string)jsonObject["Make"],
                    (string)jsonObject["Model"],
                    (string)jsonObject["MotorType"],
                    (double)jsonObject["Wingspan"]);
            case 3:
                return new Boat(
                    (int)jsonObject["Id"],
                    (VehicleType)(int)jsonObject["Type"],
                    (int)jsonObject["Year"],
                    (string)jsonObject["Color"],
                    (string)jsonObject["Make"],
                    (string)jsonObject["Model"],
                    (int)jsonObject["EngineBlades"],
                    (double)jsonObject["MaximumWeightAccepted"]);
        }

        return null;
    }
}