using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services
{
    public interface IRepairOrderService
    {
        Task<IEnumerable<RepairOrder>> GetAllAsync();
        Task<RepairOrder?> GetByIdAsync(string fran, string brch, string workshop, string repairType, string repairNo, string repairSrl);
        Task AddAsync(RepairOrder entity);
        Task UpdateAsync(RepairOrder entity);
        Task DeleteAsync(string fran, string brch, string workshop, string repairType, string repairNo, string repairSrl);
    }
}

