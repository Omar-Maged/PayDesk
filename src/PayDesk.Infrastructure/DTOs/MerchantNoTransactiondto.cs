using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Infrastructure.DTOs
{
    public class MerchantNoTransactiondto
    {
        public int MerchantId { get; set; }
        public string MerchantName { get; set; } = null!;
    }
}
