using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api1.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace api1.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
