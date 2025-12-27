using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Reporting.Interfaces;
using ERP.Application.Reporting.Interfaces.Repositories;
using ERP.Contracts.Reporting;

namespace ERP.Application.Reporting.Services
{
    public sealed class InventoryReportingService : IInventoryReportingService
    {
        private readonly IInventoryReportingRepository _repo;
        public InventoryReportingService(IInventoryReportingRepository repo) => _repo = repo;

        public Task<InventorySummaryDto> GetInventorySummaryAsync(InventorySummaryFilter filter, CancellationToken ct)
            => _repo.GetSummaryAsync(filter, ct);
    }
}