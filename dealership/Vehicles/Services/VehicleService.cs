﻿using dealership.Vehicles.Models;
using dealership.Vehicles.Services.Interfaces;

namespace dealership.Vehicles.Services;

public class VehicleService : IVehicleService
{
    private static List<Vehicle> _vehicles;

    public VehicleService()
    {
        LoadFromFile();
    }
    
    public VehicleService(List<Vehicle> vehicles)
    {
        _vehicles = vehicles;
    }

    public List<Vehicle> GetAllVehicles()
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
        vehicle.Id = NewId();
        
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
        string text = "";
        foreach (Vehicle vehicle in _vehicles)
        {
            text += vehicle.GetSaveText() + "\n";
        }
        
        StreamWriter sw = new StreamWriter("../../../Resources/vehicles.txt");
        sw.Write(text);
        sw.Close();
    }
    
    private void LoadFromFile()
    {
        _vehicles = new List<Vehicle>();

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