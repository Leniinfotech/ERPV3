using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

/// <summary>Repository abstraction for Part persistence.</summary>
public interface IPartsRepository
{
    // Added: Added to store parts
    // Added by: Vaishnavi
    // Added on: 10-12-2025
    Task<int> AddPartByStoredProcAsync(PartRequests req, CancellationToken ct);

    // Added: Added to get parts
    // Added by: Vaishnavi
    // Added on: 12-12-2025
    Task<IReadOnlyList<Part>> GetAllPartsByStoredProcAsync(CancellationToken ct);

    Task<Part?> GetByCodeAsync(string partCode, CancellationToken ct);
    Task<IReadOnlyList<Part>> GetAllAsync(CancellationToken ct);

    // Commented by: Vaishnavi
    // Commented on: 10-12-2025

    //Task<Part> AddAsync(Part part, CancellationToken ct);
    //Task<Part?> UpdateAsync(Part part, CancellationToken ct);
    //Task<bool> DeleteAsync(string partCode, CancellationToken ct);

}