using System.Transactions;

namespace Finance.Api.Models
{
    public class FinancialTransaction
    {
        public Guid Id { get; set; }
        public string? Description { get; set; } = String.Empty;
        public decimal Amount { get; set; }
        public TransactionType? Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Category { get; set; } = String.Empty;
    }
}
