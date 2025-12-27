using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class ChartOfAccountsRepository(ErpDbContext db) : IChartOfAccountsRepository
{
    public async Task<ChartOfAccounts?> GetByKeyAsync(string fran, string accountType, string accountCode, CancellationToken ct)
    {
        return await db.ChartOfAccounts.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.AccountType == accountType && x.AccountCode == accountCode, ct);
    }

    public async Task<IReadOnlyList<ChartOfAccounts>> GetAllAsync(CancellationToken ct)
    {
        return await db.ChartOfAccounts.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.AccountType).ThenBy(x => x.AccountCode).ToListAsync(ct);
    }
}
