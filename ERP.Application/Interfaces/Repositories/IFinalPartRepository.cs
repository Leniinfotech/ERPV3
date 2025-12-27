using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IFinalPartRepository
{
    Task<FinalPart?> GetByKeyAsync(string fran, string make, string part, CancellationToken ct);
    Task<IReadOnlyList<FinalPart>> GetAllAsync(CancellationToken ct);
    Task<FinalPart> AddAsync(FinalPart entity, CancellationToken ct);
    Task<FinalPart?> UpdateAsync(FinalPart entity, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string make, string part, CancellationToken ct);
}
