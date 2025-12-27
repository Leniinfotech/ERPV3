using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class LoadingAdviceRepository(ErpDbContext db, ILogger<LoadingAdviceRepository> log) : ILoadingAdviceRepository
{
    // Headers
    public async Task<LoadingAdviceHeader?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct)
    {
        return await db.LoadingAdviceHeaders.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.LaType == laType && x.LaNo == laNo, ct);
    }

    public async Task<IReadOnlyList<LoadingAdviceHeader>> GetAllHeadersAsync(CancellationToken ct)
    {
        return await db.LoadingAdviceHeaders.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.LaNo).ToListAsync(ct);
    }

    public async Task<LoadingAdviceHeader> AddHeaderAsync(LoadingAdviceHeader entity, CancellationToken ct)
    {
        await db.LoadingAdviceHeaders.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted LoadingAdviceHeader {Fran}/{Branch}/{Warehouse}/{LaType}/{LaNo}", entity.Fran, entity.Branch, entity.Warehouse, entity.LaType, entity.LaNo);
        return entity;
    }

    public async Task<LoadingAdviceHeader?> UpdateHeaderAsync(LoadingAdviceHeader entity, CancellationToken ct)
    {
        var existing = await db.LoadingAdviceHeaders.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.LaType == entity.LaType && x.LaNo == entity.LaNo, ct);
        if (existing is null) return null;

        existing.LaDate = entity.LaDate;
        existing.InvType = entity.InvType;
        existing.InvNo = entity.InvNo;
        existing.Customer = entity.Customer;
        existing.SeqNo = entity.SeqNo;
        existing.Vessel = entity.Vessel;
        existing.PortDest = entity.PortDest;
        existing.Etd = entity.Etd;
        existing.Eta = entity.Eta;
        existing.LoadDate = entity.LoadDate;
        existing.Status = entity.Status;
        existing.NoOfCrtn = entity.NoOfCrtn;
        existing.Remarks = entity.Remarks;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct)
    {
        var existing = await db.LoadingAdviceHeaders.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.LaType == laType && x.LaNo == laNo, ct);
        if (existing is null) return false;

        db.LoadingAdviceHeaders.Remove(existing);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Deleted LoadingAdviceHeader {Fran}/{Branch}/{Warehouse}/{LaType}/{LaNo}", fran, branch, warehouse, laType, laNo);
        return true;
    }

    // Details (LADET)
    public async Task<LoadingAdviceDetail?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct)
    {
        return await db.LoadingAdviceDetails.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.LaType == laType && x.LaNo == laNo && x.CrtnType == crtnType && x.Crtn == crtn, ct);
    }

    public async Task<IReadOnlyList<LoadingAdviceDetail>> GetAllDetailsAsync(CancellationToken ct)
    {
        return await db.LoadingAdviceDetails.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.LaNo).ToListAsync(ct);
    }

    public async Task<LoadingAdviceDetail> AddDetailAsync(LoadingAdviceDetail entity, CancellationToken ct)
    {
        await db.LoadingAdviceDetails.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<LoadingAdviceDetail?> UpdateDetailAsync(LoadingAdviceDetail entity, CancellationToken ct)
    {
        var existing = await db.LoadingAdviceDetails.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.LaType == entity.LaType && x.LaNo == entity.LaNo && x.CrtnType == entity.CrtnType && x.Crtn == entity.Crtn, ct);
        if (existing is null) return null;

        existing.DocDate = entity.DocDate;
        existing.CntrNo = entity.CntrNo;
        existing.CntrDate = entity.CntrDate;
        existing.MsCrtn = entity.MsCrtn;
        existing.PackType = entity.PackType;
        existing.PackNo = entity.PackNo;
        existing.Customer = entity.Customer;
        existing.InvType = entity.InvType;
        existing.InvNo = entity.InvNo;
        existing.SubInvNo = entity.SubInvNo;
        existing.Status = entity.Status;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct)
    {
        var existing = await db.LoadingAdviceDetails.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.LaType == laType && x.LaNo == laNo && x.CrtnType == crtnType && x.Crtn == crtn, ct);
        if (existing is null) return false;

        db.LoadingAdviceDetails.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }

    // Detail2 (LADET2)
    public async Task<LoadingAdviceDetail2?> GetDetail2ByKeyAsync(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct)
    {
        return await db.LoadingAdviceDetails2.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.InvType == invType && x.InvNo == invNo && x.InvSrl == invSrl, ct);
    }

    public async Task<IReadOnlyList<LoadingAdviceDetail2>> GetAllDetails2Async(CancellationToken ct)
    {
        return await db.LoadingAdviceDetails2.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.InvNo).ToListAsync(ct);
    }

    public async Task<LoadingAdviceDetail2> AddDetail2Async(LoadingAdviceDetail2 entity, CancellationToken ct)
    {
        await db.LoadingAdviceDetails2.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<LoadingAdviceDetail2?> UpdateDetail2Async(LoadingAdviceDetail2 entity, CancellationToken ct)
    {
        var existing = await db.LoadingAdviceDetails2.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.InvType == entity.InvType && x.InvNo == entity.InvNo && x.InvSrl == entity.InvSrl, ct);
        if (existing is null) return null;

        existing.InvDate = entity.InvDate;
        existing.Customer = entity.Customer;
        existing.Part = entity.Part;
        existing.Make = entity.Make;
        existing.Qty = entity.Qty;
        existing.UnitRate = entity.UnitRate;
        existing.NetValue = entity.NetValue;
        existing.Currency = entity.Currency;
        existing.Status = entity.Status;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteDetail2Async(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct)
    {
        var existing = await db.LoadingAdviceDetails2.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.InvType == invType && x.InvNo == invNo && x.InvSrl == invSrl, ct);
        if (existing is null) return false;

        db.LoadingAdviceDetails2.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }
}
