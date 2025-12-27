using Microsoft.Extensions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class PriceGroupRepository(ErpDbContext db, ILogger<PriceGroupRepository> log) : IPriceGroupRepository
{
    // Masters
    public async Task<PriceGroupMaster?> GetMasterByKeyAsync(string fran, string prcType, string prcGrp, CancellationToken ct)
    {
        return await db.PriceGroupMasters.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.PrcType == prcType && x.PrcGrp == prcGrp, ct);
    }

    public async Task<IReadOnlyList<PriceGroupMaster>> GetAllMastersAsync(CancellationToken ct)
    {
        return await db.PriceGroupMasters.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.PrcType).ThenBy(x => x.PrcGrp).ToListAsync(ct);
    }

    public async Task<PriceGroupMaster> AddMasterAsync(PriceGroupMaster entity, CancellationToken ct)
    {
        await db.PriceGroupMasters.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        log.LogInformation("Inserted PriceGroupMaster {Fran}/{PrcType}/{PrcGrp}", entity.Fran, entity.PrcType, entity.PrcGrp);
        return entity;
    }

    public async Task<PriceGroupMaster?> UpdateMasterAsync(PriceGroupMaster entity, CancellationToken ct)
    {
        var existing = await db.PriceGroupMasters.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.PrcType == entity.PrcType && x.PrcGrp == entity.PrcGrp, ct);
        if (existing is null) return null;

        existing.Flag1 = entity.Flag1;
        existing.Flag2 = entity.Flag2;
        existing.Flag3 = entity.Flag3;
        existing.Factor1 = entity.Factor1;
        existing.Factor2 = entity.Factor2;
        existing.Factor3 = entity.Factor3;
        existing.Remarks = entity.Remarks;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteMasterAsync(string fran, string prcType, string prcGrp, CancellationToken ct)
    {
        var existing = await db.PriceGroupMasters.FirstOrDefaultAsync(
            x => x.Fran == fran && x.PrcType == prcType && x.PrcGrp == prcGrp, ct);
        if (existing is null) return false;

        db.PriceGroupMasters.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }

    // Factors
    public async Task<PriceGroupFactor?> GetFactorByKeyAsync(string fran, string type, string prcGrp, string name, string value, CancellationToken ct)
    {
        return await db.PriceGroupFactors.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Fran == fran && x.Type == type && x.PrcGrp == prcGrp && x.Name == name && x.Value == value, ct);
    }

    public async Task<IReadOnlyList<PriceGroupFactor>> GetAllFactorsAsync(CancellationToken ct)
    {
        return await db.PriceGroupFactors.AsNoTracking().OrderBy(x => x.Fran).ThenBy(x => x.Type).ThenBy(x => x.PrcGrp).ToListAsync(ct);
    }

    public async Task<PriceGroupFactor> AddFactorAsync(PriceGroupFactor entity, CancellationToken ct)
    {
        await db.PriceGroupFactors.AddAsync(entity, ct);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<PriceGroupFactor?> UpdateFactorAsync(PriceGroupFactor entity, CancellationToken ct)
    {
        var existing = await db.PriceGroupFactors.FirstOrDefaultAsync(
            x => x.Fran == entity.Fran && x.Type == entity.Type && x.PrcGrp == entity.PrcGrp && x.Name == entity.Name && x.Value == entity.Value, ct);
        if (existing is null) return null;

        existing.Factor1 = entity.Factor1;
        existing.Factor2 = entity.Factor2;
        existing.Factor3 = entity.Factor3;
        existing.UpdateDt = entity.UpdateDt;
        existing.UpdateTm = entity.UpdateTm;
        existing.UpdateBy = entity.UpdateBy;
        existing.UpdateRemarks = entity.UpdateRemarks;

        await db.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteFactorAsync(string fran, string type, string prcGrp, string name, string value, CancellationToken ct)
    {
        var existing = await db.PriceGroupFactors.FirstOrDefaultAsync(
            x => x.Fran == fran && x.Type == type && x.PrcGrp == prcGrp && x.Name == name && x.Value == value, ct);
        if (existing is null) return false;

        db.PriceGroupFactors.Remove(existing);
        await db.SaveChangesAsync(ct);
        return true;
    }
}
