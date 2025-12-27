using ERP.Contracts.Orders;

namespace ERP.Application.Interfaces.Services;

public interface ILoadingAdviceService
{
    // Headers
    Task<IReadOnlyList<LoadingAdviceHeaderDto>> GetAllHeadersAsync(CancellationToken ct);
    Task<LoadingAdviceHeaderDto?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct);
    Task<LoadingAdviceHeaderDto> CreateHeaderAsync(CreateLoadingAdviceHeaderRequest request, CancellationToken ct);
    Task<LoadingAdviceHeaderDto?> UpdateHeaderAsync(string fran, string branch, string warehouse, string laType, string laNo, UpdateLoadingAdviceHeaderRequest request, CancellationToken ct);
    Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct);
    
    // Details
    Task<IReadOnlyList<LoadingAdviceDetailDto>> GetAllDetailsAsync(CancellationToken ct);
    Task<LoadingAdviceDetailDto?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct);
    Task<LoadingAdviceDetailDto> CreateDetailAsync(CreateLoadingAdviceDetailRequest request, CancellationToken ct);
    Task<LoadingAdviceDetailDto?> UpdateDetailAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, UpdateLoadingAdviceDetailRequest request, CancellationToken ct);
    Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct);
    
    // Detail2
    Task<IReadOnlyList<LoadingAdviceDetail2Dto>> GetAllDetails2Async(CancellationToken ct);
    Task<LoadingAdviceDetail2Dto?> GetDetail2ByKeyAsync(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct);
    Task<LoadingAdviceDetail2Dto> CreateDetail2Async(CreateLoadingAdviceDetail2Request request, CancellationToken ct);
    Task<LoadingAdviceDetail2Dto?> UpdateDetail2Async(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, UpdateLoadingAdviceDetail2Request request, CancellationToken ct);
    Task<bool> DeleteDetail2Async(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct);
}
