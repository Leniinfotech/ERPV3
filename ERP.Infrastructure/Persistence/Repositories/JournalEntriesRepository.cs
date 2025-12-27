using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using ERP.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class JournalEntriesRepository : IJournalEntriesRepository
{
    private readonly ErpDbContext _db;
    public JournalEntriesRepository(ErpDbContext db) => _db = db;

    // Added: Added method to insert journal 
    // Added by: Vaishnavi
    // Added on: 15-12-2025

    public async Task InsertAsync(
       string customer,
       string saleNo,
       decimal billAmount,
       string paymentMethod,
       string? cardNumber,
       string? remarks,
       CancellationToken ct)
    {
        var parameters = new[]
        {
            new SqlParameter("@Customer", customer),
            new SqlParameter("@SaleNo", saleNo),
            new SqlParameter("@BillAmount", billAmount),
            new SqlParameter("@PaymentMethod", paymentMethod),
            new SqlParameter("@CardNumber", cardNumber ?? string.Empty),
            new SqlParameter("@Remarks", remarks ?? string.Empty)
        };

        await _db.Database.ExecuteSqlRawAsync(
            @"EXEC dbo.SP_InsertJournalEntry 
              @Customer, @SaleNo, @BillAmount, @PaymentMethod, @CardNumber, @Remarks",
            parameters,
            ct);
    }

    //Commented by: Vaishnavi
    //Commented on: 15-12-2025
    //public async Task<IReadOnlyList<JournalEntryHeader>> GetAllAsync(CancellationToken ct)
    //    => await _db.JournalEntries.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.JournalType).ThenBy(x => x.JournalEntryId).ToListAsync(ct);

    //public async Task<JournalEntryHeader?> GetByKeyAsync(string fran, string journalType, decimal journalEntryId, CancellationToken ct)
    //    => await _db.JournalEntries.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.JournalType == journalType && x.JournalEntryId == journalEntryId, ct);

}

