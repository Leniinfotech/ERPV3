using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Repositories;

public interface IJournalEntriesRepository
{
    // Added: Added method to insert journal 
    // Added by: Vaishnavi
    // Added on: 15-12-2025

    Task InsertAsync(string customer, string saleNo, decimal billAmount, string paymentMethod, string? cardNumber, string? remarks, CancellationToken ct);

    //Commented by: Vaishnavi
    //Commented on: 15-12-2025

    //Task<IReadOnlyList<JournalEntryHeader>> GetAllAsync(CancellationToken ct);
    //Task<JournalEntryHeader?> GetByKeyAsync(string fran, string journalType, decimal journalEntryId, CancellationToken ct);
}
