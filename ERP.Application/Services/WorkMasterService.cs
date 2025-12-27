using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class WorkMasterService : IWorkMasterService
    {
        private readonly IWorkMasterRepository _repository;

        public WorkMasterService(IWorkMasterRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<WorkMaster>> GetAllAsync() => _repository.GetAllAsync();

        public Task<WorkMaster?> GetByIdAsync(string fran, string workType, decimal workId) =>
            _repository.GetByIdAsync(fran, workType, workId);

        public Task AddAsync(WorkMaster entity) => _repository.AddAsync(entity);

        public Task UpdateAsync(WorkMaster entity) => _repository.UpdateAsync(entity);

        public Task DeleteAsync(string fran, string workType, decimal workId) => _repository.DeleteAsync(fran, workType, workId);
    }
}

