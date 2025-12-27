using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class AuthorityRepository(ErpDbContext db, ILogger<AuthorityRepository> log) : IAuthorityRepository
{

    private readonly ErpDbContext _db;

    public async Task<IReadOnlyList<Authority>> GetAllAsync(CancellationToken ct)
        => await _db.Authorities.AsNoTracking().ToListAsync(ct);

    public async Task<Authority?> GetByKeyAsync(
        string fran,
        string type,
        string userId,
        string menu,
        string subMenu,
        CancellationToken ct)
    {
        return await _db.Authorities.FirstOrDefaultAsync(x =>
            x.Fran == fran &&
            x.Type == type &&
            x.UserId == userId &&
            x.Menu == menu &&
            x.SubMenu == subMenu, ct);
    }

    public async Task AddAsync(Authority entity, CancellationToken ct)
    {
        _db.Authorities.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Authority entity, CancellationToken ct)
    {
        _db.Authorities.Update(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<bool> DeleteAsync(
        string fran,
        string type,
        string userId,
        string menu,
        string subMenu,
        CancellationToken ct)
    {
        var entity = await GetByKeyAsync(fran, type, userId, menu, subMenu, ct);
        if (entity is null) return false;

        _db.Authorities.Remove(entity);
        await _db.SaveChangesAsync(ct);
        return true;
    }


    //public async Task<Authority?> GetByKeyAsync(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct)
    //{
    //    return await db.Authorities.AsNoTracking()
    //        .FirstOrDefaultAsync(x => x.Fran == fran && x.Type == type && x.UserId == userId && x.Menu == menu && x.SubMenu == subMenu, ct);
    //}

    //public async Task<IReadOnlyList<Authority>> GetAllAsync(CancellationToken ct)
    //{
    //    return await db.Authorities.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.UserId).ToListAsync(ct);
    //}

    //public async Task<Authority> AddAsync(Authority entity, CancellationToken ct)
    //{
    //    await db.Authorities.AddAsync(entity, ct);
    //    await db.SaveChangesAsync(ct);
    //    log.LogInformation("Inserted Authority {Fran}/{Type}/{UserId}/{Menu}/{SubMenu}", entity.Fran, entity.Type, entity.UserId, entity.Menu, entity.SubMenu);
    //    return entity;
    //}

    //public async Task<Authority?> UpdateAsync(Authority entity, CancellationToken ct)
    //{
    //    var existing = await db.Authorities.FirstOrDefaultAsync(
    //        x => x.Fran == entity.Fran && x.Type == entity.Type && x.UserId == entity.UserId && x.Menu == entity.Menu && x.SubMenu == entity.SubMenu, ct);
    //    if (existing is null) return null;

    //    existing.MenuText = entity.MenuText;
    //    existing.SubMenuText = entity.SubMenuText;
    //    existing.Status = entity.Status;
    //    existing.UpdateDt = entity.UpdateDt;
    //    existing.UpdateTm = entity.UpdateTm;
    //    existing.UpdateBy = entity.UpdateBy;
    //    existing.UpdateRemarks = entity.UpdateRemarks;

    //    await db.SaveChangesAsync(ct);
    //    return existing;
    //}

    //public async Task<bool> DeleteAsync(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct)
    //{
    //    var existing = await db.Authorities.FirstOrDefaultAsync(
    //        x => x.Fran == fran && x.Type == type && x.UserId == userId && x.Menu == menu && x.SubMenu == subMenu, ct);
    //    if (existing is null) return false;

    //    db.Authorities.Remove(existing);
    //    await db.SaveChangesAsync(ct);
    //    log.LogInformation("Deleted Authority {Fran}/{Type}/{UserId}/{Menu}/{SubMenu}", fran, type, userId, menu, subMenu);
    //    return true;
    //}
}
