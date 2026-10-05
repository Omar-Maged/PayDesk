using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Domain
{
    public class MaskedCard
    {
        public string StoredDigits { get; }
        public string Scheme { get; }

        public string MaskedNumber =>
            StoredDigits[..6] + "******" + StoredDigits[^4..];

        public MaskedCard(string storedDigits, string scheme)
        {
            if (string.IsNullOrWhiteSpace(storedDigits))
            {
                throw new ArgumentException("Stored card digits are required.");
            }

            if (storedDigits.Length != 10)
            {
                throw new ArgumentException(
                    "Stored card digits must contain exactly 10 digits.");
            }

            if (!storedDigits.All(char.IsDigit))
            {
                throw new ArgumentException(
                    "Stored card data must contain digits only.");
            }

            if (string.IsNullOrWhiteSpace(scheme))
            {
                throw new ArgumentException("Card scheme is required.");
            }

            StoredDigits = storedDigits;
            Scheme = scheme;
        }
    }
}
