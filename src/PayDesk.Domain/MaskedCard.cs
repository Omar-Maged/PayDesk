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
            if (maskedNumber.All(c => char.IsDigit(c)))
            {
                throw new ArgumentException("A full card number cannot be stored.");
            }
            if (!IsValidMask(maskedNumber))
            {
                throw new ArgumentException("Masked Card Number can only use one masking type");
            }
            if (string.IsNullOrWhiteSpace(scheme))
            {
                throw new ArgumentException("Card scheme is required.");
            }
            if(maskedNumber.Length != 16)
            {
                throw new ArgumentException("Masked Card Number Must be exactly 16 characters");
            }    

            MaskedNumber = maskedNumber;
            Scheme = scheme;
        }


        private bool IsValidMask(string maskedNumber)
        {
            char? maskedCharacter = null;

            foreach (char character in maskedNumber)
            {
                if (char.IsDigit(character))
                {
                    continue;
                }
                if (maskedCharacter == null)
                {
                    maskedCharacter = character;
                }
                else if (character != maskedCharacter)
                {
                    return false;
                }

            }

            return true;

        }
    }
}
