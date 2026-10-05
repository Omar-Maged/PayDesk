using Microsoft.EntityFrameworkCore;
using PayDesk.Domain;
using PayDesk.Infrastructure.Data;

namespace PayDesk.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PayDeskDbContext _context;

        public TransactionRepository(PayDeskDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetApprovedTransactionsAsync()
        {
            return await _context.Transactions
                .AsNoTracking()
                .Where(t => t.Status == TransactionStatus.Approved)
                .Include(t => t.Merchant)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetYesterdayTransactionsAsync()
        {
            var yesterday = DateTime.UtcNow.Date.AddDays(-1);
            var today = DateTime.UtcNow.Date;
            
            return await _context.Transactions
                .AsNoTracking ()
                .Where(t => t.CreatedAtUtc >= yesterday && t.CreatedAtUtc < today)
                .ToListAsync ();
        }
    }
}