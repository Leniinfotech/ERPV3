using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface IMakesService
{
    Task<IReadOnlyList<MakeDto>> GetAllAsync(CancellationToken ct);
    Task<MakeDto?> GetByKeyAsync(string fran, string makeCode, CancellationToken ct);
    Task<MakeDto> CreateAsync(CreateMakeRequest request, CancellationToken ct);
    Task<MakeDto?> UpdateAsync(string fran, string makeCode, UpdateMakeRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string makeCode, CancellationToken ct);

    // Added: Added method to call the storedprocedure
    // Added by: Vaishnavi
    // Added on: 12-12-2025

    Task<IReadOnlyList<MakeDto>> GetMake(CancellationToken ct);

}
