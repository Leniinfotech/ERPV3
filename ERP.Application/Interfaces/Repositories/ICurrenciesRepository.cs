using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface ICurrenciesRepository
{
    Task<IReadOnlyList<Currency>> GetAllAsync(CancellationToken ct);
    Task<Currency?> GetByKeyAsync(string currencyCode, CancellationToken ct);
    Task<Currency> AddAsync(Currency entity, CancellationToken ct);
    Task<Currency?> UpdateAsync(Currency entity, CancellationToken ct);
    Task<bool> DeleteAsync(string currencyCode, CancellationToken ct);
}
