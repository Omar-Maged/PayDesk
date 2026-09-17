using PayDesk.Domain;

namespace PayDesk.UnitTests
{
    public class TerminalTests
    {
        [Fact]
        public void Constructor_WithValidData_CreatesActiveTerminal()
        {
            var terminal = new Terminal(1, "TERM0001", 1, TerminalChannel.Pos);

            Assert.Equal(TerminalStatus.Active, terminal.Status);
            Assert.Equal(1, terminal.MerchantId);
        }

        [Fact]
        public void Constructor_WithInvalidTerminalCode_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Terminal(1, "TERM-001", 1, TerminalChannel.Pos));
        }

        [Fact]
        public void Constructor_WithoutValidMerchant_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Terminal(1, "TERM0001", 0, TerminalChannel.Pos));
        }

        [Fact]
        public void Deactivate_ChangesStatusToInactive()
        {
            var terminal = new Terminal(1, "TERM0001", 1, TerminalChannel.Pos);

            terminal.Deactivate();

            Assert.Equal(TerminalStatus.Inactive, terminal.Status);
        }
    }
}