using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class PoB2BRepository(ErpDbContext db, ILogger<PoB2BRepository> log) : IPoB2BRepository
{
    public async Task<PoB2B?> GetByKeyAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct)
    {
        return await db.PoB2Bs.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.B2BType == b2bType && x.B2BNo == b2bNo && x.B2BSrl == b2bSrl, ct);
    }

    public async Task<IReadOnlyList<PoB2B>> GetAllAsync(CancellationToken ct)
    {
        return await db.PoB2Bs.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.B2BNo).ThenBy(x => x.B2BSrl).ToListAsync(ct);
    }

    public async Task<PoB2B> AddAsync(PoB2B entity, CancellationToken ct)
    {
        await db.PoB2Bs.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted PoB2B {Fran}/{Branch}/{Warehouse}/{B2BType}/{B2BNo}/{B2BSrl}", entity.Fran, entity.Branch, entity.Warehouse, entity.B2BType, entity.B2BNo, entity.B2BSrl);
        return entity;
    }

    public async Task<PoB2B?> UpdateAsync(PoB2B entity, CancellationToken ct)
    {
        var existing = await db.PoB2Bs.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.B2BType == entity.B2BType && x.B2BNo == entity.B2BNo && x.B2BSrl == entity.B2BSrl, ct);
        if (existing is null) return null;

        existing.B2BDate = entity.B2BDate;
        existing.Make = entity.Make;
        existing.Part = entity.Part;
        existing.OrdPart = entity.OrdPart;
        existing.Qty = entity.Qty;
        existing.OrdQty = entity.OrdQty;
        existing.PoQty = entity.PoQty;
        existing.UnitPrice = entity.UnitPrice;
        existing.NetValue = entity.NetValue;
        existing.Currency = entity.Currency;
        existing.Customer = entity.Customer;
        existing.Status = entity.Status;
        existing.Vendor = entity.Vendor;
        existing.StoreId = entity.StoreId;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct)
    {
        var existing = await db.PoB2Bs.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.B2BType == b2bType && x.B2BNo == b2bNo && x.B2BSrl == b2bSrl, ct);
        if (existing is null) return false;

        db.PoB2Bs.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }
}
