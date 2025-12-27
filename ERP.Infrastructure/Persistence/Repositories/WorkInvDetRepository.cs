using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using ERP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class WorkInvDetRepository : IWorkInvDetRepository
    {
        private readonly ErpDbContext _context;

        public WorkInvDetRepository(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkInvDet>> GetAllAsync()
        {
            return await _context.WorkInvDets.ToListAsync();
        }

        public async Task<WorkInvDet?> GetByIdAsync(string fran, string brch, string workshop, string workInvType, string workInvNo, decimal workInvSrl)
        {
            return await _context.WorkInvDets.FindAsync(fran, brch, workshop, workInvType, workInvNo, workInvSrl);
        }

        public async Task AddAsync(WorkInvDet entity)
        {
            _context.WorkInvDets.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkInvDet entity)
        {
            _context.WorkInvDets.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string fran, string brch, string workshop, string workInvType, string workInvNo, decimal workInvSrl)
        {
            var entity = await GetByIdAsync(fran, brch, workshop, workInvType, workInvNo, workInvSrl);
            if (entity != null)
            {
                _context.WorkInvDets.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

