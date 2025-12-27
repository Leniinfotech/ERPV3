using ERP.Contracts.Orders;

namespace ERP.Application.Interfaces.Services;

public interface IShipmentDetailsService
{
    Task<IReadOnlyList<ShipmentDetailDto>> GetAllAsync(CancellationToken ct);
    Task<ShipmentDetailDto?> GetByKeyAsync(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct);
    Task<ShipmentDetailDto> CreateAsync(CreateShipmentDetailRequest req, CancellationToken ct);
    Task<bool> UpdateAsync(string fran, string brch, string whse, string type, string no, decimal srl, UpdateShipmentDetailRequest req, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct);
}
