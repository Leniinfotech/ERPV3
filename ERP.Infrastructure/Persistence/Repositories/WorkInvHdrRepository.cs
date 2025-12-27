using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using ERP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class WorkInvHdrRepository : IWorkInvHdrRepository
    {
        private readonly ErpDbContext _context;

        public WorkInvHdrRepository(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkInvHdr>> GetAllAsync()
        {
            return await _context.WorkInvHdrs.ToListAsync();
        }

        public async Task<WorkInvHdr?> GetByIdAsync(string fran, string brch, string workshop, string workInvType, string workInvNo)
        {
            return await _context.WorkInvHdrs.FindAsync(fran, brch, workshop, workInvType, workInvNo);
        }

        public async Task AddAsync(WorkInvHdr entity)
        {
            _context.WorkInvHdrs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkInvHdr entity)
        {
            _context.WorkInvHdrs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string fran, string brch, string workshop, string workInvType, string workInvNo)
        {
            var entity = await GetByIdAsync(fran, brch, workshop, workInvType, workInvNo);
            if (entity != null)
            {
                _context.WorkInvHdrs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

