using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _orderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }



        [HttpGet("getbyid")]
        public IActionResult Get(int Id)
        {
            var result = _orderService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]

        public IActionResult Add(Orders order)
        {
            var result = _orderService.Add(order);

            if (result.Success)
            {
                return Ok(new DataResult<Orders>(order, result.Success, result.Message));
            }
            return BadRequest(result.Message);
        }

        public IActionResult Delete(Orders order)
        {
            var result = _orderService.Delete(order);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        public IActionResult Update(Orders order)
        {
            var result = _orderService.Update(order);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
