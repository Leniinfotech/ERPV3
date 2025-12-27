using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services
{
    public interface IEmployeeMasterService
    {
        Task<IEnumerable<EmployeeMaster>> GetAllAsync();
        Task<EmployeeMaster?> GetByIdAsync(string fran, string employee);
        Task AddAsync(EmployeeMaster entity);
        Task UpdateAsync(EmployeeMaster entity);
        Task DeleteAsync(string fran, string employee);
    }
}

