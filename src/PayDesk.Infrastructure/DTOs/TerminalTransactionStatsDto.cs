namespace PayDesk.Infrastructure.DTOs
{
    public class TerminalTransactionStatsDto
    {
        public int TerminalId { get; set; }
        public string TerminalCode { get; set; } = null!;
        public int TransactionCount { get; set; }
        public double DeclinedPercentage { get; set; }
    }
}