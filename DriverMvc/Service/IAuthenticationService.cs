namespace DriverMvc.Service;

public  interface IAuthenticationService
{
    bool Authenticate(string username, string password);
}