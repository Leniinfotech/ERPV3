using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

// Read-only repository for Chart of Accounts
public interface IChartOfAccountsRepository
{
    Task<ChartOfAccounts?> GetByKeyAsync(string fran, string accountType, string accountCode, CancellationToken ct);
    Task<IReadOnlyList<ChartOfAccounts>> GetAllAsync(CancellationToken ct);
}
