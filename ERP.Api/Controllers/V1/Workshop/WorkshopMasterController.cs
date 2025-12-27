using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WorkshopMasterController : ControllerBase
    {
        private readonly IWorkshopMasterService _service;

        public WorkshopMasterController(IWorkshopMasterService service) // ✅ inject interface
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{fran}/{workshop}")]
        public async Task<IActionResult> Get(string fran, decimal workshop)
        {
            var entity = await _service.GetByIdAsync(fran, workshop);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkshopMaster entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { fran = entity.Fran, workshop = entity.Workshop }, entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WorkshopMaster entity)
        {
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{fran}/{workshop}")]
        public async Task<IActionResult> Delete(string fran, decimal workshop)
        {
            await _service.DeleteAsync(fran, workshop);
            return NoContent();
        }
    }
}
