using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class OrderPlanRepository(ErpDbContext db, ILogger<OrderPlanRepository> log) : IOrderPlanRepository
{
    // Headers
    public async Task<OrderPlanHeader?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct)
    {
        return await db.OrderPlanHeaders.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.PlanType == planType && x.PlanNo == planNo, ct);
    }

    public async Task<IReadOnlyList<OrderPlanHeader>> GetAllHeadersAsync(CancellationToken ct)
    {
        return await db.OrderPlanHeaders.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.PlanNo).ToListAsync(ct);
    }

    public async Task<OrderPlanHeader> AddHeaderAsync(OrderPlanHeader entity, CancellationToken ct)
    {
        await db.OrderPlanHeaders.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted OrderPlanHeader {Fran}/{Branch}/{Warehouse}/{PlanType}/{PlanNo}", entity.Fran, entity.Branch, entity.Warehouse, entity.PlanType, entity.PlanNo);
        return entity;
    }

    public async Task<OrderPlanHeader?> UpdateHeaderAsync(OrderPlanHeader entity, CancellationToken ct)
    {
        var existing = await db.OrderPlanHeaders.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.PlanType == entity.PlanType && x.PlanNo == entity.PlanNo, ct);
        if (existing is null) return null;

        existing.PlanDate = entity.PlanDate;
        existing.TranType = entity.TranType;
        existing.SeqNo = entity.SeqNo;
        existing.NoItems = entity.NoItems;
        existing.NetValue = entity.NetValue;
        existing.Status = entity.Status;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct)
    {
        var existing = await db.OrderPlanHeaders.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.PlanType == planType && x.PlanNo == planNo, ct);
        if (existing is null) return false;

        db.OrderPlanHeaders.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }

    // Details
    public async Task<OrderPlanDetail?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct)
    {
        return await db.OrderPlanDetails.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.PlanType == planType && x.PlanNo == planNo && x.PlanSrl == planSrl, ct);
    }

    public async Task<IReadOnlyList<OrderPlanDetail>> GetAllDetailsAsync(CancellationToken ct)
    {
        return await db.OrderPlanDetails.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.PlanNo).ThenBy(x => x.PlanSrl).ToListAsync(ct);
    }

    public async Task<OrderPlanDetail> AddDetailAsync(OrderPlanDetail entity, CancellationToken ct)
    {
        await db.OrderPlanDetails.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<OrderPlanDetail?> UpdateDetailAsync(OrderPlanDetail entity, CancellationToken ct)
    {
        var existing = await db.OrderPlanDetails.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.PlanType == entity.PlanType && x.PlanNo == entity.PlanNo && x.PlanSrl == entity.PlanSrl, ct);
        if (existing is null) return null;

        existing.PlanDate = entity.PlanDate;
        existing.Vendor = entity.Vendor;
        existing.Make = entity.Make;
        existing.Part = entity.Part;
        existing.Qty = entity.Qty;
        existing.UnitPrice = entity.UnitPrice;
        existing.NetValue = entity.NetValue;
        existing.Currency = entity.Currency;
        existing.Remarks = entity.Remarks;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct)
    {
        var existing = await db.OrderPlanDetails.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.PlanType == planType && x.PlanNo == planNo && x.PlanSrl == planSrl, ct);
        if (existing is null) return false;

        db.OrderPlanDetails.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }

    // Masters
    public async Task<OrderPlanMaster?> GetMasterByKeyAsync(string fran, string type, string name, CancellationToken ct)
    {
        return await db.OrderPlanMasters.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Type == type && x.Name == name, ct);
    }

    public async Task<IReadOnlyList<OrderPlanMaster>> GetAllMastersAsync(CancellationToken ct)
    {
        return await db.OrderPlanMasters.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Type).ThenBy(x => x.Name).ToListAsync(ct);
    }

    public async Task<OrderPlanMaster> AddMasterAsync(OrderPlanMaster entity, CancellationToken ct)
    {
        await db.OrderPlanMasters.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<OrderPlanMaster?> UpdateMasterAsync(OrderPlanMaster entity, CancellationToken ct)
    {
        var existing = await db.OrderPlanMasters.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Type == entity.Type && x.Name == entity.Name, ct);
        if (existing is null) return null;

        existing.SelectSql = entity.SelectSql;
        existing.FilterSql = entity.FilterSql;
        existing.GroupBySql = entity.GroupBySql;
        existing.OrderBySql = entity.OrderBySql;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteMasterAsync(string fran, string type, string name, CancellationToken ct)
    {
        var existing = await db.OrderPlanMasters.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Type == type && x.Name == name, ct);
        if (existing is null) return false;

        db.OrderPlanMasters.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }
}
