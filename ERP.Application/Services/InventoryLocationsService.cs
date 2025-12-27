using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Inventory;
using ERP.Domain.Entities;

namespace ERP.Application.Services
{
    /// <summary>Application service for Inventory Location operations.</summary>
    public sealed class InventoryLocationsService : IInventoryLocationsService
    {
        private readonly IInventoryLocationsRepository _repo;
        private readonly IAppLogger<InventoryLocationsService> _log;

        public InventoryLocationsService(IInventoryLocationsRepository repo, IAppLogger<InventoryLocationsService> log)
        {
            _repo = repo;
            _log = log;
        }

        public async Task<InventoryLocationDto?> GetByCodeAsync(string warehouseCode, CancellationToken ct)
        {
            var entity = await _repo.GetByCodeAsync(warehouseCode, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<IReadOnlyList<InventoryLocationDto>> GetAllAsync(CancellationToken ct)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(ToDto).ToList();
        }

        public async Task<InventoryLocationDto> CreateAsync(InventoryLocationDto dto, CancellationToken ct)
        {
            var now = DateTime.UtcNow;
            var today = DateOnly.FromDateTime(now);
            var entity = new InventoryLocation
            {
                WarehouseCode = dto.WarehouseCode,
                Name = dto.Name ?? string.Empty,
                NameAr = dto.NameAr ?? string.Empty,

                // Required defaults for NOT NULL columns
                Fran = "F1",
                Branch = "B1",
                CreateDt = today,
                CreateTm = now,
                CreateBy = string.Empty,
                CreateRemarks = string.Empty,
                UpdateDt = today,
                UpdateTm = now,
                UpdateBy = string.Empty,
                UpdateRemarks = string.Empty
            };
            var created = await _repo.AddAsync(entity, ct);
            _log.Info("Created InventoryLocation {WarehouseCode}", created.WarehouseCode);
            return ToDto(created);
        }

        public async Task<InventoryLocationDto?> UpdateAsync(string warehouseCode, InventoryLocationDto dto, CancellationToken ct)
        {
            var now = DateTime.UtcNow;
            var today = DateOnly.FromDateTime(now);
            var toUpdate = new InventoryLocation
            {
                WarehouseCode = warehouseCode,
                Name = dto.Name ?? string.Empty,
                NameAr = dto.NameAr ?? string.Empty,

                // keep existing Fran/Branch from DB via repo; but set audit on update
                UpdateDt = today,
                UpdateTm = now,
                UpdateBy = string.Empty,
                UpdateRemarks = string.Empty
            };
            var updated = await _repo.UpdateAsync(toUpdate, ct);
            if (updated is null)
            {
                _log.Warn("InventoryLocation not found for update {WarehouseCode}", warehouseCode);
                return null;
            }
            _log.Info("Updated InventoryLocation {WarehouseCode}", warehouseCode);
            return ToDto(updated);
        }

        public async Task<bool> DeleteAsync(string warehouseCode, CancellationToken ct)
        {
            var ok = await _repo.DeleteAsync(warehouseCode, ct);
            if (!ok) _log.Warn("InventoryLocation not found for delete {WarehouseCode}", warehouseCode);
            else _log.Info("Deleted InventoryLocation {WarehouseCode}", warehouseCode);
            return ok;
        }

        private static InventoryLocationDto ToDto(InventoryLocation e) => new()
        {
            WarehouseCode = e.WarehouseCode,
            Name = e.Name,
            NameAr = e.NameAr
        };
    }
}