using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class SubsPartRepository(ErpDbContext db, ILogger<SubsPartRepository> log) : ISubsPartRepository
{
    public async Task<SubsPart?> GetByKeyAsync(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct)
    {
        return await db.SubsParts.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Make == make && x.Part == part && x.FinalPart == finalPart && x.GrpNo == grpNo, ct);
    }

    public async Task<IReadOnlyList<SubsPart>> GetAllAsync(CancellationToken ct)
    {
        return await db.SubsParts.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Make).ThenBy(x => x.Part).ToListAsync(ct);
    }

    public async Task<SubsPart> AddAsync(SubsPart entity, CancellationToken ct)
    {
        await db.SubsParts.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted SubsPart {Fran}/{Make}/{Part}/{FinalPart}/{GrpNo}", entity.Fran, entity.Make, entity.Part, entity.FinalPart, entity.GrpNo);
        return entity;
    }

    public async Task<SubsPart?> UpdateAsync(SubsPart entity, CancellationToken ct)
    {
        var existing = await db.SubsParts.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Make == entity.Make && x.Part == entity.Part && x.FinalPart == entity.FinalPart && x.GrpNo == entity.GrpNo, ct);
        if (existing is null) return null;

        existing.PsSubSeq = entity.PsSubSeq;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct)
    {
        var existing = await db.SubsParts.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Make == make && x.Part == part && x.FinalPart == finalPart && x.GrpNo == grpNo, ct);
        if (existing is null) return false;

        db.SubsParts.Remove(existing);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Deleted SubsPart {Fran}/{Make}/{Part}/{FinalPart}/{GrpNo}", fran, make, part, finalPart, grpNo);
        return true;
    }
}
