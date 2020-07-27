using AutoMapper;
using LaFarina.Entities;
using LaFarina.Models.IngredientM;
using LaFarina.Models.OrderM;
using LaFarina.Models.PizzaM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Pizza Map
            CreateMap<Pizza, PizzaModel>();
            CreateMap<RegisterPizzaModel, Pizza>();
            CreateMap<UpdatePizzaModel, Pizza>();

            //Ingredient Map
            CreateMap<Ingredient, IngredientModel>();
            CreateMap<RegisterIngredientModel, Ingredient>();
            CreateMap<UpdateIngredientModel, Ingredient>();

            //Order Map
            CreateMap<Order, OrderModel>();
            CreateMap<RegisterOrderModel, Order>();
            CreateMap<UpdateOrderModel, Order>();
        }

    }
}
