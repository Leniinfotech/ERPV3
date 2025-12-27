using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IMakesRepository
{
    Task<IReadOnlyList<Make>> GetAllAsync(CancellationToken ct);
    Task<Make?> GetByKeyAsync(string fran, string makeCode, CancellationToken ct);
    Task<Make> AddAsync(Make entity, CancellationToken ct);
    Task<Make?> UpdateAsync(Make entity, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string makeCode, CancellationToken ct);

    // Added: Added method to call the storedprocedure
    // Added by: Vaishnavi
    // Added on: 12-12-2025

    Task<IReadOnlyList<Make>> GetMake(CancellationToken ct);

}
