using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IPackingRepository
{
    // Headers
    Task<IReadOnlyList<PackingHeader>> GetAllHeadersAsync(CancellationToken ct);
    Task<PackingHeader?> GetHeaderByKeyAsync(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct);
    Task CreateHeaderAsync(PackingHeader entity, CancellationToken ct);
    Task UpdateHeaderAsync(PackingHeader entity, CancellationToken ct);
    Task DeleteHeaderAsync(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct);

    // Lines
    Task<IReadOnlyList<PackingDetail>> GetAllLinesAsync(CancellationToken ct);
    Task<PackingDetail?> GetLineByKeyAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct);
    Task CreateLineAsync(PackingDetail entity, CancellationToken ct);
    Task UpdateLineAsync(PackingDetail entity, CancellationToken ct);
    Task DeleteLineAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct);
}
