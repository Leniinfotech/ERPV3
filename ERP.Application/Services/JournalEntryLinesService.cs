using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Finance;

namespace ERP.Application.Services;

public sealed class JournalEntryLinesService(IJournalEntryLinesRepository repo) : IJournalEntryLinesService
{
    public async Task<IReadOnlyList<JournalEntryLineDto>> GetAllAsync(CancellationToken ct)
    {
        var rows = await repo.GetAllAsync(ct);
        return rows.Select(x => new JournalEntryLineDto
        {
            Fran = x.Fran,
            JournalEntryId = x.JournalEntryId,
            JournalEntryLineId = x.JournalEntryLineId,
            AccountCode = x.AccountCode,
            Debit = x.Debit,
            Credit = x.Credit,
            Remarks = x.Remarks
        }).ToList();
    }

    public async Task<JournalEntryLineDto?> GetByKeyAsync(string fran, decimal journalEntryId, decimal journalEntryLineId, CancellationToken ct)
    {
        var x = await repo.GetByKeyAsync(fran, journalEntryId, journalEntryLineId, ct);
        return x is null ? null : new JournalEntryLineDto
        {
            Fran = x.Fran,
            JournalEntryId = x.JournalEntryId,
            JournalEntryLineId = x.JournalEntryLineId,
            AccountCode = x.AccountCode,
            Debit = x.Debit,
            Credit = x.Credit,
            Remarks = x.Remarks
        };
    }
}
