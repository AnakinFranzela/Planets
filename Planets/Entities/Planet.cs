using System.ComponentModel.DataAnnotations;
namespace Planets.Entities
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MoonCount { get; set; }
        public int PopulationCount { get; set; }
    }
}
