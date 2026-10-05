using Microsoft.EntityFrameworkCore;
using PayDesk.Domain;
using PayDesk.Infrastructure.Data;

namespace PayDesk.Infrastructure.Repositories
{
    public class TerminalRepository : ITerminalRepository
    {
        private readonly PayDeskDbContext _context;

        public TerminalRepository(PayDeskDbContext context)
        {
            _context = context;
        }

        public async Task<Terminal?> GetByIdAsync(int id)
        {
            return await _context.Terminals
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Terminal>> GetAllAsync()
        {
            return await _context.Terminals
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(Terminal terminal)
        {
            await _context.Terminals.AddAsync(terminal);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}