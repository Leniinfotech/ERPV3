using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WorkInvHdrController : ControllerBase
    {
        private readonly IWorkInvHdrService _service;

        public WorkInvHdrController(IWorkInvHdrService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{fran}/{brch}/{workshop}/{workInvType}/{workInvNo}")]
        public async Task<IActionResult> Get(string fran, string brch, string workshop, string workInvType, string workInvNo)
        {
            var entity = await _service.GetByIdAsync(fran, brch, workshop, workInvType, workInvNo);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkInvHdr entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { fran = entity.Fran, brch = entity.Brch, workshop = entity.Workshop, workInvType = entity.WorkInvType, workInvNo = entity.WorkInvNo }, entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WorkInvHdr entity)
        {
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{fran}/{brch}/{workshop}/{workInvType}/{workInvNo}")]
        public async Task<IActionResult> Delete(string fran, string brch, string workshop, string workInvType, string workInvNo)
        {
            await _service.DeleteAsync(fran, brch, workshop, workInvType, workInvNo);
            return NoContent();
        }
    }
}

