using ERP.Contracts.Orders;

namespace ERP.Application.Interfaces.Services;

public interface ICustomerOrdersService
{
    // Headers
    Task<IReadOnlyList<CustomerOrderHeaderDto>> GetAllHeadersAsync(CancellationToken ct);
    Task<CustomerOrderHeaderDto?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct);
    Task<CustomerOrderHeaderDto> CreateHeaderAsync(CreateCustomerOrderHeaderRequest request, CancellationToken ct);
    Task<CustomerOrderHeaderDto?> UpdateHeaderAsync(string fran, string branch, string warehouse, string cordType, string cordNo, UpdateCustomerOrderHeaderRequest request, CancellationToken ct);
    Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct);
    
    // Details
    Task<IReadOnlyList<CustomerOrderDetailDto>> GetAllDetailsAsync(CancellationToken ct);
    Task<CustomerOrderDetailDto?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct);
    Task<CustomerOrderDetailDto> CreateDetailAsync(CreateCustomerOrderDetailRequest request, CancellationToken ct);
    Task<CustomerOrderDetailDto?> UpdateDetailAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, UpdateCustomerOrderDetailRequest request, CancellationToken ct);
    Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct);
}
