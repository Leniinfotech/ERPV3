using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class PoAllocationRepository(ErpDbContext db, ILogger<PoAllocationRepository> log) : IPoAllocationRepository
{
    public async Task<PoAllocation?> GetByKeyAsync(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct)
    {
        return await db.PoAllocations.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.AlocSrl == alocSrl, ct);
    }

    public async Task<IReadOnlyList<PoAllocation>> GetAllAsync(CancellationToken ct)
    {
        return await db.PoAllocations.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.AlocSrl).ToListAsync(ct);
    }

    public async Task<PoAllocation> AddAsync(PoAllocation entity, CancellationToken ct)
    {
        await db.PoAllocations.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted PoAllocation {Fran}/{Branch}/{Warehouse}/{AlocSrl}", entity.Fran, entity.Branch, entity.Warehouse, entity.AlocSrl);
        return entity;
    }

    public async Task<PoAllocation?> UpdateAsync(PoAllocation entity, CancellationToken ct)
    {
        var existing = await db.PoAllocations.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.AlocSrl == entity.AlocSrl, ct);
        if (existing is null) return null;

        existing.AlocType = entity.AlocType;
        existing.AlocDate = entity.AlocDate;
        existing.Part = entity.Part;
        existing.Make = entity.Make;
        existing.OrdPart = entity.OrdPart;
        existing.Qty = entity.Qty;
        existing.UnitPrice = entity.UnitPrice;
        existing.NetValue = entity.NetValue;
        existing.Status = entity.Status;
        existing.RefType = entity.RefType;
        existing.RefNo = entity.RefNo;
        existing.RefSrl = entity.RefSrl;
        existing.RefSource = entity.RefSource;
        existing.StoreId = entity.StoreId;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct)
    {
        var existing = await db.PoAllocations.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.AlocSrl == alocSrl, ct);
        if (existing is null) return false;

        db.PoAllocations.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }
}
