using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface ISubsPartRepository
{
    Task<SubsPart?> GetByKeyAsync(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct);
    Task<IReadOnlyList<SubsPart>> GetAllAsync(CancellationToken ct);
    Task<SubsPart> AddAsync(SubsPart entity, CancellationToken ct);
    Task<SubsPart?> UpdateAsync(SubsPart entity, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct);
}
