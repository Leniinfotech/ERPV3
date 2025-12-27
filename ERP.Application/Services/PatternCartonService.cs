using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Inventory;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class PatternCartonService(IPatternCartonRepository repo) : IPatternCartonService
{
    public async Task<IReadOnlyList<PatternCartonHeaderDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await repo.GetAllAsync(ct);
        return items.Select(MapToDto).ToList();
    }

    public async Task<PatternCartonHeaderDto?> GetByKeyAsync(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct)
    {
        var item = await repo.GetByKeyAsync(fran, branch, warehouse, crtnType, crtn, ct);
        return item is null ? null : MapToDto(item);
    }

    public async Task<PatternCartonHeaderDto> CreateAsync(CreatePatternCartonHeaderRequest request, CancellationToken ct)
    {
        var entity = new PatternCartonHeader
        {
            Fran = request.Fran, Branch = request.Branch, Warehouse = request.Warehouse,
            CrtnType = request.CrtnType, Crtn = request.Crtn,
            Length = request.Length ?? 0m, Width = request.Width ?? 0m, Height = request.Height ?? 0m,
            Volume = request.Volume ?? 0m, NetWeight = request.NetWeight ?? 0m, GrossWeight = request.GrossWeight ?? 0m,
            Customer = request.Customer ?? string.Empty, PackType = request.PackType ?? string.Empty,
            PackNo = request.PackNo ?? string.Empty, Status = request.Status ?? string.Empty,
            LocnId = 0m, NoItems = 0m, TotQty = 0m, PakGrp = string.Empty, CntrId = string.Empty,
            SourType = string.Empty, SourNo = string.Empty, CaseMark = string.Empty, PackIns = string.Empty,
            CrtnCatg = string.Empty, CrtnPrefix = string.Empty, CrtnSeqNo = 0m, ShipCaseMark = string.Empty,
            KeyInGrossWeight = 0m, LaType = string.Empty, LaNo = string.Empty, SinvNo = string.Empty,
            StoreId = string.Empty, InvType = string.Empty, InvNo = string.Empty, DespStatus = string.Empty,
            CreateDt = DateTime.UtcNow, CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateTime.UtcNow, UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddAsync(entity, ct);
        return MapToDto(created);
    }

    public async Task<PatternCartonHeaderDto?> UpdateAsync(string fran, string branch, string warehouse, string crtnType, string crtn, UpdatePatternCartonHeaderRequest request, CancellationToken ct)
    {
        var existing = await repo.GetByKeyAsync(fran, branch, warehouse, crtnType, crtn, ct);
        if (existing is null) return null;
        existing.Length = request.Length ?? existing.Length;
        existing.Status = request.Status ?? existing.Status;
        existing.UpdateDt = DateTime.UtcNow;
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateAsync(existing, ct);
        return updated is null ? null : MapToDto(updated);
    }

    public Task<bool> DeleteAsync(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct)
        => repo.DeleteAsync(fran, branch, warehouse, crtnType, crtn, ct);

    private static PatternCartonHeaderDto MapToDto(PatternCartonHeader e) => new(
        e.Fran, e.Branch, e.Warehouse, e.CrtnType, e.Crtn, e.Length, e.Width, e.Height, e.Volume,
        e.NetWeight, e.GrossWeight, e.Customer, e.PackType, e.PackNo, e.Status,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
