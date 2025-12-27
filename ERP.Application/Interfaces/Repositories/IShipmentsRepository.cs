using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

/// <summary>Repository abstraction for Shipments (SINVHDR).</summary>
public interface IShipmentsRepository
{
    Task<IReadOnlyList<Shipment>> GetAllAsync(CancellationToken ct);
    Task<Shipment?> GetByKeyAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct);
    Task<Shipment> AddAsync(Shipment shipment, CancellationToken ct);
    Task<Shipment?> UpdateAsync(Shipment shipment, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct);
}