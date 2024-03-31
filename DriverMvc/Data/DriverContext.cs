using Microsoft.EntityFrameworkCore;
using DriverMvc.Models; 

namespace DriverMvc.Data
{
    public class DriverContext : DbContext
    {
        public DriverContext(DbContextOptions<DriverContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        // Add other DbSets for your other entities
    }
}