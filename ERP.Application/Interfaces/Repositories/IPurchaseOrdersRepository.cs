using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

/// <summary>Repository abstraction for Purchase Orders (header + lines).</summary>
public interface IPurchaseOrdersRepository
{
    Task<IReadOnlyList<PurchaseOrder>> GetAllAsync(CancellationToken ct);
    Task<PurchaseOrder?> GetByKeyAsync(string fran, string branch, string warehouseCode, string poType, string poNumber, CancellationToken ct);
    Task<PurchaseOrder> AddAsync(PurchaseOrder header, IEnumerable<PurchaseOrderLine> lines, CancellationToken ct);
    Task<PurchaseOrder?> UpdateAsync(PurchaseOrder header, IEnumerable<PurchaseOrderLine> lines, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string poType, string poNumber, CancellationToken ct);
}