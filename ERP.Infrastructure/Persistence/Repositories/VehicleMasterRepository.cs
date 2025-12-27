using ERP.Domain.Entities;
using ERP.Domain.Interfaces;
using ERP.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories
{
    public class VehicleMasterRepository : IVehicleMasterRepository
    {
        private readonly ErpDbContext _context;

        public VehicleMasterRepository(ErpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleMaster>> GetAllAsync()
        {
            return await _context.VehicleMasters.ToListAsync();
        }

        public async Task<VehicleMaster?> GetByIdAsync(decimal vechileId)
        {
            return await _context.VehicleMasters.FindAsync(vechileId);
        }

        public async Task AddAsync(VehicleMaster entity)
        {
            _context.VehicleMasters.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VehicleMaster entity)
        {
            _context.VehicleMasters.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(decimal vechileId)
        {
            var entity = await GetByIdAsync(vechileId);
            if (entity != null)
            {
                _context.VehicleMasters.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

