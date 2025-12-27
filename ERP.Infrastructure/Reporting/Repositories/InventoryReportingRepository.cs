using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using ERP.Application.Reporting;
using ERP.Application.Reporting.Interfaces.Repositories;
using ERP.Contracts.Reporting;

namespace ERP.Infrastructure.Reporting.Repositories
{
    internal sealed class InventoryReportingRepository : IInventoryReportingRepository
    {
        private readonly IDbConnection _db;
        public InventoryReportingRepository(IDbConnection db) => _db = db;

        public async Task<InventorySummaryDto> GetSummaryAsync(InventorySummaryFilter filter, CancellationToken ct)
        {
            var sql = @"SELECT @Branch as Branch, @Warehouse as Warehouse, 0 as SkuCount, 0 as TotalQuantity, 0 as TotalValue";
            var result = await _db.QuerySingleAsync<InventorySummaryDto>(new CommandDefinition(sql, new
            {
                Branch = filter.Branch ?? "",
                Warehouse = filter.Warehouse ?? ""
            }, cancellationToken: ct));
            return result;
        }
    }
}