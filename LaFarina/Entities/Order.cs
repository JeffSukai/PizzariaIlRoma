using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Entities
{
    public class Order
    {

        public Order()
        {
            Pizzas = new List<Pizza>();
        }

        [Key]
        public int Id { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }
        public float Price { get; set; }
        public string Comment { get; set; }
    }
}
