using System;
using System.Collections.Generic;
using System.Text;

namespace PayDesk.Domain
{
    public class MaskedCard
    {
        public string MaskedNumber { get; }
        public string Scheme { get; }



        public MaskedCard (string maskedNumber, string scheme)
        {
            if (string.IsNullOrWhiteSpace (maskedNumber))
            {
                throw new ArgumentException("Masked Card Number is required.");
            }
            if (!maskedNumber.Contains('*'))
            {
                throw new ArgumentException("A full card number cannot be stored.");
            }
            if (!maskedNumber.All(c=> char.IsDigit (c) || c =='*'))
            {
                throw new ArgumentException("Masked number contains invalid chahracters.");
            }
            if (string.IsNullOrWhiteSpace(scheme))
            {
                throw new ArgumentException("Card scheme is required.");
            }

            MaskedNumber = maskedNumber;
            Scheme = scheme;
        }
    }
}
