using dealership.Users.Models;
using dealership.Users.Services.Interfaces;
using Newtonsoft.Json;

namespace dealership.Users.Services;

public class UserServiceJson : IUserService
{
    private List<User> _users;
    private int _newId;

    public UserServiceJson()
    {
        LoadFromFile();
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }
    public User? GetById(int id)
    {
        foreach (User user in _users)
        {
            if (user.Id == id) return user;
        }
        return null;
    }

    public void AddUser(User user)
    {
        user.Id = _newId;
        _newId++;

        _users.Add(user);
        SaveAll();
    }

    public void UpdateUser(User user)
    {
        User? found =GetById(user.Id);
        if (found == null) return;

        _users.Remove(found);
        _users.Add(user);
        SaveAll();
    }

    public void DeleteById(int id)
    {
        User? user = GetById(id);
        if (user == null) return;

        _users.Remove(user);
        SaveAll();
    }

    private void SaveAll()
    {
        string jsonString = JsonConvert.SerializeObject(_users, Formatting.Indented);
        File.WriteAllText("../../../Resources/users.json", jsonString);
    }

    private void LoadFromFile()
    {
        string jsonString = File.ReadAllText("../../../Resources/users.json");
        _users = JsonConvert.DeserializeObject<List<User>>(jsonString)!;
        _newId = _users.Count > 0 ? _users.Last().Id + 1 : 1;
    }
}