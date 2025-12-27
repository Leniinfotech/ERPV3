using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.Persistence.Repositories;

/// <summary>EF Core repository for Branches (dbo.BRCH).</summary>
public sealed class BranchesRepository(ErpDbContext db, ILogger<BranchesRepository> log) : IBranchesRepository
{
    private readonly ErpDbContext _db = db;
    private readonly ILogger<BranchesRepository> _log = log;

    public async Task<IReadOnlyList<Branch>> GetAllAsync(CancellationToken ct)
        => await _db.Branches.AsNoTracking().OrderBy(b => b.BranchCode).ToListAsync(ct);

    public async Task<Branch?> GetByKeyAsync(decimal branchCode, CancellationToken ct)
        => await _db.Branches.AsNoTracking().FirstOrDefaultAsync(b => b.BranchCode == branchCode, ct);

    public async Task<Branch> AddAsync(Branch entity, CancellationToken ct)
    {
        await _db.Branches.AddAsync(entity, ct);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Inserted Branch {BranchCode}", entity.BranchCode);
        return entity;
    }

    public async Task<Branch?> UpdateAsync(Branch entity, CancellationToken ct)
    {
        var existing = await _db.Branches.FirstOrDefaultAsync(b => b.BranchCode == entity.BranchCode, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted update of non-existent Branch {BranchCode}", entity.BranchCode);
            return null;
        }

        // Non-destructive for optional fields (none are optional by schema), update core metadata
        existing.Name = string.IsNullOrWhiteSpace(entity.Name) ? existing.Name : entity.Name;
        existing.NameAr = string.IsNullOrWhiteSpace(entity.NameAr) ? existing.NameAr : entity.NameAr;
        existing.RefNo = string.IsNullOrWhiteSpace(entity.RefNo) ? existing.RefNo : entity.RefNo;

        // Audit passed from service
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Updated Branch {BranchCode}", existing.BranchCode);
        return existing;
    }

    public async Task<bool> DeleteAsync(decimal branchCode, CancellationToken ct)
    {
        var existing = await _db.Branches.FirstOrDefaultAsync(b => b.BranchCode == branchCode, ct);
        if (existing is null)
        {
            _log.LogWarning("Attempted delete of non-existent Branch {BranchCode}", branchCode);
            return false;
        }
        _db.Branches.Remove(existing);
        await _db.SaveChangesAsync(ct);
        _log.LogInformation("Deleted Branch {BranchCode}", branchCode);
        return true;
    }
}
