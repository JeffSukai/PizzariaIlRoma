using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Models.IngredientM
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int PizzaId { get; set; }
    }
}
