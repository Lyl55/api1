﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api1.Models.NewFolder
{
    public class PlanetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasWater { get; set; }
        public string PlanetarySystem { get; set; }
        public bool Livable { get; set; }

    }
}