using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api1.Models.ProductModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
