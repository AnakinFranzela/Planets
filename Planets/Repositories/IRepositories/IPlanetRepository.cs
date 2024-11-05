using Planets.Entities;

namespace Planets.Repositories.IRepositories
{
    public interface IPlanetRepository
    {
        public bool Add(Planet planet);
        public bool Update(Planet planet);
        public List<Planet> ToList();
        public Planet? CheckForExistingPlanet(string? planetName);
        public Planet? FindById(int? id);
        public bool Delete(int id);
    }
}
