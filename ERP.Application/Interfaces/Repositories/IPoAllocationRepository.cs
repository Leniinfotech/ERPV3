using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IPoAllocationRepository
{
    Task<PoAllocation?> GetByKeyAsync(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct);
    Task<IReadOnlyList<PoAllocation>> GetAllAsync(CancellationToken ct);
    Task<PoAllocation> AddAsync(PoAllocation entity, CancellationToken ct);
    Task<PoAllocation?> UpdateAsync(PoAllocation entity, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct);
}
