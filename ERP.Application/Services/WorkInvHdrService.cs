using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class WorkInvHdrService : IWorkInvHdrService
    {
        private readonly IWorkInvHdrRepository _repository;

        public WorkInvHdrService(IWorkInvHdrRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<WorkInvHdr>> GetAllAsync() => _repository.GetAllAsync();

        public Task<WorkInvHdr?> GetByIdAsync(string fran, string brch, string workshop, string workInvType, string workInvNo) =>
            _repository.GetByIdAsync(fran, brch, workshop, workInvType, workInvNo);

        public Task AddAsync(WorkInvHdr entity) => _repository.AddAsync(entity);

        public Task UpdateAsync(WorkInvHdr entity) => _repository.UpdateAsync(entity);

        public Task DeleteAsync(string fran, string brch, string workshop, string workInvType, string workInvNo) => 
            _repository.DeleteAsync(fran, brch, workshop, workInvType, workInvNo);
    }
}

