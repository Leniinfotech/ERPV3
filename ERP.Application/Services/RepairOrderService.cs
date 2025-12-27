using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class RepairOrderService : IRepairOrderService
    {
        private readonly IRepairOrderRepository _repository;

        public RepairOrderService(IRepairOrderRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<RepairOrder>> GetAllAsync() => _repository.GetAllAsync();

        public Task<RepairOrder?> GetByIdAsync(string fran, string brch, string workshop, string repairType, string repairNo, string repairSrl) =>
            _repository.GetByIdAsync(fran, brch, workshop, repairType, repairNo, repairSrl);

        public Task AddAsync(RepairOrder entity) => _repository.AddAsync(entity);

        public Task UpdateAsync(RepairOrder entity) => _repository.UpdateAsync(entity);

        public Task DeleteAsync(string fran, string brch, string workshop, string repairType, string repairNo, string repairSrl) => 
            _repository.DeleteAsync(fran, brch, workshop, repairType, repairNo, repairSrl);
    }
}

