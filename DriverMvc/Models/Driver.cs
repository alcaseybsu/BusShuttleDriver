namespace DriverMvc.Models;

public class Driver
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }
    
    public Driver(int id, string username, string password, bool role, bool isActive)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
        IsActive = isActive;
    }

    public void UpdateDriver(string username, string password, string role, bool isActive)
    {
        Username = username;
        Password = password;
        Role = role;
        IsActive = isActive;        
    }
}