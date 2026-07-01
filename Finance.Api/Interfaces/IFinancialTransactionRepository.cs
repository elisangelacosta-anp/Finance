using Finance.Api.Models;

namespace Finance.Api.Interfaces;

public interface IFinancialTransactionRepository
{
    Task<List<FinancialTransaction>> GetAllAsync();

    Task<FinancialTransaction?> GetByIdAsync(Guid id);

    Task AddAsync(FinancialTransaction entity);

    Task UpdateAsync(FinancialTransaction entity);

    Task DeleteAsync(Guid id);
}