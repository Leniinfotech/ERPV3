using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services
{
    public interface IWorkMasterService
    {
        Task<IEnumerable<WorkMaster>> GetAllAsync();
        Task<WorkMaster?> GetByIdAsync(string fran, string workType, decimal workId);
        Task AddAsync(WorkMaster entity);
        Task UpdateAsync(WorkMaster entity);
        Task DeleteAsync(string fran, string workType, decimal workId);
    }
}

