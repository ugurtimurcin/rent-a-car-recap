using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ColorDto color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public IActionResult Edit(ColorDto color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ColorDto color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
