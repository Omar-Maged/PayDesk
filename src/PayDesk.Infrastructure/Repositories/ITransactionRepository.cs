using PayDesk.Domain;

namespace PayDesk.Infrastructure.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction?> GetByIdAsync(int id);

        Task<List<Transaction>> GetAllAsync();

        Task AddAsync(Transaction transaction);

        Task SaveChangesAsync();

        Task<List<Transaction>> GetApprovedTransactionsAsync();
        Task<List<Transaction>> GetYesterdayTransactionsAsync();

    }
}