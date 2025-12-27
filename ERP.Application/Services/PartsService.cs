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
    /// <summary>Application service for Part operations.</summary>
    public sealed class PartsService : IPartsService
    {
        private readonly IPartsRepository _repo;
        private readonly IAppLogger<PartsService> _log;

        public PartsService(IPartsRepository repo, IAppLogger<PartsService> log)
        {
            _repo = repo;
            _log = log;
        }

        /// <summary>Get a single part by code.</summary>
        public async Task<PartDto?> GetByCodeAsync(string partCode, CancellationToken ct)
        {
            var entity = await _repo.GetByCodeAsync(partCode, ct);
            return entity is null ? null : ToDto(entity);
        }

        /// <summary>List all parts.</summary>
        public async Task<IReadOnlyList<PartDto>> GetAllAsync(CancellationToken ct)
        {
            var list = await _repo.GetAllAsync(ct);
            return list.Select(ToDto).ToList();
        }

        // Added: Added to store parts
        // Added by: Vaishnavi
        // Added on: 10-12-2025
        public async Task<int> CreatePartAsync(PartRequests request, CancellationToken ct)
        {
            var result = await _repo.AddPartByStoredProcAsync(request, ct);

            _log.Info("Stored procedure SP_ADD_PART executed for Part: {Part}", request.PartCode);

            return result;
        }
        private static PartDto ToDto(Part e) => new()
        {
            PartCode = e.PartCode,
            Description = e.Description,
            Make = e.Make,
            Active = e.Active,
            Category = e.Category,
            SubsPart = e.SubsPart,
            FinalPart = e.FinalPart
        };

        // Added: Added to get parts
        // Added by: Vaishnavi
        // Added on: 12-12-2025
        public async Task<IReadOnlyList<PartDto>> GetAllPartsByStoredProcAsync(CancellationToken ct)
        {
            var list = await _repo.GetAllPartsByStoredProcAsync(ct);
            _log.Info("Stored procedure SP_GET_PART executed: Retrieved {Count} records", list.Count);
            return list.Select(ToDto).ToList();
        }


        // Commented by: Vaishnavi
        // Commented on: 10-12-2025

        // <summary>Create a new part.</summary>

        //public async Task<PartDto> CreateAsync(CreatePartRequest request, CancellationToken ct)
        //{
        //    var entity = new Part
        //    {
        //        PartCode = request.Code,
        //        Description = request.Description ?? string.Empty,
        //        Make = "GEN",
        //        StockKey = string.Empty,
        //        Barcode = string.Empty,
        //        SubsPart = string.Empty,
        //        FinalPart = string.Empty,
        //        InvClass = string.Empty,
        //        Category = string.Empty,
        //        Group = string.Empty,
        //        CountryOfOrigin = string.Empty,
        //        Lc = 0m,
        //        Fob = 0m,
        //        NetWeight = 0m,
        //        Stock = 0m,
        //        Cmsale = 0m,
        //        Lmsale = 0m,
        //        M3sale = 0m,
        //        M6sale = 0m,
        //        M12sale = 0m,
        //        Avgm6 = 0m,
        //        Active = true
        //    };
        //    var created = await _repo.AddAsync(entity, ct);
        //    _log.Info("Created Part {PartCode}", created.PartCode);
        //    return ToDto(created);
        //}

        ///// <summary>Update an existing part.</summary>
        //public async Task<PartDto?> UpdateAsync(string partCode, CreatePartRequest request, CancellationToken ct)
        //{
        //    var toUpdate = new Part
        //    {
        //        PartCode = partCode,
        //        Description = request.Description,
        //        Make = "GEN",
        //        Active = true
        //    };
        //    var updated = await _repo.UpdateAsync(toUpdate, ct);
        //    if (updated is null)
        //    {
        //        _log.Warn("Part not found for update {PartCode}", partCode);
        //        return null;
        //    }
        //    _log.Info("Updated Part {PartCode}", partCode);
        //    return ToDto(updated);
        //}

        ///// <summary>Delete a part by code.</summary>
        //public async Task<bool> DeleteAsync(string partCode, CancellationToken ct)
        //{
        //    var ok = await _repo.DeleteAsync(partCode, ct);
        //    if (!ok) _log.Warn("Part not found for delete {PartCode}", partCode);
        //    else _log.Info("Deleted Part {PartCode}", partCode);
        //    return ok;
        //}



    }
}