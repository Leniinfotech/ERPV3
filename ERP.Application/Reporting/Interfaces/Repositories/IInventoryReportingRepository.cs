using System.Threading;
using System.Threading.Tasks;
using ERP.Contracts.Reporting;
using ERP.Application.Reporting;

namespace ERP.Application.Reporting.Interfaces.Repositories
{
    public interface IInventoryReportingRepository
    {
        Task<InventorySummaryDto> GetSummaryAsync(InventorySummaryFilter filter, CancellationToken ct);
    }
}