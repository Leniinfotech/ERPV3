using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface ICompetitorService
{
    Task<IReadOnlyList<CompetitorDto>> GetAllAsync(CancellationToken ct);
    Task<CompetitorDto?> GetByCodeAsync(string competitorCode, CancellationToken ct);
    Task<CompetitorDto> CreateAsync(CreateCompetitorRequest request, CancellationToken ct);
    Task<CompetitorDto?> UpdateAsync(string competitorCode, UpdateCompetitorRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string competitorCode, CancellationToken ct);
}
