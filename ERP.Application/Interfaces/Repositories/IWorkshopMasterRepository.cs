using ERP.Domain.Entities;

namespace ERP.Domain.Interfaces
{
    public interface IWorkshopMasterRepository
    {
        Task<IEnumerable<WorkshopMaster>> GetAllAsync();
        Task<WorkshopMaster?> GetByIdAsync(string fran, decimal workshop);
        Task AddAsync(WorkshopMaster entity);
        Task UpdateAsync(WorkshopMaster entity);
        Task DeleteAsync(string fran, decimal workshop);
    }
}
