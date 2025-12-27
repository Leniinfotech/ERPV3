using ERP.Domain.Entities;

namespace ERP.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(string fran, decimal appointId);
        Task AddAsync(Appointment entity);
        Task UpdateAsync(Appointment entity);
        Task DeleteAsync(string fran, decimal appointId);
    }
}

