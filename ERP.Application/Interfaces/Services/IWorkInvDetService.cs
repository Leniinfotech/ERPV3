using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services
{
    public interface IWorkInvDetService
    {
        Task<IEnumerable<WorkInvDet>> GetAllAsync();
        Task<WorkInvDet?> GetByIdAsync(string fran, string brch, string workshop, string workInvType, string workInvNo, decimal workInvSrl);
        Task AddAsync(WorkInvDet entity);
        Task UpdateAsync(WorkInvDet entity);
        Task DeleteAsync(string fran, string brch, string workshop, string workInvType, string workInvNo, decimal workInvSrl);
    }
}

