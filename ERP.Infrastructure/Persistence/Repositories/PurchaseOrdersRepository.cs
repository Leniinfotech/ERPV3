using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;

namespace ERP.Infrastructure.Persistence.Repositories;

/// <summary>EF Core repository for Purchase Orders (header + lines).</summary>
public sealed class PurchaseOrdersRepository(ErpDbContext db, ILogger<PurchaseOrdersRepository> log) : IPurchaseOrdersRepository
{
    private readonly ErpDbContext _db = db;
    private readonly ILogger<PurchaseOrdersRepository> _log = log;

    public async Task<IReadOnlyList<PurchaseOrder>> GetAllAsync(CancellationToken ct)
        => await _db.PurchaseOrders.AsNoTracking().OrderBy(h => h.PoNumber).ToListAsync(ct);

    public async Task<PurchaseOrder?> GetByKeyAsync(string fran, string branch, string warehouseCode, string poType, string poNumber, CancellationToken ct)
        => await _db.PurchaseOrders.AsNoTracking()
            .Include(h => h.Lines)
            .FirstOrDefaultAsync(h => h.Fran == fran && h.Branch == branch && h.WarehouseCode == warehouseCode && h.PoType == poType && h.PoNumber == poNumber, ct);

    public async Task<PurchaseOrder> AddAsync(PurchaseOrder header, IEnumerable<PurchaseOrderLine> lines, CancellationToken ct)
    {
        // attach lines
        foreach (var l in lines)
        {
            header.Lines.Add(l);
        }
        await _db.PurchaseOrders.AddAsync(header, ct);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Inserted PO {Fran}/{Branch}/{Wh}/{Type}/{No}", header.Fran, header.Branch, header.WarehouseCode, header.PoType, header.PoNumber);
        return header;
    }

    public async Task<PurchaseOrder?> UpdateAsync(PurchaseOrder header, IEnumerable<PurchaseOrderLine> lines, CancellationToken ct)
    {
        var existing = await _db.PurchaseOrders.Include(h => h.Lines).FirstOrDefaultAsync(
            h => h.Fran == header.Fran && h.Branch == header.Branch && h.WarehouseCode == header.WarehouseCode && h.PoType == header.PoType && h.PoNumber == header.PoNumber, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted update of non-existent PO {Fran}/{Branch}/{Wh}/{Type}/{No}", header.Fran, header.Branch, header.WarehouseCode, header.PoType, header.PoNumber);
            return null;
        }

        // Update scalars
        existing.PoDate = header.PoDate;
        existing.SupplierCode = header.SupplierCode;
        existing.SupplierRefNo = header.SupplierRefNo;
        existing.Currency = header.Currency;
        existing.NoOfItems = header.NoOfItems;
        existing.Discount = header.Discount;
        existing.TotalValue = header.TotalValue;

        // Replace lines wholesale for simplicity
        _db.PurchaseOrderLines.RemoveRange(existing.Lines);
        foreach (var l in lines)
        {
            existing.Lines.Add(l);
        }

        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Updated PO {Fran}/{Branch}/{Wh}/{Type}/{No}", existing.Fran, existing.Branch, existing.WarehouseCode, existing.PoType, existing.PoNumber);
        return existing;
    }

    public async Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string poType, string poNumber, CancellationToken ct)
    {
        var existing = await _db.PurchaseOrders.Include(h => h.Lines).FirstOrDefaultAsync(
            h => h.Fran == fran && h.Branch == branch && h.WarehouseCode == warehouseCode && h.PoType == poType && h.PoNumber == poNumber, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted delete of non-existent PO {Fran}/{Branch}/{Wh}/{Type}/{No}", fran, branch, warehouseCode, poType, poNumber);
            return false;
        }

        _db.PurchaseOrderLines.RemoveRange(existing.Lines);
        _db.PurchaseOrders.Remove(existing);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Deleted PO {Fran}/{Branch}/{Wh}/{Type}/{No}", fran, branch, warehouseCode, poType, poNumber);
        return true;
    }
}