using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PayDesk.Domain
{

    public class Money : IEquatable<Money>
    {
        public long Amount { get; }
        public string Currency { get; }

        public Money(long amount, string currency)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Ammount cannot be negative.");
            }
            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentException("Currency is required.");                
            }

            currency = currency.ToUpper();

            if (currency != "EGP" && currency != "USD" && currency != "SAR")
            {
                throw new ArgumentException("Invalid Currency.");
            }

            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
            {
                throw new ArgumentException("Cannot add money with different currencies.");
            }

            return new Money(Amount +  other.Amount, Currency);
        }

        public Money Subtract (Money other)
        {
            if (Currency != other.Currency)
            {
                throw new ArgumentException("Cannot subtract money with different currencies.");
            }
            return new Money (Amount - other.Amount, Currency);
        }

        public override string ToString()
        {
            return $"{Amount / 100m:F2} {Currency}";
        }

        public bool Equals(Money? other)
        {
            if (other == null)
            {
                return false;
            }
            return Amount == other.Amount && Currency == other.Currency;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Money);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

    }
}
