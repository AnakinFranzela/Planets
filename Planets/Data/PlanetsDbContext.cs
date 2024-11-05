using Microsoft.EntityFrameworkCore;
using Planets.Entities;

namespace Planets.Data
{
    public class PlanetsDbContext : DbContext
    {
        public PlanetsDbContext(DbContextOptions<PlanetsDbContext> options) : base(options)
        {

        }
        public DbSet<Planet> Planets { get; set; }
    }
}
