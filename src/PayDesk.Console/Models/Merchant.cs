using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Console.Models
{
    public class Merchant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}