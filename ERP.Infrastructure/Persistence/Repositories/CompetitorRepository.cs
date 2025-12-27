using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class CompetitorRepository(ErpDbContext db, ILogger<CompetitorRepository> log) : ICompetitorRepository
{
    public async Task<Competitor?> GetByCodeAsync(string competitorCode, CancellationToken ct)
    {
        return await db.Competitors.AsNoTracking().FirstOrDefaultAsync(x => x.CompetitorCode == competitorCode, ct);
    }

    public async Task<IReadOnlyList<Competitor>> GetAllAsync(CancellationToken ct)
    {
        return await db.Competitors.AsNoTracking().OrderBy(x => x.CompetitorCode).ToListAsync(ct);
    }

    public async Task<Competitor> AddAsync(Competitor entity, CancellationToken ct)
    {
        await db.Competitors.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted Competitor {CompetitorCode}", entity.CompetitorCode);
        return entity;
    }

    public async Task<Competitor?> UpdateAsync(Competitor entity, CancellationToken ct)
    {
        var existing = await db.Competitors.FirstOrDefaultAsync(x => x.CompetitorCode == entity.CompetitorCode, ct);
        if (existing is null) return null;

        existing.Name = entity.Name;
        existing.NameAr = entity.NameAr;
        existing.Phone = entity.Phone;
        existing.Email = entity.Email;
        existing.Address = entity.Address;
        existing.VatNo = entity.VatNo;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateMarks = entity.UpdateMarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(string competitorCode, CancellationToken ct)
    {
        var existing = await db.Competitors.FirstOrDefaultAsync(x => x.CompetitorCode == competitorCode, ct);
        if (existing is null) return false;

        db.Competitors.Remove(existing);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Deleted Competitor {CompetitorCode}", competitorCode);
        return true;
    }
}
