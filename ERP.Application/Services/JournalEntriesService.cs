using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Finance;
using static ERP.Application.Services.JournalEntriesService;

namespace ERP.Application.Services;

public sealed class JournalEntriesService(IJournalEntriesRepository repo) : IJournalEntriesService
{

    // Added: Added method to insert journal 
    // Added by: Vaishnavi
    // Added on: 15-12-2025
    public async Task InsertAsync(
            InsertJournalEntryRequestDto dto,
            CancellationToken ct)
        {
            await repo.InsertAsync(
                dto.Customer,
                dto.SaleNo,
                dto.BillAmount,
                dto.PaymentMethod,
                dto.CardNumber,
                dto.Remarks,
                ct);
        }

    //Commented by: Vaishnavi
    //Commented on: 15-12-2025

    //public async Task<IReadOnlyList<JournalEntryHeaderDto>> GetAllAsync(CancellationToken ct)
    //{
    //    var rows = await repo.GetAllAsync(ct);
    //    return rows.Select(x => new JournalEntryHeaderDto
    //    {
    //        Fran = x.Fran,
    //        JournalType = x.JournalType,
    //        JournalEntryId = x.JournalEntryId,
    //        JournalEntryDate = x.JournalEntryDate.ToString("yyyy-MM-dd"),
    //        Description = x.Description,
    //        Reference = x.Reference
    //    }).ToList();
    //}

    //public async Task<JournalEntryHeaderDto?> GetByKeyAsync(string fran, string journalType, decimal journalEntryId, CancellationToken ct)
    //{
    //    var x = await repo.GetByKeyAsync(fran, journalType, journalEntryId, ct);
    //    return x is null ? null : new JournalEntryHeaderDto
    //    {
    //        Fran = x.Fran,
    //        JournalType = x.JournalType,
    //        JournalEntryId = x.JournalEntryId,
    //        JournalEntryDate = x.JournalEntryDate.ToString("yyyy-MM-dd"),
    //        Description = x.Description,
    //        Reference = x.Reference
    //    };
    //}
}
