using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface ICurrenciesService
{
    Task<IReadOnlyList<CurrencyDto>> GetAllAsync(CancellationToken ct);
    Task<CurrencyDto?> GetByKeyAsync(string currencyCode, CancellationToken ct);
    Task<CurrencyDto> CreateAsync(CreateCurrencyRequest request, CancellationToken ct);
    Task<CurrencyDto?> UpdateAsync(string currencyCode, UpdateCurrencyRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string currencyCode, CancellationToken ct);
}
