using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class FinalPartService(IFinalPartRepository repo) : IFinalPartService
{
    public async Task<IReadOnlyList<FinalPartDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await repo.GetAllAsync(ct);
        return items.Select(MapToDto).ToList();
    }

    public async Task<FinalPartDto?> GetByKeyAsync(string fran, string make, string part, CancellationToken ct)
    {
        var item = await repo.GetByKeyAsync(fran, make, part, ct);
        return item is null ? null : MapToDto(item);
    }

    public async Task<FinalPartDto> CreateAsync(CreateFinalPartRequest request, CancellationToken ct)
    {
        var entity = new FinalPart
        {
            Fran = request.Fran,
            Make = request.Make,
            Part = request.Part,
            OhQty = request.OhQty ?? 0m,
            OoQty = request.OoQty ?? 0m,
            CmSaleQty = request.CmSaleQty ?? 0m,
            LmSaleQty = request.LmSaleQty ?? 0m,
            M3SaleQty = request.M3SaleQty ?? 0m,
            M6SaleQty = request.M6SaleQty ?? 0m,
            M12SaleQty = request.M12SaleQty ?? 0m,
            M24SaleQty = request.M24SaleQty ?? 0m,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty
        };
        var created = await repo.AddAsync(entity, ct);
        return MapToDto(created);
    }

    public async Task<FinalPartDto?> UpdateAsync(string fran, string make, string part, UpdateFinalPartRequest request, CancellationToken ct)
    {
        var existing = await repo.GetByKeyAsync(fran, make, part, ct);
        if (existing is null) return null;

        existing.OhQty = request.OhQty ?? existing.OhQty;
        existing.OoQty = request.OoQty ?? existing.OoQty;
        existing.CmSaleQty = request.CmSaleQty ?? existing.CmSaleQty;
        existing.LmSaleQty = request.LmSaleQty ?? existing.LmSaleQty;
        existing.M3SaleQty = request.M3SaleQty ?? existing.M3SaleQty;
        existing.M6SaleQty = request.M6SaleQty ?? existing.M6SaleQty;
        existing.M12SaleQty = request.M12SaleQty ?? existing.M12SaleQty;
        existing.M24SaleQty = request.M24SaleQty ?? existing.M24SaleQty;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        existing.UpdateBy = "SYSTEM";

        var updated = await repo.UpdateAsync(existing, ct);
        return updated is null ? null : MapToDto(updated);
    }

    public Task<bool> DeleteAsync(string fran, string make, string part, CancellationToken ct)
        => repo.DeleteAsync(fran, make, part, ct);

    private static FinalPartDto MapToDto(FinalPart e) => new(
        e.Fran, e.Make, e.Part, e.OhQty, e.OoQty, e.CmSaleQty, e.LmSaleQty, e.M3SaleQty, e.M6SaleQty, e.M12SaleQty, e.M24SaleQty,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
