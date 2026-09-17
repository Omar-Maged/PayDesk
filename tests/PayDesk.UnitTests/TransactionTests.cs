using PayDesk.Domain;

namespace PayDesk.UnitTests
{
    public class TransactionTests
    {
        private Transaction CreateTranaction()
        {
            var amount = new Money(1050, "EGP");

            var card = new MaskedCard("411111******1111", "Visa");
            return new Transaction(1, "TXN001", 1, 1, amount, card);
        }

        [Fact]
        public void Constructor_CreateTransactionAsPending()
        {
            var transaction = CreateTranaction();
            Assert.Equal(TransactionStatus.Pending, transaction.Status);
        }

        [Fact]
        public void Approve_PendingTransaction_ChangesStatusToApproved()
        {
            var transaction = CreateTranaction();

            transaction.Approve();

            Assert.Equal(TransactionStatus.Approved, transaction.Status);
        }

        [Fact]
        public void Decline_PendingTransaction_ChangeStatusToDeclined()
        {
            var transaction = CreateTranaction();

            transaction.Decline();

            Assert.Equal(TransactionStatus.Declined, transaction.Status);
        }

        [Fact]
        public void Refund_ApprovedTransaction_ChangeStatusToRefunded()
        {
            var transaction = CreateTranaction();

            transaction.Approve();
            transaction.Refund();

            Assert.Equal(TransactionStatus.Refunded, transaction.Status);
        }

        [Fact]
        public void Approve_DeclinedTransaction_ThrowsException()
        {
            var transaction = CreateTranaction();

            transaction.Decline();

            Assert.Throws<InvalidOperationException>(() => transaction.Approve());
        }

        [Fact]
        public void Constructor_WithZeroAmount_ThrowsException()
        {
            var amount = new Money(0, "EGP");

            var card = new MaskedCard("411111******1111", "Visa");

            Assert.Throws<ArgumentException>(() => new Transaction(1, "TXN001", 1, 1, amount, card));
        }
    }
}
