using ERP.Contracts.Finance;

namespace ERP.Application.Interfaces.Services;

// Read-only service for Chart of Accounts
public interface IChartOfAccountsService
{
    Task<IReadOnlyList<ChartOfAccountsDto>> GetAllAsync(CancellationToken ct);
    Task<ChartOfAccountsDto?> GetByKeyAsync(string fran, string accountType, string accountCode, CancellationToken ct);
}
