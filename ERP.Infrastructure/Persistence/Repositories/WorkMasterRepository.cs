using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using ERP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class WorkMasterRepository : IWorkMasterRepository
    {
        private readonly ErpDbContext _context;

        public WorkMasterRepository(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkMaster>> GetAllAsync()
        {
            return await _context.WorkMasters.ToListAsync();
        }

        public async Task<WorkMaster?> GetByIdAsync(string fran, string workType, decimal workId)
        {
            return await _context.WorkMasters.FindAsync(fran, workType, workId);
        }

        public async Task AddAsync(WorkMaster entity)
        {
            _context.WorkMasters.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkMaster entity)
        {
            _context.WorkMasters.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string fran, string workType, decimal workId)
        {
            var entity = await GetByIdAsync(fran, workType, workId);
            if (entity != null)
            {
                _context.WorkMasters.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

