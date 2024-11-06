using Eecomerce.Helpers;
using Planets.Entities;
namespace Planets.Services.IServices
{
    public interface IPlanetService
    {
        Planet? GetCategoryById(int? id);
        public void SetModelStateDictionary(IValidationDictionary modelState);
        public List<Planet> GetPlanetList();
        public bool AddPlanet(Planet planet);
        public bool UpdatePlanet(Planet planet);
        public bool DeletePlanet(int id);
        public bool ValidatePlanet(Planet planet);

    }
}
