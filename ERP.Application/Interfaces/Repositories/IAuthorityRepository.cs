using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IAuthorityRepository
{

    Task<IReadOnlyList<Authority>> GetAllAsync(CancellationToken ct);
    Task<Authority?> GetByKeyAsync(
        string fran,
        string type,
        string userId,
        string menu,
        string subMenu,
        CancellationToken ct);

    Task AddAsync(Authority entity, CancellationToken ct);
    Task UpdateAsync(Authority entity, CancellationToken ct);
    Task<bool> DeleteAsync(
        string fran,
        string type,
        string userId,
        string menu,
        string subMenu,
        CancellationToken ct);

    //Task<Authority?> GetByKeyAsync(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct);
    //Task<IReadOnlyList<Authority>> GetAllAsync(CancellationToken ct);
    //Task<Authority> AddAsync(Authority entity, CancellationToken ct);
    //Task<Authority?> UpdateAsync(Authority entity, CancellationToken ct);
    //Task<bool> DeleteAsync(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct);
}
