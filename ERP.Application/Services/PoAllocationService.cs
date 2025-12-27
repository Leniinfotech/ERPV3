using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class PoAllocationService(IPoAllocationRepository repo) : IPoAllocationService
{
    public async Task<IReadOnlyList<PoAllocationDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await repo.GetAllAsync(ct);
        return items.Select(MapToDto).ToList();
    }

    public async Task<PoAllocationDto?> GetByKeyAsync(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct)
    {
        var item = await repo.GetByKeyAsync(fran, branch, warehouse, alocSrl, ct);
        return item is null ? null : MapToDto(item);
    }

    public async Task<PoAllocationDto> CreateAsync(CreatePoAllocationRequest request, CancellationToken ct)
    {
        var entity = new PoAllocation
        {
            Fran = request.Fran, Branch = request.Branch, Warehouse = request.Warehouse,
            AlocType = request.AlocType ?? string.Empty, AlocDate = request.AlocDate ?? DateTime.UtcNow,
            Part = request.Part ?? string.Empty, Make = request.Make ?? string.Empty,
            OrdPart = request.OrdPart ?? string.Empty, Qty = request.Qty ?? 0m,
            UnitPrice = request.UnitPrice ?? 0m, NetValue = request.NetValue ?? 0m,
            Status = request.Status ?? string.Empty, RefType = request.RefType ?? string.Empty,
            RefNo = request.RefNo ?? string.Empty, RefSrl = request.RefSrl ?? 0m,
            RefSource = request.RefSource ?? string.Empty, StoreId = request.StoreId ?? string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddAsync(entity, ct);
        return MapToDto(created);
    }

    public async Task<PoAllocationDto?> UpdateAsync(string fran, string branch, string warehouse, decimal alocSrl, UpdatePoAllocationRequest request, CancellationToken ct)
    {
        var existing = await repo.GetByKeyAsync(fran, branch, warehouse, alocSrl, ct);
        if (existing is null) return null;
        existing.Status = request.Status ?? existing.Status;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateAsync(existing, ct);
        return updated is null ? null : MapToDto(updated);
    }

    public Task<bool> DeleteAsync(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct)
        => repo.DeleteAsync(fran, branch, warehouse, alocSrl, ct);

    private static PoAllocationDto MapToDto(PoAllocation e) => new(
        e.Fran, e.Branch, e.Warehouse, e.AlocSrl, e.AlocType, e.AlocDate, e.Part, e.Make, e.OrdPart, e.Qty,
        e.UnitPrice, e.NetValue, e.Status, e.RefType, e.RefNo, e.RefSrl, e.RefSource, e.StoreId,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
