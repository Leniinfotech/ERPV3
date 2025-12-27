using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IOrderPlanRepository
{
    // Headers (OPLNHDR)
    Task<OrderPlanHeader?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct);
    Task<IReadOnlyList<OrderPlanHeader>> GetAllHeadersAsync(CancellationToken ct);
    Task<OrderPlanHeader> AddHeaderAsync(OrderPlanHeader entity, CancellationToken ct);
    Task<OrderPlanHeader?> UpdateHeaderAsync(OrderPlanHeader entity, CancellationToken ct);
    Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct);
    
    // Details (OPLNDET)
    Task<OrderPlanDetail?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct);
    Task<IReadOnlyList<OrderPlanDetail>> GetAllDetailsAsync(CancellationToken ct);
    Task<OrderPlanDetail> AddDetailAsync(OrderPlanDetail entity, CancellationToken ct);
    Task<OrderPlanDetail?> UpdateDetailAsync(OrderPlanDetail entity, CancellationToken ct);
    Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct);
    
    // Masters (OPLNMST)
    Task<OrderPlanMaster?> GetMasterByKeyAsync(string fran, string type, string name, CancellationToken ct);
    Task<IReadOnlyList<OrderPlanMaster>> GetAllMastersAsync(CancellationToken ct);
    Task<OrderPlanMaster> AddMasterAsync(OrderPlanMaster entity, CancellationToken ct);
    Task<OrderPlanMaster?> UpdateMasterAsync(OrderPlanMaster entity, CancellationToken ct);
    Task<bool> DeleteMasterAsync(string fran, string type, string name, CancellationToken ct);
}
