using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Entities
{
    public class Pizza
    {

        public Pizza()
        {
            Ingredients = new List<Ingredient>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }    
        public string imgPath { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }

        [ForeignKey("OrderId")]
        public int Order_Id { get; set; }
    }
}
