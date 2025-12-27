using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class CompetitorService(ICompetitorRepository repo) : ICompetitorService
{
    public async Task<IReadOnlyList<CompetitorDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await repo.GetAllAsync(ct);
        return items.Select(MapToDto).ToList();
    }

    public async Task<CompetitorDto?> GetByCodeAsync(string competitorCode, CancellationToken ct)
    {
        var item = await repo.GetByCodeAsync(competitorCode, ct);
        return item is null ? null : MapToDto(item);
    }

    public async Task<CompetitorDto> CreateAsync(CreateCompetitorRequest request, CancellationToken ct)
    {
        var entity = new Competitor
        {
            CompetitorCode = request.CompetitorCode,
            Name = request.Name ?? string.Empty,
            NameAr = request.NameAr ?? string.Empty,
            Phone = request.Phone ?? string.Empty,
            Email = request.Email ?? string.Empty,
            Address = request.Address ?? string.Empty,
            VatNo = request.VatNo ?? string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty,
            UpdateMarks = string.Empty
        };
        var created = await repo.AddAsync(entity, ct);
        return MapToDto(created);
    }

    public async Task<CompetitorDto?> UpdateAsync(string competitorCode, UpdateCompetitorRequest request, CancellationToken ct)
    {
        var existing = await repo.GetByCodeAsync(competitorCode, ct);
        if (existing is null) return null;

        existing.Name = request.Name ?? existing.Name;
        existing.NameAr = request.NameAr ?? existing.NameAr;
        existing.Phone = request.Phone ?? existing.Phone;
        existing.Email = request.Email ?? existing.Email;
        existing.Address = request.Address ?? existing.Address;
        existing.VatNo = request.VatNo ?? existing.VatNo;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        existing.UpdateBy = "SYSTEM";

        var updated = await repo.UpdateAsync(existing, ct);
        return updated is null ? null : MapToDto(updated);
    }

    public Task<bool> DeleteAsync(string competitorCode, CancellationToken ct)
        => repo.DeleteAsync(competitorCode, ct);

    private static CompetitorDto MapToDto(Competitor e) => new(
        e.Id, e.CompetitorCode, e.Name, e.NameAr, e.Phone, e.Email, e.Address, e.VatNo,
        e.CreateDt, e.CreateTm, e.CreateBy);
}
