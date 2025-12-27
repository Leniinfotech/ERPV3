using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IShipmentDetailsRepository
{
    Task<IReadOnlyList<ShipmentDetail>> GetAllAsync(CancellationToken ct);
    Task<ShipmentDetail?> GetByKeyAsync(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct);
    Task CreateAsync(ShipmentDetail entity, CancellationToken ct);
    Task UpdateAsync(ShipmentDetail entity, CancellationToken ct);
    Task DeleteAsync(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct);
}
