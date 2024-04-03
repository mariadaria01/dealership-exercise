using dealership.Vehicles.Models;

namespace dealership.Vehicles.Services.Interfaces;

public interface IVehicleService
{
    List<Vehicle> GetAllVehicles();
    List<Vehicle> GetByYear(int year);

    Vehicle? GetVehicleById(int id);

    void AddVehicle(Vehicle vehicle);

    void UpdateVehicle(Vehicle vehicle);

    void DeleteVehicleById(int id);

    List<Vehicle> GetByMake(string make);
}