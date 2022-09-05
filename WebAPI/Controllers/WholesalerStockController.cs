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
    public class WholesalerStockController : ControllerBase
    {
        IWholesalerStockService _wholesalerStockService;

        public WholesalerStockController(IWholesalerStockService wholesalerStockService)
        {
            _wholesalerStockService = wholesalerStockService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _wholesalerStockService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallbywholesalerid")]
        public IActionResult GetAllByBreweryId(int Id)
        {
            var result = _wholesalerStockService.GetAllByWholesalerId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int Id)
        {
            var result = _wholesalerStockService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]

        public IActionResult Add(WholesalerStock wholesalerStock)
        {
            var result = _wholesalerStockService.Add(wholesalerStock);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
