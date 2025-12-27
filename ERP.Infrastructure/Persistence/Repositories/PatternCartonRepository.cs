using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class PatternCartonRepository(ErpDbContext db, ILogger<PatternCartonRepository> log) : IPatternCartonRepository
{
    public async Task<PatternCartonHeader?> GetByKeyAsync(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct)
    {
        return await db.PatternCartonHeaders.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.CrtnType == crtnType && x.Crtn == crtn, ct);
    }

    public async Task<IReadOnlyList<PatternCartonHeader>> GetAllAsync(CancellationToken ct)
    {
        return await db.PatternCartonHeaders.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Crtn).ToListAsync(ct);
    }

    public async Task<PatternCartonHeader> AddAsync(PatternCartonHeader entity, CancellationToken ct)
    {
        await db.PatternCartonHeaders.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted PatternCartonHeader {Fran}/{Branch}/{Warehouse}/{CrtnType}/{Crtn}", entity.Fran, entity.Branch, entity.Warehouse, entity.CrtnType, entity.Crtn);
        return entity;
    }

    public async Task<PatternCartonHeader?> UpdateAsync(PatternCartonHeader entity, CancellationToken ct)
    {
        var existing = await db.PatternCartonHeaders.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.CrtnType == entity.CrtnType && x.Crtn == entity.Crtn, ct);
        if (existing is null) return null;

        existing.Length = entity.Length;
        existing.Width = entity.Width;
        existing.Height = entity.Height;
        existing.Volume = entity.Volume;
        existing.NetWeight = entity.NetWeight;
        existing.GrossWeight = entity.GrossWeight;
        existing.Customer = entity.Customer;
        existing.PackType = entity.PackType;
        existing.PackNo = entity.PackNo;
        existing.Status = entity.Status;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct)
    {
        var existing = await db.PatternCartonHeaders.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.CrtnType == crtnType && x.Crtn == crtn, ct);
        if (existing is null) return false;

        db.PatternCartonHeaders.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }
}
