using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class SubsPartService(ISubsPartRepository repo) : ISubsPartService
{
    public async Task<IReadOnlyList<SubsPartDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await repo.GetAllAsync(ct);
        return items.Select(MapToDto).ToList();
    }

    public async Task<SubsPartDto?> GetByKeyAsync(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct)
    {
        var item = await repo.GetByKeyAsync(fran, make, part, finalPart, grpNo, ct);
        return item is null ? null : MapToDto(item);
    }

    public async Task<SubsPartDto> CreateAsync(CreateSubsPartRequest request, CancellationToken ct)
    {
        var entity = new SubsPart
        {
            Fran = request.Fran,
            Make = request.Make,
            Part = request.Part,
            FinalPart = request.FinalPart,
            GrpNo = request.GrpNo,
            PsSubSeq = request.PsSubSeq ?? 0m,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty
        };
        var created = await repo.AddAsync(entity, ct);
        return MapToDto(created);
    }

    public async Task<SubsPartDto?> UpdateAsync(string fran, string make, string part, string finalPart, decimal grpNo, UpdateSubsPartRequest request, CancellationToken ct)
    {
        var existing = await repo.GetByKeyAsync(fran, make, part, finalPart, grpNo, ct);
        if (existing is null) return null;

        existing.PsSubSeq = request.PsSubSeq ?? existing.PsSubSeq;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        existing.UpdateBy = "SYSTEM";

        var updated = await repo.UpdateAsync(existing, ct);
        return updated is null ? null : MapToDto(updated);
    }

    public Task<bool> DeleteAsync(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct)
        => repo.DeleteAsync(fran, make, part, finalPart, grpNo, ct);

    private static SubsPartDto MapToDto(SubsPart e) => new(
        e.Fran, e.Make, e.Part, e.FinalPart, e.GrpNo, e.PsSubSeq,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
