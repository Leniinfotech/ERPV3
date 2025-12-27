using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services
{
    /// <summary>Service abstraction for Supplier operations.</summary>
    public interface ISuppliersService
    {
        Task<SupplierDto?> GetByCodeAsync(string supplierCode, CancellationToken ct);
        Task<IReadOnlyList<SupplierDto>> GetAllAsync(CancellationToken ct);
        Task<SupplierDto> CreateAsync(SupplierDto dto, CancellationToken ct);
        Task<SupplierDto?> UpdateAsync(string supplierCode, SupplierDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(string supplierCode, CancellationToken ct);
    }
}