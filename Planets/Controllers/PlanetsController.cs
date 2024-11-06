using Microsoft.AspNetCore.Mvc;
using Planets.Models;
using Planets.Entities;
using Planets.Services.IServices;
using System.Web;
using Eecomerce.Helpers;

namespace Planets.Controllers
{
    public class PlanetsController : Controller
    {
        private IPlanetService _planetService;
        //private IHttpContextAccessor _httpContextAccessor;

        public PlanetsController(IPlanetService planetService)
        {
            _planetService = planetService;
        }
        public IActionResult Index()
        {
            List<Planet> planets = _planetService.GetPlanetList();
            return View(planets);
        }

        public IActionResult Create()
        {
            PlanetsViewModel viewModel = new PlanetsViewModel();
            return View(viewModel);
        }

        public IActionResult Update(int id)
        {
            PlanetsViewModel viewModel = new PlanetsViewModel();
            Planet? planet = _planetService.GetCategoryById(id);

            if (planet == null)
            {
                TempData["error"] = "Category with id " + id + " not found!";
                return RedirectToAction("Index");
            }
            viewModel.PopulateFromPlanet(planet);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PlanetsViewModel viewModel)
        {
            _planetService.SetModelStateDictionary(new ModelStateWrapper(ModelState));
            Planet? planet = _planetService.GetCategoryById(viewModel.Id);

            if (planet == null)
            {
                TempData["error"] = "Unable to find planet!";
                return RedirectToAction("Index");
            }

            viewModel.PopulatePlanet(planet);
            if (_planetService.UpdatePlanet(planet))
            {
                TempData["success"] = $"Category {planet.Name} was updated successfully!";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                TempData["error"] = "Unable to update category!";
            }


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlanetsViewModel viewModel)
        {
            _planetService.SetModelStateDictionary(new ModelStateWrapper(ModelState));
            Planet planet = new Planet();

            viewModel.PopulatePlanet(planet);
            if (_planetService.AddPlanet(planet))
            {
                TempData["success"] = $"Category {planet.Name} was created successfully!";
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                TempData["error"] = "Unable to create category!";
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (_planetService.DeletePlanet(id))
            {
                TempData["success"] = "Category was deleted successfully";
            }
            else
            {
                TempData["error"] = "Unable to delete category";
            }
            return RedirectToAction("Index");
        }
    }
}
