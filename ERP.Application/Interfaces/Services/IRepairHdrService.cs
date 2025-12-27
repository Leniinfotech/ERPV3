using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services
{
    public interface IRepairHdrService
    {
        Task<IEnumerable<RepairHdr>> GetAllAsync();
        Task<RepairHdr?> GetByIdAsync(string fran, string brch, string workshop, string repairType, string repairNo);
        Task AddAsync(RepairHdr entity);
        Task UpdateAsync(RepairHdr entity);
        Task DeleteAsync(string fran, string brch, string workshop, string repairType, string repairNo);
    }
}

