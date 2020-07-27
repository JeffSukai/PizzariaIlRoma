using LaFarina.Entities;
using LaFarina.Helpers;
using LaFarina.Models.PizzaM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Services
{
    public interface IPizzaService
    {
        IEnumerable<Pizza> GetAll();
        Pizza Create(Pizza pizza);
        void Update(int Id,Pizza pizza);
        void Delete(int id);
    }

    public class PizzaService : IPizzaService
    {
        public LaFarinaContext _context;

        public PizzaService(LaFarinaContext context)
        {
            _context = context;
        }

        public Pizza Create(Pizza pizza)
        {
            if (string.IsNullOrWhiteSpace(pizza.Name))
                throw new AppException("Name is required");

            _context.Pizzas.Add(pizza);
            _context.SaveChanges();

            return pizza;
        }

        public IEnumerable<Pizza> GetAll()
        {
            //TODO: Add ingredient to Pizza > ingredient List
            return _context.Pizzas;
        }

        public void Update(int Id, Pizza pizza)
        {
            var _Pizza = _context.Pizzas.Find(Id);

            if (_Pizza == null)
                throw new AppException("Pizza not found");

            if (!string.IsNullOrEmpty(pizza.Name) || !string.IsNullOrEmpty(pizza.Price))
            {
                _Pizza.Name = pizza.Name;
                _Pizza.Price = pizza.Price;
            }

            _context.Pizzas.Update(_Pizza);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var _Pizza = _context.Pizzas.Find(id);
            if (_Pizza != null)
            {
                _context.Pizzas.Remove(_Pizza);
                _context.SaveChanges();
            }
        }
    }
}
