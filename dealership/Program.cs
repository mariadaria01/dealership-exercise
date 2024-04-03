using dealership.Users.Models;
using dealership.Users.Services;
using dealership.Users.Services.Interfaces;
using dealership.Vehicles.Models;
using dealership.Vehicles.Services;
using dealership.Vehicles.Services.Interfaces;
using Newtonsoft.Json;

namespace dealership;

internal class Program
{
    public static void Main(string[] args)
    {
        /*IVehicleService service = new VehicleServiceJson();
        service.AddVehicle(new Car(36, VehicleType.Car, 2000, "Red", "Dacia", "Logan", 100));
        foreach (Vehicle? vehicle in service.GetAllVehicles())
        {
            Console.WriteLine(vehicle);
        }*/

        IUserService service = new UserServiceJson();
        service.AddUser(new User(1,UserType.Customer, "Marius",20, "marius@email.com", "parola"));
    }
}