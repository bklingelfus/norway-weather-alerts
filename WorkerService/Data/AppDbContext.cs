using Microsoft.EntityFrameworkCore;
using WorkerService.Data.Entities;

namespace WorkerService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WeatherAlert> WeatherAlerts { get; set; }
    }
}
