using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services
{
    public interface IVehicleMasterService
    {
        Task<IEnumerable<VehicleMaster>> GetAllAsync();
        Task<VehicleMaster?> GetByIdAsync(decimal vechileId);
        Task AddAsync(VehicleMaster entity);
        Task UpdateAsync(VehicleMaster entity);
        Task DeleteAsync(decimal vechileId);
    }
}

