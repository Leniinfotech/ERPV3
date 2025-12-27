using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface ICartonsRepository
{
    // Headers (CRTN)
    Task<IReadOnlyList<Carton>> GetAllAsync(CancellationToken ct);
    Task<Carton?> GetByKeyAsync(string fran, string crtnType, string crtnCatg, CancellationToken ct);
    Task CreateAsync(Carton entity, CancellationToken ct);
    Task UpdateAsync(Carton entity, CancellationToken ct);
    Task DeleteAsync(string fran, string crtnType, string crtnCatg, CancellationToken ct);

    // Lines (CRTNDET)
    Task<IReadOnlyList<CartonDetail>> GetAllLinesAsync(CancellationToken ct);
    Task<CartonDetail?> GetLineByKeyAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct);
    Task CreateLineAsync(CartonDetail entity, CancellationToken ct);
    Task UpdateLineAsync(CartonDetail entity, CancellationToken ct);
    Task DeleteLineAsync(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct);
}
