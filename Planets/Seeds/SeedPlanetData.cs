using Microsoft.EntityFrameworkCore;
using Planets.Data;
using Planets.Entities;

namespace Planets.Seeds
{
    public class SeedPlanetData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PlanetsDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PlanetsDbContext>>()))
            {
                // Look for any categories.
                if (context.Planets.Any())
                {
                    return;   // DB has been seeded
                }
                context.Planets.AddRange(
                    new Planet
                    {
                        Name = "Mars",
                        MoonCount = 1,
                        PopulationCount = 82374
                    },
                    new Planet
                    {
                        Name = "Pluto",
                        MoonCount = 5,
                        PopulationCount = 13
                    },
                    new Planet
                    {
                        Name = "Jupiter",
                        MoonCount = 7,
                        PopulationCount = 235
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
