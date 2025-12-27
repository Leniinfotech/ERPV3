using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WorkMasterController : ControllerBase
    {
        private readonly IWorkMasterService _service;

        public WorkMasterController(IWorkMasterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{fran}/{workType}/{workId}")]
        public async Task<IActionResult> Get(string fran, string workType, decimal workId)
        {
            var entity = await _service.GetByIdAsync(fran, workType, workId);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkMaster entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { fran = entity.Fran, workType = entity.WorkType, workId = entity.WorkId }, entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WorkMaster entity)
        {
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{fran}/{workType}/{workId}")]
        public async Task<IActionResult> Delete(string fran, string workType, decimal workId)
        {
            await _service.DeleteAsync(fran, workType, workId);
            return NoContent();
        }
    }
}

