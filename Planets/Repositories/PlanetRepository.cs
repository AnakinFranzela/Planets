using Planets.Data;
using Planets.Entities;
using Planets.Repositories.IRepositories;
using Planets.Services.IServices;

namespace Planets.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly PlanetsDbContext _context;

        public PlanetRepository(PlanetsDbContext context)
        {
            _context = context;
        }

        public bool Add(Planet planet)
        {
            try
            {
                _context.Planets.Add(planet);
                int stateNumber = _context.SaveChanges();
                return stateNumber > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Planet planet)
        {
            try
            {
                _context.Planets.Update(planet);
                int stateNumber = _context.SaveChanges();
                return stateNumber > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Planet> ToList()
        {
            return _context.Planets.ToList();
        }

        public Planet? CheckForExistingPlanet(string? planetName)
        {
            if (String.IsNullOrEmpty(planetName))
            {
                return null;
            }

            return _context.Planets.Where(s => s.Name!.ToUpper().Equals(planetName.ToUpper())).FirstOrDefault();
        }

        public Planet? FindById(int? id)
        {
            if (id == null || id == 0)
            {
                return null;
            }

            Planet? planet = _context.Planets.Find(id);
            return planet;
        }

        public bool Delete(int id)
        {
            Planet? planet = FindById(id);
            if (planet == null)
            {
                return false;
            }

            try
            {
                _context.Planets.Remove(planet);
                int stateNumber = _context.SaveChanges();
                return stateNumber > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
