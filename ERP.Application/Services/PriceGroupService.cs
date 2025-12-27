using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class PriceGroupService(IPriceGroupRepository repo) : IPriceGroupService
{
    // Masters
    public async Task<IReadOnlyList<PriceGroupMasterDto>> GetAllMastersAsync(CancellationToken ct)
    {
        var items = await repo.GetAllMastersAsync(ct);
        return items.Select(MapMasterToDto).ToList();
    }

    public async Task<PriceGroupMasterDto?> GetMasterByKeyAsync(string fran, string prcType, string prcGrp, CancellationToken ct)
    {
        var item = await repo.GetMasterByKeyAsync(fran, prcType, prcGrp, ct);
        return item is null ? null : MapMasterToDto(item);
    }

    public async Task<PriceGroupMasterDto> CreateMasterAsync(CreatePriceGroupMasterRequest request, CancellationToken ct)
    {
        var entity = new PriceGroupMaster
        {
            Fran = request.Fran, PrcType = request.PrcType, PrcGrp = request.PrcGrp,
            Flag1 = request.Flag1 ?? string.Empty, Flag2 = request.Flag2 ?? string.Empty, Flag3 = request.Flag3 ?? string.Empty,
            Factor1 = request.Factor1 ?? 0m, Factor2 = request.Factor2 ?? 0m, Factor3 = request.Factor3 ?? 0m,
            Remarks = request.Remarks ?? string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddMasterAsync(entity, ct);
        return MapMasterToDto(created);
    }

    public async Task<PriceGroupMasterDto?> UpdateMasterAsync(string fran, string prcType, string prcGrp, UpdatePriceGroupMasterRequest request, CancellationToken ct)
    {
        var existing = await repo.GetMasterByKeyAsync(fran, prcType, prcGrp, ct);
        if (existing is null) return null;
        existing.Factor1 = request.Factor1 ?? existing.Factor1;
        existing.Remarks = request.Remarks ?? existing.Remarks;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateMasterAsync(existing, ct);
        return updated is null ? null : MapMasterToDto(updated);
    }

    public Task<bool> DeleteMasterAsync(string fran, string prcType, string prcGrp, CancellationToken ct)
        => repo.DeleteMasterAsync(fran, prcType, prcGrp, ct);

    // Factors
    public async Task<IReadOnlyList<PriceGroupFactorDto>> GetAllFactorsAsync(CancellationToken ct)
    {
        var items = await repo.GetAllFactorsAsync(ct);
        return items.Select(MapFactorToDto).ToList();
    }

    public async Task<PriceGroupFactorDto?> GetFactorByKeyAsync(string fran, string type, string prcGrp, string name, string value, CancellationToken ct)
    {
        var item = await repo.GetFactorByKeyAsync(fran, type, prcGrp, name, value, ct);
        return item is null ? null : MapFactorToDto(item);
    }

    public async Task<PriceGroupFactorDto> CreateFactorAsync(CreatePriceGroupFactorRequest request, CancellationToken ct)
    {
        var entity = new PriceGroupFactor
        {
            Fran = request.Fran, Type = request.Type, PrcGrp = request.PrcGrp, Name = request.Name, Value = request.Value,
            Factor1 = request.Factor1 ?? 0m, Factor2 = request.Factor2 ?? 0m, Factor3 = request.Factor3 ?? 0m,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddFactorAsync(entity, ct);
        return MapFactorToDto(created);
    }

    public async Task<PriceGroupFactorDto?> UpdateFactorAsync(string fran, string type, string prcGrp, string name, string value, UpdatePriceGroupFactorRequest request, CancellationToken ct)
    {
        var existing = await repo.GetFactorByKeyAsync(fran, type, prcGrp, name, value, ct);
        if (existing is null) return null;
        existing.Factor1 = request.Factor1 ?? existing.Factor1;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateFactorAsync(existing, ct);
        return updated is null ? null : MapFactorToDto(updated);
    }

    public Task<bool> DeleteFactorAsync(string fran, string type, string prcGrp, string name, string value, CancellationToken ct)
        => repo.DeleteFactorAsync(fran, type, prcGrp, name, value, ct);

    private static PriceGroupMasterDto MapMasterToDto(PriceGroupMaster e) => new(
        e.Fran, e.PrcType, e.PrcGrp, e.Flag1, e.Flag2, e.Flag3, e.Factor1, e.Factor2, e.Factor3, e.Remarks,
        e.CreateDt, e.CreateTm, e.CreateBy);

    private static PriceGroupFactorDto MapFactorToDto(PriceGroupFactor e) => new(
        e.Fran, e.Type, e.PrcGrp, e.Name, e.Value, e.Factor1, e.Factor2, e.Factor3,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
