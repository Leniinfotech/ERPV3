using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class FinalPartRepository(ErpDbContext db, ILogger<FinalPartRepository> log) : IFinalPartRepository
{
    public async Task<FinalPart?> GetByKeyAsync(string fran, string make, string part, CancellationToken ct)
    {
        return await db.FinalParts.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.Make == make && x.Part == part, ct);
    }

    public async Task<IReadOnlyList<FinalPart>> GetAllAsync(CancellationToken ct)
    {
        return await db.FinalParts.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Make).ThenBy(x => x.Part).ToListAsync(ct);
    }

    public async Task<FinalPart> AddAsync(FinalPart entity, CancellationToken ct)
    {
        await db.FinalParts.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted FinalPart {Fran}/{Make}/{Part}", entity.Fran, entity.Make, entity.Part);
        return entity;
    }

    public async Task<FinalPart?> UpdateAsync(FinalPart entity, CancellationToken ct)
    {
        var existing = await db.FinalParts.FirstOrDefaultAsync(x => x.Fran == entity.Fran && x.Make == entity.Make && x.Part == entity.Part, ct);
        if (existing is null) return null;

        existing.OhQty = entity.OhQty;
        existing.OoQty = entity.OoQty;
        existing.CmSaleQty = entity.CmSaleQty;
        existing.LmSaleQty = entity.LmSaleQty;
        existing.M3SaleQty = entity.M3SaleQty;
        existing.M6SaleQty = entity.M6SaleQty;
        existing.M12SaleQty = entity.M12SaleQty;
        existing.M24SaleQty = entity.M24SaleQty;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(string fran, string make, string part, CancellationToken ct)
    {
        var existing = await db.FinalParts.FirstOrDefaultAsync(x => x.Fran == fran && x.Make == make && x.Part == part, ct);
        if (existing is null) return false;

        db.FinalParts.Remove(existing);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Deleted FinalPart {Fran}/{Make}/{Part}", fran, make, part);
        return true;
    }
}
