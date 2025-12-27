using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface IFranchisesService
{
    Task<IReadOnlyList<FranchiseDto>> GetAllAsync(CancellationToken ct);
    Task<FranchiseDto?> GetByKeyAsync(string fran, CancellationToken ct);
    Task<FranchiseDto> CreateAsync(CreateFranchiseRequest request, CancellationToken ct);
    Task<FranchiseDto?> UpdateAsync(string fran, UpdateFranchiseRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, CancellationToken ct);
}
