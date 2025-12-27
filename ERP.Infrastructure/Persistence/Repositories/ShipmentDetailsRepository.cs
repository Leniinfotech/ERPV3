using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class ShipmentDetailsRepository(ErpDbContext db) : IShipmentDetailsRepository
{
    public async Task<IReadOnlyList<ShipmentDetail>> GetAllAsync(CancellationToken ct)
        => await db.ShipmentDetails.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Branch).ThenBy(x => x.WarehouseCode).ThenBy(x => x.ShipmentType).ThenBy(x => x.ShipmentNumber).ThenBy(x => x.ShipmentSerial).ToListAsync(ct);

    public async Task<ShipmentDetail?> GetByKeyAsync(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct)
        => await db.ShipmentDetails.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.WarehouseCode == whse && x.ShipmentType == type && x.ShipmentNumber == no && x.ShipmentSerial == srl, ct);

    public async Task CreateAsync(ShipmentDetail entity, CancellationToken ct)
    {
        db.ShipmentDetails.Add(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(ShipmentDetail entity, CancellationToken ct)
    {
        db.ShipmentDetails.Update(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct)
    {
        var tracked = await db.ShipmentDetails.FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == brch && x.WarehouseCode == whse && x.ShipmentType == type && x.ShipmentNumber == no && x.ShipmentSerial == srl, ct);
        if (tracked is null) return;
        db.ShipmentDetails.Remove(tracked);
        await db.SaveChangesAsync(ct);
    }
}
