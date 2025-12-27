using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class RepairHdrService : IRepairHdrService
    {
        private readonly IRepairHdrRepository _repository;

        public RepairHdrService(IRepairHdrRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<RepairHdr>> GetAllAsync() => _repository.GetAllAsync();

        public Task<RepairHdr?> GetByIdAsync(string fran, string brch, string workshop, string repairType, string repairNo) =>
            _repository.GetByIdAsync(fran, brch, workshop, repairType, repairNo);

        public Task AddAsync(RepairHdr entity) => _repository.AddAsync(entity);

        public Task UpdateAsync(RepairHdr entity) => _repository.UpdateAsync(entity);

        public Task DeleteAsync(string fran, string brch, string workshop, string repairType, string repairNo) => 
            _repository.DeleteAsync(fran, brch, workshop, repairType, repairNo);
    }
}

