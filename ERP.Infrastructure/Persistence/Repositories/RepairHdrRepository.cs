using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using ERP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class RepairHdrRepository : IRepairHdrRepository
    {
        private readonly ErpDbContext _context;

        public RepairHdrRepository(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RepairHdr>> GetAllAsync()
        {
            return await _context.RepairHdrs.ToListAsync();
        }

        public async Task<RepairHdr?> GetByIdAsync(string fran, string brch, string workshop, string repairType, string repairNo)
        {
            return await _context.RepairHdrs.FindAsync(fran, brch, workshop, repairType, repairNo);
        }

        public async Task AddAsync(RepairHdr entity)
        {
            _context.RepairHdrs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RepairHdr entity)
        {
            _context.RepairHdrs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string fran, string brch, string workshop, string repairType, string repairNo)
        {
            var entity = await GetByIdAsync(fran, brch, workshop, repairType, repairNo);
            if (entity != null)
            {
                _context.RepairHdrs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

