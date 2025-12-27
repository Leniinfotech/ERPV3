using ERP.Contracts.Inventory;

namespace ERP.Application.Interfaces.Services;

public interface IStoresService
{
    Task<IReadOnlyList<StoreDto>> GetAllAsync(CancellationToken ct);
    Task<StoreDto?> GetByKeyAsync(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct);
    Task<StoreDto> CreateAsync(CreateStoreRequest request, CancellationToken ct);
    Task<StoreDto?> UpdateAsync(string fran, string branch, string warehouseCode, string storeCode, UpdateStoreRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct);
}
