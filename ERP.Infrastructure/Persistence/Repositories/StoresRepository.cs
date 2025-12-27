using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class StoresRepository(ErpDbContext db) : IStoresRepository
{
    private readonly ErpDbContext _db = db;

    public async Task<IReadOnlyList<Store>> GetAllAsync(CancellationToken ct)
        => await _db.Stores.AsNoTracking()
            .OrderBy(s => s.Fran).ThenBy(s => s.Branch).ThenBy(s => s.WarehouseCode).ThenBy(s => s.StoreCode)
            .ToListAsync(ct);

    public async Task<Store?> GetByKeyAsync(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct)
        => await _db.Stores.AsNoTracking().FirstOrDefaultAsync(s => s.Fran == fran && s.Branch == branch && s.WarehouseCode == warehouseCode && s.StoreCode == storeCode, ct);

    public async Task<Store> AddAsync(Store entity, CancellationToken ct)
    {
        await _db.Stores.AddAsync(entity, ct);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<Store?> UpdateAsync(Store entity, CancellationToken ct)
    {
        var existing = await _db.Stores.FirstOrDefaultAsync(s => s.Fran == entity.Fran && s.Branch == entity.Branch && s.WarehouseCode == entity.WarehouseCode && s.StoreCode == entity.StoreCode, ct);
        if (existing is null) return null;
        existing.Name = string.IsNullOrWhiteSpace(entity.Name) ? existing.Name : entity.Name;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;
        await _db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct)
    {
        var existing = await _db.Stores.FirstOrDefaultAsync(s => s.Fran == fran && s.Branch == branch && s.WarehouseCode == warehouseCode && s.StoreCode == storeCode, ct);
        if (existing is null) return false;
        _db.Stores.Remove(existing);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
