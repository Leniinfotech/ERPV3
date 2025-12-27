using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using ERP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class WorkshopMasterRepository : IWorkshopMasterRepository
    {
        private readonly ErpDbContext _context;

        public WorkshopMasterRepository(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkshopMaster>> GetAllAsync()
        {
            return await _context.WorkshopMasters.ToListAsync();
        }

        public async Task<WorkshopMaster?> GetByIdAsync(string fran, decimal workshop)
        {
            return await _context.WorkshopMasters.FindAsync(fran, workshop);
        }

        public async Task AddAsync(WorkshopMaster entity)
        {
            _context.WorkshopMasters.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkshopMaster entity)
        {
            _context.WorkshopMasters.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string fran, decimal workshop)
        {
            var entity = await GetByIdAsync(fran, workshop);
            if (entity != null)
            {
                _context.WorkshopMasters.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
