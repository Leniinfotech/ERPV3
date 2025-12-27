using ERP.Domain.Entities;

namespace ERP.Domain.Interfaces
{
    public interface IRepairOrderRepository
    {
        Task<IEnumerable<RepairOrder>> GetAllAsync();
        Task<RepairOrder?> GetByIdAsync(string fran, string brch, string workshop, string repairType, string repairNo, string repairSrl);
        Task AddAsync(RepairOrder entity);
        Task UpdateAsync(RepairOrder entity);
        Task DeleteAsync(string fran, string brch, string workshop, string repairType, string repairNo, string repairSrl);
    }
}

