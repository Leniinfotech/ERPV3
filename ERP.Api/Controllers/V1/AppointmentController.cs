using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{fran}/{appointId}")]
        public async Task<IActionResult> Get(string fran, decimal appointId)
        {
            var entity = await _service.GetByIdAsync(fran, appointId);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Appointment entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { fran = entity.Fran, appointId = entity.AppointId }, entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Appointment entity)
        {
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{fran}/{appointId}")]
        public async Task<IActionResult> Delete(string fran, decimal appointId)
        {
            await _service.DeleteAsync(fran, appointId);
            return NoContent();
        }
    }
}

