using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

/// <summary>Repository abstraction for Branch persistence.</summary>
public interface IBranchesRepository
{
    Task<IReadOnlyList<Branch>> GetAllAsync(CancellationToken ct);
    Task<Branch?> GetByKeyAsync(decimal branchCode, CancellationToken ct);
    Task<Branch> AddAsync(Branch entity, CancellationToken ct);
    Task<Branch?> UpdateAsync(Branch entity, CancellationToken ct);
    Task<bool> DeleteAsync(decimal branchCode, CancellationToken ct);
}
