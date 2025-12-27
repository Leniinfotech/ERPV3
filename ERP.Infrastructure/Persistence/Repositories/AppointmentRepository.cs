using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using ERP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ErpDbContext _context;

        public AppointmentRepository(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(string fran, decimal appointId)
        {
            return await _context.Appointments.FindAsync(fran, appointId);
        }

        public async Task AddAsync(Appointment entity)
        {
            _context.Appointments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment entity)
        {
            _context.Appointments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string fran, decimal appointId)
        {
            var entity = await GetByIdAsync(fran, appointId);
            if (entity != null)
            {
                _context.Appointments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

