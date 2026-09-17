using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Domain
{
    public class Terminal
    {
        public int Id { get; }
        public string TerminalCode { get; }
        public int MerchantId { get; }
        public TerminalChannel Channel { get; }
        public TerminalStatus Status { get; private set; }

    

        public Terminal(int id, string terminalCode, int merchantId, TerminalChannel channel)
        {
            if (string.IsNullOrWhiteSpace(terminalCode) || terminalCode.Length != 8 || !terminalCode.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Terminal code must be exactly 8 alphanumeric characters.");
            }

            if (merchantId <= 0)
            {
                throw new ArgumentException("Terminal must belong to a merchant.");
            }

            Id = id;
            TerminalCode = terminalCode;
            MerchantId = merchantId;
            Channel = channel;
            Status = TerminalStatus.Active;
        }

        public void Activate()
        {
            Status = TerminalStatus.Active;
        }
        public void Deactivate()
        {
            Status = TerminalStatus.Inactive;
        }

    }
}
