using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        IRentService _rentService;

        public RentsController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbydto")]
        public IActionResult GetAllByDto()
        {
            var result = _rentService.GetRentByDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(RentalPaymentDto rental)
        {
            var result = _rentService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rent rent)
        {
            var result = _rentService.Delete(rent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rent rent)
        {
            var result = _rentService.Update(rent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}