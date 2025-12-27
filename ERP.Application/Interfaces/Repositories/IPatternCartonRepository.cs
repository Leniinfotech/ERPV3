using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IPatternCartonRepository
{
    Task<PatternCartonHeader?> GetByKeyAsync(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct);
    Task<IReadOnlyList<PatternCartonHeader>> GetAllAsync(CancellationToken ct);
    Task<PatternCartonHeader> AddAsync(PatternCartonHeader entity, CancellationToken ct);
    Task<PatternCartonHeader?> UpdateAsync(PatternCartonHeader entity, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct);
}
