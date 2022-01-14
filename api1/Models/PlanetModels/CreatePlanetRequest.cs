using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api1.Models.PlanetModels
{
    public class CreatePlanetRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool HasWater { get; set; }
        [Required]
        public string PlanetarySystem { get; set; }
        [Required]
        public bool Livable { get; set; }
    }
}
