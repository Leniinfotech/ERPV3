using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class MakesRepository(ErpDbContext db) : IMakesRepository
{
    private readonly ErpDbContext _db = db;

    public async Task<IReadOnlyList<Make>> GetAllAsync(CancellationToken ct)
        => await _db.Makes.AsNoTracking().OrderBy(m => m.Fran).ThenBy(m => m.MakeCode).ToListAsync(ct);

    public async Task<Make?> GetByKeyAsync(string fran, string makeCode, CancellationToken ct)
        => await _db.Makes.AsNoTracking().FirstOrDefaultAsync(m => m.Fran == fran && m.MakeCode == makeCode, ct);

    public async Task<Make> AddAsync(Make entity, CancellationToken ct)
    {
        await _db.Makes.AddAsync(entity, ct);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<Make?> UpdateAsync(Make entity, CancellationToken ct)
    {
        var existing = await _db.Makes.FirstOrDefaultAsync(m => m.Fran == entity.Fran && m.MakeCode == entity.MakeCode, ct);
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

    public async Task<bool> DeleteAsync(string fran, string makeCode, CancellationToken ct)
    {
        var existing = await _db.Makes.FirstOrDefaultAsync(m => m.Fran == fran && m.MakeCode == makeCode, ct);
        if (existing is null) return false;
        _db.Makes.Remove(existing);
        await _db.SaveChangesAsync(ct);
        return true;
    }

    // Added: Added method to call the storedprocedure
    // Added by: Vaishnavi
    // Added on: 12-12-2025
    public async Task<IReadOnlyList<Make>> GetMake(CancellationToken ct)
    {
        return await _db.Makes
            .FromSqlRaw("EXEC [dbo].[SP_GetMakeList]")
            .AsNoTracking()
            .ToListAsync(ct);
    }

}
