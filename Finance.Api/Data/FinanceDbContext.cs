using Finance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance.Api.Data
{
    public class FinanceDbContext : DbContext
    {
        public DbSet<Finance.Api.DTOs.FinancialTransactionResponseDto> FinancialTransactionResponseDto { get; set; } = default!;
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
            : base(options) { }

        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialTransaction>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);
        }
    }
}
