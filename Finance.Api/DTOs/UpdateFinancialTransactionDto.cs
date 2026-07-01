using Finance.Api.Models;

namespace Finance.Api.DTOs
{
    public class UpdateFinancialTransactionDto
    {
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType? Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Category { get; set; }

    }
}
