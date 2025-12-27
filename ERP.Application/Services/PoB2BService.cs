using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class PoB2BService(IPoB2BRepository repo) : IPoB2BService
{
    public async Task<IReadOnlyList<PoB2BDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await repo.GetAllAsync(ct);
        return items.Select(MapToDto).ToList();
    }

    public async Task<PoB2BDto?> GetByKeyAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct)
    {
        var item = await repo.GetByKeyAsync(fran, branch, warehouse, b2bType, b2bNo, b2bSrl, ct);
        return item is null ? null : MapToDto(item);
    }

    public async Task<PoB2BDto> CreateAsync(CreatePoB2BRequest request, CancellationToken ct)
    {
        var entity = new PoB2B
        {
            Fran = request.Fran, Branch = request.Branch, Warehouse = request.Warehouse,
            B2BType = request.B2BType, B2BNo = request.B2BNo, B2BSrl = request.B2BSrl,
            B2BDate = request.B2BDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            Make = request.Make ?? string.Empty, Part = request.Part ?? string.Empty,
            OrdPart = request.OrdPart, Qty = request.Qty ?? 0m, OrdQty = request.OrdQty ?? 0m,
            PoQty = request.PoQty ?? 0m, UnitPrice = request.UnitPrice ?? 0m, NetValue = request.NetValue ?? 0m,
            Currency = request.Currency ?? string.Empty, Customer = request.Customer ?? string.Empty,
            Status = request.Status ?? string.Empty, Vendor = request.Vendor ?? string.Empty,
            StoreId = request.StoreId ?? string.Empty, RefType = string.Empty, RefNo = string.Empty,
            RefSrl = 0m, UnitPack = 0m, PoType = string.Empty, PoNo = string.Empty, PoSrl = 0m,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow), CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM", CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow), UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty, UpdateRemarks = string.Empty
        };
        var created = await repo.AddAsync(entity, ct);
        return MapToDto(created);
    }

    public async Task<PoB2BDto?> UpdateAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, UpdatePoB2BRequest request, CancellationToken ct)
    {
        var existing = await repo.GetByKeyAsync(fran, branch, warehouse, b2bType, b2bNo, b2bSrl, ct);
        if (existing is null) return null;
        existing.Status = request.Status ?? existing.Status;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        var updated = await repo.UpdateAsync(existing, ct);
        return updated is null ? null : MapToDto(updated);
    }

    public Task<bool> DeleteAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct)
        => repo.DeleteAsync(fran, branch, warehouse, b2bType, b2bNo, b2bSrl, ct);

    private static PoB2BDto MapToDto(PoB2B e) => new(
        e.Fran, e.Branch, e.Warehouse, e.B2BType, e.B2BNo, e.B2BSrl, e.B2BDate, e.Make, e.Part, e.OrdPart,
        e.Qty, e.OrdQty, e.PoQty, e.UnitPrice, e.NetValue, e.Currency, e.Customer, e.Status, e.Vendor, e.StoreId,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
