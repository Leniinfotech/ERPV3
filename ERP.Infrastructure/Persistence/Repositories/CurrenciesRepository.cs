using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class CurrenciesRepository(ErpDbContext db) : ICurrenciesRepository
{
    private readonly ErpDbContext _db = db;

    public async Task<IReadOnlyList<Currency>> GetAllAsync(CancellationToken ct)
        => await _db.Currencies.AsNoTracking().OrderBy(c => c.CurrencyCode).ToListAsync(ct);

    public async Task<Currency?> GetByKeyAsync(string currencyCode, CancellationToken ct)
        => await _db.Currencies.AsNoTracking().FirstOrDefaultAsync(c => c.CurrencyCode == currencyCode, ct);

    public async Task<Currency> AddAsync(Currency entity, CancellationToken ct)
    {
        await _db.Currencies.AddAsync(entity, ct);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<Currency?> UpdateAsync(Currency entity, CancellationToken ct)
    {
        var existing = await _db.Currencies.FirstOrDefaultAsync(c => c.CurrencyCode == entity.CurrencyCode, ct);
        if (existing is null) return null;
        existing.BaseCurrency = string.IsNullOrWhiteSpace(entity.BaseCurrency) ? existing.BaseCurrency : entity.BaseCurrency;
        existing.Factor1 = entity.Factor1 == default ? existing.Factor1 : entity.Factor1;
        existing.Factor2 = entity.Factor2 == default ? existing.Factor2 : entity.Factor2;
        existing.DecimalPlace = entity.DecimalPlace == default ? existing.DecimalPlace : entity.DecimalPlace;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;
        await _db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(string currencyCode, CancellationToken ct)
    {
        var existing = await _db.Currencies.FirstOrDefaultAsync(c => c.CurrencyCode == currencyCode, ct);
        if (existing is null) return false;
        _db.Currencies.Remove(existing);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
