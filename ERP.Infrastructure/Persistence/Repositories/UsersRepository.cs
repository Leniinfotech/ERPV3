using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class UsersRepository : IUsersRepository
{
    private readonly ErpDbContext _db;
    public UsersRepository(ErpDbContext db) => _db = db;

    public async Task<IReadOnlyList<UserAccount>> GetAllAsync(CancellationToken ct)
        => await _db.Users.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.UserId).ToListAsync(ct);

    public async Task<UserAccount?> GetByKeyAsync(string fran, string userId, CancellationToken ct)
        => await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.UserId == userId, ct);

    public async Task CreateAsync(UserAccount entity, CancellationToken ct)
    {
        _db.Users.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(UserAccount entity, CancellationToken ct)
    {
        _db.Users.Update(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(string fran, string userId, CancellationToken ct)
    {
        var tracked = await _db.Users.FirstOrDefaultAsync(x => x.Fran == fran && x.UserId == userId, ct);
        if (tracked is null) return;
        _db.Users.Remove(tracked);
        await _db.SaveChangesAsync(ct);
    }
}
