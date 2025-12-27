using ERP.Application.Abstractions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class BranchesService(IBranchesRepository repo, IAppLogger<BranchesService> log) : IBranchesService
{
    private readonly IBranchesRepository _repo = repo;
    private readonly IAppLogger<BranchesService> _log = log;

    public async Task<IReadOnlyList<BranchDto>> GetAllAsync(CancellationToken ct)
        => (await _repo.GetAllAsync(ct)).Select(MapToDto).ToList();

    public async Task<BranchDto?> GetByKeyAsync(decimal branchCode, CancellationToken ct)
    {
        var e = await _repo.GetByKeyAsync(branchCode, ct);
        return e is null ? null : MapToDto(e);
    }

    public async Task<BranchDto> CreateAsync(CreateBranchRequest request, CancellationToken ct)
    {
        Validate(request);
        var now = DateTime.UtcNow;
        var e = new Branch
        {
            Fran = request.Fran ?? string.Empty,
            RefNo = request.RefNo ?? string.Empty,
            Name = request.Name ?? string.Empty,
            NameAr = request.NameAr ?? string.Empty,

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
        _log.Info("Created Branch {BranchCode}", created.BranchCode);
        return MapToDto(created);
    }

    public async Task<BranchDto?> UpdateAsync(decimal branchCode, UpdateBranchRequest request, CancellationToken ct)
    {
        ValidateUpdate(request);
        var now = DateTime.UtcNow;
        var e = new Branch
        {
            BranchCode = branchCode,
            Name = request.Name ?? string.Empty,
            NameAr = request.NameAr ?? string.Empty,
            RefNo = request.RefNo ?? string.Empty,
            UpdateDt = DateOnly.FromDateTime(now),
            UpdateTm = now,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty,
        };
        var updated = await _repo.UpdateAsync(e, ct);
        if (updated is null)
        {
            _log.Warn("Branch not found for update {BranchCode}", branchCode);
            return null;
        }
        _log.Info("Updated Branch {BranchCode}", branchCode);
        return MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(decimal branchCode, CancellationToken ct)
    {
        var ok = await _repo.DeleteAsync(branchCode, ct);
        if (!ok) _log.Warn("Branch not found for delete {BranchCode}", branchCode);
        else _log.Info("Deleted Branch {BranchCode}", branchCode);
        return ok;
    }

    private static void Validate(CreateBranchRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Fran)) throw new ArgumentException("Fran is required");
        if (string.IsNullOrWhiteSpace(request.Name)) throw new ArgumentException("Name is required");
        if (string.IsNullOrWhiteSpace(request.NameAr)) throw new ArgumentException("NameAr is required");
        if (string.IsNullOrWhiteSpace(request.RefNo)) throw new ArgumentException("RefNo is required");
    }

    private static void ValidateUpdate(UpdateBranchRequest request)
    {
        // At least one updatable field should be supplied
        if (string.IsNullOrWhiteSpace(request.Name) && string.IsNullOrWhiteSpace(request.NameAr) && string.IsNullOrWhiteSpace(request.RefNo))
            throw new ArgumentException("At least one field (Name/NameAr/RefNo) must be provided");
    }

    private static BranchDto MapToDto(Branch e) => new()
    {
        BranchCode = e.BranchCode,
        Fran = e.Fran,
        RefNo = e.RefNo,
        Name = e.Name,
        NameAr = e.NameAr,
    };
}
