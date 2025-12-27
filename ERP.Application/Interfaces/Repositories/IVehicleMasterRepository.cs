using ERP.Domain.Entities;

namespace ERP.Domain.Interfaces
{
    public interface IVehicleMasterRepository
    {
        Task<IEnumerable<VehicleMaster>> GetAllAsync();
        Task<VehicleMaster?> GetByIdAsync(decimal vechileId);
        Task AddAsync(VehicleMaster entity);
        Task UpdateAsync(VehicleMaster entity);
        Task DeleteAsync(decimal vechileId);
    }
}

