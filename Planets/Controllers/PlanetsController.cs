using Microsoft.AspNetCore.Mvc;
using Planets.Models;
using Planets.Entities;
using Planets.Services.IServices;
using System.Web;

namespace Planets.Controllers
{
    public class PlanetsController : Controller
    {
        private IPlanetService _planetService;
        private IHttpContextAccessor _httpContextAccessor;

        public PlanetsController(IPlanetService categoryService, IHttpContextAccessor httpContextAccessor)
        {
            _planetService = categoryService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
