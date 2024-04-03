namespace dealership.Users.Models;

public class User
{
   public int Id { get; set; }
   public UserType Type { get; set; }
   public string Email { get; set; }
   public string Password { get; set; }
   public string FullName { get; set; }
   public int Age { get; set; }

   public User (int id, UserType type, string fullName, int age, string email, string password)
   {
      Id = id;
      Type = type;
      FullName = fullName;
      Age = age;
      Email = email;
      Password = password;
   }

   public override string ToString()
   {
      string description = "";
      
      description += $"Id: {Id}\n";
      description += $"UserType: {Type}\n";
      description += $"Email: {Email}\n";
      description += $"Password: {Password}\n";
      description += $"FullName: {FullName}\n";
      description += $"Age: {Age}\n";

      return description;
   }
}