using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface ILoadingAdviceRepository
{
    // Headers (LAHDR)
    Task<LoadingAdviceHeader?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct);
    Task<IReadOnlyList<LoadingAdviceHeader>> GetAllHeadersAsync(CancellationToken ct);
    Task<LoadingAdviceHeader> AddHeaderAsync(LoadingAdviceHeader entity, CancellationToken ct);
    Task<LoadingAdviceHeader?> UpdateHeaderAsync(LoadingAdviceHeader entity, CancellationToken ct);
    Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct);
    
    // Details (LADET)
    Task<LoadingAdviceDetail?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct);
    Task<IReadOnlyList<LoadingAdviceDetail>> GetAllDetailsAsync(CancellationToken ct);
    Task<LoadingAdviceDetail> AddDetailAsync(LoadingAdviceDetail entity, CancellationToken ct);
    Task<LoadingAdviceDetail?> UpdateDetailAsync(LoadingAdviceDetail entity, CancellationToken ct);
    Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct);
    
    // Detail2 (LADET2)
    Task<LoadingAdviceDetail2?> GetDetail2ByKeyAsync(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct);
    Task<IReadOnlyList<LoadingAdviceDetail2>> GetAllDetails2Async(CancellationToken ct);
    Task<LoadingAdviceDetail2> AddDetail2Async(LoadingAdviceDetail2 entity, CancellationToken ct);
    Task<LoadingAdviceDetail2?> UpdateDetail2Async(LoadingAdviceDetail2 entity, CancellationToken ct);
    Task<bool> DeleteDetail2Async(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct);
}
