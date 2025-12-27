namespace ERP.Application.Reporting
{
    public sealed record InventorySummaryFilter(string? Branch, string? Warehouse, DateOnly? AsOf);
}