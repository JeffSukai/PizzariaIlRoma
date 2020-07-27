using LaFarina.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Models.PizzaM
{
    public class RegisterPizzaModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string imgPath { get; set; }
        public int Order_Id { get; set; }
    }
}
