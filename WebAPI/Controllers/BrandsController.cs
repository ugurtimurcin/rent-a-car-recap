using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(BrandDto brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest(result);
        }

        [HttpPut("edit")]
        public IActionResult Edit(BrandDto brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(BrandDto brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
