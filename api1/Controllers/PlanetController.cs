using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api1.Models.NewFolder;
using api1.Models.PlanetModels;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Route("[controller]")]
    public class PlanetController : ControllerBase
    {
        private static readonly List<PlanetModel> planets = new List<PlanetModel>
        {
            new PlanetModel
            {
                Id = 1,
                HasWater = true,
                PlanetarySystem = "SolarSystem",
                Livable = true,
                Name = "Earth"
            },
            new PlanetModel
            {
                Id = 2,
                PlanetarySystem = "SolarSystem",
                HasWater = false,
                Livable = false,
                Name = "Mars"
            }
        };

        [HttpGet]
        public IActionResult Planets()
        {
            var models = planets.Select(x => new PlanetModel()
            {
                Id = x.Id,
                Name = x.Name
            });

            return Ok(models);
        }

        //[HttpGet("{id}/{name}")]
        [HttpGet("id")]
        public IActionResult Planet(int id)
        {
            var planet = planets.FirstOrDefault(x => x.Id == id);

            return Ok(planet);
        }

        [HttpPost]
        public IActionResult Add(CreatePlanetRequest model)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Not valid!");
            }

            var planet = new PlanetModel
            {
                HasWater = model.HasWater,
                Livable = model.Livable,
                Name = model.Name,
                PlanetarySystem = model.PlanetarySystem
            };
            var Lid = planets.LastOrDefault()?.Id ?? 0;
            planet.Id = Lid + 1;
            planets.Add(planet);
            return StatusCode((int) HttpStatusCode.Created);
        }

        [HttpPost]
        public IActionResult Update(UpdatePlanetRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Not valid!");
            }

            var planet = planets.FirstOrDefault(x => x.Id == request.Id);
            if (planet == null)
            {
                return BadRequest("Planet not found!");
            }

            planet.Id = request.Id;
            planet.Name = request.Name;
            planet.HasWater = request.HasWater;
            planet.PlanetarySystem = request.PlenatarySystem;
            planet.Livable = request.Livable;
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(DeletePlanetRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Not valid!");
            }

            var planet = planets.FirstOrDefault(x => x.Id == request.Id);
            if (planet!=null)
            {
                planets.RemoveAll(s => s.Id == request.Id);
            }
            
            return Ok();
        }
    }
}