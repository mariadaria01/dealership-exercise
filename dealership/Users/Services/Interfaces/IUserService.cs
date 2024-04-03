using dealership.Users.Models;

namespace dealership.Users.Services.Interfaces;

public interface IUserService
{
    List<User>GetAllUsers();
    User? GetById(int id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteById(int id);
}