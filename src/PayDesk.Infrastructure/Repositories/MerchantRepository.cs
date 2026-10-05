using Microsoft.EntityFrameworkCore;
using PayDesk.Domain;
using PayDesk.Infrastructure.Data;

namespace PayDesk.Infrastructure.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly PayDeskDbContext _context;

        public MerchantRepository(PayDeskDbContext context)
        {
            _context = context;
        }

        public async Task<Merchant?> GetByIdAsync(int id)
        {
            return await _context.Merchants
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Merchant>> GetAllAsync()
        {
            return await _context.Merchants
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Merchant merchant)
        {
            await _context.Merchants.AddAsync(merchant);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Merchant>> GetActiveMerchantsAsync()
        {
            return await _context.Merchants
                .AsNoTracking()
                .Where(m => m.Status == MerchantStatus.Active)
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

    }
}