using PayDesk.Domain;

namespace PayDesk.UnitTests
{
    public class MerchantTests
    {
        [Fact]
        public void Constructor_WithValidData_CreatesActiveMerchant()
        {
            var merchant = new Merchant(1, "Cairo Market", "Cairo", "contact@cairomarket.com", "ABC123");

            Assert.Equal(MerchantStatus.Active, merchant.Status);
            Assert.True(merchant.CanTakeTransactions());
        }

        [Fact]
        public void Constructor_WithInvalidName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Merchant(1, "A", "Cairo", "contact@test.com", "ABC123"));
        }

        [Fact]
        public void Constructor_WithInvalidMerchantCode_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Merchant(1, "Cairo Market", "Cairo", "contact@test.com", "ABC-12"));
        }

        [Fact]
        public void Constructor_WithInvalidEmail_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Merchant(1, "Cairo Market", "Cairo", "invalid-email", "ABC123"));
        }

        [Fact]
        public void Suspend_PreventsMerchantFromTakingTransactions()
        {
            var merchant = new Merchant(1, "Cairo Market", "Cairo", "contact@test.com", "ABC123");

            merchant.Suspend();

            Assert.Equal(MerchantStatus.Suspended, merchant.Status);
            Assert.False(merchant.CanTakeTransactions());
        }
    }
}