using ERP.Domain.Entities;

namespace ERP.Domain.Interfaces
{
    public interface IWorkInvHdrRepository
    {
        Task<IEnumerable<WorkInvHdr>> GetAllAsync();
        Task<WorkInvHdr?> GetByIdAsync(string fran, string brch, string workshop, string workInvType, string workInvNo);
        Task AddAsync(WorkInvHdr entity);
        Task UpdateAsync(WorkInvHdr entity);
        Task DeleteAsync(string fran, string brch, string workshop, string workInvType, string workInvNo);
    }
}

