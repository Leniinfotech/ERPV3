using ERP.Application.Abstractions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Inventory;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class StoresService(IStoresRepository repo, IAppLogger<StoresService> log) : IStoresService
{
    private readonly IStoresRepository _repo = repo;
    private readonly IAppLogger<StoresService> _log = log;

    public async Task<IReadOnlyList<StoreDto>> GetAllAsync(CancellationToken ct)
        => (await _repo.GetAllAsync(ct)).Select(Map).ToList();

    public async Task<StoreDto?> GetByKeyAsync(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct)
    {
        var e = await _repo.GetByKeyAsync(fran, branch, warehouseCode, storeCode, ct);
        return e is null ? null : Map(e);
    }

    public async Task<StoreDto> CreateAsync(CreateStoreRequest request, CancellationToken ct)
    {
        Validate(request);
        var now = DateTime.UtcNow;
        var e = new Store
        {
            Fran = request.Fran,
            Branch = request.Branch,
            WarehouseCode = request.WarehouseCode,
            StoreCode = request.StoreCode,
            Name = request.Name,
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
        _log.Info("Created Store {Fran}-{Branch}-{Wh}-{Store}", e.Fran, e.Branch, e.WarehouseCode, e.StoreCode);
        return Map(created);
    }

    public async Task<StoreDto?> UpdateAsync(string fran, string branch, string warehouseCode, string storeCode, UpdateStoreRequest request, CancellationToken ct)
    {
        var now = DateTime.UtcNow;
        var e = new Store
        {
            Fran = fran,
            Branch = branch,
            WarehouseCode = warehouseCode,
            StoreCode = storeCode,
            Name = request.Name ?? string.Empty,
            UpdateDt = DateOnly.FromDateTime(now),
            UpdateTm = now,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty,
        };
        var updated = await _repo.UpdateAsync(e, ct);
        if (updated is null) return null;
        _log.Info("Updated Store {Fran}-{Branch}-{Wh}-{Store}", fran, branch, warehouseCode, storeCode);
        return Map(updated);
    }

    public Task<bool> DeleteAsync(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct)
        => _repo.DeleteAsync(fran, branch, warehouseCode, storeCode, ct);

    private static void Validate(CreateStoreRequest r)
    {
        if (string.IsNullOrWhiteSpace(r.Fran)) throw new ArgumentException("Fran is required");
        if (string.IsNullOrWhiteSpace(r.Branch)) throw new ArgumentException("Branch is required");
        if (string.IsNullOrWhiteSpace(r.WarehouseCode)) throw new ArgumentException("WarehouseCode is required");
        if (string.IsNullOrWhiteSpace(r.StoreCode)) throw new ArgumentException("StoreCode is required");
        if (string.IsNullOrWhiteSpace(r.Name)) throw new ArgumentException("Name is required");
    }

    private static StoreDto Map(Store e) => new()
    {
        Fran = e.Fran,
        Branch = e.Branch,
        WarehouseCode = e.WarehouseCode,
        StoreCode = e.StoreCode,
        Name = e.Name,
    };
}
