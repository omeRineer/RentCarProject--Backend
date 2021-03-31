using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utility.Helpers.FileHelpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
            
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name ="Image")] IFormFile file,[FromForm] CarImage carImage)
        {

            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}