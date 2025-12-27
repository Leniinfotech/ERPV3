using ERP.Contracts.Finance;
using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

// Read-only repository for Params
public interface IParamsRepository
{
    Task<Params?> GetByKeyAsync(string fran, string paramType, string paramValue, CancellationToken ct);
    Task<IReadOnlyList<Params>> GetAllAsync(CancellationToken ct);

    // Added: Added method to loadparam
    // Added by: Vaishnavi
    // Added on: 12-12-2025
    Task<IReadOnlyList<LoadParam>> LoadByParamAsync(string fran, string paramType, CancellationToken ct);

}
