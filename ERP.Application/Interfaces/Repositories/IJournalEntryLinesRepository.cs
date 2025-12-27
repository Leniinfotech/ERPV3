using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Repositories;

public interface IJournalEntryLinesRepository
{
    Task<IReadOnlyList<JournalEntryLine>> GetAllAsync(CancellationToken ct);
    Task<JournalEntryLine?> GetByKeyAsync(string fran, decimal journalEntryId, decimal journalEntryLineId, CancellationToken ct);
}
