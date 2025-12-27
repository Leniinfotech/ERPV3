using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class WorkshopsRepository : IWorkshopsRepository
{
    private readonly ErpDbContext _db;
    public WorkshopsRepository(ErpDbContext db) => _db = db;

    public async Task<IReadOnlyList<Workshop>> GetAllAsync(CancellationToken ct)
        => await _db.Workshops.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.WorkshopId).ToListAsync(ct);

    public async Task<Workshop?> GetByKeyAsync(string fran, decimal workshopId, CancellationToken ct)
        => await _db.Workshops.AsNoTracking().FirstOrDefaultAsync(x => x.Fran == fran && x.WorkshopId == workshopId, ct);

    public async Task CreateAsync(Workshop entity, CancellationToken ct)
    {
        _db.Workshops.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Workshop entity, CancellationToken ct)
    {
        _db.Workshops.Update(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(string fran, decimal workshopId, CancellationToken ct)
    {
        var tracked = await _db.Workshops.FirstOrDefaultAsync(x => x.Fran == fran && x.WorkshopId == workshopId, ct);
        if (tracked is null) return;
        _db.Workshops.Remove(tracked);
        await _db.SaveChangesAsync(ct);
    }
}
