using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface ICustomersRepository
{
    Task<IReadOnlyList<Customer>> GetAllAsync(CancellationToken ct);
    Task<Customer?> GetByCodeAsync(string customerCode, CancellationToken ct);
    Task CreateAsync(Customer entity, CancellationToken ct);
    Task UpdateAsync(Customer entity, CancellationToken ct);
    Task DeleteAsync(string customerCode, CancellationToken ct);
}
