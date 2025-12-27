using ERP.Contracts.Orders;

namespace ERP.Application.Interfaces.Services;

public interface IOrderPlanService
{
    // Headers
    Task<IReadOnlyList<OrderPlanHeaderDto>> GetAllHeadersAsync(CancellationToken ct);
    Task<OrderPlanHeaderDto?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct);
    Task<OrderPlanHeaderDto> CreateHeaderAsync(CreateOrderPlanHeaderRequest request, CancellationToken ct);
    Task<OrderPlanHeaderDto?> UpdateHeaderAsync(string fran, string branch, string warehouse, string planType, string planNo, UpdateOrderPlanHeaderRequest request, CancellationToken ct);
    Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct);
    
    // Details
    Task<IReadOnlyList<OrderPlanDetailDto>> GetAllDetailsAsync(CancellationToken ct);
    Task<OrderPlanDetailDto?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct);
    Task<OrderPlanDetailDto> CreateDetailAsync(CreateOrderPlanDetailRequest request, CancellationToken ct);
    Task<OrderPlanDetailDto?> UpdateDetailAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, UpdateOrderPlanDetailRequest request, CancellationToken ct);
    Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct);
    
    // Masters
    Task<IReadOnlyList<OrderPlanMasterDto>> GetAllMastersAsync(CancellationToken ct);
    Task<OrderPlanMasterDto?> GetMasterByKeyAsync(string fran, string type, string name, CancellationToken ct);
    Task<OrderPlanMasterDto> CreateMasterAsync(CreateOrderPlanMasterRequest request, CancellationToken ct);
    Task<OrderPlanMasterDto?> UpdateMasterAsync(string fran, string type, string name, UpdateOrderPlanMasterRequest request, CancellationToken ct);
    Task<bool> DeleteMasterAsync(string fran, string type, string name, CancellationToken ct);
}
