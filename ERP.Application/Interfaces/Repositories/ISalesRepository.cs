using ERP.Contracts.Orders;
using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface ISalesRepository
{

    // Added: Added method for receivable and payable
    // Added by: Vaishnavi
    // Added on: 15-12-2025


    Task<IReadOnlyList<SaleReceivablePayableDto>>
    GetSaleReceivablePayableAsync(string fran, string mode, CancellationToken ct);

    // Commented by: Vaishnavi
    // Commented on: 15-12-2025


    // Headers
    //Task<IReadOnlyList<SaleHeader>> GetAllHeadersAsync(CancellationToken ct);
    //Task<SaleHeader?> GetHeaderByKeyAsync(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct);
    //Task CreateHeaderAsync(SaleHeader entity, CancellationToken ct);
    //Task UpdateHeaderAsync(SaleHeader entity, CancellationToken ct);
    //Task DeleteHeaderAsync(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct);

    //// Lines
    //Task<IReadOnlyList<SaleDetail>> GetAllLinesAsync(CancellationToken ct);
    //Task<SaleDetail?> GetLineByKeyAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct);
    //Task CreateLineAsync(SaleDetail entity, CancellationToken ct);
    //Task UpdateLineAsync(SaleDetail entity, CancellationToken ct);
    //Task DeleteLineAsync(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct);
}
