using ERP.Application.Abstractions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class MakesService(IMakesRepository repo, IAppLogger<MakesService> log) : IMakesService
{
    private readonly IMakesRepository _repo = repo;
    private readonly IAppLogger<MakesService> _log = log;

    public async Task<IReadOnlyList<MakeDto>> GetAllAsync(CancellationToken ct)
        => (await _repo.GetAllAsync(ct)).Select(Map).ToList();

    public async Task<MakeDto?> GetByKeyAsync(string fran, string makeCode, CancellationToken ct)
    {
        var e = await _repo.GetByKeyAsync(fran, makeCode, ct);
        return e is null ? null : Map(e);
    }

    public async Task<MakeDto> CreateAsync(CreateMakeRequest request, CancellationToken ct)
    {
        Validate(request);
        var now = DateTime.UtcNow;
        var e = new Make
        {
            Fran = request.Fran,
            MakeCode = request.MakeCode,
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
        _log.Info("Created Make {Fran}-{Make}", created.Fran, created.MakeCode);
        return Map(created);
    }

    public async Task<MakeDto?> UpdateAsync(string fran, string makeCode, UpdateMakeRequest request, CancellationToken ct)
    {
        var now = DateTime.UtcNow;
        var e = new Make
        {
            Fran = fran,
            MakeCode = makeCode,
            Name = request.Name ?? string.Empty,
            NameAr = request.NameAr ?? string.Empty,
            UpdateDt = DateOnly.FromDateTime(now),
            UpdateTm = now,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty,
        };
        var updated = await _repo.UpdateAsync(e, ct);
        if (updated is null) return null;
        _log.Info("Updated Make {Fran}-{Make}", fran, makeCode);
        return Map(updated);
    }

    public Task<bool> DeleteAsync(string fran, string makeCode, CancellationToken ct) => _repo.DeleteAsync(fran, makeCode, ct);

    private static void Validate(CreateMakeRequest r)
    {
        if (string.IsNullOrWhiteSpace(r.Fran)) throw new ArgumentException("Fran is required");
        if (string.IsNullOrWhiteSpace(r.MakeCode)) throw new ArgumentException("MakeCode is required");
        if (string.IsNullOrWhiteSpace(r.Name)) throw new ArgumentException("Name is required");
        if (string.IsNullOrWhiteSpace(r.NameAr)) throw new ArgumentException("NameAr is required");
    }

    private static MakeDto Map(Make e) => new()
    {
        Fran = e.Fran,
        MakeCode = e.MakeCode,
        Name = e.Name,
        NameAr = e.NameAr,
    };

    // Added: Added method to call the storedprocedure
    // Added by: Vaishnavi
    // Added on: 12-12-2025
    public async Task<IReadOnlyList<MakeDto>> GetMake(CancellationToken ct)
    {
        var result = await _repo.GetMake(ct);
        return result.Select(Map).ToList();
    }

}
