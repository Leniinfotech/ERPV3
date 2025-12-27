using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class FranchisesRepository(ErpDbContext db) : IFranchisesRepository
{
    private readonly ErpDbContext _db = db;

    public async Task<IReadOnlyList<Franchise>> GetAllAsync(CancellationToken ct)
        => await _db.Franchises.AsNoTracking().OrderBy(f => f.Fran).ToListAsync(ct);

    public async Task<Franchise?> GetByKeyAsync(string fran, CancellationToken ct)
        => await _db.Franchises.AsNoTracking().FirstOrDefaultAsync(f => f.Fran == fran, ct);

    public async Task<Franchise> AddAsync(Franchise entity, CancellationToken ct)
    {
        await _db.Franchises.AddAsync(entity, ct);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<Franchise?> UpdateAsync(Franchise entity, CancellationToken ct)
    {
        var existing = await _db.Franchises.FirstOrDefaultAsync(f => f.Fran == entity.Fran, ct);
        if (existing is null) return null;
        existing.Name = string.IsNullOrWhiteSpace(entity.Name) ? existing.Name : entity.Name;
        existing.NameAr = string.IsNullOrWhiteSpace(entity.NameAr) ? existing.NameAr : entity.NameAr;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;
        await _db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(string fran, CancellationToken ct)
    {
        var existing = await _db.Franchises.FirstOrDefaultAsync(f => f.Fran == fran, ct);
        if (existing is null) return false;
        _db.Franchises.Remove(existing);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
