using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class WorkInvDetService : IWorkInvDetService
    {
        private readonly IWorkInvDetRepository _repository;

        public WorkInvDetService(IWorkInvDetRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<WorkInvDet>> GetAllAsync() => _repository.GetAllAsync();

        public Task<WorkInvDet?> GetByIdAsync(string fran, string brch, string workshop, string workInvType, string workInvNo, decimal workInvSrl) =>
            _repository.GetByIdAsync(fran, brch, workshop, workInvType, workInvNo, workInvSrl);

        public Task AddAsync(WorkInvDet entity) => _repository.AddAsync(entity);

        public Task UpdateAsync(WorkInvDet entity) => _repository.UpdateAsync(entity);

        public Task DeleteAsync(string fran, string brch, string workshop, string workInvType, string workInvNo, decimal workInvSrl) => 
            _repository.DeleteAsync(fran, brch, workshop, workInvType, workInvNo, workInvSrl);
    }
}

