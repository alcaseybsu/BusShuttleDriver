namespace DriverMvc.Data;

public class DataModel
{
    
}

public class Driver
{
    public Driver()
    {
        Username = string.Empty;
        Password = string.Empty;
    }
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsManager { get; set; }
    public bool IsDriver { get; set; }
    
}