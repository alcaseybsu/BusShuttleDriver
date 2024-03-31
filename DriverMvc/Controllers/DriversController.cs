using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DriverMvc.Data;
using DriverMvc.Models;
using System.Threading.Tasks;

namespace DriverMvc.Controllers
{
    public class DriversController : Controller    
    {
        private readonly AppDbContext _dbContext;
        //private readonly DriverContext _dbContext;

        public DriversController(DriverContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lists all drivers
        [HttpGet] 
        public async Task<IActionResult> Index()
        {
            var drivers = await _dbContext.Driver.ToListAsync();
            return View(drivers);
        }

        // Displays the edit form for a driver
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var driver = await _dbContext.Drivers.FindAsync(id);
            if (driver == null) return NotFound();

            return View(driver);
        }

        // Processes the edit form submission
        [HttpPost]
        public async Task<IActionResult> Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(driver);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        [HttpPost]
        public async Task<IActionResult> Signup(DriverSignupModel model)
        {
            if (ModelState.IsValid)
            {
                var driver = new Driver
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role,
                    IsActive = model.IsActive
                };
                _dbContext.Add(driver);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
