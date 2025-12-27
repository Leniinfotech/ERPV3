using System.Threading;
using System.Threading.Tasks;
using ERP.Contracts.Reporting;

namespace ERP.Application.Reporting.Interfaces
{
    public interface IInventoryReportingService
    {
        Task<InventorySummaryDto> GetInventorySummaryAsync(InventorySummaryFilter filter, CancellationToken ct);
    }
}