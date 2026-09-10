using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Console.Models
{
    internal class Transaction
    {
        public int MerchantId { get; set; }
        public long Amount { get; set; }
        public DateTime Date {  get; set; }
    }
}
