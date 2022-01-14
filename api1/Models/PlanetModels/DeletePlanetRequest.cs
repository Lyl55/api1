using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api1.Models.PlanetModels
{
    public class DeletePlanetRequest
    {
        [Range(1, int.MaxValue)]
        [Required]
        public int Id { get; set; }
    }
}
