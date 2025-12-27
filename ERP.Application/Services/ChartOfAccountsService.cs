using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Finance;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class ChartOfAccountsService(IChartOfAccountsRepository repo) : IChartOfAccountsService
{
    public async Task<IReadOnlyList<ChartOfAccountsDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await repo.GetAllAsync(ct);
        return items.Select(MapToDto).ToList();
    }

    public async Task<ChartOfAccountsDto?> GetByKeyAsync(string fran, string accountType, string accountCode, CancellationToken ct)
    {
        var item = await repo.GetByKeyAsync(fran, accountType, accountCode, ct);
        return item is null ? null : MapToDto(item);
    }

    private static ChartOfAccountsDto MapToDto(ChartOfAccounts e) => new(
        e.Fran, e.AccountType, e.AccountCode, e.AccountName, e.AccountBalance, e.Remarks,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
