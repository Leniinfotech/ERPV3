using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class VehicleMasterService : IVehicleMasterService
    {
        private readonly IVehicleMasterRepository _repository;

        public VehicleMasterService(IVehicleMasterRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<VehicleMaster>> GetAllAsync() => _repository.GetAllAsync();

        public Task<VehicleMaster?> GetByIdAsync(decimal vechileId) =>
            _repository.GetByIdAsync(vechileId);

        public Task AddAsync(VehicleMaster entity) => _repository.AddAsync(entity);

        public Task UpdateAsync(VehicleMaster entity) => _repository.UpdateAsync(entity);

        public Task DeleteAsync(decimal vechileId) => _repository.DeleteAsync(vechileId);
    }
}

