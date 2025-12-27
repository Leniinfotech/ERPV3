using ERP.Application.Interfaces.Repositories;
using ERP.Infrastructure.Persistence;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class JournalEntryLinesRepository : IJournalEntryLinesRepository
{
    private readonly ErpDbContext _db;
    public JournalEntryLinesRepository(ErpDbContext db) => _db = db;

    public async Task<IReadOnlyList<JournalEntryLine>> GetAllAsync(CancellationToken ct)
        => await _db.JournalEntryLines.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.JournalEntryId).ThenBy(x => x.JournalEntryLineId).ToListAsync(ct);

    public async Task<JournalEntryLine?> GetByKeyAsync(string fran, decimal journalEntryId, decimal journalEntryLineId, CancellationToken ct)
        => await _db.JournalEntryLines.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.JournalEntryId == journalEntryId && x.JournalEntryLineId == journalEntryLineId, ct);
}
