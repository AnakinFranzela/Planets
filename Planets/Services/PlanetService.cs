using Planets.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using Planets.Repositories.IRepositories;
using Planets.Services.IServices;
using Eecomerce.Helpers;

namespace Planets.Services
{
    public class PlanetService : IPlanetService
    {
        private IPlanetRepository _repository;
        private IValidationDictionary? _modelState;

        public PlanetService(IPlanetRepository repository)
        {
            _repository = repository;
        }

        public void SetModelStateDictionary(IValidationDictionary modelState)
        {
            _modelState = modelState;
        }

        public Planet? GetCategoryById(int? id)
        {
            return _repository.FindById(id);
        }

        public List<Planet> GetPlanetList()
        {
            return _repository.ToList();
        }

        public bool AddPlanet(Planet planet)
        {
            try
            {
                if (!ValidatePlanet(planet))
                {
                    return false;
                }
                return _repository.Add(planet);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePlanet(Planet planet)
        {
            try
            {
                if (!ValidatePlanet(planet))
                {
                    return false;
                }
                return _repository.Update(planet);
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePlanet(int id)
        {
            return _repository.Delete(id);
        }

        public bool ValidatePlanet(Planet planet)
        {
            if (_modelState == null)
            {
                throw new ArgumentNullException(nameof(_modelState));
            }

            if (!String.IsNullOrEmpty(planet.Name) && planet.Name.ToLower() == "test")
            {
                _modelState.AddError("Name", "\"Test\" is an invalid value!");
            }

            Planet? category1 = _repository.CheckForExistingPlanet(planet.Name);
            if (category1 != null)
            {
                if (planet.Id != category1.Id)
                {
                    _modelState.AddError("", $"Category {category1.Name} already exists.");
                }
            }

            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(planet.Name);
            if (match.Success)
            {
                _modelState.AddError("", "Category name can not have a number.");
            }

            return _modelState.IsValid;
        }
    }
}
