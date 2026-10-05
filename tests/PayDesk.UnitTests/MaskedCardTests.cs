using PayDesk.Domain;

namespace PayDesk.UnitTests
{
    public class MaskedCardTests
    {
        [Fact]
        public void Constructor_WithValidMaskedNumber_CreatesMaskedCard()
        {
            var card = new MaskedCard("4111111111", "Visa");

            Assert.Equal("4111111111", card.MaskedNumber);
            Assert.Equal("Visa", card.Scheme);
        }

        [Fact]
        public void Constructor_WithFullCardNumber_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new MaskedCard("4111111111111111","Visa"));
        }

        [Fact]
        public void Constructor_WithInvalidCharacters_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new MaskedCard("411111-*****-1111", "Visa"));
        }

        [Fact]
        public void Constructor_WithEmptyScheme_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new MaskedCard("411111******1111", ""));
        }
    }
}