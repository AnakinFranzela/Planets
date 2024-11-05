namespace Planets.Models
{
    public class PlanetsViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int MoonCount { get; set; }
        public int PopulationCount { get; set; }

        public void PopulatePlanet(Planets.Entities.Planet planet)
        {
            planet.Name = Name;
            planet.MoonCount = MoonCount;
            planet.PopulationCount = PopulationCount;
        }

        public void PopulateFromPlanet(Planets.Entities.Planet? planet)
        {
            if (planet == null)
                return;
            Id = planet.Id;
            Name = planet.Name;
            MoonCount = planet.MoonCount;
            PopulationCount = planet.PopulationCount;
        }
    }
}
