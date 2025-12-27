using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IStoresRepository
{
    Task<IReadOnlyList<Store>> GetAllAsync(CancellationToken ct);
    Task<Store?> GetByKeyAsync(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct);
    Task<Store> AddAsync(Store entity, CancellationToken ct);
    Task<Store?> UpdateAsync(Store entity, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct);
}
