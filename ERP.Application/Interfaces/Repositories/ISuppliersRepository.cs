using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

/// <summary>Repository abstraction for Supplier persistence.</summary>
public interface ISuppliersRepository
{
    Task<Supplier?> GetByCodeAsync(string supplierCode, CancellationToken ct);
    Task<IReadOnlyList<Supplier>> GetAllAsync(CancellationToken ct);
    Task<Supplier> AddAsync(Supplier supplier, CancellationToken ct);
    Task<Supplier?> UpdateAsync(Supplier supplier, CancellationToken ct);
    Task<bool> DeleteAsync(string supplierCode, CancellationToken ct);
}