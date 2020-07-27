using AutoMapper;
using LaFarina.Entities;
using LaFarina.Models.OrderM;
using LaFarina.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Controllers.OrderC
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpPost("create")]
        public IActionResult Register([FromBody] RegisterOrderModel model)
        {
            var _order = _mapper.Map<Order>(model);
            try
            {
                _orderService.Create(_order);
                return Ok(_order);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var _order = _orderService.GetAll();
            var model = _mapper.Map<IList<OrderModel>>(_order);
            return Ok(model);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateOrderModel model)
        {
            var _order = _mapper.Map<Order>(model);

            try
            {
                _orderService.Update(_order);
                return Ok(_order);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return Ok();
        }
    }
}
