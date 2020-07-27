using LaFarina.Entities;
using LaFarina.Helpers;
using LaFarina.Models.IngredientM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Services
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient Create(Ingredient ingredient);
        void Update(Ingredient ingredient);
        void Delete(int id);
    }

    public class IngredientService : IIngredientService
    {
        public LaFarinaContext _context;

        public IngredientService(LaFarinaContext context)
        {
            _context = context;
        }

        public Ingredient Create(Ingredient ingredient)
        {
            if (string.IsNullOrWhiteSpace(ingredient.Name))
                throw new AppException("Name is required");

            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();

            return ingredient;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _context.Ingredients;
        }

        public void Update(Ingredient ingredient)
        {
            var _Ingredient = _context.Ingredients.Find(ingredient.Id);

            if (_Ingredient == null)
                throw new AppException("Ingredient not found");

            if (!string.IsNullOrWhiteSpace(ingredient.Name))
            {
                if (_context.Ingredients.Any(x => x.Name == ingredient.Name))
                    throw new AppException("Ingredient: " + ingredient.Name + " is allready taken");

                _Ingredient.Name = ingredient.Name;
                _Ingredient.Price = ingredient.Price;
            }

            _Ingredient.Name = ingredient.Name;
            _Ingredient.Price = ingredient.Price;

            _context.Ingredients.Update(_Ingredient);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var _Ingredient = _context.Ingredients.Find(id);
            if(_Ingredient != null)
            {
                _context.Ingredients.Remove(_Ingredient);
                _context.SaveChanges();
            }
        }
    }
}
