using dealership.Vehicles.Models;
using dealership.Vehicles.Services;

namespace dealership;

internal class Program
{
    public static void Main(string[] args)
    {
        /*VehicleService service = new VehicleService(new List<Vehicle>
        {
            new Car(1, VehicleType.Car, 2010, "Red", "Skoda", "Fabia", 100),
            new Airplane(2, VehicleType.Airplane, 2015, "White", "Ikarus", "C42", "Rotor", 3)
        });
        
        service.AddVehicle(new Car(3, VehicleType.Car, 2004, "blue", "renault", "clio", 300 ));
        service.UpdateVehicle(new Car(1, VehicleType.Car, 2010, "Blue", "Skoda", "Fabia", 100));
        
        foreach (Vehicle vehicle in service.GetAllVehicles())
        {
            Console.WriteLine(vehicle);
        }*/

        VehicleService service = new VehicleService();
        foreach (Vehicle? vehicle in service.GetAllVehicles())
        {
            Console.WriteLine(vehicle);
        }
    }
}