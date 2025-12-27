using ERP.Contracts.Finance;

namespace ERP.Application.Interfaces.Services;

// Read-only service for Params
public interface IParamsService
{
    Task<IReadOnlyList<ParamsDto>> GetAllAsync(CancellationToken ct);
    Task<ParamsDto?> GetByKeyAsync(string fran, string paramType, string paramValue, CancellationToken ct);

    // Added: Added method to loadparam
    // Added by: Vaishnavi
    // Added on: 12-12-2025
    Task<IReadOnlyList<LoadParam>> LoadByParamAsync(string fran, string paramType, CancellationToken ct);

}
