using ERP.Application.Abstractions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class CurrenciesService(ICurrenciesRepository repo, IAppLogger<CurrenciesService> log) : ICurrenciesService
{
    private readonly ICurrenciesRepository _repo = repo;
    private readonly IAppLogger<CurrenciesService> _log = log;

    public async Task<IReadOnlyList<CurrencyDto>> GetAllAsync(CancellationToken ct)
        => (await _repo.GetAllAsync(ct)).Select(Map).ToList();

    public async Task<CurrencyDto?> GetByKeyAsync(string currencyCode, CancellationToken ct)
    {
        var e = await _repo.GetByKeyAsync(currencyCode, ct);
        return e is null ? null : Map(e);
    }

    public async Task<CurrencyDto> CreateAsync(CreateCurrencyRequest request, CancellationToken ct)
    {
        Validate(request);
        var now = DateTime.UtcNow;
        var e = new Currency
        {
            CurrencyCode = request.CurrencyCode,
            BaseCurrency = request.BaseCurrency,
            Factor1 = request.Factor1,
            Factor2 = request.Factor2,
            DecimalPlace = request.DecimalPlace,
            CreateDt = DateOnly.FromDateTime(now),
            CreateTm = now,
            CreateBy = string.Empty,
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(now),
            UpdateTm = now,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty,
        };
        var created = await _repo.AddAsync(e, ct);
        _log.Info("Created Currency {Currency}", created.CurrencyCode);
        return Map(created);
    }

    public async Task<CurrencyDto?> UpdateAsync(string currencyCode, UpdateCurrencyRequest request, CancellationToken ct)
    {
        var now = DateTime.UtcNow;
        var e = new Currency
        {
            CurrencyCode = currencyCode,
            BaseCurrency = request.BaseCurrency ?? string.Empty,
            Factor1 = request.Factor1 ?? 0m,
            Factor2 = request.Factor2 ?? 0m,
            DecimalPlace = request.DecimalPlace ?? 0m,
            UpdateDt = DateOnly.FromDateTime(now),
            UpdateTm = now,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty,
        };
        var updated = await _repo.UpdateAsync(e, ct);
        if (updated is null) return null;
        _log.Info("Updated Currency {Currency}", currencyCode);
        return Map(updated);
    }

    public Task<bool> DeleteAsync(string currencyCode, CancellationToken ct) => _repo.DeleteAsync(currencyCode, ct);

    private static void Validate(CreateCurrencyRequest r)
    {
        if (string.IsNullOrWhiteSpace(r.CurrencyCode)) throw new ArgumentException("CurrencyCode is required");
        if (string.IsNullOrWhiteSpace(r.BaseCurrency)) throw new ArgumentException("BaseCurrency is required");
    }

    private static CurrencyDto Map(Currency e) => new()
    {
        CurrencyCode = e.CurrencyCode,
        BaseCurrency = e.BaseCurrency,
        Factor1 = e.Factor1,
        Factor2 = e.Factor2,
        DecimalPlace = e.DecimalPlace,
    };
}
