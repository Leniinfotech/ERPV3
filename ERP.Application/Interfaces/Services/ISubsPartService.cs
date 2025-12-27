using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface ISubsPartService
{
    Task<IReadOnlyList<SubsPartDto>> GetAllAsync(CancellationToken ct);
    Task<SubsPartDto?> GetByKeyAsync(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct);
    Task<SubsPartDto> CreateAsync(CreateSubsPartRequest request, CancellationToken ct);
    Task<SubsPartDto?> UpdateAsync(string fran, string make, string part, string finalPart, decimal grpNo, UpdateSubsPartRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct);
}
