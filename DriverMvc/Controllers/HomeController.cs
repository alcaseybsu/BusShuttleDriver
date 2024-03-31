using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DriverMvc.Models;
using DriverMvc.Service;

namespace DriverMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<HomeController> _logger; 

        public HomeController(IAuthenticationService authenticationService, ILogger<HomeController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Result of auth {_authenticationService.Authenticate(username, password)}"); // Using _logger instead of Console.WriteLine
                if (_authenticationService.Authenticate(username, password))
                {
                    // Authentication successful
                    // Redirect to dashboard/home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }
            // If model state invalid or auth fail, return to login view w/error
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}