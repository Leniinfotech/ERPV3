using ERP.Contracts.Orders;

namespace ERP.Application.Interfaces.Services;

public interface IPoAllocationService
{
    Task<IReadOnlyList<PoAllocationDto>> GetAllAsync(CancellationToken ct);
    Task<PoAllocationDto?> GetByKeyAsync(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct);
    Task<PoAllocationDto> CreateAsync(CreatePoAllocationRequest request, CancellationToken ct);
    Task<PoAllocationDto?> UpdateAsync(string fran, string branch, string warehouse, decimal alocSrl, UpdatePoAllocationRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct);
}
