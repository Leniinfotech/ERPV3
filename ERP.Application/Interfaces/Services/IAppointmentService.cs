using ERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Application.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(string fran, decimal appointId);
        Task AddAsync(Appointment entity);
        Task UpdateAsync(Appointment entity);
        Task DeleteAsync(string fran, decimal appointId);
    }
}

