using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerDto customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest(result);
        }

        [HttpPut("edit")]
        public IActionResult Edit(CustomerDto customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(CustomerDto customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(result);
        }
    }
}
