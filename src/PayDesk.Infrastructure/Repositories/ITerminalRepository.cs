using PayDesk.Domain;

namespace PayDesk.Infrastructure.Repositories
{
    public interface ITerminalRepository
    {
        Task<Terminal?> GetByIdAsync(int id);

        Task<List<Terminal>> GetAllAsync();

        Task AddAsync(Terminal terminal);

        Task SaveChangesAsync();
    }
}