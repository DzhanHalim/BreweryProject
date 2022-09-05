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
    public class WholesalerController : ControllerBase
    {

        IWholesalerService _wholesalerService;

        public WholesalerController(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _wholesalerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }



        [HttpGet("getbyid")]
        public IActionResult Get(int Id)
        {
            var result = _wholesalerService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]

        public IActionResult Add(Wholesaler wholesaler)
        {
            var result = _wholesalerService.Add(wholesaler);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        public IActionResult Delete(Wholesaler wholesaler)
        {
            var result = _wholesalerService.Delete(wholesaler);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        public IActionResult Update(Wholesaler wholesaler)
        {
            var result = _wholesalerService.Update(wholesaler);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }

}
