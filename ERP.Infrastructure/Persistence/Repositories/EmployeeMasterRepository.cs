using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using ERP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class EmployeeMasterRepository : IEmployeeMasterRepository
    {
        private readonly ErpDbContext _context;

        public EmployeeMasterRepository(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeMaster>> GetAllAsync()
        {
            return await _context.EmployeeMasters.ToListAsync();
        }

        public async Task<EmployeeMaster?> GetByIdAsync(string fran, string employee)
        {
            return await _context.EmployeeMasters.FindAsync(fran, employee);
        }

        public async Task AddAsync(EmployeeMaster entity)
        {
            _context.EmployeeMasters.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeMaster entity)
        {
            _context.EmployeeMasters.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string fran, string employee)
        {
            var entity = await GetByIdAsync(fran, employee);
            if (entity != null)
            {
                _context.EmployeeMasters.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

