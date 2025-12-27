using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ERP.Contracts.Inventory;

namespace ERP.Application.Interfaces.Services
{
    /// <summary>Service abstraction for Inventory Location operations.</summary>
    public interface IInventoryLocationsService
    {
        Task<InventoryLocationDto?> GetByCodeAsync(string warehouseCode, CancellationToken ct);
        Task<IReadOnlyList<InventoryLocationDto>> GetAllAsync(CancellationToken ct);
        Task<InventoryLocationDto> CreateAsync(InventoryLocationDto dto, CancellationToken ct);
        Task<InventoryLocationDto?> UpdateAsync(string warehouseCode, InventoryLocationDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(string warehouseCode, CancellationToken ct);
    }
}