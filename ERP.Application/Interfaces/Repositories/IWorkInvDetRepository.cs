using ERP.Domain.Entities;

namespace ERP.Domain.Interfaces
{
    public interface IWorkInvDetRepository
    {
        Task<IEnumerable<WorkInvDet>> GetAllAsync();
        Task<WorkInvDet?> GetByIdAsync(string fran, string brch, string workshop, string workInvType, string workInvNo, decimal workInvSrl);
        Task AddAsync(WorkInvDet entity);
        Task UpdateAsync(WorkInvDet entity);
        Task DeleteAsync(string fran, string brch, string workshop, string workInvType, string workInvNo, decimal workInvSrl);
    }
}

