using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

/// <summary>EF Core repository for Inventory Locations.</summary>
public sealed class InventoryLocationsRepository(ErpDbContext db, ILogger<InventoryLocationsRepository> log) : IInventoryLocationsRepository
{
    private readonly ErpDbContext _db = db;
    private readonly ILogger<InventoryLocationsRepository> _log = log;

    public async Task<InventoryLocation?> GetByCodeAsync(string warehouseCode, CancellationToken ct)
        => await _db.InventoryLocations.AsNoTracking().FirstOrDefaultAsync(w => w.WarehouseCode == warehouseCode, ct);

    public async Task<IReadOnlyList<InventoryLocation>> GetAllAsync(CancellationToken ct)
        => await _db.InventoryLocations.AsNoTracking().OrderBy(w => w.WarehouseCode).ToListAsync(ct);

    public async Task<InventoryLocation> AddAsync(InventoryLocation location, CancellationToken ct)
    {
        await _db.InventoryLocations.AddAsync(location, ct);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Inserted InventoryLocation {WarehouseCode}", location.WarehouseCode);
        return location;
    }

    public async Task<InventoryLocation?> UpdateAsync(InventoryLocation location, CancellationToken ct)
    {
        var existing = await _db.InventoryLocations.FirstOrDefaultAsync(w => w.WarehouseCode == location.WarehouseCode, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted update of non-existent InventoryLocation {WarehouseCode}", location.WarehouseCode);
            return null;
        }

        existing.Name = location.Name;
        existing.NameAr = location.NameAr;
        // Update audit fields
        if (location.UpdateDt != default) existing.UpdateDt = location.UpdateDt;
        if (location.UpdateTm != default) existing.UpdateTm = location.UpdateTm;
        existing.UpdateBy = location.UpdateBy ?? string.Empty;
        existing.UpdateRemarks = location.UpdateRemarks ?? string.Empty;

        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Updated InventoryLocation {WarehouseCode}", existing.WarehouseCode);
        return existing;
    }

    public async Task<bool> DeleteAsync(string warehouseCode, CancellationToken ct)
    {
        var existing = await _db.InventoryLocations.FirstOrDefaultAsync(w => w.WarehouseCode == warehouseCode, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted delete of non-existent InventoryLocation {WarehouseCode}", warehouseCode);
            return false;
        }

        _db.InventoryLocations.Remove(existing);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Deleted InventoryLocation {WarehouseCode}", warehouseCode);
        return true;
    }
}