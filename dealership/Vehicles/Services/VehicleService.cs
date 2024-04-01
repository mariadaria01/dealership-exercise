using dealership.Vehicles.Models;

namespace dealership.Vehicles.Services;

public class VehicleService
{
    private static List<Vehicle?> _vehicles;

    public VehicleService()
    {
        LoadFromFile();
    }
    
    public VehicleService(List<Vehicle?> vehicles)
    {
        _vehicles = vehicles;
    }

    public List<Vehicle?> GetAllVehicles()
    {
        return _vehicles;
    }

    // List<Vehicle> GetByMake(string make)
    // List<Vehicle> GetByYear(int year)
    
    public Vehicle? GetVehicleById(int id)
    {
        foreach (Vehicle? vehicle in _vehicles)
        {
            if (vehicle.Id == id) return vehicle;
        }

        return null;
    }
    
    public void AddVehicle(Vehicle? vehicle)
    {
        vehicle.Id = NewId();
        
        _vehicles.Add(vehicle);
    }

    public void UpdateVehicle(Vehicle? vehicle)
    {
        Vehicle? found = GetVehicleById(vehicle.Id);
        if (found == null) return;

        _vehicles.Remove(found);
        _vehicles.Add(vehicle);
    }
    
    public void DeleteVehicleById(int id)
    {
        Vehicle? vehicle = GetVehicleById(id);

        if (vehicle == null) return;

        _vehicles.Remove(vehicle);
    }

    public static Vehicle? GetByMake(string make)
    {
        foreach (Vehicle? vehicle in _vehicles)
        {
            if ((vehicle.Make == make)) return vehicle;
        }

        return null;
    }

    public static Vehicle? GetByYear(int year)
    {
        foreach (Vehicle? vehicle in _vehicles)
        {
            if (vehicle.Year == year) return vehicle;
        }

        return null;
    }
    
    // PRIVATE METHODS

    private void LoadFromFile()
    {
        _vehicles = new List<Vehicle?>();

        StreamReader sr = new StreamReader("../../../Resources/vehicles.txt");

        while (!sr.EndOfStream)
        {
            string text = sr.ReadLine()!;

            switch (int.Parse(text.Split('/')[1]))
            {
                case 1:
                    _vehicles.Add(new Car(text));
                    break;
                case 2:
                    _vehicles.Add(new Airplane(text));
                    break;
                case 3:
                    _vehicles.Add(new Boat(text));
                    break;
            }
        }
        
        sr.Close();
    }
    
    private int NewId()
    {
        Random random = new Random();
        int id = random.Next(1, 10000);

        while (GetVehicleById(id) != null)
        {
            id = random.Next(1, 10000);
        }

        return id;
    }
}