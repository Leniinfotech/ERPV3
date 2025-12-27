using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface ICustomerOrdersRepository
{
    // Headers
    Task<CustomerOrderHeader?> GetHeaderByKeyAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct);
    Task<IReadOnlyList<CustomerOrderHeader>> GetAllHeadersAsync(CancellationToken ct);
    Task<CustomerOrderHeader> AddHeaderAsync(CustomerOrderHeader entity, CancellationToken ct);
    Task<CustomerOrderHeader?> UpdateHeaderAsync(CustomerOrderHeader entity, CancellationToken ct);
    Task<bool> DeleteHeaderAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct);
    
    // Details
    Task<CustomerOrderDetail?> GetDetailByKeyAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct);
    Task<IReadOnlyList<CustomerOrderDetail>> GetAllDetailsAsync(CancellationToken ct);
    Task<IReadOnlyList<CustomerOrderDetail>> GetDetailsByHeaderAsync(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct);
    Task<CustomerOrderDetail> AddDetailAsync(CustomerOrderDetail entity, CancellationToken ct);
    Task<CustomerOrderDetail?> UpdateDetailAsync(CustomerOrderDetail entity, CancellationToken ct);
    Task<bool> DeleteDetailAsync(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct);
}
