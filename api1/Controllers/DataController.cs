using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api1.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult SumResult(decimal a, decimal b, decimal c)
        {
            return Ok(new Sum
            {
                Result = a + b + c
            });
        }
    }
}

        

    

