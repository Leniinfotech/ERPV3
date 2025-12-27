using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface IFinalPartService
{
    Task<IReadOnlyList<FinalPartDto>> GetAllAsync(CancellationToken ct);
    Task<FinalPartDto?> GetByKeyAsync(string fran, string make, string part, CancellationToken ct);
    Task<FinalPartDto> CreateAsync(CreateFinalPartRequest request, CancellationToken ct);
    Task<FinalPartDto?> UpdateAsync(string fran, string make, string part, UpdateFinalPartRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string make, string part, CancellationToken ct);
}
