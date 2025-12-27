using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class PackingRepository(ErpDbContext db) : IPackingRepository
{
    public async Task<IReadOnlyList<PackingHeader>> GetAllHeadersAsync(CancellationToken ct)
        => await db.PackingHeaders.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Branch).ThenBy(x => x.Warehouse).ThenBy(x => x.PackType).ThenBy(x => x.PackNo).ToListAsync(ct);

    public async Task<PackingHeader?> GetHeaderByKeyAsync(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct)
        => await db.PackingHeaders.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.PackType == packType && x.PackNo == packNo, ct);

    public async Task CreateHeaderAsync(PackingHeader entity, CancellationToken ct)
    {
        db.PackingHeaders.Add(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateHeaderAsync(PackingHeader entity, CancellationToken ct)
    {
        db.PackingHeaders.Update(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteHeaderAsync(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct)
    {
        var tracked = await db.PackingHeaders.FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.PackType == packType && x.PackNo == packNo, ct);
        if (tracked is null) return;
        db.PackingHeaders.Remove(tracked);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<PackingDetail>> GetAllLinesAsync(CancellationToken ct)
        => await db.PackingDetails.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Branch).ThenBy(x => x.Warehouse).ThenBy(x => x.PackType).ThenBy(x => x.PackNo).ThenBy(x => x.PackSrl).ToListAsync(ct);

    public async Task<PackingDetail?> GetLineByKeyAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct)
        => await db.PackingDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.PackType == packType && x.PackNo == packNo && x.PackSrl == packSrl, ct);

    public async Task CreateLineAsync(PackingDetail entity, CancellationToken ct)
    {
        db.PackingDetails.Add(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateLineAsync(PackingDetail entity, CancellationToken ct)
    {
        db.PackingDetails.Update(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteLineAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct)
    {
        var tracked = await db.PackingDetails.FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.PackType == packType && x.PackNo == packNo && x.PackSrl == packSrl, ct);
        if (tracked is null) return;
        db.PackingDetails.Remove(tracked);
        await db.SaveChangesAsync(ct);
    }
}
