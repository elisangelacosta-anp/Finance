using Finance.Api.Models;

namespace Finance.Api.DTOs;

public class FinancialTransactionResponseDto
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public TransactionType Type { get; set; }

    public DateTime TransactionDate { get; set; }

    public string Category { get; set; } = string.Empty;
}