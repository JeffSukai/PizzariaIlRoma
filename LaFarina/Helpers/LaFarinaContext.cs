using LaFarina.Entities;
using LaFarina.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Helpers
{
    public class LaFarinaContext : DbContext
    {

        public LaFarinaContext(DbContextOptions<LaFarinaContext> options) : base(options)
        { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order>  Orders {get; set;}
    }
}
