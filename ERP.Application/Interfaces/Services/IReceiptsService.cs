using ERP.Contracts.Orders;

namespace ERP.Application.Interfaces.Services;

public interface IReceiptsService
{
    // Headers
    Task<IReadOnlyList<ReceiptHeaderDto>> GetAllHeadersAsync(CancellationToken ct);
    Task<ReceiptHeaderDto?> GetHeaderByKeyAsync(string fran, string brch, string whse, string rectType, string rectNo, CancellationToken ct);
    Task<ReceiptHeaderDto> CreateHeaderAsync(CreateReceiptHeaderRequest req, CancellationToken ct);
    Task<bool> UpdateHeaderAsync(string fran, string brch, string whse, string rectType, string rectNo, UpdateReceiptHeaderRequest req, CancellationToken ct);
    Task<bool> DeleteHeaderAsync(string fran, string brch, string whse, string rectType, string rectNo, CancellationToken ct);

    // Lines
    Task<IReadOnlyList<ReceiptDetailDto>> GetAllLinesAsync(CancellationToken ct);
    Task<ReceiptDetailDto?> GetLineByKeyAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, CancellationToken ct);
    Task<ReceiptDetailDto> CreateLineAsync(CreateReceiptDetailRequest req, CancellationToken ct);
    Task<bool> UpdateLineAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, UpdateReceiptDetailRequest req, CancellationToken ct);
    Task<bool> DeleteLineAsync(string fran, string brch, string whse, string rectType, string rectNo, decimal rectSrl, CancellationToken ct);
}
