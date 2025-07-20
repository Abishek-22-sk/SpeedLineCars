using Microsoft.EntityFrameworkCore;
using SpeedLinecars.Models;

namespace SpeedLinecars.Data
{
    public class SpeedLineDbContext : DbContext
    {
        public SpeedLineDbContext(DbContextOptions<SpeedLineDbContext> options) : base(options) 
        { 

        }

        public DbSet<Brand>Brands { get; set; }
    }
}
