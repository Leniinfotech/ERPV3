using ERP.Contracts.Orders;

namespace ERP.Application.Interfaces.Services;

public interface ISalesService
{

    // Added: Added method for receivable and payable
    // Added by: Vaishnavi
    // Added on: 15-12-2025

    Task<IReadOnlyList<SaleReceivablePayableDto>>
    GetSaleReceivablePayableAsync(string fran, string mode, CancellationToken ct);

    // Commented by: Vaishnavi
    // Commented on: 15-12-2025


    // Headers
    //Task<IReadOnlyList<SaleHeaderDto>> GetAllHeadersAsync(CancellationToken ct);
    //Task<SaleHeaderDto?> GetHeaderByKeyAsync(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct);
    //Task<SaleHeaderDto> CreateHeaderAsync(CreateSaleHeaderRequest req, CancellationToken ct);
    //Task<bool> UpdateHeaderAsync(string fran, string brch, string whse, string saleType, string saleNo, UpdateSaleHeaderRequest req, CancellationToken ct);
    //Task<bool> DeleteHeaderAsync(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct);

    //// Lines
    //Task<IReadOnlyList<SaleDetailDto>> GetAllLinesAsync(CancellationToken ct);
    //Task<SaleDetailDto?> GetLineByKeyAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct);
    //Task<SaleDetailDto> CreateLineAsync(CreateSaleDetailRequest req, CancellationToken ct);
    //Task<bool> UpdateLineAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, UpdateSaleDetailRequest req, CancellationToken ct);
    //Task<bool> DeleteLineAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct);
}
