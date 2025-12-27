using ERP.Domain.Entities;

namespace ERP.Domain.Interfaces
{
    public interface IRepairHdrRepository
    {
        Task<IEnumerable<RepairHdr>> GetAllAsync();
        Task<RepairHdr?> GetByIdAsync(string fran, string brch, string workshop, string repairType, string repairNo);
        Task AddAsync(RepairHdr entity);
        Task UpdateAsync(RepairHdr entity);
        Task DeleteAsync(string fran, string brch, string workshop, string repairType, string repairNo);
    }
}

