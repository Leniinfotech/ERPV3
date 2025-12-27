using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface ICompetitorRepository
{
    Task<Competitor?> GetByCodeAsync(string competitorCode, CancellationToken ct);
    Task<IReadOnlyList<Competitor>> GetAllAsync(CancellationToken ct);
    Task<Competitor> AddAsync(Competitor entity, CancellationToken ct);
    Task<Competitor?> UpdateAsync(Competitor entity, CancellationToken ct);
    Task<bool> DeleteAsync(string competitorCode, CancellationToken ct);
}
