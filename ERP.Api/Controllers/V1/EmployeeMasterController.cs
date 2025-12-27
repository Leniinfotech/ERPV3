using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly IEmployeeMasterService _service;

        public EmployeeMasterController(IEmployeeMasterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{fran}/{employee}")]
        public async Task<IActionResult> Get(string fran, string employee)
        {
            var entity = await _service.GetByIdAsync(fran, employee);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeMaster entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { fran = entity.Fran, employee = entity.Employee }, entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeMaster entity)
        {
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{fran}/{employee}")]
        public async Task<IActionResult> Delete(string fran, string employee)
        {
            await _service.DeleteAsync(fran, employee);
            return NoContent();
        }
    }
}

