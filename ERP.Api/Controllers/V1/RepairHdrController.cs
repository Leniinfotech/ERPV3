using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class RepairHdrController : ControllerBase
    {
        private readonly IRepairHdrService _service;

        public RepairHdrController(IRepairHdrService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{fran}/{brch}/{workshop}/{repairType}/{repairNo}")]
        public async Task<IActionResult> Get(string fran, string brch, string workshop, string repairType, string repairNo)
        {
            var entity = await _service.GetByIdAsync(fran, brch, workshop, repairType, repairNo);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RepairHdr entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { fran = entity.Fran, brch = entity.Brch, workshop = entity.Workshop, repairType = entity.RepairType, repairNo = entity.RepairNo }, entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RepairHdr entity)
        {
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{fran}/{brch}/{workshop}/{repairType}/{repairNo}")]
        public async Task<IActionResult> Delete(string fran, string brch, string workshop, string repairType, string repairNo)
        {
            await _service.DeleteAsync(fran, brch, workshop, repairType, repairNo);
            return NoContent();
        }
    }
}

