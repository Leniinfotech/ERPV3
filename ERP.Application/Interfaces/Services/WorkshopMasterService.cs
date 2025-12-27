// ERP.Application/Services/WorkshopMasterService.cs
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class WorkshopMasterService : IWorkshopMasterService
    {
        private readonly IWorkshopMasterRepository _repository;

        public WorkshopMasterService(IWorkshopMasterRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<WorkshopMaster>> GetAllAsync() => _repository.GetAllAsync();

        public Task<WorkshopMaster?> GetByIdAsync(string fran, decimal workshop) =>
            _repository.GetByIdAsync(fran, workshop);

        public Task AddAsync(WorkshopMaster entity) => _repository.AddAsync(entity);

        public Task UpdateAsync(WorkshopMaster entity) => _repository.UpdateAsync(entity);

        public Task DeleteAsync(string fran, decimal workshop) => _repository.DeleteAsync(fran, workshop);
    }
}
