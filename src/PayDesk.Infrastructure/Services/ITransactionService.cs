using PayDesk.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Infrastructure.Services
{
    public interface ITransactionService
    {
        Task<List<MerchantApprovedTotalDto>>GetApprovedTotalsByMerchantAsync();
    }
}
