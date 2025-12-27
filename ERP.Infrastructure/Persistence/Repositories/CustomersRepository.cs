using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class CustomersRepository : ICustomersRepository
{
    private readonly ErpDbContext _db;
    public CustomersRepository(ErpDbContext db) => _db = db;

    public async Task<IReadOnlyList<Customer>> GetAllAsync(CancellationToken ct)
        => await _db.Set<Customer>().AsNoTracking().OrderBy(x => x.CustomerCode).ToListAsync(ct);

    public async Task<Customer?> GetByCodeAsync(string customerCode, CancellationToken ct)
        => await _db.Set<Customer>().AsNoTracking().FirstOrDefaultAsync(x => x.CustomerCode == customerCode, ct);

    public async Task CreateAsync(Customer entity, CancellationToken ct)
    {
        _db.Set<Customer>().Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Customer entity, CancellationToken ct)
    {
        _db.Set<Customer>().Update(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(string customerCode, CancellationToken ct)
    {
        var tracked = await _db.Set<Customer>().FirstOrDefaultAsync(x => x.CustomerCode == customerCode, ct);
        if (tracked is null) return;
        _db.Set<Customer>().Remove(tracked);
        await _db.SaveChangesAsync(ct);
    }
}
