using AutoMapper;
using LaFarina.Entities;
using LaFarina.Models.PizzaM;
using LaFarina.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LaFarina.Controllers.PizzaC
{
    [ApiController]
    [Route("api/pizza")]
    public class PizzaController : ControllerBase
    {
        private IPizzaService _pizzaService;
        private IMapper _mapper;

        public PizzaController(IPizzaService pizzaService, IMapper mapper)
        {
            _pizzaService = pizzaService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Register([FromBody] RegisterPizzaModel model)
        {
            var _pizza = _mapper.Map<Pizza>(model);
            try
            {
                _pizzaService.Create(_pizza);
                return Ok(_pizza);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var _pizza = _pizzaService.GetAll();
            var model = _mapper.Map<IList<PizzaModel>>(_pizza);
            return Ok(model);
        }

        [HttpPut("update/{Id}")]
        public IActionResult Update(int Id, [FromBody] UpdatePizzaModel model)
        {
            var _pizza = _mapper.Map<Pizza>(model);

            try
            {
                _pizzaService.Update(Id,_pizza);
                return Ok(_pizza);
            }
            catch (Exception ex)
            { 
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _pizzaService.Delete(id);
            return Ok();
        }

    }
}
