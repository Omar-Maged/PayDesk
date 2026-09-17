using PayDesk.Domain;

namespace PayDesk.UnitTests
{
    public class MoneyTests
    {
        [Fact]
        public void Constructor_WithNegativeAmount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new Money(-100, "EGP"));
        }

        [Fact]
        public void Constructor_WithInvalidCurrency_ThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => new Money(1000, "ABC"));
        }

        [Fact]
        public void ToString_FormatsAmountCorrectly()
        {
            var money = new Money(1050, "EGP");

            Assert.Equal("10.50 EGP", money.ToString());
        }

        [Fact]
        public void Add_WithSameCurrency_ReturnsCorrectMoney()
        {
            var first = new Money(1000, "EGP");
            var second = new Money(500, "EGP");

            var result = first.Add(second);

            Assert.Equal(new Money(1500, "EGP"), result);
        }

        [Fact]
        public void Add_WithDifferentCurrencies_ThrowsException()
        {
            var egp = new Money(1000, "EGP");
            var usd = new Money(500, "USD");

            Assert.Throws<ArgumentException>(
                () => egp.Add(usd));
        }

        [Fact]
        public void TwoMoneyValues_WithSameAmountAndCurrency_AreEqual()
        {
            var first = new Money(1050, "EGP");
            var second = new Money(1050, "EGP");

            Assert.Equal(first, second);
        }
    }
}