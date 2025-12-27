using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IUsersRepository
{
    Task<IReadOnlyList<UserAccount>> GetAllAsync(CancellationToken ct);
    Task<UserAccount?> GetByKeyAsync(string fran, string userId, CancellationToken ct);
    Task CreateAsync(UserAccount entity, CancellationToken ct);
    Task UpdateAsync(UserAccount entity, CancellationToken ct);
    Task DeleteAsync(string fran, string userId, CancellationToken ct);
}
