using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IPriceGroupRepository
{
    // Masters (PGRPMST)
    Task<PriceGroupMaster?> GetMasterByKeyAsync(string fran, string prcType, string prcGrp, CancellationToken ct);
    Task<IReadOnlyList<PriceGroupMaster>> GetAllMastersAsync(CancellationToken ct);
    Task<PriceGroupMaster> AddMasterAsync(PriceGroupMaster entity, CancellationToken ct);
    Task<PriceGroupMaster?> UpdateMasterAsync(PriceGroupMaster entity, CancellationToken ct);
    Task<bool> DeleteMasterAsync(string fran, string prcType, string prcGrp, CancellationToken ct);
    
    // Factors (PGRPFACTOR)
    Task<PriceGroupFactor?> GetFactorByKeyAsync(string fran, string type, string prcGrp, string name, string value, CancellationToken ct);
    Task<IReadOnlyList<PriceGroupFactor>> GetAllFactorsAsync(CancellationToken ct);
    Task<PriceGroupFactor> AddFactorAsync(PriceGroupFactor entity, CancellationToken ct);
    Task<PriceGroupFactor?> UpdateFactorAsync(PriceGroupFactor entity, CancellationToken ct);
    Task<bool> DeleteFactorAsync(string fran, string type, string prcGrp, string name, string value, CancellationToken ct);
}
