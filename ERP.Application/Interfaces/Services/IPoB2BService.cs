using ERP.Contracts.Orders;

namespace ERP.Application.Interfaces.Services;

public interface IPoB2BService
{
    Task<IReadOnlyList<PoB2BDto>> GetAllAsync(CancellationToken ct);
    Task<PoB2BDto?> GetByKeyAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct);
    Task<PoB2BDto> CreateAsync(CreatePoB2BRequest request, CancellationToken ct);
    Task<PoB2BDto?> UpdateAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, UpdatePoB2BRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct);
}
