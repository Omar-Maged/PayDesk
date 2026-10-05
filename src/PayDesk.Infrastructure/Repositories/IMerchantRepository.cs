using System;
using System.Collections.Generic;
using System.Text;

using PayDesk.Domain;

namespace PayDesk.Infrastructure.Repositories
{
    public interface IMerchantRepository
    {
        Task<Merchant?> GetByIdAsync(int id);

        Task<List<Merchant>> GetAllAsync();

        Task AddAsync(Merchant merchant);

        Task SaveChangesAsync();

        Task<List<Merchant>> GetActiveMerchantsAsync();

    }
}
