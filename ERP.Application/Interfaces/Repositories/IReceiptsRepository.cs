using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IReceiptsRepository
{
    // Headers
    Task<IReadOnlyList<ReceiptHeader>> GetAllHeadersAsync(CancellationToken ct);
    Task<ReceiptHeader?> GetHeaderByKeyAsync(string fran, string brch, string whse, string rectType, string rectNo, CancellationToken ct);
    Task CreateHeaderAsync(ReceiptHeader entity, CancellationToken ct);
    Task UpdateHeaderAsync(ReceiptHeader entity, CancellationToken ct);
    Task DeleteHeaderAsync(string fran, string brch, string whse, string rectType, string rectNo, CancellationToken ct);

    // Lines
    Task<IReadOnlyList<ReceiptDetail>> GetAllLinesAsync(CancellationToken ct);
    Task<ReceiptDetail?> GetLineByKeyAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, CancellationToken ct);
    Task CreateLineAsync(ReceiptDetail entity, CancellationToken ct);
    Task UpdateLineAsync(ReceiptDetail entity, CancellationToken ct);
    Task DeleteLineAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, CancellationToken ct);
}
