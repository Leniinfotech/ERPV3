using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface IBranchesService
{
    Task<IReadOnlyList<BranchDto>> GetAllAsync(CancellationToken ct);
    Task<BranchDto?> GetByKeyAsync(decimal branchCode, CancellationToken ct);
    Task<BranchDto> CreateAsync(CreateBranchRequest request, CancellationToken ct);
    Task<BranchDto?> UpdateAsync(decimal branchCode, UpdateBranchRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(decimal branchCode, CancellationToken ct);
}
