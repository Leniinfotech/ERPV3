using ERP.Contracts.Finance;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services;

public interface IJournalEntryLinesService
{
    Task<IReadOnlyList<JournalEntryLineDto>> GetAllAsync(CancellationToken ct);
    Task<JournalEntryLineDto?> GetByKeyAsync(string fran, decimal journalEntryId, decimal journalEntryLineId, CancellationToken ct);
}
