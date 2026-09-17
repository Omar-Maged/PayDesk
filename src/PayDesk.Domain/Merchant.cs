using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace PayDesk.Domain
{
    public class Merchant
    {
        public int Id { get; }
        public string Name { get; }
        public string City { get; }
        public string ContactEmail { get; }
        public string MerchantCode { get; }
        public MerchantStatus Status { get; private set; }

        public Merchant (int id, string name, string city, string contactEmail, string merchantCode)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2 || name.Length > 200)
            {
                throw new ArgumentException("Names must be between 2 and 200 characters");
            }

            if (string.IsNullOrWhiteSpace(merchantCode) || merchantCode.Length != 6 || !merchantCode.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Merchant code must be exactly 6 alphanumeric characters.");
            }

            if (!MailAddress.TryCreate(contactEmail, out _))
            {
                throw new ArgumentException("Invalid email address.");
            }

            Id = id;
            Name = name;
            City = city;
            ContactEmail = contactEmail;
            MerchantCode = merchantCode;
            Status = MerchantStatus.Active;

        }

        public void Suspend()
        {
            Status = MerchantStatus.Suspended;
        }
        public void Activate()
        {
            Status = MerchantStatus.Active;
        }
        public bool CanTakeTransactions()
        {
            return Status == MerchantStatus.Active;
        }
    }
}
