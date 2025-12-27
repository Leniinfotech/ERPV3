using System.Collections.Generic;

namespace ERP.Contracts.Reporting
{
    public sealed record InventorySummaryDto(
        string Branch,
        string Warehouse,
        int SkuCount,
        decimal TotalQuantity,
        decimal TotalValue
    );

    public sealed record PagingRequest(int Page = 1, int PageSize = 50);

    public sealed record PagingResponse<T>(IReadOnlyList<T> Items, int Page, int PageSize, int TotalCount);
}