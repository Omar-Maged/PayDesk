using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Infrastructure.DTOs
{
    public class MerchantApprovedTotalDto
    {
        public int MerchantId { get; set; }
        public string MerchantName { get; set; } = null!;
        public long TotalAmount { get; set; }
    }
}
