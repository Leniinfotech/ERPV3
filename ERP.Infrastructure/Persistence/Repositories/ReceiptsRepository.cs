using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class ReceiptsRepository(ErpDbContext db) : IReceiptsRepository
{
    // Headers
    public async Task<IReadOnlyList<ReceiptHeader>> GetAllHeadersAsync(CancellationToken ct)
        => await db.ReceiptHeaders.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Branch).ThenBy(x => x.Warehouse).ThenBy(x => x.ReceiptType).ThenBy(x => x.ReceiptNo).ToListAsync(ct);

    public async Task<ReceiptHeader?> GetHeaderByKeyAsync(string fran, string brch, string whse, string rectType, string rectNo, CancellationToken ct)
        => await db.ReceiptHeaders.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.ReceiptType == rectType && x.ReceiptNo == rectNo, ct);

    public async Task CreateHeaderAsync(ReceiptHeader entity, CancellationToken ct)
    {
        db.ReceiptHeaders.Add(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateHeaderAsync(ReceiptHeader entity, CancellationToken ct)
    {
        db.ReceiptHeaders.Update(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteHeaderAsync(string fran, string brch, string whse, string rectType, string rectNo, CancellationToken ct)
    {
        var tracked = await db.ReceiptHeaders.FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.ReceiptType == rectType && x.ReceiptNo == rectNo, ct);
        if (tracked is null) return;
        db.ReceiptHeaders.Remove(tracked);
        await db.SaveChangesAsync(ct);
    }

    // Lines
    public async Task<IReadOnlyList<ReceiptDetail>> GetAllLinesAsync(CancellationToken ct)
        => await db.ReceiptDetails.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Branch).ThenBy(x => x.Warehouse).ThenBy(x => x.ReceiptType).ThenBy(x => x.ReceiptNo).ThenBy(x => x.ReceiptSerial).ToListAsync(ct);

    public async Task<ReceiptDetail?> GetLineByKeyAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, CancellationToken ct)
        => await db.ReceiptDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.ReceiptType == rectType && x.ReceiptNo == rectNo && x.ReceiptSerial == rectSrl, ct);

    public async Task CreateLineAsync(ReceiptDetail entity, CancellationToken ct)
    {
        db.ReceiptDetails.Add(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateLineAsync(ReceiptDetail entity, CancellationToken ct)
    {
        db.ReceiptDetails.Update(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteLineAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, CancellationToken ct)
    {
        var tracked = await db.ReceiptDetails.FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.Warehouse == whse && x.ReceiptType == rectType && x.ReceiptNo == rectNo && x.ReceiptSerial == rectSrl, ct);
        if (tracked is null) return;
        db.ReceiptDetails.Remove(tracked);
        await db.SaveChangesAsync(ct);
    }
}
