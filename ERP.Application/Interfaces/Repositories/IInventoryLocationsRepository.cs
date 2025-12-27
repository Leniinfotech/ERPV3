using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

/// <summary>Repository abstraction for InventoryLocation persistence.</summary>
public interface IInventoryLocationsRepository
{
    Task<InventoryLocation?> GetByCodeAsync(string warehouseCode, CancellationToken ct);
    Task<IReadOnlyList<InventoryLocation>> GetAllAsync(CancellationToken ct);
    Task<InventoryLocation> AddAsync(InventoryLocation location, CancellationToken ct);
    Task<InventoryLocation?> UpdateAsync(InventoryLocation location, CancellationToken ct);
    Task<bool> DeleteAsync(string warehouseCode, CancellationToken ct);
}