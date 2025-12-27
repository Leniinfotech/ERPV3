using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class WorkshopsService(IWorkshopsRepository repo) : IWorkshopsService
{
    public async Task<IReadOnlyList<WorkshopDto>> GetAllAsync(CancellationToken ct)
        => (await repo.GetAllAsync(ct)).Select(ToDto).ToList();

    public async Task<WorkshopDto?> GetByKeyAsync(string fran, decimal workshopId, CancellationToken ct)
    {
        var x = await repo.GetByKeyAsync(fran, workshopId, ct);
        return x is null ? null : ToDto(x);
    }

    public async Task<WorkshopDto> CreateAsync(CreateWorkshopRequest req, CancellationToken ct)
    {
        var entity = new Workshop
        {
            Fran = req.Fran,
            WorkshopId = req.WorkshopId,
            Name = req.Name,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "api",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = "api",
            UpdateRemarks = string.Empty,
        };
        await repo.CreateAsync(entity, ct);
        return ToDto(entity);
    }

    public async Task<bool> UpdateAsync(string fran, decimal workshopId, UpdateWorkshopRequest req, CancellationToken ct)
    {
        var current = await repo.GetByKeyAsync(fran, workshopId, ct);
        if (current is null) return false;
        current.Name = req.Name ?? current.Name;
        current.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        current.UpdateTm = DateTime.UtcNow;
        current.UpdateBy = "api";
        await repo.UpdateAsync(current, ct);
        return true;
    }

    public async Task<bool> DeleteAsync(string fran, decimal workshopId, CancellationToken ct)
    {
        var exists = await repo.GetByKeyAsync(fran, workshopId, ct);
        if (exists is null) return false;
        await repo.DeleteAsync(fran, workshopId, ct);
        return true;
    }

    private static WorkshopDto ToDto(Workshop x) => new()
    {
        Fran = x.Fran,
        WorkshopId = x.WorkshopId,
        Name = x.Name
    };
}
