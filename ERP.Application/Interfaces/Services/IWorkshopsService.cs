using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface IWorkshopsService
{
    Task<IReadOnlyList<WorkshopDto>> GetAllAsync(CancellationToken ct);
    Task<WorkshopDto?> GetByKeyAsync(string fran, decimal workshopId, CancellationToken ct);
    Task<WorkshopDto> CreateAsync(CreateWorkshopRequest req, CancellationToken ct);
    Task<bool> UpdateAsync(string fran, decimal workshopId, UpdateWorkshopRequest req, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, decimal workshopId, CancellationToken ct);
}
