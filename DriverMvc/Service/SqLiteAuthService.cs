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
        PrintAllDrivers();
        Console.WriteLine("authenticate hit at sqlite auth");
        // Query the database to check if username and password match
        var driver = _dbContext.Drivers.FirstOrDefault(u => u.Username == username && u.Password == password);
        Console.WriteLine("Driver" + driver);
        return driver != null;
    }

    // For testing: 
    public void PrintAllDrivers()
    {
        var drivers = _dbContext.Drivers.ToList();

        // Print details of all drivers
        {
            Console.WriteLine($"Driver ID: {driver.Id}, Username: {driver.Username}, Password: {driver.Password}, IsManager: {driver.IsManager}, IsDriver: {driver.IsDriver}");
        }
    }
}