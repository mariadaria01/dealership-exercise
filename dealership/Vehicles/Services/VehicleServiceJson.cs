using dealership.Vehicles.Converters;
using dealership.Vehicles.Models;
using dealership.Vehicles.Services.Interfaces;
using Newtonsoft.Json;

namespace dealership.Vehicles.Services;

public class VehicleServiceJson : IVehicleService
{
    private List<Vehicle> _vehicles;
    private int _newId;

    public VehicleServiceJson()
    {
        LoadFromFile();
    }

    public List<Vehicle?> GetAllVehicles()
    {
        return _vehicles;
    }
    
    public List<Vehicle> GetByYear(int year)
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        
        foreach (Vehicle vehicle in _vehicles)
        {
            if ((vehicle.Year == year)) vehicles.Add(vehicle);
        }

        return vehicles;
    }    
    
    public List<Vehicle> GetByMake(string make)
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        
        foreach (Vehicle vehicle in _vehicles)
        {
            if ((vehicle.Make == make)) vehicles.Add(vehicle);
        }

        return vehicles;
    }
    public Vehicle? GetVehicleById(int id)
    {
        foreach (Vehicle? vehicle in _vehicles)
        {
            if (vehicle.Id == id) return vehicle;
        }

        return null;
    }
    
    public void AddVehicle(Vehicle vehicle)
    {
        vehicle.Id = _newId;
        _newId++;
        
        _vehicles.Add(vehicle);
        SaveAll();
    }

    public void UpdateVehicle(Vehicle vehicle)
    {
        Vehicle? found = GetVehicleById(vehicle.Id);
        if (found == null) return;

        _vehicles.Remove(found);
        _vehicles.Add(vehicle);
        SaveAll();
    }
    
    public void DeleteVehicleById(int id)
    {
        Vehicle? vehicle = GetVehicleById(id);

        if (vehicle == null) return;

        _vehicles.Remove(vehicle);
        SaveAll();
    }
    
    // PRIVATE METHODS

    private void SaveAll()
    {
        string jsonString = JsonConvert.SerializeObject(_vehicles, Formatting.Indented);
        File.WriteAllText("../../../Resources/vehicles.json", jsonString);
    }
    
    private void LoadFromFile()
    {
        string jsonString = File.ReadAllText("../../../Resources/vehicles.json");
        _vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(jsonString, new VehicleConverter())!;
        _newId = _vehicles.Count > 0 ? _vehicles.Last().Id + 1 : 1;
    }
}