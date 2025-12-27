using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Services
{
    public class EmployeeMasterService : IEmployeeMasterService
    {
        private readonly IEmployeeMasterRepository _repository;

        public EmployeeMasterService(IEmployeeMasterRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<EmployeeMaster>> GetAllAsync() => _repository.GetAllAsync();

        public Task<EmployeeMaster?> GetByIdAsync(string fran, string employee) =>
            _repository.GetByIdAsync(fran, employee);

        public Task AddAsync(EmployeeMaster entity) => _repository.AddAsync(entity);

        public Task UpdateAsync(EmployeeMaster entity) => _repository.UpdateAsync(entity);

        public Task DeleteAsync(string fran, string employee) => _repository.DeleteAsync(fran, employee);
    }
}

