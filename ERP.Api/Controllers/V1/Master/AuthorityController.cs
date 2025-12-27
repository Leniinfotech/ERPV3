using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Master;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/master/[controller]")]
#if DEBUG
[AllowAnonymous]
#endif
public class AuthorityController(IAuthorityService svc) : ControllerBase
{


    //[HttpGet]
    //public async Task<ActionResult<IReadOnlyList<AuthorityDto>>> GetAll(CancellationToken ct)
    //    => Ok(await svc.GetAllAsync(ct));

    //[HttpGet("{fran}/{type}/{userId}/{menu}/{subMenu}")]
    //public async Task<ActionResult<AuthorityDto>> GetByKey(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct)
    //{
    //    var dto = await svc.GetByKeyAsync(fran, type, userId, menu, subMenu, ct);
    //    return dto is null ? NotFound() : Ok(dto);
    //}

    //[HttpPost]
    //public async Task<ActionResult<AuthorityDto>> Create([FromBody] CreateAuthorityRequest request, CancellationToken ct)
    //{
    //    var dto = await svc.CreateAsync(request, ct);
    //    return CreatedAtAction(nameof(GetByKey), new { dto.Fran, dto.Type, dto.UserId, dto.Menu, dto.SubMenu }, dto);
    //}

    //[HttpPut("{fran}/{type}/{userId}/{menu}/{subMenu}")]
    //public async Task<ActionResult<AuthorityDto>> Update(string fran, string type, string userId, string menu, string subMenu, [FromBody] UpdateAuthorityRequest request, CancellationToken ct)
    //{
    //    var dto = await svc.UpdateAsync(fran, type, userId, menu, subMenu, request, ct);
    //    return dto is null ? NotFound() : Ok(dto);
    //}

    //[HttpDelete("{fran}/{type}/{userId}/{menu}/{subMenu}")]
    //public async Task<IActionResult> Delete(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct)
    //    => await svc.DeleteAsync(fran, type, userId, menu, subMenu, ct) ? NoContent() : NotFound();
}
