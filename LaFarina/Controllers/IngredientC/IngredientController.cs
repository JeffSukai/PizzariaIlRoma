using AutoMapper;
using LaFarina.Entities;
using LaFarina.Models.IngredientM;
using LaFarina.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Controllers.IngredientC
{
    [ApiController]
    [Route("api/pizza/ingredient")]
    public class IngredientController : ControllerBase
    {
        private IIngredientService _ingredientService;
        private IMapper _mapper;

        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Register([FromBody] RegisterIngredientModel model)
        {
            var _ingredient = _mapper.Map<Ingredient>(model);
            try
            {
                _ingredientService.Create(_ingredient);
                return Ok(_ingredient);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var _ingredient = _ingredientService.GetAll();
            var model = _mapper.Map<IList<IngredientModel>>(_ingredient);
            return Ok(model);
        }

        [HttpPut("update/{Id}")]
        public IActionResult Update(int Id,[FromBody] UpdateIngredientModel model)
        {
            var _ingredient = _mapper.Map<Ingredient>(model);
            _ingredient.Id = Id;
           
            try
            {
                _ingredientService.Update(_ingredient);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _ingredientService.Delete(id);
            return Ok();
        }
    }
}
