using ERP.Contracts.Inventory;

namespace ERP.Application.Interfaces.Services;

public interface IPatternCartonService
{
    Task<IReadOnlyList<PatternCartonHeaderDto>> GetAllAsync(CancellationToken ct);
    Task<PatternCartonHeaderDto?> GetByKeyAsync(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct);
    Task<PatternCartonHeaderDto> CreateAsync(CreatePatternCartonHeaderRequest request, CancellationToken ct);
    Task<PatternCartonHeaderDto?> UpdateAsync(string fran, string branch, string warehouse, string crtnType, string crtn, UpdatePatternCartonHeaderRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct);
}
