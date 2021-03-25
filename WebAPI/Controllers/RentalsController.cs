using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(RentalDto rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest(result);
        }

        [HttpPut("add")]
        public IActionResult Edit(RentalDto rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(RentalDto rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(result);
        }
    }
}
