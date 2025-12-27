using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface ICustomersService
{
    Task<IReadOnlyList<CustomerDto>> GetAllAsync(CancellationToken ct);
    Task<CustomerDto?> GetByCodeAsync(string customerCode, CancellationToken ct);
    Task<CustomerDto> CreateAsync(CreateCustomerRequest req, CancellationToken ct);
    Task<bool> UpdateAsync(string customerCode, UpdateCustomerRequest req, CancellationToken ct);
    Task<bool> DeleteAsync(string customerCode, CancellationToken ct);
}
