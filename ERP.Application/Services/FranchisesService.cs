using ERP.Application.Abstractions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class FranchisesService(IFranchisesRepository repo, IAppLogger<FranchisesService> log) : IFranchisesService
{
    private readonly IFranchisesRepository _repo = repo;
    private readonly IAppLogger<FranchisesService> _log = log;

    public async Task<IReadOnlyList<FranchiseDto>> GetAllAsync(CancellationToken ct)
        => (await _repo.GetAllAsync(ct)).Select(Map).ToList();

    public async Task<FranchiseDto?> GetByKeyAsync(string fran, CancellationToken ct)
    {
        var e = await _repo.GetByKeyAsync(fran, ct);
        return e is null ? null : Map(e);
    }

    public async Task<FranchiseDto> CreateAsync(CreateFranchiseRequest request, CancellationToken ct)
    {
        Validate(request);
        var now = DateTime.UtcNow;
        var e = new Franchise
        {
            Fran = request.Fran,
            Name = request.Name,
            NameAr = request.NameAr,
            CreateDt = DateOnly.FromDateTime(now),
            CreateTm = now,
            CreateBy = string.Empty,
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(now),
            UpdateTm = now,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty,
        };
        var created = await _repo.AddAsync(e, ct);
        _log.Info("Created Franchise {Fran}", created.Fran);
        return Map(created);
    }

    public async Task<FranchiseDto?> UpdateAsync(string fran, UpdateFranchiseRequest request, CancellationToken ct)
    {
        var now = DateTime.UtcNow;
        var e = new Franchise
        {
            Fran = fran,
            Name = request.Name ?? string.Empty,
            NameAr = request.NameAr ?? string.Empty,
            UpdateDt = DateOnly.FromDateTime(now),
            UpdateTm = now,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty,
        };
        var updated = await _repo.UpdateAsync(e, ct);
        if (updated is null) return null;
        _log.Info("Updated Franchise {Fran}", fran);
        return Map(updated);
    }

    public Task<bool> DeleteAsync(string fran, CancellationToken ct) => _repo.DeleteAsync(fran, ct);

    private static void Validate(CreateFranchiseRequest r)
    {
        if (string.IsNullOrWhiteSpace(r.Fran)) throw new ArgumentException("Fran is required");
        if (string.IsNullOrWhiteSpace(r.Name)) throw new ArgumentException("Name is required");
        if (string.IsNullOrWhiteSpace(r.NameAr)) throw new ArgumentException("NameAr is required");
    }

    private static FranchiseDto Map(Franchise e) => new()
    {
        Fran = e.Fran,
        Name = e.Name,
        NameAr = e.NameAr,
    };
}
