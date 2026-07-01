using System.Transactions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Finance.Api.Models
{
    public class FinancialTransaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string? Description { get; set; } = String.Empty;
        public decimal Amount { get; set; }
        public TransactionType? Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Category { get; set; } = String.Empty;
    }
}
