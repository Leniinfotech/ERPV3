using ERP.Contracts.Finance;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services;

public interface IJournalEntriesService
{
    // Added: Added method to insert journal 
    // Added by: Vaishnavi
    // Added on: 15-12-2025
    Task InsertAsync(InsertJournalEntryRequestDto dto, CancellationToken ct);

    //Commented by: Vaishnavi
    //Commented on: 15-12-2025

    //Task<IReadOnlyList<JournalEntryHeaderDto>> GetAllAsync(CancellationToken ct);
    //Task<JournalEntryHeaderDto?> GetByKeyAsync(string fran, string journalType, decimal journalEntryId, CancellationToken ct);
}
