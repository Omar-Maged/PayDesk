using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Domain
{
    public class Transaction
    {
        public int Id { get; private set; }
        public string Reference { get; private set; }
        public int MerchantId { get; private set; }
        public Merchant Merchant { get; private set; } = null!;

        public int TerminalId { get; private set; }
        public Terminal Terminal { get; private set; } = null!;
        public Money Amount { get; private set; }
        public MaskedCard Card { get; private set; }
        public TransactionStatus Status { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }

        private Transaction()
        {
            Reference = null!;
            Amount = null!;
            Card = null!;
        }

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
