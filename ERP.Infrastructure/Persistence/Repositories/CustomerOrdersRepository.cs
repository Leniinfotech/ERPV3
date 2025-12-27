using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class CustomerOrdersRepository(ErpDbContext db, ILogger<CustomerOrdersRepository> log) : ICustomerOrdersRepository
{
    // Headers
    public async Task<CustomerOrderHeader?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct)
    {
        return await db.CustomerOrderHeaders.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.CordType == cordType && x.CordNo == cordNo, ct);
    }

    public async Task<IReadOnlyList<CustomerOrderHeader>> GetAllHeadersAsync(CancellationToken ct)
    {
        return await db.CustomerOrderHeaders.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.CordNo).ToListAsync(ct);
    }

    public async Task<CustomerOrderHeader> AddHeaderAsync(CustomerOrderHeader entity, CancellationToken ct)
    {
        await db.CustomerOrderHeaders.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted CustomerOrderHeader {Fran}/{Branch}/{Warehouse}/{CordType}/{CordNo}", entity.Fran, entity.Branch, entity.Warehouse, entity.CordType, entity.CordNo);
        return entity;
    }

    public async Task<CustomerOrderHeader?> UpdateHeaderAsync(CustomerOrderHeader entity, CancellationToken ct)
    {
        var existing = await db.CustomerOrderHeaders.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.CordType == entity.CordType && x.CordNo == entity.CordNo, ct);
        if (existing is null) return null;

        existing.CordDate = entity.CordDate;
        existing.Customer = entity.Customer;
        existing.SeqNo = entity.SeqNo;
        existing.SeqPrefix = entity.SeqPrefix;
        existing.Currency = entity.Currency;
        existing.NoOfItems = entity.NoOfItems;
        existing.DiscountValue = entity.DiscountValue;
        existing.GrossValue = entity.GrossValue;
        existing.NetValue = entity.NetValue;
        existing.VatValue = entity.VatValue;
        existing.TotalValue = entity.TotalValue;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct)
    {
        var existing = await db.CustomerOrderHeaders.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.CordType == cordType && x.CordNo == cordNo, ct);
        if (existing is null) return false;

        db.CustomerOrderHeaders.Remove(existing);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Deleted CustomerOrderHeader {Fran}/{Branch}/{Warehouse}/{CordType}/{CordNo}", fran, branch, warehouse, cordType, cordNo);
        return true;
    }

    // Details
    public async Task<CustomerOrderDetail?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct)
    {
        return await db.CustomerOrderDetails.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.CordType == cordType && x.CordNo == cordNo && x.CordSrl == cordSrl, ct);
    }

    public async Task<IReadOnlyList<CustomerOrderDetail>> GetAllDetailsAsync(CancellationToken ct)
    {
        return await db.CustomerOrderDetails.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.CordNo).ThenBy(x => x.CordSrl).ToListAsync(ct);
    }

    public async Task<IReadOnlyList<CustomerOrderDetail>> GetDetailsByHeaderAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct)
    {
        return await db.CustomerOrderDetails.AsNoTracking()
            .Where(x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.CordType == cordType && x.CordNo == cordNo)
            .OrderBy(x => x.CordSrl).ToListAsync(ct);
    }

    public async Task<CustomerOrderDetail> AddDetailAsync(CustomerOrderDetail entity, CancellationToken ct)
    {
        await db.CustomerOrderDetails.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted CustomerOrderDetail {Fran}/{Branch}/{Warehouse}/{CordType}/{CordNo}/{CordSrl}", entity.Fran, entity.Branch, entity.Warehouse, entity.CordType, entity.CordNo, entity.CordSrl);
        return entity;
    }

    public async Task<CustomerOrderDetail?> UpdateDetailAsync(CustomerOrderDetail entity, CancellationToken ct)
    {
        var existing = await db.CustomerOrderDetails.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Branch == entity.Branch && x.Warehouse == entity.Warehouse && x.CordType == entity.CordType && x.CordNo == entity.CordNo && x.CordSrl == entity.CordSrl, ct);
        if (existing is null) return null;

        existing.CordDate = entity.CordDate;
        existing.Make = entity.Make;
        existing.Part = entity.Part;
        existing.Qty = entity.Qty;
        existing.AccpQty = entity.AccpQty;
        existing.NotAvlQty = entity.NotAvlQty;
        existing.Price = entity.Price;
        existing.Discount = entity.Discount;
        existing.VatPercentage = entity.VatPercentage;
        existing.VatValue = entity.VatValue;
        existing.DiscountValue = entity.DiscountValue;
        existing.TotalValue = entity.TotalValue;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct)
    {
        var existing = await db.CustomerOrderDetails.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Branch == branch && x.Warehouse == warehouse && x.CordType == cordType && x.CordNo == cordNo && x.CordSrl == cordSrl, ct);
        if (existing is null) return false;

        db.CustomerOrderDetails.Remove(existing);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Deleted CustomerOrderDetail {Fran}/{Branch}/{Warehouse}/{CordType}/{CordNo}/{CordSrl}", fran, branch, warehouse, cordType, cordNo, cordSrl);
        return true;
    }
}
