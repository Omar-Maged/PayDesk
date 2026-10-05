using PayDesk.Infrastructure.DTOs;
using PayDesk.Infrastructure.Repositories;
using PayDesk.Infrastructure.Services;

namespace PayDesk.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<MerchantApprovedTotalDto>>GetApprovedTotalsByMerchantAsync()
        {
            var transactions = await _transactionRepository.GetApprovedTransactionsAsync();

            var result = new List<MerchantApprovedTotalDto>();

            foreach (var transaction in transactions)
            {
                var existingMerchant = result.FirstOrDefault(x => x.MerchantId == transaction.MerchantId);

                if (existingMerchant == null)
                {
                    result.Add(new MerchantApprovedTotalDto
                    {
                        MerchantId = transaction.MerchantId,
                        MerchantName = transaction.Merchant.Name,
                        TotalAmount = transaction.Amount.Amount
                    });
                }
                else
                {
                    existingMerchant.TotalAmount += transaction.Amount.Amount;
                }
            }

            return result.OrderByDescending(x => x.TotalAmount).ToList();
        }

    }
}