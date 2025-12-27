using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Abstractions.Logging;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services
{
    /// <summary>Application service for Supplier operations.</summary>
    public sealed class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository _repo;
        private readonly IAppLogger<SuppliersService> _log;

        public SuppliersService(ISuppliersRepository repo, IAppLogger<SuppliersService> log)
        {
            _repo = repo;
            _log = log;
        }

        public async Task<SupplierDto?> GetByCodeAsync(string supplierCode, CancellationToken ct)
        {
            var entity = await _repo.GetByCodeAsync(supplierCode, ct);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<IReadOnlyList<SupplierDto>> GetAllAsync(CancellationToken ct)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(ToDto).ToList();
        }

        public async Task<SupplierDto> CreateAsync(SupplierDto dto, CancellationToken ct)
        {
            var entity = new Supplier
            {
                SupplierCode = dto.SupplierCode,
                Name = dto.Name ?? string.Empty,
                NameAr = dto.NameAr ?? string.Empty,
                Phone = dto.Phone ?? string.Empty,
                Email = dto.Email ?? string.Empty,
                Address = dto.Address ?? string.Empty,
                VatNo = dto.VatNo ?? string.Empty
            };
            var created = await _repo.AddAsync(entity, ct);
            _log.Info("Created Supplier {SupplierCode}", created.SupplierCode);
            return ToDto(created);
        }

        public async Task<SupplierDto?> UpdateAsync(string supplierCode, SupplierDto dto, CancellationToken ct)
        {
            var toUpdate = new Supplier
            {
                SupplierCode = supplierCode,
                Name = dto.Name ?? string.Empty,
                NameAr = dto.NameAr ?? string.Empty,
                Phone = dto.Phone ?? string.Empty,
                Email = dto.Email ?? string.Empty,
                Address = dto.Address ?? string.Empty,
                VatNo = dto.VatNo ?? string.Empty
            };
            var updated = await _repo.UpdateAsync(toUpdate, ct);
            if (updated is null)
            {
                _log.Warn("Supplier not found for update {SupplierCode}", supplierCode);
                return null;
            }
            _log.Info("Updated Supplier {SupplierCode}", supplierCode);
            return ToDto(updated);
        }

        public async Task<bool> DeleteAsync(string supplierCode, CancellationToken ct)
        {
            var ok = await _repo.DeleteAsync(supplierCode, ct);
            if (!ok) _log.Warn("Supplier not found for delete {SupplierCode}", supplierCode);
            else _log.Info("Deleted Supplier {SupplierCode}", supplierCode);
            return ok;
        }

        private static SupplierDto ToDto(Supplier e) => new()
        {
            SupplierCode = e.SupplierCode,
            Name = e.Name,
            NameAr = e.NameAr,
            Phone = e.Phone,
            Email = e.Email,
            Address = e.Address,
            VatNo = e.VatNo
        };
    }
}