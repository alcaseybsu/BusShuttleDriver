namespace DriverMvc.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsManager { get; set; }
    public bool IsDriver { get; set; }
    
    public User(int id, string username, string password, bool isManager, bool isDriver)
    {
        Id = id;
        Username = username;
        Password = password;
        IsManager = isManager;
        IsDriver = isDriver;
    }

    public void UpdateUser(string username, string password, bool isManager, bool isDriver)
    {
        Username = username;
        Password = password;
        IsManager = isManager;
        IsDriver = isDriver;        
    }
}