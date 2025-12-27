using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IWorkshopsRepository
{
    Task<IReadOnlyList<Workshop>> GetAllAsync(CancellationToken ct);
    Task<Workshop?> GetByKeyAsync(string fran, decimal workshopId, CancellationToken ct);
    Task CreateAsync(Workshop entity, CancellationToken ct);
    Task UpdateAsync(Workshop entity, CancellationToken ct);
    Task DeleteAsync(string fran, decimal workshopId, CancellationToken ct);
}
