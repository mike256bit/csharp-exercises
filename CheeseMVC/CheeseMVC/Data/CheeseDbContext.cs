using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {

        public DbSet<Cheese> Cheeses { get; set; }

        //takes DbContextOptions, calls base constructor, basic boiler plate code
        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
            : base(options)
        {
        }
    }
}
