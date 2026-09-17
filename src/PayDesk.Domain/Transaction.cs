using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Domain
{
    public class Transaction
    {
        public int Id { get; }
        public string Reference { get; }
        public int MerchantId { get; }
        public int TerminalId { get; }
        public Money Amount { get; }
        public MaskedCard Card { get; }
        public TransactionStatus Status { get; private set; }
        public DateTime CreatedAtUtc { get; }

        public Transaction(int id, string reference, int merchantId, int terminalId, Money amount, MaskedCard card)
        {
            if (amount.Amount <= 0)
            {
                throw new ArgumentException("Transaction amount must be greater than zero");
            }

            Id = id;
            Reference = reference;
            MerchantId = merchantId;
            TerminalId = terminalId;
            Amount = amount;
            Card = card;

            Status = TransactionStatus.Pending;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public void Approve()
        {
            if (Status != TransactionStatus.Pending)
            {
                throw new InvalidOperationException("Only Pending Transactions can be approved");
            }
            Status = TransactionStatus.Approved;
        }

        public void Decline()
        {
            if(Status != TransactionStatus.Pending)
            {
                throw new InvalidOperationException("Only Pending Transactions can be declined");
            }
            Status = TransactionStatus.Declined;
        }

        public void Refund()
        {
            if(Status != TransactionStatus.Approved)
            {
                throw new InvalidOperationException("Only approved transactions can be refunded");
            }
            Status = TransactionStatus.Refunded;
        }
    }
}
