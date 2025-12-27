using ERP.Domain.Entities;

namespace ERP.Domain.Interfaces
{
    public interface IWorkMasterRepository
    {
        Task<IEnumerable<WorkMaster>> GetAllAsync();
        Task<WorkMaster?> GetByIdAsync(string fran, string workType, decimal workId);
        Task AddAsync(WorkMaster entity);
        Task UpdateAsync(WorkMaster entity);
        Task DeleteAsync(string fran, string workType, decimal workId);
    }
}

