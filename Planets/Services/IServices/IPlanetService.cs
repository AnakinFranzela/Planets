using Planets.Entities;
namespace Planets.Services.IServices
{
    public interface IPlanetService
    {
        Planet? GetCategoryById(int? id);
    }
}
