using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Finance;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class ParamsService(IParamsRepository repo) : IParamsService
{
    public async Task<IReadOnlyList<ParamsDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await repo.GetAllAsync(ct);
        return items.Select(MapToDto).ToList();
    }

    public async Task<ParamsDto?> GetByKeyAsync(string fran, string paramType, string paramValue, CancellationToken ct)
    {
        var item = await repo.GetByKeyAsync(fran, paramType, paramValue, ct);
        return item is null ? null : MapToDto(item);
    }

    private static ParamsDto MapToDto(Params e) => new(
        e.Id, e.Fran, e.ParamType, e.ParamValue, e.ParamValueStr1, e.ParamValueNum1,
        e.ParamDesc, e.ParamCategory, e.ParamRemarks,
        e.CreateDt, e.CreateTm, e.CreateBy);

    // Added: Added method to loadparam
    // Added by: Vaishnavi
    // Added on: 12-12-2025
    public async Task<IReadOnlyList<LoadParam>> LoadByParamAsync(string fran, string paramType, CancellationToken ct)
    {
        return await repo.LoadByParamAsync(fran, paramType, ct);
    }
}
