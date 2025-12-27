using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ERP.Contracts.Orders;

namespace ERP.Application.Interfaces.Services
{
    /// <summary>Service abstraction for Shipment operations.</summary>
    public interface IShipmentsService
    {
        Task<IReadOnlyList<ShipmentDto>> GetAllAsync(CancellationToken ct);
        Task<ShipmentDto?> GetByKeyAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct);
        Task<ShipmentDto> CreateAsync(ShipmentDto dto, CancellationToken ct);
        Task<ShipmentDto?> UpdateAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, ShipmentDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct);
    }
}