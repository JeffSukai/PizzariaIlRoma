using LaFarina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Models.OrderM
{
    public class OrderModel
    {
        public int Id { get; set; }
        public ICollection<Pizza> pizzas { get; set; }
        public float Price { get; set; }
        public string Comment { get; set; }
    }
}
