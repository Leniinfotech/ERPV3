using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IFranchisesRepository
{
    Task<IReadOnlyList<Franchise>> GetAllAsync(CancellationToken ct);
    Task<Franchise?> GetByKeyAsync(string fran, CancellationToken ct);
    Task<Franchise> AddAsync(Franchise entity, CancellationToken ct);
    Task<Franchise?> UpdateAsync(Franchise entity, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, CancellationToken ct);
}
