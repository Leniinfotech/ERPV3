using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class CartonsRepository(ErpDbContext db) : ICartonsRepository
{
    public async Task<IReadOnlyList<Carton>> GetAllAsync(CancellationToken ct)
        => await db.Cartons.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.CrtnType).ThenBy(x => x.CrtnCatg).ToListAsync(ct);

    public async Task<Carton?> GetByKeyAsync(string fran, string crtnType, string crtnCatg, CancellationToken ct)
        => await db.Cartons.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.CrtnType == crtnType && x.CrtnCatg == crtnCatg, ct);

    public async Task CreateAsync(Carton entity, CancellationToken ct)
    {
        db.Cartons.Add(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Carton entity, CancellationToken ct)
    {
        db.Cartons.Update(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(string fran, string crtnType, string crtnCatg, CancellationToken ct)
    {
        var tracked = await db.Cartons.FirstOrDefaultAsync(x => x.Fran == fran && x.CrtnType == crtnType && x.CrtnCatg == crtnCatg, ct);
        if (tracked is null) return;
        db.Cartons.Remove(tracked);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<CartonDetail>> GetAllLinesAsync(CancellationToken ct)
        => await db.CartonDetails.AsNoTracking().OrderBy(x => x.CDFRAN).ThenBy(x => x.CDBRCH).ThenBy(x => x.CDWHSE).ThenBy(x => x.CDCRTN).ThenBy(x => x.CDCRTNTYPE).ThenBy(x => x.CDCRTNSRL).ToListAsync(ct);

    public async Task<CartonDetail?> GetLineByKeyAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct)
        => await db.CartonDetails.AsNoTracking().FirstOrDefaultAsync(x => x.CDFRAN == cdf && x.CDBRCH == cdb && x.CDWHSE == cdw && x.CDCRTN == cdcrtn && x.CDCRTNTYPE == cdtype && x.CDCRTNSRL == cdsrl, ct);

    public async Task CreateLineAsync(CartonDetail entity, CancellationToken ct)
    {
        db.CartonDetails.Add(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateLineAsync(CartonDetail entity, CancellationToken ct)
    {
        db.CartonDetails.Update(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteLineAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct)
    {
        var tracked = await db.CartonDetails.FirstOrDefaultAsync(x => x.CDFRAN == cdf && x.CDBRCH == cdb && x.CDWHSE == cdw && x.CDCRTN == cdcrtn && x.CDCRTNTYPE == cdtype && x.CDCRTNSRL == cdsrl, ct);
        if (tracked is null) return;
        db.CartonDetails.Remove(tracked);
        await db.SaveChangesAsync(ct);
    }
}
