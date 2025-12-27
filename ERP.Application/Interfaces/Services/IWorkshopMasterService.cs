// ERP.Application/Interfaces/Services/IWorkshopMasterService.cs
using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services
{
    public interface IWorkshopMasterService
    {
        Task<IEnumerable<WorkshopMaster>> GetAllAsync();
        Task<WorkshopMaster?> GetByIdAsync(string fran, decimal workshop);
        Task AddAsync(WorkshopMaster entity);
        Task UpdateAsync(WorkshopMaster entity);
        Task DeleteAsync(string fran, decimal workshop);
    }
}
