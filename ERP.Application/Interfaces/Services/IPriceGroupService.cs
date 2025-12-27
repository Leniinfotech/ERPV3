using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface IPriceGroupService
{
    // Masters
    Task<IReadOnlyList<PriceGroupMasterDto>> GetAllMastersAsync(CancellationToken ct);
    Task<PriceGroupMasterDto?> GetMasterByKeyAsync(string fran, string prcType, string prcGrp, CancellationToken ct);
    Task<PriceGroupMasterDto> CreateMasterAsync(CreatePriceGroupMasterRequest request, CancellationToken ct);
    Task<PriceGroupMasterDto?> UpdateMasterAsync(string fran, string prcType, string prcGrp, UpdatePriceGroupMasterRequest request, CancellationToken ct);
    Task<bool> DeleteMasterAsync(string fran, string prcType, string prcGrp, CancellationToken ct);
    
    // Factors
    Task<IReadOnlyList<PriceGroupFactorDto>> GetAllFactorsAsync(CancellationToken ct);
    Task<PriceGroupFactorDto?> GetFactorByKeyAsync(string fran, string type, string prcGrp, string name, string value, CancellationToken ct);
    Task<PriceGroupFactorDto> CreateFactorAsync(CreatePriceGroupFactorRequest request, CancellationToken ct);
    Task<PriceGroupFactorDto?> UpdateFactorAsync(string fran, string type, string prcGrp, string name, string value, UpdatePriceGroupFactorRequest request, CancellationToken ct);
    Task<bool> DeleteFactorAsync(string fran, string type, string prcGrp, string name, string value, CancellationToken ct);
}
