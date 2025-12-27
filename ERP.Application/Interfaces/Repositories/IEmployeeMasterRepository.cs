using ERP.Domain.Entities;

namespace ERP.Domain.Interfaces
{
    public interface IEmployeeMasterRepository
    {
        Task<IEnumerable<EmployeeMaster>> GetAllAsync();
        Task<EmployeeMaster?> GetByIdAsync(string fran, string employee);
        Task AddAsync(EmployeeMaster entity);
        Task UpdateAsync(EmployeeMaster entity);
        Task DeleteAsync(string fran, string employee);
    }
}

