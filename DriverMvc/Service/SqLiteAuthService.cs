using Microsoft.AspNetCore.Authentication;
using DriverMvc.Data;

namespace DriverMvc.Service;

public class SqLiteAuthService : IAuthenticationService
{
    private readonly DriverContext _dbContext;

    public SqLiteAuthService(DriverContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Auth logic
    public bool Authenticate(string username, string password)
    {
        PrintAllUsers();
        Console.WriteLine("authenticate hit at sqlite auth");
        // Query the database to check if username and password match
        var user = _dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        Console.WriteLine("User " + user);
        return user != null;
    }

    // For testing: 
    public void PrintAllUsers()
    {
        var users = _dbContext.Users.ToList();

        // Print details of all users
        foreach (var user in users)
        {
            Console.WriteLine($"User ID: {user.Id}, Username: {user.Username}, Password: {user.Password}, IsManager: {user.IsManager}, IsDriver: {user.IsDriver}");
        }
    }
}