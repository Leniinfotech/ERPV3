using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class VehicleMasterController : ControllerBase
    {
        private readonly IVehicleMasterService _service;

        public VehicleMasterController(IVehicleMasterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{vechileId}")]
        public async Task<IActionResult> Get(decimal vechileId)
        {
            var entity = await _service.GetByIdAsync(vechileId);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleMaster entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { vechileId = entity.VechileId }, entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VehicleMaster entity)
        {
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{vechileId}")]
        public async Task<IActionResult> Delete(decimal vechileId)
        {
            await _service.DeleteAsync(vechileId);
            return NoContent();
        }
    }
}

