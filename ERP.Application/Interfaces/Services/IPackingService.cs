using ERP.Contracts.Inventory;

namespace ERP.Application.Interfaces.Services;

public interface IPackingService
{
    // Headers
    Task<IReadOnlyList<PackingHeaderDto>> GetAllHeadersAsync(CancellationToken ct);
    Task<PackingHeaderDto?> GetHeaderByKeyAsync(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct);
    Task<PackingHeaderDto> CreateHeaderAsync(CreatePackingHeaderRequest req, CancellationToken ct);
    Task<bool> UpdateHeaderAsync(string fran, string brch, string whse, string packType, string packNo, UpdatePackingHeaderRequest req, CancellationToken ct);
    Task<bool> DeleteHeaderAsync(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct);

    // Lines
    Task<IReadOnlyList<PackingDetailDto>> GetAllLinesAsync(CancellationToken ct);
    Task<PackingDetailDto?> GetLineByKeyAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct);
    Task<PackingDetailDto> CreateLineAsync(CreatePackingDetailRequest req, CancellationToken ct);
    Task<bool> UpdateLineAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, UpdatePackingDetailRequest req, CancellationToken ct);
    Task<bool> DeleteLineAsync(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct);
}
