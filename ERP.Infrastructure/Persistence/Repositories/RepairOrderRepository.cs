using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using ERP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class RepairOrderRepository : IRepairOrderRepository
    {
        private readonly ErpDbContext _context;

        public RepairOrderRepository(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RepairOrder>> GetAllAsync()
        {
            return await _context.RepairOrders.ToListAsync();
        }

        public async Task<RepairOrder?> GetByIdAsync(string fran, string brch, string workshop, string repairType, string repairNo, string repairSrl)
        {
            return await _context.RepairOrders.FindAsync(fran, brch, workshop, repairType, repairNo, repairSrl);
        }

        public async Task AddAsync(RepairOrder entity)
        {
            _context.RepairOrders.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RepairOrder entity)
        {
            _context.RepairOrders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string fran, string brch, string workshop, string repairType, string repairNo, string repairSrl)
        {
            var entity = await GetByIdAsync(fran, brch, workshop, repairType, repairNo, repairSrl);
            if (entity != null)
            {
                _context.RepairOrders.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

