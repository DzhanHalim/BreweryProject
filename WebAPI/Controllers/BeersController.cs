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
    public class BeersController : ControllerBase
    {
        IBeerService _beerService;

        public BeersController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _beerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallbybreweryid")]
        public IActionResult GetAllByBreweryId(int Id)
        {
            var result = _beerService.GetAllByBreweryId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int Id)
        {
            var result = _beerService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]

        public IActionResult Add(Beer beer)
        {
            var result = _beerService.Add(beer);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
