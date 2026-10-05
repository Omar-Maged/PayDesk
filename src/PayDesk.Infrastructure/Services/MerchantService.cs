using PayDesk.Domain;
using PayDesk.Infrastructure.DTOs;
using PayDesk.Infrastructure.Repositories;

namespace PayDesk.Infrastructure.Services
{
    public class MerchantService
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ITransactionRepository _transactionRepository;

        public MerchantService(
            IMerchantRepository merchantRepository,
            ITransactionRepository transactionRepository)
        {
            _merchantRepository = merchantRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<List<MerchantNoTransactiondto>>GetMerchantsWithNoTransactionsYesterdayAsync()
        {
            var merchants = await _merchantRepository.GetAllAsync();

            var yesterdayTransactions =await _transactionRepository.GetYesterdayTransactionsAsync();

            var result = new List<MerchantNoTransactiondto>();

            foreach (var merchant in merchants)
            {
                bool hasTransaction = yesterdayTransactions.Any(t => t.MerchantId == merchant.Id);

                if (!hasTransaction)
                {
                    result.Add(new MerchantNoTransactiondto
                    {
                        MerchantId = merchant.Id,
                        MerchantName = merchant.Name
                    });
                }
            }

            return result;
        }
    }
}