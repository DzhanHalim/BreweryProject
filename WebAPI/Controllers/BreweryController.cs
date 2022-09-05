using Business.Abstract;
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
    public class BreweryController : ControllerBase
    {
        IBreweryService _breweryService;

        public BreweryController(IBreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _breweryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        

        [HttpGet("getbyid")]
        public IActionResult Get(int Id)
        {
            var result = _breweryService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]

        public IActionResult Add(Brewery brewery)
        {
            var result = _breweryService.Add(brewery);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        public IActionResult Delete(Brewery brewery)
        {
            var result = _breweryService.Delete(brewery);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        public IActionResult Update(Brewery brewery)
        {
            var result = _breweryService.Update(brewery);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
