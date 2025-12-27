using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services
{
    public interface IWorkInvHdrService
    {
        Task<IEnumerable<WorkInvHdr>> GetAllAsync();
        Task<WorkInvHdr?> GetByIdAsync(string fran, string brch, string workshop, string workInvType, string workInvNo);
        Task AddAsync(WorkInvHdr entity);
        Task UpdateAsync(WorkInvHdr entity);
        Task DeleteAsync(string fran, string brch, string workshop, string workInvType, string workInvNo);
    }
}

