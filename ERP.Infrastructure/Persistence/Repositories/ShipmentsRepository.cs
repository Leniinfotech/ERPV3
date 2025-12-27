using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;

namespace ERP.Infrastructure.Persistence.Repositories;

/// <summary>EF Core repository for Shipments (SINVHDR).</summary>
public sealed class ShipmentsRepository(ErpDbContext db, ILogger<ShipmentsRepository> log) : IShipmentsRepository
{
    private readonly ErpDbContext _db = db;
    private readonly ILogger<ShipmentsRepository> _log = log;

    public async Task<IReadOnlyList<Shipment>> GetAllAsync(CancellationToken ct)
        => await _db.Shipments.AsNoTracking().OrderBy(s => s.ShipmentNumber).ToListAsync(ct);

    public async Task<Shipment?> GetByKeyAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct)
        => await _db.Shipments.AsNoTracking().FirstOrDefaultAsync(s => s.Fran == fran && s.Branch == branch && s.WarehouseCode == warehouseCode && s.ShipmentType == shipmentType && s.ShipmentNumber == shipmentNumber, ct);

    public async Task<Shipment> AddAsync(Shipment shipment, CancellationToken ct)
    {
        await _db.Shipments.AddAsync(shipment, ct);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Inserted Shipment {Fran}/{Branch}/{Wh}/{Type}/{No}", shipment.Fran, shipment.Branch, shipment.WarehouseCode, shipment.ShipmentType, shipment.ShipmentNumber);
        return shipment;
    }

    public async Task<Shipment?> UpdateAsync(Shipment shipment, CancellationToken ct)
    {
        var existing = await _db.Shipments.FirstOrDefaultAsync(s => s.Fran == shipment.Fran && s.Branch == shipment.Branch && s.WarehouseCode == shipment.WarehouseCode && s.ShipmentType == shipment.ShipmentType && s.ShipmentNumber == shipment.ShipmentNumber, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted update of non-existent Shipment {Fran}/{Branch}/{Wh}/{Type}/{No}", shipment.Fran, shipment.Branch, shipment.WarehouseCode, shipment.ShipmentType, shipment.ShipmentNumber);
            return null;
        }

        existing.ShipmentDate = shipment.ShipmentDate;
        existing.SupplierCode = shipment.SupplierCode;
        existing.Currency = shipment.Currency;
        if (shipment.BlNumber is not null) existing.BlNumber = shipment.BlNumber;
        if (shipment.BlDate.HasValue) existing.BlDate = shipment.BlDate;
        if (shipment.BuyerCode is not null) existing.BuyerCode = shipment.BuyerCode;
        if (shipment.ShippingStatus is not null) existing.ShippingStatus = shipment.ShippingStatus;
        if (shipment.ShipCompanyCode is not null) existing.ShipCompanyCode = shipment.ShipCompanyCode;

        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Updated Shipment {Fran}/{Branch}/{Wh}/{Type}/{No}", existing.Fran, existing.Branch, existing.WarehouseCode, existing.ShipmentType, existing.ShipmentNumber);
        return existing;
    }

    public async Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct)
    {
        var existing = await _db.Shipments.FirstOrDefaultAsync(s => s.Fran == fran && s.Branch == branch && s.WarehouseCode == warehouseCode && s.ShipmentType == shipmentType && s.ShipmentNumber == shipmentNumber, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted delete of non-existent Shipment {Fran}/{Branch}/{Wh}/{Type}/{No}", fran, branch, warehouseCode, shipmentType, shipmentNumber);
            return false;
        }
        _db.Shipments.Remove(existing);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Deleted Shipment {Fran}/{Branch}/{Wh}/{Type}/{No}", fran, branch, warehouseCode, shipmentType, shipmentNumber);
        return true;
    }
}