using AirportSim.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportSim.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Log> Logs { get; set; }
    }
}
