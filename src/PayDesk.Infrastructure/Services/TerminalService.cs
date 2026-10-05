using PayDesk.Domain;
using PayDesk.Infrastructure.DTOs;
using PayDesk.Infrastructure.Repositories;

namespace PayDesk.Infrastructure.Services
{
    public class TerminalService
    {
        private readonly ITerminalRepository _terminalRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TerminalService(
            ITerminalRepository terminalRepository,
            ITransactionRepository transactionRepository)
        {
            _terminalRepository = terminalRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<List<TerminalTransactionStatsDto>>GetTerminalTransactionStatsAsync()
        {
            var terminals = await _terminalRepository.GetAllAsync();

            var transactions = await _transactionRepository.GetAllAsync();

            var result = new List<TerminalTransactionStatsDto>();

            foreach (var terminal in terminals)
            {
                int transactionCount = 0;
                int declinedCount = 0;

                foreach (var transaction in transactions)
                {
                    if (transaction.TerminalId == terminal.Id)
                    {
                        transactionCount++;

                        if (transaction.Status == TransactionStatus.Declined)
                        {
                            declinedCount++;
                        }
                    }
                }

                double declinedPercentage = 0;

                if (transactionCount > 0)
                {
                    declinedPercentage = declinedCount * 100.0 / transactionCount;
                }

                result.Add(new TerminalTransactionStatsDto
                {
                    TerminalId = terminal.Id,
                    TerminalCode = terminal.TerminalCode,
                    TransactionCount = transactionCount,
                    DeclinedPercentage = declinedPercentage
                });
            }

            return result;
        }
    }
}