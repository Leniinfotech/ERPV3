using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IPoB2BRepository
{
    Task<PoB2B?> GetByKeyAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct);
    Task<IReadOnlyList<PoB2B>> GetAllAsync(CancellationToken ct);
    Task<PoB2B> AddAsync(PoB2B entity, CancellationToken ct);
    Task<PoB2B?> UpdateAsync(PoB2B entity, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct);
}
