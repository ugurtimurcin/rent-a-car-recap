using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetailbyid")]
        public IActionResult GetCarDetail(int id)
        {
            var result = _carService.GetCarDetailById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int id)
        {
            var result = _carService.GetCarsByBrand(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CarDto car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest(result);
        }

        [HttpPut("edit")]
        public IActionResult Edit(CarDto car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(CarDto car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(result);
        }
    }
}
