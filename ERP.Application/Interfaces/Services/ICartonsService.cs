using ERP.Contracts.Inventory;

namespace ERP.Application.Interfaces.Services;

public interface ICartonsService
{
    // Headers
    Task<IReadOnlyList<CartonDto>> GetAllAsync(CancellationToken ct);
    Task<CartonDto?> GetByKeyAsync(string fran, string crtnType, string crtnCatg, CancellationToken ct);
    Task<CartonDto> CreateAsync(CreateCartonRequest req, CancellationToken ct);
    Task<bool> UpdateAsync(string fran, string crtnType, string crtnCatg, UpdateCartonRequest req, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string crtnType, string crtnCatg, CancellationToken ct);

    // Lines
    Task<IReadOnlyList<CartonDetailDto>> GetAllLinesAsync(CancellationToken ct);
    Task<CartonDetailDto?> GetLineByKeyAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct);
    Task<CartonDetailDto> CreateLineAsync(CreateCartonDetailRequest req, CancellationToken ct);
    Task<bool> UpdateLineAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, UpdateCartonDetailRequest req, CancellationToken ct);
    Task<bool> DeleteLineAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct);
}
