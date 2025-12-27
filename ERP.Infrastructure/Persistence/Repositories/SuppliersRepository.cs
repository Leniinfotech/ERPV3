using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

/// <summary>EF Core repository for Suppliers.</summary>
public sealed class SuppliersRepository(ErpDbContext db, ILogger<SuppliersRepository> log) : ISuppliersRepository
{
    private readonly ErpDbContext _db = db;
    private readonly ILogger<SuppliersRepository> _log = log;

    public async Task<Supplier?> GetByCodeAsync(string supplierCode, CancellationToken ct)
    {
        return await _db.Suppliers.AsNoTracking().FirstOrDefaultAsync(s => s.SupplierCode == supplierCode, ct);
    }

    public async Task<IReadOnlyList<Supplier>> GetAllAsync(CancellationToken ct)
    {
        return await _db.Suppliers.AsNoTracking().OrderBy(s => s.SupplierCode).ToListAsync(ct);
    }

    public async Task<Supplier> AddAsync(Supplier supplier, CancellationToken ct)
    {
        await _db.Suppliers.AddAsync(supplier, ct);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Inserted Supplier {SupplierCode}", supplier.SupplierCode);
        return supplier;
    }

    public async Task<Supplier?> UpdateAsync(Supplier supplier, CancellationToken ct)
    {
        var existing = await _db.Suppliers.FirstOrDefaultAsync(s => s.SupplierCode == supplier.SupplierCode, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted update of non-existent Supplier {SupplierCode}", supplier.SupplierCode);
            return null;
        }

        existing.Name = supplier.Name;
        existing.NameAr = supplier.NameAr;
        existing.Phone = supplier.Phone;
        existing.Email = supplier.Email;
        existing.Address = supplier.Address;
        existing.VatNo = supplier.VatNo;

        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Updated Supplier {SupplierCode}", existing.SupplierCode);
        return existing;
    }

    public async Task<bool> DeleteAsync(string supplierCode, CancellationToken ct)
    {
        var existing = await _db.Suppliers.FirstOrDefaultAsync(s => s.SupplierCode == supplierCode, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted delete of non-existent Supplier {SupplierCode}", supplierCode);
            return false;
        }

        _db.Suppliers.Remove(existing);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Deleted Supplier {SupplierCode}", supplierCode);
        return true;
    }
}